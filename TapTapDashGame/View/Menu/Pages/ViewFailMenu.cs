using Model.Menu.Pages;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление меню проигрыша
  /// </summary>
  public abstract class ViewFailMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Меню проигрыша</param>
    public ViewFailMenu(FailMenu parMenu) : base(parMenu)
    {
    }
  }
}
