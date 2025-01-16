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
  /// Контроллер меню ввода никнейма пользователя
  /// </summary>
  public abstract class UsernameMenuController : ControllerBase
  {
    /// <summary>
    /// Меню ввода никнейма пользователя
    /// </summary>
    public UsernameMenu UsernameMenu { get; set; } = new UsernameMenu(TextConstants.MenuUsernameTitle, 
      Properties.MENU_USERNAME_INPUT_MAX_LENGTH);

    /// <summary>
    /// Представление меню ввода никнейма пользователя
    /// </summary>
    public ViewUsernameMenu ViewUsernameMenu { get; set; }

    /// <summary>
    /// Таблица рекордов
    /// </summary>
    public RatingInfo RecordInfo { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public UsernameMenuController()
    {
      UsernameMenu.AddActionSelectForSave(() =>
      {
        if (!UsernameMenu.Items[0].Value.Equals(string.Empty)) 
        {
          SaveRecords();
          Stop();
          ControllersStack.Stack.Push(this);
          CreateMainMenuController().Start();
        }
      });

      ViewUsernameMenu = CreateViewUsernameMenu();
    }

    /// <summary>
    /// Сохрнаить рекорды
    /// </summary>
    private void SaveRecords()
    {
      RecordInfo = new(UsernameMenu.Items[0].Value);
      Rating.Add(RecordInfo);
      Rating.WriteInFile();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewUsernameMenu.Draw();
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
    /// Создать представление меню ввода никнейма пользователя
    /// </summary>
    /// <returns>Представлние меню ввода никнейма пользователя</returns>
    public abstract ViewUsernameMenu CreateViewUsernameMenu();

    /// <summary>
    /// Создать контроллер главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public abstract MainMenuController CreateMainMenuController();
  }
}
