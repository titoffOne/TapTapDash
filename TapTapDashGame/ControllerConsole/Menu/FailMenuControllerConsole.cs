using Controller.Menu;
using Model.Menu.Pages;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер меню проигрыша для консольного приложения
  /// </summary>
  public class FailMenuControllerConsole : FailMenuController
  {
    /// <summary>
    /// Создание контроллера главного меню
    /// </summary>
    public override MainMenuController CreateMainMenuController()
    {
      return new MainMenuControllerConsole();
    }

    /// <summary>
    /// Создание представления меню неудачи
    /// </summary>
    public override ViewFailMenu CreateViewFailMenu()
    {
      return new ViewFailMenuConsole(FailMenu);
    }

    /// <summary>
    /// Обработка нажатий клавиш в меню неудачи
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.UpArrow:
            FailMenu.FocusPrevious(); 
            break;
          case ConsoleKey.DownArrow:
            FailMenu.FocusNext(); 
            break;
          case ConsoleKey.Enter:
            FailMenu.SelectFocusedItem(); 
            break;
        }
      }
    }
  }
}
