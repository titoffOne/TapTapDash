using Model.Geometry;
using Model.Menu;

namespace View.Menu
{
  /// <summary>
  /// Представление элемента меню
  /// </summary>
  public abstract class ViewMenuItem : ViewBase
  {
    /// <summary>
    /// Элемент меню
    /// </summary>
    public MenuItem Item { get; protected set; }

    /// <summary>
    /// Прямоугольник
    /// </summary>
    public Rectangle<int> Rectangle { get; set; } = new Rectangle<int>(0, 0, 0, 0, 0);

    /// <summary>
    /// Позиция
    /// </summary>
    public Position<int> Position { get; set; } = new(0, 0);

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    public ViewMenuItem(MenuItem parItem)
    {
      Item = parItem;
    }
  }
}
