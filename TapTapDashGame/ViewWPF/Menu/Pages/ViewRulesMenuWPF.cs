using CommonResources;
using Model.Menu.Pages;
using System.Windows;
using System.Windows.Controls;
using View.Menu;
using View.Menu.Pages;

namespace ViewWPF.Menu.Pages
{
  /// <summary>
  /// Представление меню правил игры в WPF
  /// </summary>
  public class ViewRulesMenuWPF : ViewRulesMenu
  {
    /// <summary>
    /// Компоновщик для меню
    /// </summary>
    private Grid Grid { get; set; } = new();

    /// <summary>
    /// Панель для размещения элементов меню
    /// </summary>
    private StackPanel StackPanel { get; set; } = new()
    {
      Orientation = Orientation.Vertical,
      VerticalAlignment = VerticalAlignment.Center,
      HorizontalAlignment = HorizontalAlignment.Center,
    };

    /// <summary>
    /// Конструктор для инициализации меню с правилами игры
    /// </summary>
    /// <param name="parMenu">Модель меню с правилами игры</param>
    public ViewRulesMenuWPF(RulesMenu parMenu) : base(parMenu)
    {
      MainWindow.Instance.SetSize(Properties.WPF_APPLICATION_WIDTH, Properties.WPF_APPLICATION_HEIGHT);
      MainWindow.Instance.Clear();

      Grid.Width = MainWindow.Instance.Canvas.Width;
      Grid.Height = MainWindow.Instance.Canvas.Height;

      AddTitle();
      AddDescription();
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
    /// Добавить описание правил
    /// </summary>
    private void AddDescription()
    {
      TextBlock description = new()
      {
        Text = string.Join(Environment.NewLine, RulesMenu.ReadDescriptionFromFile(TextConstants.MenuRulesItemDescriptionFilePath)),
        FontSize = 20,
        FontFamily = Properties.WPF_APPLICATION_FONT,
        Foreground = Properties.WPF_COLOR_TEXT_DESCRIPTION,
        Margin = new(0, 20, 0, 20)
      };

      StackPanel.Children.Insert(1, description);
    }

    /// <summary>
    /// Отображение меню с правилами игры
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
