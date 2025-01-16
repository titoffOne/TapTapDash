using CommonResources;
using Model.Menu.Pages;
using System.Windows;
using System.Windows.Controls;
using View.Menu;
using View.Menu.Pages;

namespace ViewWPF.Menu.Pages
{
  /// <summary>
  /// Представление меню для ввода имени пользователя в WPF
  /// </summary>
  public class ViewUsernameMenuWPF : ViewUsernameMenu
  {
    /// <summary>
    /// Компоновщик для размещения элементов в меню
    /// </summary>
    private Grid Grid { get; set; } = new();

    /// <summary>
    /// Стэк панель для вертикального размещения элементов
    /// </summary>
    private StackPanel StackPanel { get; set; } = new()
    {
      Orientation = Orientation.Vertical,
      VerticalAlignment = VerticalAlignment.Center,
      HorizontalAlignment = HorizontalAlignment.Center,
    };

    /// <summary>
    /// Конструктор для инициализации меню ввода имени пользователя
    /// </summary>
    /// <param name="parMenu">Модель меню для ввода имени пользователя</param>
    public ViewUsernameMenuWPF(UsernameMenu parMenu) : base(parMenu)
    {
      MainWindow.Instance.SetSize(Properties.WPF_APPLICATION_WIDTH, Properties.WPF_APPLICATION_HEIGHT);
      MainWindow.Instance.Clear();

      Grid.Width = MainWindow.Instance.Canvas.Width;
      Grid.Height = MainWindow.Instance.Canvas.Height;

      MainWindow.Instance.Title = Menu.Title;

      AddTitle();
      AddInputHeading();
    }

    /// <summary>
    /// Добавить заголовок в меню
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
    /// Добавить заголовок для ввода имени пользователя
    /// </summary>
    private void AddInputHeading()
    {
      TextBlock heading = new()
      {
        Text = TextConstants.MenuUsernameItemHeading,
        FontSize = 30,
        FontFamily = Properties.WPF_APPLICATION_FONT,
        Foreground = Properties.WPF_COLOR_TEXT_HEADING,
        Margin = new(0, 20, 0, 20),
        HorizontalAlignment = HorizontalAlignment.Left,
        TextAlignment = TextAlignment.Center
      };

      StackPanel.Children.Insert(1, heading);
    }

    /// <summary>
    /// Отображение меню ввода имени пользователя
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
    /// Создание элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    /// <returns>Представление элемента меню</returns>
    public override ViewMenuItem CreateItem(Model.Menu.MenuItem parItem)
    {
      ViewMenuItemWPF menuItem = new(parItem);
      StackPanel.Children.Add(menuItem.Border);
      return menuItem;
    }
  }
}
