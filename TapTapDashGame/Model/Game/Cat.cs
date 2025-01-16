using Model.Game.Levels;
using Model.Geometry;

namespace Model.Game
{
  /// <summary>
  /// Кот (игровой персонаж)
  /// </summary>
  public class Cat 
  {
    /// <summary>
    /// Событие изменения направления
    /// </summary>
    public event Action? DirectionChanged;

    /// <summary>
    /// Событие увеличения размера
    /// </summary>
    public event Action? SizeIncreased;

    /// <summary>
    /// Событие увеличения размера
    /// </summary>
    public event Action? SizeDecreased;

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
    /// Направление движения
    /// </summary>
    public DirectionType Direction { get; set; }

    /// <summary>
    /// Кол-во собранных монет
    /// </summary>
    public int CoinsCollected { get; set; }

    /// <summary>
    /// Жив ли игрок
    /// </summary>
    public bool IsAlive { get; set; }

    /// <summary>
    /// Совершен ли прыжок
    /// </summary>
    private bool _jumpPerformed = false;

    /// <summary>
    /// Конструктор без параметров
    /// </summary>
    public Cat() : this(new(0, 0), new(0, 0), new(0), DirectionType.Up, 0, true)
    { 
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parDirection">Направление</param>
    /// <param name="parCoinsCollected">Кол-во собранных монет</param>
    /// <param name="parIsAlive">Жив ли игрок</param>
    public Cat(DirectionType parDirection, int parCoinsCollected, bool parIsAlive) 
      : this(new(0, 0), new(0, 0), new(0), parDirection, parCoinsCollected, parIsAlive)
    {
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPosition">Позциия</param>
    /// <param name="parSize">Размер</param>
    /// <param name="parRotation">Поворот</param>
    /// <param name="parDirection">Направление движения</param>
    /// <param name="parCoinsCollected">Кол-во собранных монет</param>
    /// <param name="isAlive">Жив ли игрок</param>
    public Cat(Position<int> parPosition, Size<int> parSize, Rotation<int> parRotation,
      DirectionType parDirection, int parCoinsCollected, bool isAlive)
    {
      Position = parPosition;
      Size = parSize;
      Rotation = parRotation;
      Direction = parDirection;
      CoinsCollected = parCoinsCollected;
      IsAlive = isAlive;
    }

    /// <summary>
    /// Проверить позицию кота
    /// </summary>
    /// <param name="parTile"></param>
    public void CheckCatState(Tile parTile)
    {
      switch (parTile.Type)
      {
        case TileTypes.Coin:
          CoinsCollected++;
          parTile.Type = TileTypes.Empty;
          break;
        case TileTypes.Forward:
          if (!_jumpPerformed)
            SizeDecreased?.Invoke();
          break;
        case TileTypes.Abyss:
          if (!_jumpPerformed)
            IsAlive = false;
          break;
        default:
          _jumpPerformed = false;
          SizeDecreased?.Invoke();
          break;
      }
    }

    /// <summary>
    /// Изменить направление в зависимости от направления ячейки
    /// </summary>
    /// <param name="parTileType">Текущее направление ячейки</param>
    public void ChangeDirection(TileTypes parTileType)
    {
      switch(parTileType)
      {
        case TileTypes.TurnLeft:
          ChangeDirectionTurnLeft();
          break;
        case TileTypes.TurnRight:
          ChangeDirectionTurnRight();
          break;
        case TileTypes.Forward:
          _jumpPerformed = true;
          SizeIncreased?.Invoke();
          break;
        default:
          ChangeDirection();
          break;
      }

      DirectionChanged?.Invoke();
    }

    /// <summary>
    /// Изменить направление
    /// </summary>
    public void ChangeDirection()
    {
      switch(Direction)
      {
        case DirectionType.Up:
          Direction = DirectionType.Right;
          break;
        case DirectionType.Down:
          Direction = DirectionType.Left;
          break;
        case DirectionType.Left:
          Direction = DirectionType.Up;
          break;
        case DirectionType.Right: 
          Direction = DirectionType.Down;
          break;
      }
    }

    /// <summary>
    /// Изменить направление при повороте налево
    /// </summary>
    public void ChangeDirectionTurnLeft()
    {
      switch (Direction)
      {
        case DirectionType.Up:
          Direction = DirectionType.Left;
          break;
        case DirectionType.Down:
          Direction = DirectionType.Right;
          break;
        case DirectionType.Left:
          Direction = DirectionType.Down;
          break;
        case DirectionType.Right:
          Direction = DirectionType.Up;
          break;
      }
    }

    /// <summary>
    /// Изменить направление при повороте направо
    /// </summary>
    public void ChangeDirectionTurnRight()
    {
      switch (Direction)
      {
        case DirectionType.Up:
          Direction = DirectionType.Right;
          break;
        case DirectionType.Down:
          Direction = DirectionType.Left;
          break;
        case DirectionType.Left:
          Direction = DirectionType.Up;
          break;
        case DirectionType.Right:
          Direction = DirectionType.Down;
          break;
      }
    }
  }
}
