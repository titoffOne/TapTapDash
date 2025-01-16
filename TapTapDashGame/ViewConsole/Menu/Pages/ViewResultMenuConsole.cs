using CommonResources;
using Model.Game.Records;
using Model.Menu.Pages;
using View.Menu;
using View.Menu.Pages;

namespace ViewConsole.Menu.Pages
{
  /// <summary>
  /// Представление меню результатов в консоли
  /// </summary>
  public class ViewResultMenuConsole : ViewResultMenu
  {
    /// <summary>
    /// Конструктор представления меню результатов
    /// </summary>
    /// <param name="parMenu">Меню результатов</param>
    public ViewResultMenuConsole(ResultMenu parMenu) : base(parMenu)
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
        y += 2;
        item.Rectangle.Position.Y = y;
      }
    }

    /// <summary>
    /// Отрисовка заголовка меню
    /// </summary>
    private void DrawTitle()
    {
      int x = Console.WindowWidth / 2 - Menu.Title.Length / 2;
      int y = Rectangle.Position.Y - 6;

      ConsoleWriter.Frame.Write(x, y, Menu.Title, Colors.Red);
    }

    /// <summary>
    /// Отрисовка информации о набранных очках
    /// </summary>
    private void DrawScoreInformation()
    {
      int x = Console.WindowWidth / 2 - Menu.Title.Length / 2;
      int y = Rectangle.Position.Y - 2;

      string scoreInfo = TextConstants.MenuResultItemScore + Rating.CurrentPlayer.CurrentScore.ToString();
      ConsoleWriter.Frame.Write(x, y, scoreInfo, Colors.White);
    }

    /// <summary>
    /// Отрисовка меню результатов
    /// </summary>
    public override void Draw()
    {
      ConsoleWriter.SetSize(Properties.CONSOLE_APPLICATION_WIDTH,
        Properties.CONSOLE_APPLICATION_HEIGHT);
      DrawTitle();
      DrawScoreInformation();
      base.Draw();
      ConsoleWriter.Print();
    }

    /// <summary>
    /// Создание представления элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    /// <returns>Представление элемента меню</returns>
    public override ViewMenuItem CreateItem(Model.Menu.MenuItem parItem)
    {
      return new ViewMenuItemConsole(parItem);
    }
  }
}
