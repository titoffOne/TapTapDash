using CommonResources;
using Model.Geometry;
using View.Game;
using View.Game.Levels;
using ViewConsole.Game.Level;

namespace ViewConsole.Game
{
  /// <summary>
  /// Класс для отображения игры в консольном приложении
  /// </summary>
  public class ViewGameConsole : ViewGame
  {
    // Ширина и высота игрового экрана
    private const int GAME_WIDHT = Properties.CONSOLE_APPLICATION_WIDTH;
    private const int GAME_HEIGHT = Properties.CONSOLE_APPLICATION_HEIGHT + 8;

    // Начальная позиция, размер и вращение ячейки
    private static Position<int> InitialTilePostionWPF { get; } = new(28, 18);
    private static Size<int> InitialTileSizeWPF { get; } = new(6, 6);
    private static Rotation<int> InitialTileRotationWPF { get; } = new(0);

    // Начальная позиция, размер и вращение кота
    private static Position<int> InitialCatPostionWPF { get; } = new(30, 20);
    private static Size<int> InitialCatSizeWPF { get; } = new(2, 2);
    private static Rotation<int> InitialCatRotationWPF { get; } = new(0);

    /// <summary>
    /// Конструктор для инициализации игры в консольном представлении
    /// </summary>
    public ViewGameConsole(Model.Game.Game parGame) : base(parGame)
    {
    }

    /// <summary>
    /// Отобразить состояние игры на экране
    /// </summary>
    public override void Draw()
    {
      ConsoleWriter.SetSize(GAME_WIDHT, GAME_HEIGHT);
      ConsoleWriter.SetFont(Properties.CONSOLE_APPLICATION_FONT, 15, 15);
      Console.CursorVisible = false;

      base.Draw();
      DrawScoreInfo();
      if (!Game.IsActive)
        DrawSettingsInfo();
      ConsoleWriter.Print();
    }

    /// <summary>
    /// Отобразить информацию о текущем счете
    /// </summary>
    private void DrawScoreInfo()
    {
      if (Game.Cat.CoinsCollected < 10)
      {
        Rectangle<int> emptyRect = new(30, 2, 1, 1, 0);
        ConsoleWriter.Frame.Fill(emptyRect, ' ', Colors.Black, Colors.Black);
        ConsoleWriter.Frame.Write(31, 2, Game.Cat.CoinsCollected.ToString());
      }
      else
      {
        ConsoleWriter.Frame.Write(30, 2, Game.Cat.CoinsCollected.ToString());
      }
    }

    /// <summary>
    /// Отобразить информацию для начала игры
    /// </summary>
    private void DrawSettingsInfo()
    {
      ConsoleWriter.Frame.Write(19, 32, "Для старта нажмите ENTER");
    }

    /// <summary>
    /// Создать объект отображения кота
    /// </summary>
    public override ViewCat CreateViewCat()
    {
      return new ViewCatConsole(Game.Cat, new(InitialCatPostionWPF),
        new(InitialCatSizeWPF), new(InitialCatRotationWPF));
    }

    /// <summary>
    /// Создать объект отображения уровня
    /// </summary>
    public override ViewLevel CreateViewLevel()
    {
      return new ViewLevelConsole(Game.Level, new(InitialTilePostionWPF),
        new(InitialTileSizeWPF), new(InitialTileRotationWPF));
    }
  }
}
