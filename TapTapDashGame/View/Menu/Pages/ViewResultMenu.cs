using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление меню результата
  /// </summary>
  public abstract class ViewResultMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Меню результата</param>
    public ViewResultMenu(ResultMenu parMenu) : base(parMenu)
    {
    }
  }
}
