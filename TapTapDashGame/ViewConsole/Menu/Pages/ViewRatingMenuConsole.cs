using CommonResources;
using Model.Game.Records;
using Model.Menu;
using Model.Menu.Pages;
using View.Menu;
using View.Menu.Pages;

namespace ViewConsole.Menu.Pages
{
  /// <summary>
  /// Представление меню рейтинга в консоли
  /// </summary>
  public class ViewRatingMenuConsole : ViewRatingMenu
  {
    /// <summary>
    /// Конструктор представления меню рейтинга
    /// </summary>
    /// <param name="parMenu">Меню рейтинга</param>
    public ViewRatingMenuConsole(RatingMenu parMenu) : base(parMenu)
    {
      InitItems();
    }

    /// <summary>
    /// Инициализация элементов меню рейтинга
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
    /// Отрисовка заголовка меню рейтинга
    /// </summary>
    private void DrawTitle()
    {
      int x = Console.WindowWidth / 2 - Menu.Title.Length / 2;
      int y = Rectangle.Position.Y - 10;

      ConsoleWriter.Frame.Write(x, y, Menu.Title, Colors.Red);
    }

    /// <summary>
    /// Отрисовка списка рекордов
    /// </summary>
    public void DrawRecords()
    {
      var records = Rating.ListRecord;

      int x = 14;
      int y = 10;

      ConsoleWriter.Frame.Write(x, y++, string.Format("{0,-20} {1,-10}", "Имя игрока", "Очки"));
      y++;

      foreach (var item in records)
      {
        

        if (item.PlayerName.Equals(Rating.CurrentPlayer.PlayerName))
        {
          ConsoleWriter.Frame.Write(x, y++, string.Format("{0,-20} {1,-10}", item.PlayerName, item.TotalScore), Colors.Green);
        }
        else
        {
          ConsoleWriter.Frame.Write(x, y++, string.Format("{0,-20} {1,-10}", item.PlayerName, item.TotalScore));
        }
      }
    }

    /// <summary>
    /// Отрисовка меню рейтинга
    /// </summary>
    public override void Draw()
    {
      ConsoleWriter.SetSize(Properties.CONSOLE_APPLICATION_WIDTH,
        Properties.CONSOLE_APPLICATION_HEIGHT);
      DrawTitle();
      DrawRecords();
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
