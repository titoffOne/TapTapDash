using Controller.Menu;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// WPF контроллер для управления главным меню
  /// </summary>
  public class MainMenuControllerWPF : MainMenuController
  {
    /// <summary>
    /// Конструктор контроллера главного меню
    /// </summary>
    public MainMenuControllerWPF() : base()
    {
    }

    /// <summary>
    /// Настройка обработки событий нажатия клавиш
    /// </summary>
    public override void HandleKey()
    {
      MainWindow.Instance.KeyDown += KeyDown;
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
    /// Обработка события нажатия клавиши
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Аргументы события</param>
    private void KeyDown(object parSender, KeyEventArgs parE)
    {
      switch (parE.Key)
      {
        case Key.Up:
          MainMenu.FocusPrevious();
          break;
        case Key.Down:
          MainMenu.FocusNext();
          break;
        case Key.Enter:
          MainMenu.SelectFocusedItem();
          break;
      }
    }

    /// <summary>
    /// Создание представления главного меню
    /// </summary>
    /// <returns>Представление главного меню</returns>
    public override ViewMainMenu CreateViewMainMenu()
    {
      return new ViewMainMenuWPF(MainMenu);
    }

    /// <summary>
    /// Создать контроллер для меню выбора уровней
    /// </summary>
    /// <returns>Контроллер меню выбора уровней</returns>
    public override LevelsMenuController CreateLevelsMenuController()
    {
      return new LevelsMenuControllerWPF();
    }

    /// <summary>
    /// Создать контроллер для меню правил
    /// </summary>
    /// <returns>Контроллер меню правил</returns>
    public override RulesMenuController CreateRulesMenuController()
    {
      return new RulesMenuControllerWPF();
    }

    /// <summary>
    /// Создать контроллер для меню рейтинга
    /// </summary>
    /// <returns>Контроллер меню рейтинга</returns>
    public override RatingMenuController CreateRatingMenuController()
    {
      return new RatingMenuControllerWPF();
    }
  }
}
