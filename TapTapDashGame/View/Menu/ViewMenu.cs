using Model.Geometry;
using Model.Menu;

namespace View.Menu
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public abstract class ViewMenu : ViewBase
  {
    /// <summary>
    /// Модель меню
    /// </summary>
    public Model.Menu.Menu Menu { get; set; }

    /// <summary>
    /// Список элементов меню
    /// </summary>
    public List<ViewMenuItem> Items { get; private set; } = new List<ViewMenuItem>();

    /// <summary>
    /// Прямоугольник
    /// </summary>
    public Rectangle<int> Rectangle { get; set; } = new(0, 0, 0, 0, 0);

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Модель меню</param>
    public ViewMenu(Model.Menu.Menu parMenu)
    {
      Menu = parMenu;

      foreach (var item in parMenu.Items)
      {
        Items.Add(CreateItem(item));
      }

      Menu.NeedRedraw += Draw;
    }

    /// <summary>
    /// Рисовать
    /// </summary>
    public override void Draw()
    {
      foreach (var item in Items)
      {
        item.Draw();
      }
    }

    /// <summary>
    /// Создание представления элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    /// <returns>Представление элемента меню</returns>
    public abstract ViewMenuItem CreateItem(MenuItem parItem);
  }
}
