using Controller.Menu;
using Model.Menu.Pages;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// Контроллер для управления меню рейтинга в WPF-приложении
  /// </summary>
  public class RatingMenuControllerWPF : RatingMenuController
  {
    /// <summary>
    /// Конструктор контроллера меню рейтинга
    /// </summary>
    public RatingMenuControllerWPF() { }

    /// <summary>
    /// Создание представления меню рейтинга
    /// </summary>
    /// <returns>Представление меню рейтинга</returns>
    public override ViewRatingMenu CreateViewRatingMenu()
    {
      return new ViewRatingMenuWPF(RatingMenu);
    }

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      MainWindow.Instance.KeyDown -= KeyDown;
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
          RatingMenu.FocusPrevious();
          break;
        case Key.Down:
          RatingMenu.FocusNext();
          break;
        case Key.Enter:
          RatingMenu.SelectFocusedItem();
          break;
      }
    }
  }
}
