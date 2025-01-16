using CommonResources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using View.Menu;
using static Model.Menu.MenuItem;

namespace ViewWPF.Menu
{
  /// <summary>
  /// WPF представление элемента меню
  /// </summary>
  public class ViewMenuItemWPF : ViewMenuItem
  {
    /// <summary>
    /// Цвета текста состояний
    /// </summary>
    private static Dictionary<States, Brush> FGColorsStates { get; set; } = new()
    {
      { States.Normal, Properties.WPF_COLOR_BUTTON_FG_NORMAL },
      { States.Focused, Properties.WPF_COLOR_BUTTON_FG_FOCUSED }
    };

    /// <summary>
    /// Цвета фона состояний
    /// </summary>
    private static Dictionary<States, Brush> BGColorsStates { get; set; } = new()
    {
      { States.Normal, Properties.WPF_COLOR_BUTTON_BG_NORMAL },
      { States.Focused, Properties.WPF_COLOR_BUTTON_BG_FOCUSED }
    };

    /// <summary>
    /// Контейнер элемента меню
    /// </summary>
    public Border Border { get; set; } = new();

    /// <summary>
    /// Текст элемента
    /// </summary>
    public TextBlock TextBlock { get; set; } = new();

    /// <summary>
    /// Конструктор для создания элемента меню
    /// </summary>
    /// <param name="parItem">Элемент меню</param>
    public ViewMenuItemWPF(Model.Menu.MenuItem parItem) : base(parItem)
    {
      if (parItem.Type.Equals(Types.Button))
        ButtonSettings();
      else
        InputSettings();
    }

    /// <summary>
    /// Настройки для кнопки
    /// </summary>
    private void ButtonSettings()
    {
      TextBlock.Text = Item.Name;
      TextBlock.FontSize = 30;
      TextBlock.Margin = new Thickness(100, 10, 100, 10);
      TextBlock.FontFamily = Properties.WPF_APPLICATION_FONT;
      TextBlock.Foreground = FGColorsStates[Item.State];
      TextBlock.HorizontalAlignment = HorizontalAlignment.Center;
      TextBlock.TextAlignment = TextAlignment.Center;

      Border.Child = TextBlock;
      Border.Background = BGColorsStates[Item.State];
      Border.CornerRadius = new CornerRadius(10); 
      Border.Padding = new Thickness(5); 
      Border.Margin = new Thickness(0, 10, 0, 10); 
    }

    /// <summary>
    /// Настройки для ввода
    /// </summary>
    private void InputSettings()
    {
      TextBlock.Text = Item.Name;
      TextBlock.FontSize = 30;
      TextBlock.Margin = new Thickness(100, 10, 100, 10); 
      TextBlock.FontFamily = Properties.WPF_APPLICATION_FONT;
      TextBlock.Foreground = FGColorsStates[States.Normal]; 
      TextBlock.HorizontalAlignment = HorizontalAlignment.Center;
      TextBlock.TextAlignment = TextAlignment.Center;

      Border.Child = TextBlock;
      Border.Background = BGColorsStates[States.Normal]; 
      Border.CornerRadius = new CornerRadius(5); 
      Border.Padding = new Thickness(5); 
      Border.Margin = new Thickness(0, 10, 0, 10); 
      Border.BorderBrush = BGColorsStates[Item.State]; 
      Border.BorderThickness = new Thickness(2); 
    }

    /// <summary>
    /// Обновить состояние и перерисовать элемент меню
    /// </summary>
    public override void Draw()
    {
      if (Item.Type.Equals(Types.Button))
      {
        TextBlock.Foreground = FGColorsStates[Item.State];
        Border.Background = BGColorsStates[Item.State];
      }
      else
      {
        TextBlock.Text = Item.Value;
        TextBlock.Foreground = BGColorsStates[States.Focused];
        Border.BorderBrush = BGColorsStates[Item.State];
      }
    }
  }
}
