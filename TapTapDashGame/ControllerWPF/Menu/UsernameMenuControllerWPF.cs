using Controller.Menu;
using Model.Menu.Pages;
using System.Windows.Input;
using View.Menu.Pages;
using ViewWPF;
using ViewWPF.Menu.Pages;

namespace ControllerWPF.Menu
{
  /// <summary>
  /// Контроллер для управления меню ввода имени пользователя в WPF-приложении
  /// </summary>
  public class UsernameMenuControllerWPF : UsernameMenuController
  {
    /// <summary>
    /// Конструктор для инициализации контроллера и отображения главного окна
    /// </summary>
    public UsernameMenuControllerWPF()
    {
      MainWindow.Instance.Show();
    }

    /// <summary>
    /// Создание контроллера главного меню
    /// </summary>
    /// <returns>Контроллер главного меню</returns>
    public override MainMenuController CreateMainMenuController()
    {
      return new MainMenuControllerWPF();
    }

    /// <summary>
    /// Создание представления меню ввода имени пользователя
    /// </summary>
    /// <returns>Представление меню ввода имени пользователя</returns>
    public override ViewUsernameMenu CreateViewUsernameMenu()
    {
      return new ViewUsernameMenuWPF(UsernameMenu);
    }

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public override void Stop()
    {
      base.Stop();
      MainWindow.Instance.KeyDown -= KeyDown;
    }

    /// <summary>
    /// Обрабатывать нажатия клавиш
    /// </summary>
    public override void HandleKey()
    {
      MainWindow.Instance.KeyDown += KeyDown;
    }

    /// <summary>
    /// Обработка нажатия клавиш и добавление символов в меню
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Аргументы события</param>
    private void KeyDown(object parSender, KeyEventArgs parE)
    {
      var key = parE.Key;

      if (key == Key.Back)
      {
        UsernameMenu.RemoveLastSymbol();
      }
      else
      {
        char keyChar = (char)KeyInterop.VirtualKeyFromKey(key);

        if (char.IsLetter(keyChar) || char.IsDigit(keyChar))
        {
          UsernameMenu.AddSymbol(keyChar);
        }
      }

      switch (parE.Key)
      {
        case Key.Up:
          UsernameMenu.FocusPrevious();
          break;
        case Key.Down:
          UsernameMenu.FocusNext();
          break;
        case Key.Enter:
          UsernameMenu.SelectFocusedItem();
          break;
      }
    }
  }
}
