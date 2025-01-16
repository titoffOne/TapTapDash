using CommonResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Меню рейтинга
  /// </summary>
  public class RatingMenu : Menu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголвок)</param>
    public RatingMenu(string parTitle) : base(parTitle)
    {
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuRatingItemGoHome));
    }

    /// <summary>
    /// Добавить событие для кнопки для выхода в главное меню
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForGoHome(Action parAction)
    {
      Items[0].Selected += parAction;
    }
  }
}
