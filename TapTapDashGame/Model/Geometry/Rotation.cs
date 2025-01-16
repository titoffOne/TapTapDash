using System;

namespace Model.Geometry
{
  /// <summary>
  /// Ротация
  /// </summary>
  public class Rotation<T>
  {
    /// <summary>
    /// Угол поворота
    /// </summary>
    public T Angle { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAngle">Угол поворота</param>
    public Rotation(T parAngle)
    {
      Angle = parAngle;
    }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parRotation">Ротация</param>
    public Rotation(Rotation<T> parRotation)
    {
      Angle = parRotation.Angle;
    }

    /// <summary>
    /// Повернуть объект влево
    /// </summary>
    /// <param name="parDegrees">Градусы смещения</param>
    public void RotateLeft(T parDegrees)
    {
      Angle = Subtract(Angle, parDegrees);
    }

    /// <summary>
    /// Повернуть объект вправо
    /// </summary>
    /// <param name="parDegrees">Градусы смещения</param>
    public void RotateRight(T parDegrees)
    {
      Angle = Add(Angle, parDegrees);
    }

    /// <summary>
    /// Сложить угол
    /// </summary>
    private T Add(T parA, T parB)
    {
      dynamic da = parA;
      dynamic db = parB;
      return da + db;
    }

    /// <summary>
    /// Вычесть угол
    /// </summary>
    private T Subtract(T parA, T parB)
    {
      dynamic da = parA;
      dynamic db = parB;
      return da - db;
    }

    /// <summary>
    /// Получить нормализованный угол (0–360)
    /// </summary>
    public T Normalize()
    {
      dynamic angle = Angle;
      dynamic fullCircle = 360;
      while (angle < 0) angle += fullCircle;
      while (angle >= fullCircle) angle -= fullCircle;
      return angle;
    }
  }
}
