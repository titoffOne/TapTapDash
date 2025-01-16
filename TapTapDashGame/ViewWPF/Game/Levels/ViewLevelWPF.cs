using Model.Game.Levels;
using Model.Geometry;
using View.Game.Levels;

namespace ViewWPF.Game.Levels
{
  /// <summary>
  /// WPF представление уровня
  /// </summary>
  public class ViewLevelWPF : ViewLevel, IAddChildren
  {
    /// <summary>
    /// Конструктор WPF представления уровня
    /// </summary>
    /// <param name="parLevel">Уровень игры</param>
    /// <param name="parTilePosition">Позиция ячеек уровня</param>
    /// <param name="parTileSize">Размер ячеек уровня</param>
    /// <param name="parTileRotation">Вращение ячеек уровня</param>
    public ViewLevelWPF(Level parLevel, Position<int> parTilePosition, Size<int> parTileSize, Rotation<int> parTileRotation)
      : base(parLevel, parTilePosition, parTileSize, parTileRotation)
    {
    }

    /// <summary>
    /// Добавление всех шагов уровня в контейнер
    /// </summary>
    public void AddChildren()
    {
      foreach (var viewStep in ViewSteps)
      {
        // Добавление каждого шага в контейнер
        ((IAddChildren)viewStep).AddChildren();
      }
    }

    /// <summary>
    /// Создание представления шага для уровня
    /// </summary>
    /// <param name="parStep">Шаг уровня</param>
    /// <param name="parRectangle">Размер и позиция ячеек шага</param>
    /// <returns>Представление шага уровня</returns>
    public override ViewStep CreateViewStep(Step parStep, Rectangle<int> parRectangle)
    {
      return new ViewStepWPF(parStep, parRectangle);
    }
  }
}
