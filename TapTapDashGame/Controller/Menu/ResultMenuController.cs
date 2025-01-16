using CommonResources;
using Model.Game.Records;
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
  /// Контроллер меню результата
  /// </summary>
  public abstract class ResultMenuController : ControllerBase
  {
    /// <summary>
    /// Меню результата
    /// </summary>
    public ResultMenu ResultMenu { get; set; } = new ResultMenu(TextConstants.MenuResultTitle);

    /// <summary>
    /// Представление меню результата
    /// </summary>
    public ViewResultMenu ViewResultMenu { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public ResultMenuController()
    {
      ResultMenu.AddActionSelectForSetLevel(() =>
      {
        Stop();
        ControllersStack.Stack.Pop();
        CreateLevelsMenuController().Start();
      });

      ResultMenu.AddActionSelectForGoHome(() =>
      {
        Stop();
        ControllersStack.Stack.Clear();
        CreateMainMenuController().Start();
      });

      ViewResultMenu = CreateViewResultMenu();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewResultMenu.Draw();
      HandleKey();
    }

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      Rating.UpdateRecord();
      IsActive = false;
    }

    /// <summary>
    /// Создать представления меню правил
    /// </summary>
    /// <returns>Представление главного меню</returns>
    public abstract ViewResultMenu CreateViewResultMenu();

    /// <summary>
    /// Создать контроллер главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public abstract MainMenuController CreateMainMenuController();

    /// <summary>
    /// Создать контроллер меню уровней
    /// </summary>
    /// <returns>Контроллер меню уровней</returns>
    public abstract LevelsMenuController CreateLevelsMenuController();
  }
}
