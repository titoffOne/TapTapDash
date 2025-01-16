using CommonResources;
using Model.Menu;
using Model.Menu.Pages;
using View.Menu;
using View.Menu.Pages;

namespace ViewConsole.Menu.Pages
{
  /// <summary>
  /// Представление меню правил в консоли
  /// </summary>
  public class ViewRulesMenuConsole : ViewRulesMenu
  {
    /// <summary>
    /// Конструктор представления меню правил
    /// </summary>
    /// <param name="parMenu">Меню правил</param>
    public ViewRulesMenuConsole(RulesMenu parMenu) : base(parMenu)
    {
      InitItems();
    }

    /// <summary>
    /// Инициализация элементов меню
    /// </summary>
    private void InitItems()
    {
      ConsoleWriter.SetSize(Properties.CONSOLE_APPLICATION_WIDTH, Properties.CONSOLE_APPLICATION_HEIGHT);
      ConsoleWriter.SetFont(Properties.CONSOLE_APPLICATION_FONT, 14, 20);
      Console.CursorVisible = false;

      int maxLength = 1;
      foreach (ViewMenuItem item in Items)
      {
        maxLength = Math.Max(maxLength, item.Item.Name.Length);
      }

      Rectangle.Position.X = Console.WindowWidth / 2 - maxLength / 2;
      Rectangle.Position.Y = Console.WindowHeight / 2 - Items.Count;

      Items[0].Rectangle.Position.X = Rectangle.Position.X;
      Items[0].Rectangle.Position.Y = Rectangle.Position.Y + 12;
    }

    /// <summary>
    /// Отрисовка заголовка меню
    /// </summary>
    private void DrawTitle()
    {
      int x = Console.WindowWidth / 2 - Menu.Title.Length / 2;
      int y = Rectangle.Position.Y - 10;

      ConsoleWriter.Frame.Write(x, y, Menu.Title, Colors.Red);
    }

    /// <summary>
    /// Отрисовка описания правил
    /// </summary>
    public void DrawRules()
    {
      var text = RulesMenu.ReadDescriptionFromFile(TextConstants.MenuRulesItemDescriptionFilePath);

      int x = 10;
      int y = 8;

      foreach (var str in text)
      {
        ConsoleWriter.Frame.Write(x, y++, str);
      }
    }

    /// <summary>
    /// Отрисовка меню правил
    /// </summary>
    public override void Draw()
    {
      ConsoleWriter.SetSize(Properties.CONSOLE_APPLICATION_WIDTH,
        Properties.CONSOLE_APPLICATION_HEIGHT);
      DrawTitle();
      DrawRules();
      base.Draw();
      ConsoleWriter.Print();
    }

    /// <summary>
    /// Создание представления элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    /// <returns>Представление элемента меню</returns>
    public override ViewMenuItem CreateItem(MenuItem parItem)
    {
      return new ViewMenuItemConsole(parItem);
    }
  }
}
