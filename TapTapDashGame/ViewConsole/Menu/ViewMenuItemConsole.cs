using Model.Menu;
using View.Menu;
using static Model.Menu.MenuItem;

namespace ViewConsole.Menu
{
  /// <summary>
  /// Представление элемента меню в консоли
  /// </summary>
  public class ViewMenuItemConsole : ViewMenuItem
  {
    /// <summary>
    /// Цвета текста для различных состояний элемента меню
    /// </summary>
    private static Dictionary<States, Colors> FGColorsStates { get; set; } = new()
    {
      { States.Normal, Colors.White }, // Цвет текста в нормальном состоянии
      { States.Focused, Colors.Blue }  // Цвет текста, когда элемент в фокусе
    };

    /// <summary>
    /// Цвета фона для различных состояний элемента меню
    /// </summary>
    private static Dictionary<States, Colors> BGColorsStates { get; set; } = new()
    {
      { States.Normal, Colors.Blue },  // Цвет фона в нормальном состоянии
      { States.Focused, Colors.White } // Цвет фона, когда элемент в фокусе
    };

    /// <summary>
    /// Конструктор для создания представления элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    public ViewMenuItemConsole(MenuItem parItem) : base(parItem)
    {
    }

    /// <summary>
    /// Отрисовка элемента меню в консоли
    /// </summary>
    public override void Draw()
    {
      if (Item.Type.Equals(Types.Button))
      {
        ConsoleWriter.Frame.Write(Rectangle.Position, Item.Name, FGColorsStates[Item.State]);
      }
      else
      {
        ConsoleWriter.Frame.Write(Rectangle.Position, new string(' ', 20));
        ConsoleWriter.Frame.Write(Rectangle.Position, Item.Value, FGColorsStates[Item.State], BGColorsStates[Item.State]);
      }
    }
  }
}
