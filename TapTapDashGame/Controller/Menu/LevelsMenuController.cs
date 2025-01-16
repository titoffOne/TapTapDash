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
  /// Контроллер меню уровней
  /// </summary>
  public abstract class LevelsMenuController : ControllerBase
  {
    /// <summary>
    /// Меню уровней
    /// </summary>
    public LevelsMenu LevelsMenu { get; set; } = new LevelsMenu(TextConstants.MenuLevelsTitle, 
      TextConstants.MenuLevelsFilePath);

    /// <summary>
    /// Представлние меню уровней
    /// </summary>
    public ViewLevelsMenu ViewLevelsMenu { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public LevelsMenuController()
    {
      LevelsMenu.SelectLevelEvent += (parPathToLevel) =>
      {
        Stop();
        CreateGameController(parPathToLevel).Start();
      };

      LevelsMenu.SelectExitEvent += () =>
      {
        Stop();
        ControllersStack.Stack.Pop().Start();
      };

      ViewLevelsMenu = CreateLevelsMenu();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewLevelsMenu.Draw();
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
    /// Создать представление меню уровней
    /// </summary>
    /// <returns>Представление меню уровней</returns>
    public abstract ViewLevelsMenu CreateLevelsMenu();

    /// <summary>
    /// Создать контроллер игры
    /// </summary>
    /// <param name="parPathToMap">Путь до карты</param>
    /// <returns>Контроллер игры</returns>
    protected abstract GameController CreateGameController(string parPathToMap);
  }
}
