using Controller.Game;
using Controller.Menu;
using ControllerConsole.Menu;
using View.Game;
using ViewConsole.Game;

namespace ControllerConsole.Game
{
  /// <summary>
  /// Контроллер игры для консольного приложения
  /// </summary>
  public class GameControllerConsole : GameController
  {
    /// <summary>
    /// Словарь для обработки действий при нажатии клавиш
    /// </summary>
    private Dictionary<ConsoleKey, Action> KeyAction { get; set; }

    /// <summary>
    /// Конструктор контроллера игры в консольном приложении
    /// </summary>
    public GameControllerConsole(string parPathToLevel) : base(parPathToLevel)
    {
      InitKeys();
      GameUpdateRate = 0.06;
    }

    /// <summary>
    /// Инициализация клавиш для управления игрой
    /// </summary>
    private void InitKeys()
    {
      KeyAction = new()
      {
        { ConsoleKey.Enter, StartGame },
        { ConsoleKey.Spacebar, ChangeCatDirection },
      };
    }

    /// <summary>
    /// Создание контроллера для меню неудачи
    /// </summary>
    public override FailMenuController CreateFailMenuController()
    {
      return new FailMenuControllerConsole();
    }

    /// <summary>
    /// Создание контроллера для итогового меню
    /// </summary>
    public override ResultMenuController CreateResultMenuController()
    {
      return new ResultMenuControllerConsole();
    }

    /// <summary>
    /// Создание представления игры для консольного приложения
    /// </summary>
    public override ViewGame CreateViewGame()
    {
      return new ViewGameConsole(Game);
    }

    /// <summary>
    /// Обработка нажатий клавиш
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        if (Console.KeyAvailable)
        {
          var key = Console.ReadKey(true).Key;

          if (KeyAction.ContainsKey(key))
          {
            KeyAction[key]();
          }
        }
      }
    }

    /// <summary>
    /// Выполнение шага игры
    /// </summary>
    public override void RunGameStep()
    {
      Game.RunGameStep();
    }
  }
}
