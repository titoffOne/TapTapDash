using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu.Pages
{
  /// <summary>
  /// Представление меню рейтинга
  /// </summary>
  public abstract class ViewRatingMenu : ViewMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Меню рейтинга</param>
    public ViewRatingMenu(RatingMenu parMenu) : base(parMenu)
    {
    }
  }
}
