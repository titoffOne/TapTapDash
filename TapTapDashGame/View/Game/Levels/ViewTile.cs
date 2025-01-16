using Model.Game.Levels;
using Model.Geometry;

namespace View.Game.Levels
{
  /// <summary>
  /// Представление ячейки
  /// </summary>
  public abstract class ViewTile : ViewBase
  {
    /// <summary>
    /// Ячейка
    /// </summary>
    public Tile Tile { get; private set; }

    /// <summary>
    /// Прямоугольник ячейки
    /// </summary>
    public Rectangle<int> TileRectangle { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTile">Ячейка</param>
    /// <param name="parTileRectengle">Прямоугольник</param>
    public ViewTile(Tile parTile, Rectangle<int> parTileRectengle)
    {
      Tile = parTile;
      TileRectangle = new(parTileRectengle);
      Tile.Position = TileRectangle.Position;
      Tile.Size = TileRectangle.Size;
      Tile.Rotation = TileRectangle.Rotation;

      Tile.NeedMoving += () =>
      {
        HandleCurrentDirectionChange(Tile.CurrentMovingDirection);
      };
    }

    /// <summary>
    /// Обработать событие изменения текущего направления движения ячейки
    /// </summary>
    /// <param name="parCurrentMovingDirection"></param>
    private void HandleCurrentDirectionChange(DirectionType parCurrentMovingDirection)
    {
      switch (parCurrentMovingDirection)
      {
        case DirectionType.Right:
          MoveRight();
          break;
        case DirectionType.Left:
          MoveLeft();
          break;
        case DirectionType.Up:
          MoveUp();
          break;
        case DirectionType.Down:
          MoveDown();
          break;
      }
    }

    /// <summary>
    /// Двигатать вниз
    /// </summary>
    private void MoveDown()
    {
      TileRectangle.Position.Y--;
    }

    /// <summary>
    /// Двигатать вверх
    /// </summary>
    private void MoveUp()
    {
      TileRectangle.Position.Y++;
    }

    /// <summary>
    /// Двигатать влево
    /// </summary>
    private void MoveLeft()
    {
      TileRectangle.Position.X++;
    }

    /// <summary>
    /// Двигатать вправо
    /// </summary>
    private void MoveRight()
    {
      TileRectangle.Position.X--;
    }
  }
}
