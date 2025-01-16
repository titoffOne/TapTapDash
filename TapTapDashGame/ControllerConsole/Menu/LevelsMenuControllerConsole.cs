using Controller.Game;
using Controller.Menu;
using ControllerConsole.Game;
using Model.Menu.Pages;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер меню уровней для консольного приложения
  /// </summary>
  public class LevelsMenuControllerConsole : LevelsMenuController
  {
    /// <summary>
    /// Создание представления меню уровней
    /// </summary>
    public override ViewLevelsMenu CreateLevelsMenu()
    {
      return new ViewLevelsMenuConsole(LevelsMenu);
    }

    /// <summary>
    /// Обработка нажатий клавиш в меню уровней
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.UpArrow:
            LevelsMenu.FocusPrevious(); 
            break;
          case ConsoleKey.DownArrow:
            LevelsMenu.FocusNext(); 
            break;
          case ConsoleKey.Enter:
            LevelsMenu.SelectFocusedItem(); 
            break;
        }
      }
    }

    /// <summary>
    /// Создание контроллера игры для указанной карты
    /// </summary>
    protected override GameController CreateGameController(string parPathToMap)
    {
      return new GameControllerConsole(parPathToMap);
    }
  }
}
