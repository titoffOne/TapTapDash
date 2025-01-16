using CommonResources;
using Model.Geometry;
using System.Windows;
using System.Windows.Controls;
using View.Game;
using View.Game.Levels;
using ViewWPF.Game.Levels;

namespace ViewWPF.Game
{
  /// <summary>
  /// WPF представление игры
  /// </summary>
  public class ViewGameWPF : ViewGame, IAddChildren
  {
    /// <summary>
    /// Начальная позиция первой ячейки
    /// </summary>
    private static Position<int> InitialTilePostionWPF { get; } = new(315, 315);

    /// <summary>
    /// Начальный размер первой ячейки
    /// </summary>
    private static Size<int> InitialTileSizeWPF { get; } = new(70, 70);

    /// <summary>
    /// Начальный поворот первой ячейки
    /// </summary>
    private static Rotation<int> InitialTileRotationWPF { get; } = new(0);

    /// <summary>
    /// Начальная позиция кота
    /// </summary>
    private static Position<int> InitialCatPostionWPF { get; } = new(330, 330);

    /// <summary>
    /// Начальный размер кота
    /// </summary>
    private static Size<int> InitialCatSizeWPF { get; } = new(40, 40);

    /// <summary>
    /// Начальный поворот кота
    /// </summary>
    private static Rotation<int> InitialCatRotationWPF { get; } = new(0);

    /// <summary>
    /// Игровые очки
    /// </summary>
    private TextBlock ScoreInfo { get; set; } = new()
    {
      Foreground = Properties.WPF_COLOR_TEXT_HEADING,
      FontSize = 40,
      FontFamily = Properties.WPF_APPLICATION_FONT,
      Text = "0",
    };

    /// <summary>
    /// Информация о настройках и старте игры
    /// </summary>
    private TextBlock SettingsInfo { get; set; } = new()
    {
      Foreground = Properties.WPF_COLOR_TEXT_HEADING,
      FontSize = 40,
      FontFamily = Properties.WPF_APPLICATION_FONT,
      Text = "ДЛЯ СТАРТА НАЖМИТЕ ENTER",
    };

    /// <summary>
    /// Конструктор ViewGameWPF
    /// </summary>
    /// <param name="parGame">Игровой объект</param>
    public ViewGameWPF(Model.Game.Game parGame) : base(parGame)
    {
    }

    /// <summary>
    /// Добавление элементов на экран
    /// </summary>
    public void AddChildren()
    {
      ((IAddChildren)ViewLevel).AddChildren();
      ((IAddChildren)ViewCat).AddChildren();

      MainWindow.Instance.Canvas.Children.Add(ScoreInfo);
      Canvas.SetLeft(SettingsInfo, 170);
      Canvas.SetTop(SettingsInfo, 500);
      MainWindow.Instance.Canvas.Children.Add(SettingsInfo);
    }

    /// <summary>
    /// Отображение игры
    /// </summary>
    public override void Draw()
    {
      Application.Current.Dispatcher.Invoke(() =>
      {
        base.Draw();
        DrawScoreInfo();

        if (Game.IsActive)
          SettingsInfo.Text = string.Empty;
      });
    }

    /// <summary>
    /// Отображение информации о очках
    /// </summary>
    private void DrawScoreInfo()
    {
      ScoreInfo.Text = Game.Cat.CoinsCollected.ToString();
      Canvas.SetLeft(ScoreInfo, 340);
      Canvas.SetTop(ScoreInfo, 10);
    }

    /// <summary>
    /// Создание представления кота
    /// </summary>
    /// <returns>Представление кота</returns>
    public override ViewCat CreateViewCat()
    {
      return new ViewCatWPF(Game.Cat, new(InitialCatPostionWPF), new(InitialCatSizeWPF), new(InitialCatRotationWPF));
    }

    /// <summary>
    /// Создание представления уровня
    /// </summary>
    /// <returns>Представление уровня</returns>
    public override ViewLevel CreateViewLevel()
    {
      return new ViewLevelWPF(Game.Level, new(InitialTilePostionWPF), new(InitialTileSizeWPF), new(InitialTileRotationWPF));
    }
  }
}
