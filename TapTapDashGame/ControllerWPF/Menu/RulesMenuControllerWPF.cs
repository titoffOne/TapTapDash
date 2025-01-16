using Controller.Menu;
using Model.Menu.Pages;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// Контроллер для управления меню правил в WPF-приложении
  /// </summary>
  public class RulesMenuControllerWPF : RulesMenuController
  {
    /// <summary>
    /// Конструктор для инициализации контроллера правил
    /// </summary>
    public RulesMenuControllerWPF() { }

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      MainWindow.Instance.KeyDown -= KeyDown;
    }

    /// <summary>
    /// Создание представления меню правил
    /// </summary>
    /// <returns>Представление меню правил</returns>
    public override ViewRulesMenu CreateViewRulesMenu()
    {
      return new ViewRulesMenuWPF(RulesMenu);
    }

    /// <summary>
    /// Настройка обработки событий нажатия клавиш
    /// </summary>
    public override void HandleKey()
    {
      MainWindow.Instance.KeyDown += KeyDown;
    }

    /// <summary>
    /// Обработка события нажатия клавиши
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Аргументы события</param>
    private void KeyDown(object parSender, KeyEventArgs parE)
    {
      switch (parE.Key)
      {
        case Key.Up:
          RulesMenu.FocusPrevious();
          break;
        case Key.Down:
          RulesMenu.FocusNext();
          break;
        case Key.Enter:
          RulesMenu.SelectFocusedItem();
          break;
      }
    }
  }
}
