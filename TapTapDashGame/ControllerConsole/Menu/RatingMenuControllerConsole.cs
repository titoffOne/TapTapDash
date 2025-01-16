using Controller.Menu;
using Model.Menu.Pages;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер меню рейтинга для консольного приложения
  /// </summary>
  public class RatingMenuControllerConsole : RatingMenuController
  {
    /// <summary>
    /// Создание представления меню рейтинга
    /// </summary>
    public override ViewRatingMenu CreateViewRatingMenu()
    {
      return new ViewRatingMenuConsole(RatingMenu);
    }

    /// <summary>
    /// Обработка нажатий клавиш в меню рейтинга
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.UpArrow:
            RatingMenu.FocusPrevious(); 
            break;
          case ConsoleKey.DownArrow:
            RatingMenu.FocusNext(); 
            break;
          case ConsoleKey.Enter:
            RatingMenu.SelectFocusedItem(); 
            break;
        }
      }
    }
  }
}
