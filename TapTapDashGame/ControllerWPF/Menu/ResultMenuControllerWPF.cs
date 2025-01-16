using Controller.Menu;
using Model.Menu.Pages;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// Контроллер для управления результатами игры в WPF-приложении
  /// </summary>
  public class ResultMenuControllerWPF : ResultMenuController
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
    /// Создание контроллера главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public override MainMenuController CreateMainMenuController()
    {
      return new MainMenuControllerWPF();
    }

    /// <summary>
    /// Создание контроллера меню уровней
    /// </summary>
    /// <returns>Контроллер меню уровней</returns>
    public override LevelsMenuController CreateLevelsMenuController()
    {
      return new LevelsMenuControllerWPF();
    }

    /// <summary>
    /// Создание представления меню результатов
    /// </summary>
    /// <returns>Представление меню результатов</returns>
    public override ViewResultMenu CreateViewResultMenu()
    {
      return new ViewResultMenuWPF(ResultMenu);
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
          ResultMenu.FocusPrevious();
          break;
        case Key.Down:
          ResultMenu.FocusNext();
          break;
        case Key.Enter:
          ResultMenu.SelectFocusedItem();
          break;
      }
    }
  }
}
