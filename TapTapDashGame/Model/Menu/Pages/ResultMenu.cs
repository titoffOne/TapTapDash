using CommonResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Меню результата
  /// </summary>
  public class ResultMenu : Menu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголовок)</param>
    public ResultMenu(string parTitle) : base(parTitle)
    {
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuResultItemLevel));
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuResultItemGoHome));
    }

    /// <summary>
    /// Добавить событие для кнопки выбора режима "Выбрать уровень"
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForSetLevel(Action parAction)
    {
      Items[0].Selected += parAction;
    }

    /// <summary>
    /// Добавить событие для кнопки для перехода в главное меню
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForGoHome(Action parAction)
    {
      Items[1].Selected += parAction;
    }
  }
}
