using CommonResources;
using Controller.Game;
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
  /// Контроллер меню проигрыша
  /// </summary>
  public abstract class FailMenuController : ControllerBase
  {
    /// <summary>
    /// Меню проигрыша
    /// </summary>
    public FailMenu FailMenu { get; set; } = new FailMenu(TextConstants.MenuFailTitle);

    /// <summary>
    /// Представлние меню проигрыша
    /// </summary>
    public ViewFailMenu ViewFailMenu { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public FailMenuController()
    {
      FailMenu.AddActionSelectForRestartGame(() =>
      {
        Stop();
        GameController gameController = (GameController)ControllersStack.Stack.Pop();
        gameController.Restart();
      });

      FailMenu.AddActionSelectForGoHome(() =>
      {
        Stop();
        ControllersStack.Stack.Clear();
        CreateMainMenuController().Start();
      });

      ViewFailMenu = CreateViewFailMenu();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewFailMenu.Draw();
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
    /// Создать представления меню проигрыша
    /// </summary>
    /// <returns>Представление меню проигрыша</returns>
    public abstract ViewFailMenu CreateViewFailMenu();

    /// <summary>
    /// Создать контроллер главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public abstract MainMenuController CreateMainMenuController();
  }
}
