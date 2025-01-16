using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Menu.MenuItem;

namespace Model.Menu
{
  /// <summary>
  /// Меню
  /// </summary>
  public class Menu : INeedRedraw
  {
    /// <summary>
    /// Событие необходимости перерисовки
    /// </summary>
    public event Action? NeedRedraw = null;

    /// <summary>
    /// Список элементов меню
    /// </summary>
    public List<MenuItem> Items { get; private set; } = new();

    /// <summary>
    /// Индекс элемента, находящегося в фокусе
    /// </summary>
    public int FocusedIndex { get; private set; }

    /// <summary>
    /// Заголовок меню
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Создать страницу меню
    /// </summary>
    /// <param name="parTitle">Заголовок страницы меню</param>
    public Menu(string parTitle)
    { 
      Title = parTitle;
    }

    /// <summary>
    /// Добавить элемент меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    public void AddItem(MenuItem parItem)
    {
      if (Items.Count == 0)
      {
        parItem.State = States.Focused;
      }

      Items.Add(parItem);
    }

    /// <summary>
    /// Смеенить фокус на следующий элемент меню
    /// </summary>
    public void FocusNext()
    {
      Items[FocusedIndex].State = States.Normal;

      FocusedIndex++;
      if (FocusedIndex == Items.Count)
        FocusedIndex = 0;

      Items[FocusedIndex].State = States.Focused;

      TriggerRedraw();
    }

    /// <summary>
    /// Смеенить фокус на предыдущий элемент меню
    /// </summary>
    public void FocusPrevious()
    {
      Items[FocusedIndex].State = States.Normal;

      FocusedIndex--;
      if (FocusedIndex == -1)
        FocusedIndex = Items.Count - 1;

      Items[FocusedIndex].State = States.Focused;

      TriggerRedraw();
    }

    /// <summary>
    /// Добавить символ
    /// </summary>
    /// <param name="parSymbol">Символ</param>
    public void AddSymbol(char parSymbol)
    {
      if (Items[FocusedIndex].Type.Equals(Types.Input))
        if (Items[FocusedIndex].Value.Length < Items[FocusedIndex].MaxLength)
        {
          Items[FocusedIndex].Value += parSymbol;
          TriggerRedraw();
        }
    }

    /// <summary>
    /// Удалить последний символ
    /// </summary>
    public void RemoveLastSymbol()
    {
      if (Items[FocusedIndex].Type.Equals(Types.Input))
        if (Items[FocusedIndex].Value.Length > 0)
        {
          Items[FocusedIndex].Value = Items[FocusedIndex].Value[..^1];
          TriggerRedraw();
        }
    }

    /// <summary>
    /// Уведомить подписчиков события NeedRedraw о необходимости перерисовки
    /// </summary>
    public void TriggerRedraw()
    {
      NeedRedraw?.Invoke();
    }

    /// <summary>
    /// Выбрать элемент, находящийся в фокусе
    /// </summary>
    public void SelectFocusedItem()
    {
      Items[FocusedIndex].Select();
    }

  }
}
