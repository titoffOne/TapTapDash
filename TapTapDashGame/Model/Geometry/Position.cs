namespace Model.Geometry
{
  /// <summary>
  /// Позиция в 2D пространстве
  /// </summary>
  public class Position<T>
  {
    /// <summary>
    /// Координата X
    /// </summary>
    public T X { get; set; }

    /// <summary>
    /// Координата Y
    /// </summary>
    public T Y { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    public Position(T parX, T parY)
    {
      X = parX;
      Y = parY;
    }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parPosition">Позиция</param>
    public Position(Position<T> parPosition)
    {
      X = parPosition.X;
      Y = parPosition.Y;
    }

    /// <summary>
    /// Сравнить
    /// </summary>
    /// <param name="parObj">Объект для сравнения</param>
    /// <returns>Равны ли объекты</returns>
    public override bool Equals(object? parObj)
    {
      return parObj is Position<T> position
          && EqualityComparer<T>.Default.Equals(X, position.X)
          && EqualityComparer<T>.Default.Equals(Y, position.Y);
    }

  }
}
