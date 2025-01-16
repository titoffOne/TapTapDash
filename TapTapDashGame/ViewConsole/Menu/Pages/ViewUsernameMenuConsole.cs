using CommonResources;
using Model.Menu;
using Model.Menu.Pages;
using View.Menu;
using View.Menu.Pages;

namespace ViewConsole.Menu.Pages
{
  /// <summary>
  /// Представление меню ввода имени пользователя в консоли
  /// </summary>
  public class ViewUsernameMenuConsole : ViewUsernameMenu
  {
    /// <summary>
    /// Конструктор для создания представления меню ввода имени пользователя
    /// </summary>
    /// <param name="parMenu">Меню ввода имени пользователя</param>
    public ViewUsernameMenuConsole(UsernameMenu parMenu) : base(parMenu)
    {
      InitItems();
      DrawTitleAndHead();
    }

    /// <summary>
    /// Инициализация элементов меню
    /// </summary>
    private void InitItems()
    {
      ConsoleWriter.SetSize(Properties.CONSOLE_APPLICATION_WIDTH, Properties.CONSOLE_APPLICATION_HEIGHT);
      ConsoleWriter.SetFont(Properties.CONSOLE_APPLICATION_FONT, 14, 20);
      Console.CursorVisible = false;
      Console.Title = Menu.Title;

      int maxLength = 5;
      Rectangle.Position.X = Console.WindowWidth / 2 - maxLength / 2;
      Rectangle.Position.Y = Console.WindowHeight / 2 - Items.Count;

      Items[0].Rectangle.Position.X = Rectangle.Position.X;
      Items[0].Rectangle.Position.Y = Rectangle.Position.Y + 2;

      Items[1].Rectangle.Position.X = Rectangle.Position.X;
      Items[1].Rectangle.Position.Y = Rectangle.Position.Y + 4;
    }

    /// <summary>
    /// Отрисовка заголовка меню и шапки
    /// </summary>
    private void DrawTitleAndHead()
    {
      int x = Console.WindowWidth / 2 - Menu.Title.Length / 2;
      int y = Rectangle.Position.Y - 4;

      ConsoleWriter.Frame.Write(x + 2, y, Menu.Title, Colors.Red);
      ConsoleWriter.Frame.Write(x, y + 2, TextConstants.MenuUsernameItemHeading, Colors.White);
    }

    /// <summary>
    /// Отрисовка меню
    /// </summary>
    public override void Draw()
    {
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
