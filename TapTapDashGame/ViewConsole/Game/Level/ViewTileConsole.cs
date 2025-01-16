using CommonResources;
using Model.Game.Levels;
using Model.Geometry;
using View.Game.Levels;

namespace ViewConsole.Game.Level
{
  /// <summary>
  /// Представление ячеек игрового уровня в консоли
  /// </summary>
  public class ViewTileConsole : ViewTile
  {
    /// <summary>
    /// Матрица для отрисовки ячейки типа Start или End
    /// </summary>
    int[,] _startOrEnd = new int[,]
    {
          { 0, 0, 0, 0, 0, 0 },
          { 0, 0, 0, 0, 0, 0 },
          { 1, 0, 1, 0, 1, 0 },
          { 0, 1, 0, 1, 0, 1 },
          { 0, 0, 0, 0, 0, 0 },
          { 0, 0, 0, 0, 0, 0 }
    };

    /// <summary>
    /// Матрица для отрисовки ячейки типа TurnLeft
    /// </summary>
    int[,] _turnleft = new int[,]
    {
          { 0, 0, 1, 0, 0, 0 },
          { 0, 1, 1, 0, 0, 0 },
          { 1, 1, 1, 1, 1, 1 },
          { 1, 1, 1, 1, 1, 1 },
          { 0, 1, 1, 0, 0, 0 },
          { 0, 0, 1, 0, 0, 0 }
    };

    /// <summary>
    /// Матрица для отрисовки ячейки типа TurnRight
    /// </summary>
    int[,] _turnRight = new int[,]
    {
          { 0, 0, 0, 1, 0, 0 },
          { 0, 0, 0, 1, 1, 0 },
          { 1, 1, 1, 1, 1, 1 },
          { 1, 1, 1, 1, 1, 1 },
          { 0, 0, 0, 1, 1, 0 },
          { 0, 0, 0, 1, 0, 0 }
    };

    /// <summary>
    /// Матрица для отрисовки ячейки типа Forward
    /// </summary>
    int[,] _forward = new int[,]
    {
          { 0, 0, 1, 1, 0, 0 },
          { 0, 1, 1, 1, 1, 0 },
          { 1, 1, 1, 1, 1, 1 },
          { 0, 0, 1, 1, 0, 0 },
          { 0, 0, 1, 1, 0, 0 },
          { 0, 0, 1, 1, 0, 0 }
    };

    /// <summary>
    /// Матрица для отрисовки ячейки типа Coin
    /// </summary>
    int[,] _coin = new int[,]
    {
          { 0, 0, 0, 0, 0, 0 },
          { 0, 0, 1, 1, 0, 0 },
          { 0, 1, 1, 1, 1, 0 },
          { 0, 1, 1, 1, 1, 0 },
          { 0, 0, 1, 1, 0, 0 },
          { 0, 0, 0, 0, 0, 0 }
    };

    /// <summary>
    /// Конструктор для инициализации ячейки и прямоугольника
    /// </summary>
    public ViewTileConsole(Tile parTile, Rectangle<int> parTileRectengle) : base(parTile, parTileRectengle)
    {
    }

    /// <summary>
    /// Отрисовать ячейку, если она в пределах допустимых координат
    /// </summary>
    public override void Draw()
    {
      if (TileRectangle.Position.X >= 0 && TileRectangle.Position.Y >= 0
        && TileRectangle.Position.X < (Properties.CONSOLE_APPLICATION_WIDTH - TileRectangle.Size.Width)
        && TileRectangle.Position.Y < (Properties.CONSOLE_APPLICATION_HEIGHT - TileRectangle.Size.Height))
      {
        DrawTile(Tile.Type);
      }
    }

    /// <summary>
    /// Отрисовывать ячейку в зависимости от её типа
    /// </summary>
    private void DrawTile(TileTypes parTileTypes)
    {
      switch (parTileTypes)
      {
        case TileTypes.Empty:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          break;

        case TileTypes.Coin:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          ConsoleWriter.Frame.Fill(TileRectangle, _coin, ' ', Colors.Black, Colors.Yellow);
          break;

        case TileTypes.Start:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          ConsoleWriter.Frame.Fill(TileRectangle, _startOrEnd, ' ', Colors.Black, Colors.Green);
          break;

        case TileTypes.End:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          ConsoleWriter.Frame.Fill(TileRectangle, _startOrEnd, ' ', Colors.Black, Colors.Red);
          break;

        case TileTypes.Forward:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          ConsoleWriter.Frame.Fill(TileRectangle, _forward, ' ', Colors.Black, Colors.Blue);
          break;

        case TileTypes.TurnLeft:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          ConsoleWriter.Frame.Fill(TileRectangle, _turnleft, ' ', Colors.Black, Colors.Blue);
          break;

        case TileTypes.TurnRight:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          ConsoleWriter.Frame.Fill(TileRectangle, _turnRight, ' ', Colors.Black, Colors.Blue);
          break;

        case TileTypes.Abyss:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.Black);
          break;

        default:
          ConsoleWriter.Frame.Fill(TileRectangle, ' ', Colors.Black, Colors.White);
          break;
      }
    }
  }
}
