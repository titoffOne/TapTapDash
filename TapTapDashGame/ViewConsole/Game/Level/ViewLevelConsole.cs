using Model.Game.Levels;
using Model.Geometry;
using View.Game.Levels;

namespace ViewConsole.Game.Level
{
  /// <summary>
  /// Представление уровня в консольном приложении
  /// </summary>
  public class ViewLevelConsole : ViewLevel
  {
    /// <summary>
    /// Конструктор для инициализации уровня, позиции, размера и вращения ячейки
    /// </summary>
    public ViewLevelConsole(Model.Game.Levels.Level parLevel,
      Position<int> parTilePosition, Size<int> parTileSize, Rotation<int> parTileRotation) : base(parLevel, parTilePosition, parTileSize, parTileRotation)
    {
    }

    /// <summary>
    /// Создать представление шага для консольного отображения
    /// </summary>
    public override ViewStep CreateViewStep(Step parStep, Rectangle<int> parRectangle)
    {
      return new ViewStepConsole(parStep, parRectangle);
    }
  }
}
