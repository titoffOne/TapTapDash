using CommonResources;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Меню проигрыша
  /// </summary>
  public class FailMenu : Menu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголовок)</param>
    public FailMenu(string parTitle) : base(parTitle)
    {
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuFailItemRestart));
      AddItem(new MenuItem(MenuItem.Types.Button, TextConstants.MenuFailItemGoHome));
    }

    /// <summary>
    /// Добавить событие для кнопки перезапуска игры
    /// </summary>
    /// <param name="parAction"></param>
    public void AddActionSelectForRestartGame(Action parAction)
    {
      Items[0].Selected += parAction;
    }

    /// <summary>
    /// Добавить событие для кнопки выхода в главное меню
    /// </summary>
    /// <param name="parAction"></param>
    public void AddActionSelectForGoHome(Action parAction)
    {
      Items[1].Selected += parAction;
    }
  }
}
