using Controller.Menu;
using Model.Game;
using Model.Game.Levels;
using View.Game;

namespace Controller.Game
{
  /// <summary>
  /// Контроллер игрового процесса
  /// </summary>
  public abstract class GameController : ControllerBase
  {
    /// <summary>
    /// Модель игры
    /// </summary>
    public Model.Game.Game Game { get; set; }

    /// <summary>
    /// Представление игры
    /// </summary>
    public ViewGame ViewGame { get; set; }

    /// <summary>
    /// Путь до папки с уровнями
    /// </summary>
    private string PathToLevel { get; set; }

    /// <summary>
    /// Поток игрового процесса
    /// </summary>
    private Thread? GameThread { get; set; }

    /// <summary>
    /// Активен ли игровой поток
    /// </summary>
    public bool IsGameThreadActive { get; set; }

    /// <summary>
    /// Частота обнолвения игрового процесса
    /// </summary>
    public double GameUpdateRate { get; set; }

    /// <summary>
    /// Нажата ли клавиша enter для старта
    /// </summary>
    private bool IsEnterHandle { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPathToLevel">Путь до папки с уровнями</param>
    public GameController(string parPathToLevel)
    {
      PathToLevel = parPathToLevel;
      CreateGame();
    }

    /// <summary>
    /// Создать игру
    /// </summary>
    public void CreateGame()
    {
      Game = new GameBuilder()
        .SetLevel(LevelReader.ReadLevelFromFile(PathToLevel))
        .SetCatDirection(DirectionType.Up)
        .SetCatCoinsCollected(0)
        .SetIsCatAlive(true)
        .SetCat()
        .Build();

      Game.GameLostEvent += () =>
      {
        OpenFailMenu();
      };

      Game.GameEndEvent += () =>
      {
        OpenResultMenu();
      };

      ViewGame = CreateViewGame();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewGame.Draw();
      HandleKey();
    }

    /// <summary>
    /// Запустить игру
    /// </summary>
    public void StartGame()
    {
      IsEnterHandle = true;
      if (!IsGameThreadActive)
      {
        Game.StartGameProcess();
        StartGameThread();
      }
    }

    /// <summary>
    /// Запустить игровой поток
    /// </summary>
    public void StartGameThread()
    {
      if (GameThread == null || !GameThread.IsAlive)
      {
        IsGameThreadActive = true;
        GameThread = new Thread(() =>
        {
          var lastUpdateTime = DateTime.Now;

          while (IsGameThreadActive)
          {
            var currentTime = DateTime.Now;
            var deltaTime = (currentTime - lastUpdateTime).TotalSeconds;

            if (deltaTime >= GameUpdateRate)
            {
              RunGameStep();
              lastUpdateTime = currentTime;
            }
          }
        })
        {
          Name = "GameThread"
        };
        GameThread.Start();
      }
    }

    /// <summary>
    /// Осуществить шаг игры
    /// </summary>
    public abstract void RunGameStep();

    /// <summary>
    /// Остановить игровой поток
    /// </summary>
    public void StopGameThread()
    {      
      IsGameThreadActive = false;
    }


    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      StopGameThread();
      GameThread = null;
      IsActive = false;
      IsEnterHandle= false;
    }

    /// <summary>
    /// Перезапустить игру
    /// </summary>
    public void Restart()
    {
      CreateGame();
      Start();
    }

    /// <summary>
    /// Изменить направление движения кота
    /// </summary>
    public void ChangeCatDirection()
    {
      if (IsEnterHandle)
      {
        Game.UpdateCatDirection();
      }
    }

    /// <summary>
    /// Открыть меню проигрыша
    /// </summary>
    public void OpenFailMenu()
    {
      Stop();
      ControllersStack.Stack.Push(this);
      CreateFailMenuController().Start();
    }

    /// <summary>
    /// Открыть меню результата
    /// </summary>
    public void OpenResultMenu()
    {
      Stop();
      ControllersStack.Stack.Push(this);
      CreateResultMenuController().Start();
    }

    /// <summary>
    /// Создать представление игры
    /// </summary>
    /// <returns>Представление игры</returns>
    public abstract ViewGame CreateViewGame();

    /// <summary>
    /// Создать контроллер меню проигрыша
    /// </summary>
    /// <returns>Контроллер меню проигрыша</returns>
    public abstract FailMenuController CreateFailMenuController();

    /// <summary>
    /// Создать контроллер меню результат
    /// </summary>
    /// <returns>Контроллер меню результата</returns>
    public abstract ResultMenuController CreateResultMenuController();
  }
}
