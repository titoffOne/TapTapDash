using Model.Game.Levels;
using Model.Geometry;
using View.Game.Levels;

namespace ViewConsole.Game.Level
{
  /// <summary>
  /// Представление шагов уровня в консольном приложении
  /// </summary>
  public class ViewStepConsole : ViewStep
  {
    /// <summary>
    /// Конструктор для инициализации шага и прямоугольника
    /// </summary>
    public ViewStepConsole(Step parStep, Rectangle<int> parTileRectangle) : base(parStep, parTileRectangle)
    {
    }

    /// <summary>
    /// Создать представление ячейки для консольного отображения
    /// </summary>
    public override ViewTile CreateViewTile(Tile parTile, Rectangle<int> parRectangle)
    {
      return new ViewTileConsole(parTile, parRectangle);
    }
  }
}
