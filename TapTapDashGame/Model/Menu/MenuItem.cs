using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
  /// <summary>
  /// Элемент меню
  /// </summary>
  public class MenuItem
  {
    /// <summary>
    /// Состояния элемента меню
    /// </summary>
    public enum States
    {
      /// <summary>
      /// Обычное
      /// </summary>
      Normal,
      /// <summary>
      /// В фокусе
      /// </summary>
      Focused
    }

    /// <summary>
    /// Типы элементов меню
    /// </summary>
    public enum Types
    {
      /// <summary>
      /// Кнопка
      /// </summary>
      Button,
      /// <summary>
      /// Поле ввода
      /// </summary>
      Input
    }

    /// <summary>
    /// События выбора элемента меню
    /// </summary>
    public event Action? Selected = null;

    /// <summary>
    /// Состояние элемента меню
    /// </summary>
    public States State { get; set; } = States.Normal;

    /// <summary>
    /// Тип элемента меню
    /// </summary>
    public Types Type { get; private set; } = Types.Button;

    /// <summary>
    /// Наименование элемента меню
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Значение элемента меню (для поля ввода)
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Максимальная длина (для поля ввода)
    /// </summary>
    public int MaxLength { get; set; }

    /// <summary>
    /// Создание элемента меню
    /// </summary>
    /// <param name="parName">Наименование элемента меню</param>
    public MenuItem(Types parType, string parName)
    {
      Type = parType;
      Name = parName;
    }

    /// <summary>
    /// Создание элемента меню
    /// </summary>
    /// <param name="parName">Наименование элемента меню</param>
    public MenuItem(Types parType, string parName, int parMaxLength)
    {
      Type = parType;
      Name = parName;
      MaxLength = parMaxLength;
    }

    /// <summary>
    /// Выбрать элемент меню
    /// </summary>
    public void Select()
    {
      Selected?.Invoke();
    }


  }
}
