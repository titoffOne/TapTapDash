using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using CommonResources;

namespace ViewWPF
{
  /// <summary>
  /// Главное окно
  /// </summary>
  public class MainWindow : Window
  {
    /// <summary>
    /// Экземпляр главного окна
    /// </summary>
    public static MainWindow Instance { get; } = new MainWindow();

    /// <summary>
    /// Основной контейнер
    /// </summary>
    public Canvas Canvas { get; set; } = new()
    {
      Background = Properties.WPF_COLOR_BACKGROUND
    };

    /// <summary>
    /// Конструктор общего графического окна
    /// </summary>
    private MainWindow()
    {
      ResizeMode = ResizeMode.NoResize;
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      AddChild(Canvas);
    }

    /// <summary>
    /// Установить размер окна
    /// </summary>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public void SetSize(int parWidth, int parHeight)
    {
      Application.Current.Dispatcher.Invoke(() =>
      {
        Width = parWidth;
        Height = parHeight;

        Canvas.Width = parWidth;
        Canvas.Height = parHeight;
      });
    }

    /// <summary>
    /// Очистить окно
    /// </summary>
    public void Clear()
    {
      Canvas.Children.Clear();
    }

    /// <summary>
    /// Получить центр экрана относительно ширины объекта
    /// </summary>
    /// <param name="parWidth">Ширина объекта</param>
    /// <returns></returns>
    public double GetWindowSenterOnWidth(double parWidth)
    {
      return (Instance.Canvas.Width - parWidth) / 2;
    }

    /// <summary>
    /// Получить центр экрана относительно высоты объекта
    /// </summary>
    /// <param name="parHeight">Высота объекта</param>
    /// <returns></returns>
    public double GetWindowSenterOnHeight(double parHeight)
    {
      return (Instance.Canvas.Height - parHeight) / 2;
    }
  }
}
