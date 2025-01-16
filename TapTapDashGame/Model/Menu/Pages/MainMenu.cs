using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonResources;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Главное меню
  /// </summary>
  public class MainMenu: Menu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголовок)</param>
    public MainMenu(string parTitle): base(parTitle) 
    {
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuMainItemPlay));
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuMainItemRules));
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuMainItemRating));
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuMainItemExit));
      
    }

    /// <summary>
    /// Добавить событие для кнокпи выбора режима "Играть"
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForPlay(Action parAction)
    {
      Items[0].Selected += parAction;
    }

    /// <summary>
    /// Добавить событие для кнопки выбора меню "Правила"
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForRules(Action parAction)
    {
      Items[1].Selected += parAction;
    }

    /// <summary>
    /// Добавить событие для кнопки выбора меню "Рейтинг"
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForRating(Action parAction)
    {
      Items[2].Selected += parAction;
    }

    /// <summary>
    /// Добавить событие для кнопки выбора режима "Выйти"
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForExit(Action parAction)
    {
      Items[3].Selected += parAction;
    }
  }
}
