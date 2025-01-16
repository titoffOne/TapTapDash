using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление меню уровней
  /// </summary>
  public abstract class ViewLevelsMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Меню уровней</param>
    public ViewLevelsMenu(LevelsMenu parMenu) : base(parMenu)
    {
    }
  }
}
