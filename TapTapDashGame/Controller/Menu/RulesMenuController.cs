using CommonResources;
using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu.Pages;

namespace Controller.Menu
{
  /// <summary>
  /// Контроллер меню правил
  /// </summary>
  public abstract class RulesMenuController : ControllerBase
  {
    /// <summary>
    /// Меню правил
    /// </summary>
    public RulesMenu RulesMenu { get; set; } = new RulesMenu(TextConstants.MenuRulesTitle);

    /// <summary>
    /// Представлние меню правил
    /// </summary>
    public ViewRulesMenu ViewRulesMenu { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public RulesMenuController()
    {
      RulesMenu.AddActionSelectForGoHome(() =>
      {
        Stop();
        ControllersStack.Stack.Pop().Start();
      });

      ViewRulesMenu = CreateViewRulesMenu();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewRulesMenu.Draw();
      HandleKey();
    }

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      IsActive = false;
    }

    /// <summary>
    /// Создать представление меню правил
    /// </summary>
    /// <returns>Представление гменю правил</returns>
    public abstract ViewRulesMenu CreateViewRulesMenu();
  }
}
