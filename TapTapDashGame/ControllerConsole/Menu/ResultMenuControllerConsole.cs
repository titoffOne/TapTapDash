using Controller.Menu;
using Model.Menu.Pages;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер меню результата для консольного приложения
  /// </summary>
  public class ResultMenuControllerConsole : ResultMenuController
  {
    /// <summary>
    /// Создание контроллера меню уровней
    /// </summary>
    public override LevelsMenuController CreateLevelsMenuController()
    {
      return new LevelsMenuControllerConsole();
    }

    /// <summary>
    /// Создание контроллера главного меню
    /// </summary>
    public override MainMenuController CreateMainMenuController()
    {
      return new MainMenuControllerConsole();
    }

    /// <summary>
    /// Создание представления меню результата
    /// </summary>
    public override ViewResultMenu CreateViewResultMenu()
    {
      return new ViewResultMenuConsole(ResultMenu);
    }

    /// <summary>
    /// Обработка нажатий клавиш в меню результата
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.UpArrow:
            ResultMenu.FocusPrevious();
            break;
          case ConsoleKey.DownArrow:
            ResultMenu.FocusNext();
            break;
          case ConsoleKey.Enter:
            ResultMenu.SelectFocusedItem();
            break;
        }
      }
    }
  }
}
