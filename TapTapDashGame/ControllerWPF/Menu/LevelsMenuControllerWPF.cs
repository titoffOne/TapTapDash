using Controller.Game;
using Controller.Menu;
using ControllerWPF.Game;
using Model.Menu.Pages;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// Контроллер для управления меню выбора уровней в WPF-приложении
  /// </summary>
  public class LevelsMenuControllerWPF : LevelsMenuController
  {
    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      MainWindow.Instance.KeyDown -= KeyDown;
    }

    /// <summary>
    /// Создать представление меню уровней
    /// </summary>
    /// <returns>Представление меню уровней</returns>
    public override ViewLevelsMenu CreateLevelsMenu()
    {
      return new ViewLevelsMenuWPF(LevelsMenu);
    }

    /// <summary>
    /// Настройка обработки событий нажатия клавиш
    /// </summary>
    public override void HandleKey()
    {
      MainWindow.Instance.KeyDown += KeyDown;
    }

    /// <summary>
    /// Обработка события нажатия клавиши
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Аргументы события</param>
    private void KeyDown(object parSender, KeyEventArgs parE)
    {
      switch (parE.Key)
      {
        case Key.Up:
          LevelsMenu.FocusPrevious();
          break;
        case Key.Down:
          LevelsMenu.FocusNext();
          break;
        case Key.Enter:
          LevelsMenu.SelectFocusedItem();
          break;
      }
    }

    /// <summary>
    /// Создать контроллер игры
    /// </summary>
    /// <param name="parPathToMap">Путь до карты</param>
    /// <returns>Контроллер игры</returns>
    protected override GameController CreateGameController(string parPathToMap)
    {
      return new GameControllerWPF(parPathToMap);
    }
  }
}
