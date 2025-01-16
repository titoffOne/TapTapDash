using CommonResources;
using Model.Game.Records;
using Model.Menu.Pages;
using System.Windows;
using System.Windows.Controls;
using View.Menu;
using View.Menu.Pages;

namespace ViewWPF.Menu.Pages
{
  /// <summary>
  /// Представление меню с рейтингом в WPF
  /// </summary>
  public class ViewRatingMenuWPF : ViewRatingMenu
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
    /// Конструктор для инициализации меню с рейтингом
    /// </summary>
    /// <param name="parMenu">Модель меню с рейтингом</param>
    public ViewRatingMenuWPF(RatingMenu parMenu) : base(parMenu)
    {
      MainWindow.Instance.SetSize(Properties.WPF_APPLICATION_WIDTH, Properties.WPF_APPLICATION_HEIGHT);
      MainWindow.Instance.Clear();

      Grid.Width = MainWindow.Instance.Canvas.Width;
      Grid.Height = MainWindow.Instance.Canvas.Height;

      AddTitle();
      AddRecords();
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
    /// Добавить записи с рейтингом
    /// </summary>
    private void AddRecords()
    {
      Grid recordsGrid = new()
      {
        Margin = new Thickness(0, 10, 0, 10),
        HorizontalAlignment = HorizontalAlignment.Center
      };

      // Добавление колонок
      recordsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) }); // Имя игрока
      recordsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) }); // Очки

      // Добавление строки для заголовка
      recordsGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

      TextBlock player = AddRatingTextBlock("Игрок");
      TextBlock score = AddRatingTextBlock("Очки");
      Grid.SetRow(player, 0);
      Grid.SetColumn(player, 0);
      recordsGrid.Children.Add(player);
      Grid.SetRow(score, 0);
      Grid.SetColumn(score, 1);
      recordsGrid.Children.Add(score);

      int row = 1;
      foreach (var item in Rating.ListRecord)
      {
        // Создание строки для записи
        recordsGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        TextBlock playerName = AddRatingTextBlock(item.PlayerName);
        TextBlock playerScore = AddRatingTextBlock(item.TotalScore.ToString());
        if (item.PlayerName.Equals(Rating.CurrentPlayer.PlayerName))
        {
          playerName.Foreground = Properties.WPF_COLOR_BUTTON_BG_FOCUSED;
          playerScore.Foreground = Properties.WPF_COLOR_BUTTON_BG_FOCUSED;
        }

        // Имя игрока
        Grid.SetRow(playerName, row);
        Grid.SetColumn(playerName, 0);
        recordsGrid.Children.Add(playerName);

        // Очки игрока
        Grid.SetRow(playerScore, row);
        Grid.SetColumn(playerScore, 1);
        recordsGrid.Children.Add(playerScore);

        row++;
      }

      StackPanel.Children.Insert(1, recordsGrid);
    }

    /// <summary>
    /// Создание текстового блока для записи рейтинга
    /// </summary>
    /// <param name="parText">Текст для отображения</param>
    /// <returns>Текстовый блок</returns>
    private TextBlock AddRatingTextBlock(string parText)
    {
      return new()
      {
        Text = parText,
        FontSize = 30,
        FontFamily = Properties.WPF_APPLICATION_FONT,
        Foreground = Properties.WPF_COLOR_TEXT_HEADING,
        VerticalAlignment = VerticalAlignment.Center,
        HorizontalAlignment = HorizontalAlignment.Left
      };
    }

    /// <summary>
    /// Отображение меню с рейтингом
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
