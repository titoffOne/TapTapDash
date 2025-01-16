using Controller.Menu;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер главного меню для консольного приложения
  /// </summary>
  public class MainMenuControllerConsole : MainMenuController
  {
    /// <summary>
    /// Создание контроллера меню уровней
    /// </summary>
    public override LevelsMenuController CreateLevelsMenuController()
    {
      return new LevelsMenuControllerConsole();
    }

    /// <summary>
    /// Создание контроллера меню рейтинга
    /// </summary>
    public override RatingMenuController CreateRatingMenuController()
    {
      return new RatingMenuControllerConsole();
    }

    /// <summary>
    /// Создание контроллера меню правил
    /// </summary>
    public override RulesMenuController CreateRulesMenuController()
    {
      return new RulesMenuControllerConsole();
    }

    /// <summary>
    /// Создание представления главного меню
    /// </summary>
    public override ViewMainMenu CreateViewMainMenu()
    {
      return new ViewMainMenuConsole(MainMenu);
    }

    /// <summary>
    /// Обработка нажатий клавиш в главном меню
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.UpArrow:
            MainMenu.FocusPrevious(); 
            break;
          case ConsoleKey.DownArrow:
            MainMenu.FocusNext(); 
            break;
          case ConsoleKey.Enter:
            MainMenu.SelectFocusedItem(); 
            break;
        }
      }
    }
  }
}
