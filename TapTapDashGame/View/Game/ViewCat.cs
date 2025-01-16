using Model.Game;
using Model.Game.Levels;
using Model.Geometry;

namespace View.Game
{
  /// <summary>
  /// Представление кота
  /// </summary>
  public abstract class ViewCat : ViewBase
  {
    /// <summary>
    /// Кот
    /// </summary>
    public Cat Cat { get; private set; }

    /// <summary>
    /// Прямоугольник отрисовки кота
    /// </summary>
    public Rectangle<int> CatRectangle { get; set; }

    /// <summary>
    /// Размер по умолчаниию
    /// </summary>
    private Size<int> _defaultCatSize;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parCat">Кот</param>
    /// <param name="parPosition">Позиция</param>
    /// <param name="parSize">Размер</param>
    /// <param name="parRotation">Поворот</param>
    public ViewCat(Cat parCat, Position<int> parPosition, Size<int> parSize, Rotation<int> parRotation) 
    {
      Cat = parCat;
      CatRectangle = new(parPosition, parSize, parRotation);
      Cat.Position = CatRectangle.Position;
      Cat.Size = CatRectangle.Size;
      _defaultCatSize = new(parSize);
      Cat.Rotation = CatRectangle.Rotation;

      Cat.DirectionChanged += () =>
      {
        HandleDirectionChange();
      };

      Cat.SizeIncreased += () =>
      {
        IncreasedCatSize();
      };

      Cat.SizeDecreased += () =>
      {
        CatRectangle.Size.Width = _defaultCatSize.Width;
        CatRectangle.Size.Height = _defaultCatSize.Height;
      };
    }

    /// <summary>
    /// Обработать событие изменения направления
    /// </summary>
    private void HandleDirectionChange()
    {
      CatRectangle.Rotation.Angle = 0;
      switch (Cat.Direction)
      {
        case DirectionType.Right:
          RotateRight();
          break;
        case DirectionType.Left:
          RotateLeft();
          break;
        case DirectionType.Up:
          RotateUp();
          break;
        case DirectionType.Down:
          RotateDown();
          break;
      }
    }

    /// <summary>
    /// Обработать событие изменения размера кота
    /// </summary>
    public abstract void IncreasedCatSize();

    /// <summary>
    /// Повернуть вниз
    /// </summary>
    private void RotateDown()
    {
      CatRectangle.Rotation.RotateRight(180);
    }

    /// <summary>
    /// Повернуть вверх
    /// </summary>
    private void RotateUp()
    {
      CatRectangle.Rotation.Angle = 0;
    }

    /// <summary>
    /// Повернуть влево
    /// </summary>
    private void RotateLeft()
    {
      CatRectangle.Rotation.RotateLeft(90);
    }

    /// <summary>
    /// Повернуть вправо
    /// </summary>
    private void RotateRight()
    {
      CatRectangle.Rotation.RotateRight(90);
    }
  }
}
