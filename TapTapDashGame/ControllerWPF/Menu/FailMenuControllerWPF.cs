using Controller.Menu;
using Model.Menu.Pages;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// Контроллер для управления меню поражения в WPF-приложении
  /// </summary>
  public class FailMenuControllerWPF : FailMenuController
  {
    /// <summary>
    /// Конструктор контроллера для меню поражения
    /// </summary>
    public FailMenuControllerWPF() { }

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      MainWindow.Instance.KeyDown -= KeyDown;
    }

    /// <summary>
    /// Создать представление меню поражения
    /// </summary>
    /// <returns>Представление меню поражения</returns>
    public override ViewFailMenu CreateViewFailMenu()
    {
      return new ViewFailMenuWPF(FailMenu);
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
          FailMenu.FocusPrevious();
          break;
        case Key.Down:
          FailMenu.FocusNext();
          break;
        case Key.Enter:
          FailMenu.SelectFocusedItem();
          break;
      }
    }

    /// <summary>
    /// Создать контроллер главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public override MainMenuController CreateMainMenuController()
    {
      return new MainMenuControllerWPF();
    }
  }
}
