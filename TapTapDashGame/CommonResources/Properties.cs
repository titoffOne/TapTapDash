using System.Windows.Media;

namespace CommonResources
{
  /// <summary>
  /// Класс, содержащий общие настройки для приложений
  /// </summary>
  public static class Properties
  {
    /// <summary>
    /// Шрифт, используемый в консольном приложении
    /// </summary>
    public static string CONSOLE_APPLICATION_FONT = "Hack";
    /// <summary>
    /// Ширина окна консольного приложения
    /// </summary>
    public const int CONSOLE_APPLICATION_WIDTH = 60;
    /// <summary>
    /// Высота окна консольного приложения
    /// </summary>
    public const int CONSOLE_APPLICATION_HEIGHT = 30;

    /// <summary>
    /// Шрифт, используемый в WPF-приложении
    /// </summary>
    public static FontFamily WPF_APPLICATION_FONT = new("American Captain Cyrillic");
    /// <summary>
    /// Ширина окна WPF-приложения
    /// </summary>
    public const int WPF_APPLICATION_WIDTH = 700;
    /// <summary>
    /// Высота окна WPF-приложения
    /// </summary>
    public const int WPF_APPLICATION_HEIGHT = 700;
    /// <summary>
    /// Максимальная длина ввода имени пользователя в меню
    /// </summary>
    public const int MENU_USERNAME_INPUT_MAX_LENGTH = 20;

    /// <summary>
    /// Фоновый цвет для WPF-приложения
    /// </summary>
    public static readonly Brush WPF_COLOR_BACKGROUND = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3d5a80"));
    /// <summary>
    /// Цвет заголовков текста в WPF-приложении
    /// </summary>
    public static readonly Brush WPF_COLOR_TEXT_HEADING = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c1d9"));
    /// <summary>
    /// Цвет описательного текста в WPF-приложении
    /// </summary>
    public static readonly Brush WPF_COLOR_TEXT_DESCRIPTION = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c1d9"));
    /// <summary>
    /// Цвет текста кнопки в нормальном состоянии в WPF-приложении
    /// </summary>
    public static readonly Brush WPF_COLOR_BUTTON_FG_NORMAL = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3d5a80"));
    /// <summary>
    /// Цвет текста кнопки в фокусированном состоянии в WPF-приложении.
    /// </summary>
    public static readonly Brush WPF_COLOR_BUTTON_FG_FOCUSED = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e0fbfc"));
    /// <summary>
    /// Цвет фона кнопки в нормальном состоянии в WPF-приложении
    /// </summary>
    public static readonly Brush WPF_COLOR_BUTTON_BG_NORMAL = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c1d9"));
    /// <summary>
    /// Цвет фона кнопки в фокусированном состоянии в WPF-приложении
    /// </summary>
    public static readonly Brush WPF_COLOR_BUTTON_BG_FOCUSED = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ee6c4d"));
  }
}
