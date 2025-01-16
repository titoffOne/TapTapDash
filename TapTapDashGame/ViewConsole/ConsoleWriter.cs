using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ViewConsole
{
  /// <summary>
  /// Консольный отрисовщик
  /// </summary>
  public static class ConsoleWriter
  {
    /// <summary>
    /// Ширина по умолчанию
    /// </summary>
    private const int DEFAULT_WIDTH = 60;

    /// <summary>
    /// Высота по умолчанию
    /// </summary>
    private const int DEFAULT_HEIGHT = 30;

    /// <summary>
    /// Дескриптор для доступа к консоли
    /// </summary>
    private static SafeFileHandle SafeFileHandle { get; set; } = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

    /// <summary>
    /// Область записи в консоли
    /// </summary>
    private static SmallRect _writeRegion = new SmallRect()
    {
      Left = 0,
      Top = 0,
      Right = DEFAULT_WIDTH,
      Bottom = DEFAULT_HEIGHT
    };

    /// <summary>
    /// Размер буфера консоли
    /// </summary>
    private static Coord _bufferSize = new Coord()
    {
      X = DEFAULT_WIDTH,
      Y = DEFAULT_HEIGHT
    };

    /// <summary>
    /// Координаты начала буфера
    /// </summary>
    private static Coord _bufferCoord = new Coord()
    {
      X = 0,
      Y = 0
    };

    /// <summary>
    /// Объект синхронизации для потокобезопасности
    /// </summary>
    private static object Lock { get; set; } = new();

    /// <summary>
    /// Буфер кадра для отрисовки
    /// </summary>
    public static Frame Frame { get; private set; } = new Frame(DEFAULT_WIDTH, DEFAULT_HEIGHT);

    /// <summary>
    /// Статический конструктор
    /// </summary>
    static ConsoleWriter()
    {
      SetSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
    }

    /// <summary>
    /// Установить размер консоли
    /// </summary>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public static void SetSize(int parWidth, int parHeight)
    {
      lock (Lock)
      {
        Console.SetWindowSize(parWidth, parHeight);

        _writeRegion.Right = (short)parWidth;
        _writeRegion.Bottom = (short)parHeight;

        _bufferSize.X = (short)parWidth;
        _bufferSize.Y = (short)parHeight;

        Frame.SetSize(parWidth, parHeight);
      }
    }

    /// <summary>
    /// Установить шрифт консоли
    /// </summary>
    /// <param name="parFont">Название шрифта</param>
    /// <param name="parFontWidth">Ширина символов шрифта</param>
    /// <param name="parFontHeight">Высота символов шрифта</param>
    public static void SetFont(string parFont, short parFontWidth, short parFontHeight)
    {
      lock (Lock)
      {
        if (!SafeFileHandle.IsInvalid)
        {
          CONSOLE_FONT_INFOEX cfi = new()
          {
            FaceName = parFont,
            FontWidth = parFontWidth,
            FontHeight = parFontHeight,
            FontFamily = 0,
            FontWeight = 0x0190,
            FontIndex = 0
          };

          SetCurrentConsoleFontEx(SafeFileHandle.DangerousGetHandle(), true, cfi);
        }
      }
    }

    /// <summary>
    /// Выполнить отрисовку кадра в консоли
    /// </summary>
    public static void Print()
    {
      if (!SafeFileHandle.IsInvalid)
      {
        WriteConsoleOutput(
          SafeFileHandle,
          Frame.Buffer,
          _bufferSize,
          _bufferCoord,
          ref _writeRegion);
      }
    }

    #region Settings
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern SafeFileHandle CreateFile(
      string parFileName,
      [MarshalAs(UnmanagedType.U4)] uint parFileAccess,
      [MarshalAs(UnmanagedType.U4)] uint parFileShare,
      IntPtr parSecurityAttributes,
      [MarshalAs(UnmanagedType.U4)] FileMode parCreationDisposition,
      [MarshalAs(UnmanagedType.U4)] int parFlags,
      IntPtr parTemplate);

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool WriteConsoleOutput(
      SafeFileHandle parHConsoleOutput,
      CharInfo[] parLpBuffer,
      Coord parDwBufferSize,
      Coord parDwBufferCoord,
      ref SmallRect parLpWriteRegion);

    /// <summary>
    /// Координаты в консоли
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
      public short X;
      public short Y;

      public Coord(short X, short Y)
      {
        this.X = X;
        this.Y = Y;
      }
    };

    /// <summary>
    /// Символы в буфере консоли
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
      [FieldOffset(0)] public short UnicodeChar;
      [FieldOffset(0)] public byte AsciiChar;
    }

    /// <summary>
    /// Информация о символах и их атрибутах
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharInfo
    {
      [FieldOffset(0)] public CharUnion Char;
      [FieldOffset(2)] public short Attributes;
    }

    /// <summary>
    /// Область консоли
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SmallRect
    {
      public short Left;
      public short Top;
      public short Right;
      public short Bottom;
    }

    /// <summary>
    /// Настройки шрифта консоли
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private class CONSOLE_FONT_INFOEX
    {
      private readonly int cbSize;
      public CONSOLE_FONT_INFOEX()
      {
        cbSize = Marshal.SizeOf(typeof(CONSOLE_FONT_INFOEX));
      }

      public int FontIndex;
      public short FontWidth;
      public short FontHeight;
      public int FontFamily;
      public int FontWeight;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string FaceName;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetCurrentConsoleFontEx
      (
        IntPtr ConsoleOutput,
        bool MaximumWindow,
        [In, Out] CONSOLE_FONT_INFOEX ConsoleCurrentFontEx
      );
    #endregion Settings
  }
}
