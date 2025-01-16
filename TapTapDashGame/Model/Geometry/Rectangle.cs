namespace Model.Geometry
{
  /// <summary>
  /// Прямоугольник
  /// </summary>
  public class Rectangle<T> where T : IComparable<T>
  {
    /// <summary>
    /// Позиция левого верхнего угла
    /// </summary>
    public Position<T> Position { get; set; }

    /// <summary>
    /// Размер
    /// </summary>
    public Size<T> Size { get; set; }

    /// <summary>
    /// Поворот
    /// </summary>
    public Rotation<T> Rotation { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPosition">Позиция левого верхнего угла</param>
    /// <param name="parSize">Размер</param>
    public Rectangle(Position<T> parPosition, Size<T> parSize, Rotation<T> parRotation)
    {
      Position = parPosition;
      Size = parSize;
      Rotation = parRotation;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public Rectangle(T parX, T parY, T parWidth, T parHeight, T parRotation)
    {
      Position = new Position<T>(parX, parY);
      Size = new Size<T>(parWidth, parHeight);
      Rotation = new Rotation<T>(parRotation);
    }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parRectangle">Прямоугольник</param>
    public Rectangle(Rectangle<T> parRectangle)
    {
      Position = new Position<T>(parRectangle.Position);
      Size = new Size<T>(parRectangle.Size);
      Rotation = new Rotation<T>(parRectangle.Rotation);
    }


    /// <summary>
    /// Возвращает середину прямоугольника
    /// </summary>
    public Position<T> GetCenter()
    {
      var centerX = Add(Position.X, Divide(Size.Width, 2));
      var centerY = Add(Position.Y, Divide(Size.Height, 2));
      return new Position<T>(centerX, centerY);
    }

    /// <summary>
    /// Проверяет, находится ли точка внутри прямоугольника
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <returns>True, если точка внутри прямоугольника, иначе False</returns>
    public bool Contains(T parX, T parY)
    {
      var xMin = Position.X;
      var yMin = Position.Y;
      var xMax = Add(Position.X, Size.Width);
      var yMax = Add(Position.Y, Size.Height);

      return parX.CompareTo(xMin) >= 0
        && parX.CompareTo(xMax) < 0
        && parY.CompareTo(yMin) >= 0
        && parY.CompareTo(yMax) < 0;
    }

    /// <summary>
    /// Метод для сложения двух значений типа T
    /// </summary>
    private T Add(T parA, T parB)
    {
      dynamic da = parA;
      dynamic db = parB;
      return da + db;
    }

    /// <summary>
    /// Метод для деления значения типа T
    /// </summary>
    private T Divide(T parA, int parB)
    {
      dynamic da = parA;
      return da / parB;
    }

    /// <summary>
    /// Проверяет, находится ли центр текущего прямоугольника внутри другого прямоугольника
    /// </summary>
    /// <param name="parOtherRectangle">Другой прямоугольник для проверки</param>
    /// <returns>True, если центр текущего прямоугольника находится внутри другого, иначе False</returns>
    public bool IsCenterInside(Rectangle<T> parOtherRectangle)
    {
      // Координаты центра текущего прямоугольника
      var centerX = Add(Position.X, Divide(Size.Width, 2));
      var centerY = Add(Position.Y, Divide(Size.Height, 2));

      // Левый верхний угол другого прямоугольника
      var xMinOther = parOtherRectangle.Position.X;
      var yMinOther = parOtherRectangle.Position.Y;

      // Правый нижний угол другого прямоугольника
      var xMaxOther = Add(parOtherRectangle.Position.X, parOtherRectangle.Size.Width);
      var yMaxOther = Add(parOtherRectangle.Position.Y, parOtherRectangle.Size.Height);

      // Проверка, что центр текущего прямоугольника находится внутри другого
      return centerX.CompareTo(xMinOther) >= 0 &&
              centerX.CompareTo(xMaxOther) <= 0 &&
              centerY.CompareTo(yMinOther) >= 0 &&
              centerY.CompareTo(yMaxOther) <= 0;
    }


  }
}
