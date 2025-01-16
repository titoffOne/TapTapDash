using Model.Game.Levels;
using Model.Game.Records;
using Model.Geometry;

namespace Model.Game
{
  /// <summary>
  /// Игра
  /// </summary>
  public class Game : INeedRedraw
  {
    /// <summary>
    /// Событие необходимости перерисовки
    /// </summary>
    public event Action? NeedRedraw;

    /// <summary>
    /// Уровень
    /// </summary>
    public Level Level { get; set; }

    /// <summary>
    /// Кот (игровой персонаж, игрок)
    /// </summary>
    public Cat Cat { get; set; }

    /// <summary>
    /// Флаг конца игрового процесса
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Событие конца игры
    /// </summary>
    public event Action? GameEndEvent;

    /// <summary>
    /// Событие проигрыша
    /// </summary>
    public event Action? GameLostEvent;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parLevel">Уровень</param>
    /// <param name="parCat">Кот</param>
    public Game(Level parLevel, Cat parCat)
    {
      Cat = parCat;
      Level = parLevel;
    }

    /// <summary>
    /// Запустить игровую логику.
    /// </summary>
    public void RunGameStep()
    {
      UpdateGame();
      NeedRedraw?.Invoke();
    }

    /// <summary>
    /// Обновлять состояние игры
    /// </summary>
    private void UpdateGame()
    {
      foreach (Step step in Level.Steps)
      {
        foreach (Tile tile in step.Tiles)
        {
          tile.Move(Cat.Direction);
        }
      }

      Tile? containTile = GetTileContainingCat();
      if (containTile == null)
      {
        GameLost();
      }
      else
      {
        Cat.CheckCatState(containTile);
        if (!Cat.IsAlive)
        {
          GameLost();
        }
        if (containTile.Type.Equals(TileTypes.End))
        {
          GameEnd();
        }
      }
    }

    /// <summary>
    /// Обновить направление кота
    /// </summary>
    public void UpdateCatDirection()
    {
      Tile? containTile = GetTileContainingCat();
      if (containTile != null)
      {
        Cat.ChangeDirection(containTile.Type);
      }
    }

    /// <summary>
    /// Получить ячейку, в которой находится кот
    /// </summary>
    /// <returns>Ячейка, если найдена</returns>
    private Tile? GetTileContainingCat()
    {
      Rectangle<int> catRectnagle = new(new(Cat.Position), new(Cat.Size), new(Cat.Rotation));
      Rectangle<int> tileRectnagle;

      foreach (Step step in Level.Steps)
      {
        foreach (Tile tile in step.Tiles)
        {
          tileRectnagle = new(new(tile.Position), new(tile.Size), new(tile.Rotation));
          if (catRectnagle.IsCenterInside(tileRectnagle))
            return tile;
        }
      }
      return null;
    }

    /// <summary>
    /// Начать игру
    /// </summary>
    public void StartGameProcess()
    {
      IsActive = true;
    }

    /// <summary>
    /// Остановить игру
    /// </summary>
    public void StopGameProcess()
    {
      IsActive = false;
    }

    /// <summary>
    /// Конец игры
    /// </summary>
    private void GameEnd()
    {
      Rating.CurrentPlayer.CurrentScore = Cat.CoinsCollected;
      StopGameProcess();
      GameEndEvent?.Invoke();
    }

    /// <summary>
    /// Проигрыш
    /// </summary>
    private void GameLost()
    {
      StopGameProcess();
      GameLostEvent?.Invoke();
    }
  }
}
