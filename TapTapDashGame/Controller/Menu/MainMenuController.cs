using CommonResources;
using Model.Menu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Menu.Pages;

namespace Controller.Menu
{
  /// <summary>
  /// Контроллер главного меню
  /// </summary>
  public abstract class MainMenuController : ControllerBase
  {
    /// <summary>
    /// Главное меню
    /// </summary>
    public MainMenu MainMenu { get; set; } = new(TextConstants.MenuMainTitle);

    /// <summary>
    /// Представление главного меню
    /// </summary>
    public ViewMainMenu ViewMainMenu { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MainMenuController() 
    {
      MainMenu.AddActionSelectForPlay(() =>
        {
          Stop();
          ControllersStack.Stack.Push(this);
          CreateLevelsMenuController().Start();
        });
      MainMenu.AddActionSelectForRating(() =>
        {
          Stop();
          ControllersStack.Stack.Push(this);
          CreateRatingMenuController().Start();
        });
      MainMenu.AddActionSelectForRules(() =>
        {
          Stop();
          ControllersStack.Stack.Push(this);
          CreateRulesMenuController().Start();
        });
      MainMenu.AddActionSelectForExit(() =>
        {
          Stop();
          Environment.Exit(0);
        });

      ViewMainMenu = CreateViewMainMenu();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewMainMenu.Draw();
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
    /// Создать представления главного меню
    /// </summary>
    /// <returns>Представление главного меню</returns>
    public abstract ViewMainMenu CreateViewMainMenu();

    /// <summary>
    /// Создать контроллер меню уровней
    /// </summary>
    /// <returns>Контроллер меню уровней</returns>
    public abstract LevelsMenuController CreateLevelsMenuController();

    /// <summary>
    /// Создать контроллер меню правил
    /// </summary>
    /// <returns>Контроллер меню правил</returns>
    public abstract RulesMenuController CreateRulesMenuController();

    /// <summary>
    /// Создать контроллер меню рейтинга
    /// </summary>
    /// <returns>Контроллер меню рейтинга</returns>
    public abstract RatingMenuController CreateRatingMenuController();
  }
}
