using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление меню правил
  /// </summary>
  public abstract class ViewRulesMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Меню правил</param>
    public ViewRulesMenu(RulesMenu parMenu) : base(parMenu)
    {
    }
  }
}
