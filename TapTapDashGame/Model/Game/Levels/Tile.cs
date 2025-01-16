using Model.Geometry;

namespace Model.Game.Levels
{
  /// <summary>
  /// Ячейка лабиринта
  /// </summary>
  public class Tile
  {
    /// <summary>
    /// Событие передвижения
    /// </summary>
    public event Action? NeedMoving;

    /// <summary>
    /// Позиция
    /// </summary>
    public Position<int> Position { get; set; }

    /// <summary>
    /// Размер
    /// </summary>
    public Size<int> Size { get; set; }

    /// <summary>
    /// Поворот
    /// </summary>
    public Rotation<int> Rotation { get; set; }

    /// <summary>
    /// Тип ячейки
    /// </summary>
    public TileTypes Type { get; set; }

    /// <summary>
    /// Текущее направление движения ячейки
    /// </summary>
    public DirectionType CurrentMovingDirection { get; set; }

    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public Tile(TileTypes parType) : this(new(0, 0), new(0, 0), new(0), parType)
    {
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPosition">Позиция</param>
    /// <param name="parSize">Размер</param>
    /// <param name="parRotation">Поворот</param>
    /// <param name="parType">Тип</param>
    public Tile(Position<int> parPosition, Size<int> parSize, Rotation<int> parRotation,
      TileTypes parType)
    {
      Position = parPosition;
      Size = parSize;
      Rotation = parRotation;
      Type = parType;
      CurrentMovingDirection = DirectionType.Up;
    }

    /// <summary>
    /// Двигать ячейку
    /// </summary>
    /// <param name="parDirectionType">Направление движения</param>
    public void Move(DirectionType parDirectionType)
    {
      CurrentMovingDirection = parDirectionType;
      NeedMoving?.Invoke();
    }
  }
}
