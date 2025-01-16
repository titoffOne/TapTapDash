using Model.Geometry;
using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление меню ввода никнейма пользователя
  /// </summary>
  public abstract class ViewUsernameMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Меню ввода никнейма пользователя</param>
    public ViewUsernameMenu(UsernameMenu parMenu) : base(parMenu)
    {
    }
  }
}
