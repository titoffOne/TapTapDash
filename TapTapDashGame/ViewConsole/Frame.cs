
using Model.Geometry;

namespace ViewConsole
{
  /// <summary>
  /// Кадр
  /// </summary>
  public class Frame
  {
    /// <summary>
    /// Буфер
    /// </summary>
    public ConsoleWriter.CharInfo[] Buffer { get; private set; }

    /// <summary>
    /// Ширина
    /// </summary>
    public int Width { get; private set; }

    /// <summary>
    /// Высота
    /// </summary>
    public int Height { get; private set; }

    /// <summary>
    /// Монитор
    /// </summary>
    private object Lock { get; set; } = new();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public Frame(int parWidth, int parHeight)
    {
      SetSize(parWidth, parHeight);
    }

    /// <summary>
    /// Установить размер
    /// </summary>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public void SetSize(int parWidth, int parHeight)
    {
      lock (Lock)
      {
        Width = parWidth;
        Height = parHeight;
        Buffer = new ConsoleWriter.CharInfo[Width * Height];
      }
    }

    /// <summary>
    /// Получить байтовый атрибут цвета
    /// </summary>
    /// <param name="parFG">Цвет текста</param>
    /// <param name="parBG">Цвет заднего фона</param>
    /// <returns>Байтовый атрибут цвета</returns>
    private static byte GetColorAttribute(Colors parFG, Colors parBG) => (byte)((byte)parFG | ((byte)parBG << 4));

    /// <summary>
    /// Конвертировать 2D позицию в индекс
    /// </summary>
    /// <param name="parX">Х Координата</param>
    /// <param name="parY">Y Координата</param>
    /// <returns>Индекс</returns>
    private int PositionToIndex(int parX, int parY)
    {
      lock (Lock)
      {
        return parX + parY * Width;
      }
    }

    /// <summary>
    /// Записать символа по индексу
    /// </summary>
    /// <param name="parIndex">Индекс</param>
    /// <param name="parCh">Символ</param>
    /// <param name="parFG">Цвет символа</param>
    /// <param name="parBG">Цвет фона</param>
    private void Write(int parIndex, char parCh, Colors parFG = Colors.White, Colors parBG = Colors.Black)
    {
      lock (Lock)
      {
        Buffer[parIndex].Attributes = GetColorAttribute(parFG, parBG);
        Buffer[parIndex].Char.UnicodeChar = (short)parCh;
      }
    }

    /// <summary>
    /// Записать символа по координатам
    /// </summary>
    /// <param name="parX">Х Координата</param>
    /// <param name="parY">Y Координата</param>
    /// <param name="parCh">Символ</param>
    /// <param name="parFG">Цвет символа</param>
    /// <param name="parBG">Цвет фона</param>
    public void Write(int parX, int parY, char parCh, Colors parFG = Colors.White, Colors parBG = Colors.Black)
    {
      lock (Lock)
      {
        Write(PositionToIndex(parX, parY), parCh, parFG, parBG);
      }
    }

    /// <summary>
    /// Записать строки по координатам
    /// </summary>
    /// <param name="parX">Х Координата</param>
    /// <param name="parY">Y Координата</param>
    /// <param name="parStr">Строка</param>
    /// <param name="parFG">Цвет строки</param>
    /// <param name="parBG">Цвет фона</param>
    public void Write(int parX, int parY, string parStr, Colors parFG = Colors.White, Colors parBG = Colors.Black)
    {
      lock (Lock)
      {
        foreach (char ch in parStr)
        {
          Write(parX++, parY, ch, parFG, parBG);
        }
      }
    }

    /// <summary>
    /// Записать строки по координатам
    /// </summary>
    /// <param name="parPosition">Позиция</param>
    /// <param name="parStr">Строка</param>
    /// <param name="parFG">Цвет строки</param>
    /// <param name="parBG">Цвет фона</param>
    public void Write(Position<int> parPosition, string parStr, Colors parFG = Colors.White, Colors parBG = Colors.Black)
    {
      lock (Lock)
      {
        int x = parPosition.X;

        foreach (char ch in parStr)
        {
          Write(x++, parPosition.Y, ch, parFG, parBG);
        }
      }
    }

    /// <summary>
    /// Заполнить прямоугольником
    /// </summary>
    /// <param name="parRectangle">Прямоугольник</param>
    /// <param name="parCh">Символ</param>
    /// <param name="parFG">Цвет символа</param>
    /// <param name="parBG">Цвет фона</param>
    public void Fill(Rectangle<int> parRectangle, char parCh, Colors parFG = Colors.White, Colors parBG = Colors.Black)
    {
      lock (Lock)
      {
        for (int i = 0; i < parRectangle.Size.Width; i++)
        {
          for (int j = 0; j < parRectangle.Size.Height; j++)
          {
            Write(parRectangle.Position.X + i, parRectangle.Position.Y + j, parCh, parFG, parBG);
          }
        }
      }
    }

    /// <summary>
    /// Заполнить прямоугольником с использованием матрицы и поворотом
    /// </summary>
    /// <param name="parRectangle">Прямоугольник</param>
    /// <param name="matrix">Матрица (0 или 1), определяющая заполнение</param>
    /// <param name="parCh">Символ</param>
    /// <param name="parFG">Цвет символа</param>
    /// <param name="parBG">Цвет фона</param>
    public void Fill(Rectangle<int> parRectangle, int[,] matrix, char parCh, Colors parFG = Colors.White, Colors parBG = Colors.Black)
    {
      lock (Lock)
      {
        // Проверка размера матрицы
        if (matrix.GetLength(0) != parRectangle.Size.Width || matrix.GetLength(1) != parRectangle.Size.Height)
        {
          throw new ArgumentException("Размер матрицы должен совпадать с размерами прямоугольника.");
        }

        // Повернуть матрицу в соответствии с углом поворота
        int[,] rotatedMatrix = RotateMatrix(matrix, parRectangle.Rotation.Angle);

        // Заполнение прямоугольника на основе повёрнутой матрицы
        for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
        {
          for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
          {
            // Если элемент матрицы равен 1, рисуем символ
            if (rotatedMatrix[j, i] == 1)
            {
              Write(parRectangle.Position.X + i, parRectangle.Position.Y + j, parCh, parFG, parBG);
            }
          }
        }
      }
    }

    /// <summary>
    /// Повернуть матрицу на указанный угол
    /// </summary>
    /// <param name="matrix">Исходная матрица</param>
    /// <param name="angle">Угол поворота (кратен 90)</param>
    /// <returns>Повернутая матрица</returns>
    private int[,] RotateMatrix(int[,] matrix, int angle)
    {
      // Нормализуем угол к диапазону [0, 360)
      angle = ((angle % 360) + 360) % 360;

      int rows = matrix.GetLength(0);
      int cols = matrix.GetLength(1);
      int[,] rotatedMatrix;

      switch (angle)
      {
        case 90: // Поворот вправо
          rotatedMatrix = new int[cols, rows];
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
              rotatedMatrix[j, rows - 1 - i] = matrix[i, j];
          break;

        case 180: // Поворот на 180 градусов
          rotatedMatrix = new int[rows, cols];
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
              rotatedMatrix[rows - 1 - i, cols - 1 - j] = matrix[i, j];
          break;

        case 270: // Поворот влево
          rotatedMatrix = new int[cols, rows];
          for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
              rotatedMatrix[cols - 1 - j, i] = matrix[i, j];
          break;

        default: // Если угол 0, возвращаем исходную матрицу
          rotatedMatrix = matrix;
          break;
      }

      return rotatedMatrix;
    }



  }
}
