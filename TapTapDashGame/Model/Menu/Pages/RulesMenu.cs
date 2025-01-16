using CommonResources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Меню правил
  /// </summary>
  public class RulesMenu : Menu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголовок)</param>
    public RulesMenu(string parTitle) : base(parTitle)
    {
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuRulesItemGoHome));
    }

    /// <summary>
    /// Добавить событие для кнопки для возвращения в главное меню
    /// </summary>
    /// <param name="parAction">Событие</param>
    public void AddActionSelectForGoHome(Action parAction)
    {
      Items[0].Selected += parAction;
    }

    /// <summary>
    /// Считать описание правил из файла
    /// </summary>
    /// <param name="parFilePath">Путь к файлу с правилами</param>
    /// <returns></returns>
    public static string[] ReadDescriptionFromFile(string parFilePath)
    {
      if (File.Exists(parFilePath))
      {
        return File.ReadAllLines(parFilePath);
      }
      else
      {
        return new string[] { TextConstants.MenuRulesItemExeption };
      }
    }
  }
}
