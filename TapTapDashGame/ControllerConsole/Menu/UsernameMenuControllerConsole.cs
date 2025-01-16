using Controller.Menu;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер меню ввода имени пользователя для консольного приложения
  /// </summary>
  public class UsernameMenuControllerConsole : UsernameMenuController
  {
    /// <summary>
    /// Создание главного меню
    /// </summary>
    public override MainMenuController CreateMainMenuController()
    {
      return new MainMenuControllerConsole();
    }

    /// <summary>
    /// Создать представление меню ввода имени пользователя
    /// </summary>
    public override ViewUsernameMenu CreateViewUsernameMenu()
    {
      return new ViewUsernameMenuConsole(UsernameMenu);
    }

    /// <summary>
    /// Обработать нажатия клавиш
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Backspace)
        {
          UsernameMenu.RemoveLastSymbol();
        }
        else
        {
          if (char.IsLetter(key.KeyChar) || char.IsDigit(key.KeyChar))
          {
            UsernameMenu.AddSymbol(char.ToUpper(key.KeyChar));
          }
        }

        switch (key.Key)
        {
          case ConsoleKey.UpArrow:
            UsernameMenu.FocusPrevious();
            break;
          case ConsoleKey.DownArrow:
            UsernameMenu.FocusNext();
            break;
          case ConsoleKey.Enter:
            UsernameMenu.SelectFocusedItem();
            break;
        }
      }
    }
  }
}
