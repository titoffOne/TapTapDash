using CommonResources;
using Model.Menu;
using Model.Menu.Pages;
using View.Menu;
using View.Menu.Pages;

namespace ViewConsole.Menu.Pages
{
  /// <summary>
  /// Представление меню уровней в консоли
  /// </summary>
  public class ViewLevelsMenuConsole : ViewLevelsMenu
  {
    /// <summary>
    /// Конструктор представления меню уровней
    /// </summary>
    /// <param name="parMenu">Меню уровней</param>
    public ViewLevelsMenuConsole(LevelsMenu parMenu) : base(parMenu)
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

      int y = Rectangle.Position.Y;
      foreach (ViewMenuItem item in Items)
      {
        item.Rectangle.Position.X = Rectangle.Position.X;
        y = y + 2;
        item.Rectangle.Position.Y = y;
      }
    }

    /// <summary>
    /// Отрисовка заголовка меню
    /// </summary>
    private void DrawTitle()
    {
      int x = Console.WindowWidth / 2 - Menu.Title.Length / 2;
      int y = Rectangle.Position.Y - 2;

      ConsoleWriter.Frame.Write(x, y, Menu.Title, Colors.Red);
    }

    /// <summary>
    /// Отрисовка страницы меню уровней
    /// </summary>
    public override void Draw()
    {
      ConsoleWriter.SetSize(Properties.CONSOLE_APPLICATION_WIDTH,
        Properties.CONSOLE_APPLICATION_HEIGHT);
      DrawTitle();
      base.Draw();
      ConsoleWriter.Print();
    }

    /// <summary>
    /// Создание представления для элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    /// <returns>Представление элемента меню</returns>
    public override ViewMenuItem CreateItem(MenuItem parItem)
    {
      return new ViewMenuItemConsole(parItem);
    }
  }
}
