using Model.Game.Levels;
using Model.Geometry;
using View.Game.Levels;

namespace ViewWPF.Game.Levels
{
  /// <summary>
  /// WPF представление шага уровня
  /// </summary>
  public class ViewStepWPF : ViewStep, IAddChildren
  {
    /// <summary>
    /// Конструктор WPF представления шага
    /// </summary>
    /// <param name="parStep">Шаг игрового уровня</param>
    /// <param name="parTileRectangle">Размер и позиция ячеек</param>
    public ViewStepWPF(Step parStep, Rectangle<int> parTileRectangle) : base(parStep, parTileRectangle)
    {
    }

    /// <summary>
    /// Добавление всех ячеек шага в контейнер
    /// </summary>
    public void AddChildren()
    {
      foreach (var viewTile in ViewTiles)
      {
        // Добавление каждого элемента в контейнер
        ((IAddChildren)viewTile).AddChildren();
      }
    }

    /// <summary>
    /// Создание представления ячейки для шага
    /// </summary>
    /// <param name="parTile">Ячейка игрового уровня</param>
    /// <param name="parRectangle">Размер и позиция ячейки</param>
    /// <returns>Представление ячейки</returns>
    public override ViewTile CreateViewTile(Tile parTile, Rectangle<int> parRectangle)
    {
      return new ViewTileWPF(parTile, parRectangle);
    }
  }
}
