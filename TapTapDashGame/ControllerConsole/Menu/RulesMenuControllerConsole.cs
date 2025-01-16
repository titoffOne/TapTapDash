using Controller.Menu;
using Model.Menu.Pages;
using View.Menu.Pages;
using ViewConsole.Menu.Pages;

namespace ControllerConsole.Menu
{
  /// <summary>
  /// Контроллер меню правил для консольного приложения
  /// </summary>
  public class RulesMenuControllerConsole : RulesMenuController
  {
    /// <summary>
    /// Создание представления меню правил
    /// </summary>
    public override ViewRulesMenu CreateViewRulesMenu()
    {
      return new ViewRulesMenuConsole(RulesMenu);
    }

    /// <summary>
    /// Обработка нажатий клавиш в меню правил
    /// </summary>
    public override void HandleKey()
    {
      while (IsActive)
      {
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.UpArrow:
            RulesMenu.FocusPrevious(); 
            break;
          case ConsoleKey.DownArrow:
            RulesMenu.FocusNext(); 
            break;
          case ConsoleKey.Enter:
            RulesMenu.SelectFocusedItem(); 
            break;
        }
      }
    }
  }
}
