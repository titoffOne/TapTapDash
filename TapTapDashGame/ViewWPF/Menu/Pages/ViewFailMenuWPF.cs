using CommonResources;
using Model.Menu.Pages;
using System.Windows;
using System.Windows.Controls;
using View.Menu;
using View.Menu.Pages;

namespace ViewWPF.Menu.Pages
{
  /// <summary>
  /// WPF-представление меню проигрыша
  /// </summary>
  public class ViewFailMenuWPF : ViewFailMenu
  {
    /// <summary>
    /// Компоновщик
    /// </summary>
    private Grid Grid { get; set; } = new();

    /// <summary>
    /// Компоновщик для размещения элементов меню
    /// </summary>
    private StackPanel StackPanel { get; set; } = new()
    {
      Orientation = Orientation.Vertical,
      VerticalAlignment = VerticalAlignment.Center,
      HorizontalAlignment = HorizontalAlignment.Center,
    };

    /// <summary>
    /// Конструктор для создания представления меню ошибки
    /// </summary>
    /// <param name="parMenu">Меню ошибок</param>
    public ViewFailMenuWPF(FailMenu parMenu) : base(parMenu)
    {
      MainWindow.Instance.SetSize(Properties.WPF_APPLICATION_WIDTH, Properties.WPF_APPLICATION_HEIGHT);
      MainWindow.Instance.Clear();

      Grid.Width = MainWindow.Instance.Canvas.Width;
      Grid.Height = MainWindow.Instance.Canvas.Height;

      AddTitle();
    }

    /// <summary>
    /// Добавление заголовка на экран
    /// </summary>
    private void AddTitle()
    {
      TextBlock title = new()
      {
        Text = Menu.Title,
        FontSize = 40,
        FontFamily = Properties.WPF_APPLICATION_FONT,
        Foreground = Properties.WPF_COLOR_TEXT_HEADING,
        Margin = new(0, 20, 0, 20),
        HorizontalAlignment = HorizontalAlignment.Center,
        TextAlignment = TextAlignment.Center
      };

      StackPanel.Children.Insert(0, title);
    }

    /// <summary>
    /// Отображение меню
    /// </summary>
    public override void Draw()
    {
      MainWindow.Instance.SetSize(Properties.WPF_APPLICATION_WIDTH, Properties.WPF_APPLICATION_HEIGHT);
      MainWindow.Instance.Clear();
      Grid.Children.Clear();
      MainWindow.Instance.Canvas.Children.Add(Grid);
      Grid.Children.Add(StackPanel);
      base.Draw();
    }

    /// <summary>
    /// Создание пункта меню
    /// </summary>
    /// <param name="parItem">Пункт меню</param>
    /// <returns>Представление пункта меню</returns>
    public override ViewMenuItem CreateItem(Model.Menu.MenuItem parItem)
    {
      ViewMenuItemWPF menuItem = new(parItem);
      StackPanel.Children.Add(menuItem.Border);
      return menuItem;
    }
  }
}
