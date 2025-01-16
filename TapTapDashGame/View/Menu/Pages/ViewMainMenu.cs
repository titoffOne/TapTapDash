using Model.Menu;
using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление главного меню
  /// </summary>
  public abstract class ViewMainMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Главное меню</param>
    public ViewMainMenu(MainMenu parMenu) : base(parMenu)
    {
    }
  }
}
