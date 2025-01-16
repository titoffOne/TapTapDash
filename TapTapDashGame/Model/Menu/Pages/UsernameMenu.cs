using CommonResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Меню ввода никнейма пользователя
  /// </summary>
  public class UsernameMenu : Menu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголовок)</param>
    /// <param name="parMaxLenght">Максимальная длина никнейма</param>
    public UsernameMenu(string parTitle, int parMaxLenght) : base(parTitle)
    {
      AddItem(new MenuItem(MenuItem.Types.Input, TextConstants.MenuUsernameItemInput, parMaxLenght));
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuUsernameItemSave));
    }

    /// <summary>
    /// Добавить событие для элемента сохранения никнейма
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForSave(Action parAction)
    {
      Items[1].Selected += parAction;
    }

  }
}
