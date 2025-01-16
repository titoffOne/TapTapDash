using Controller.Game;
using Controller.Menu;
using ControllerWPF.Menu;
using System.Windows;
using System.Windows.Input;
using View.Game;
using ViewWPF;
using ViewWPF.Game;

namespace ControllerWPF.Game
{
  /// <summary>
  /// Контроллер для управления игрой в WPF-приложении
  /// </summary>
  public class GameControllerWPF : GameController
  {
    /// <summary>
    /// Словарь действий, связанных с нажатиями клавиш
    /// </summary>
    private Dictionary<Key, Action> KeyAction { get; set; }

    /// <summary>
    /// Конструктор, инициализирующий контроллер игры для указанного уровня
    /// </summary>
    /// <param name="parPathToLevel">Путь до уровня</param>
    public GameControllerWPF(string parPathToLevel) : base(parPathToLevel)
    {
      InitKeys();
      GameUpdateRate = 0.004;
    }

    /// <summary>
    /// Инициализация действий для клавиш
    /// </summary>
    private void InitKeys()
    {
      KeyAction = new()
      {
        { Key.Enter, StartGame },
        { Key.Space, ChangeCatDirection }
      };
    }

    /// <summary>
    /// Настройка обработки событий нажатия клавиш
    /// </summary>
    public override void HandleKey()
    {
      MainWindow.Instance.KeyDown += KeyDown;
    }

    /// <summary>
    /// Выполнение одного шага игры
    /// </summary>
    public override void RunGameStep()
    {
      Application.Current.Dispatcher.Invoke(() =>
      {
        Game.RunGameStep();
      });
    }

    /// <summary>
    /// Запуск контроллера игры
    /// </summary>
    public override void Start()
    {
      MainWindow.Instance.Clear();
      ((IAddChildren)ViewGame).AddChildren();
      base.Start();
    }

    /// <summary>
    /// Остановка контроллера игры
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      MainWindow.Instance.KeyDown -= KeyDown;
    }

    /// <summary>
    /// Обработка события нажатия клавиши
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Аргументы события</param>
    private void KeyDown(object parSender, KeyEventArgs parE)
    {
      if (KeyAction.ContainsKey(parE.Key))
      {
        KeyAction[parE.Key]();
      }
    }

    /// <summary>
    /// Создание представления игры
    /// </summary>
    /// <returns>Представление игры</returns>
    public override ViewGame CreateViewGame()
    {
      return new ViewGameWPF(Game);
    }

    /// <summary>
    /// Создание контроллера меню поражения
    /// </summary>
    /// <returns>Контроллер меню поражения</returns>
    public override FailMenuController CreateFailMenuController()
    {
      return new FailMenuControllerWPF();
    }

    /// <summary>
    /// Создание контроллера меню результатов
    /// </summary>
    /// <returns>Контроллер меню результатов</returns>
    public override ResultMenuController CreateResultMenuController()
    {
      return new ResultMenuControllerWPF();
    }
  }
}
