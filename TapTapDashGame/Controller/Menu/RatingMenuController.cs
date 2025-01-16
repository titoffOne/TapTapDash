using CommonResources;
using Model.Game.Records;
using Model.Menu.Pages;
using View.Menu.Pages;

namespace Controller.Menu
{
  /// <summary>
  /// Контроллер рейтинга
  /// </summary>
  public abstract class RatingMenuController : ControllerBase
  {
    /// <summary>
    /// Меню рейтинга
    /// </summary>
    public RatingMenu RatingMenu { get; set; } = new RatingMenu(TextConstants.MenuRatingTitle);

    /// <summary>
    /// Представление меню рейтинга
    /// </summary>
    public ViewRatingMenu ViewRatingMenu { get; set; }

    /// <summary>
    /// Консттруктор
    /// </summary>
    public RatingMenuController()
    {
      Rating.SortByTotalScoreDesc();

      RatingMenu.AddActionSelectForGoHome(() =>
      {
        Stop();
        ControllersStack.Stack.Pop().Start();
      });

      ViewRatingMenu = CreateViewRatingMenu();
    }

    /// <summary>
    /// Запустить работу контроллера
    /// </summary>
    public override void Start()
    {
      IsActive = true;
      ViewRatingMenu.Draw();
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
    /// Создать представление меню рейтинга
    /// </summary>
    /// <returns>Представление меню рейтинга</returns>
    public abstract ViewRatingMenu CreateViewRatingMenu();
  }
}
