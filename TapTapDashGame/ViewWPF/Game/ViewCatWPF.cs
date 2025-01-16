using CommonResources;
using Model.Game;
using Model.Geometry;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using View.Game;
using ViewWPF.Texture;

namespace ViewWPF.Game
{
  /// <summary>
  /// WPF представление кота
  /// </summary>
  public class ViewCatWPF : ViewCat, IAddChildren
  {
    /// <summary>
    /// WPF прямоугольник для кота
    /// </summary>
    public Rectangle WPFCatRectangle { get; set; } = new();

    /// <summary>
    /// Конструктор представления кота
    /// </summary>
    /// <param name="parCat">Кот</param>
    /// <param name="parPosition">Позиция кота</param>
    /// <param name="parSize">Размер кота</param>
    /// <param name="parRotation">Вращение кота</param>
    public ViewCatWPF(Cat parCat, Position<int> parPosition, Size<int> parSize, Rotation<int> parRotation)
      : base(parCat, parPosition, parSize, parRotation)
    {
      InitCatRectangle();
    }

    /// <summary>
    /// Отображение кота
    /// </summary>
    public override void Draw()
    {
      SetCatSize();
      ApplyRotation();
    }

    /// <summary>
    /// Инициализация прямоугольника кота
    /// </summary>
    private void InitCatRectangle()
    {
      WPFCatRectangle.Fill = TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathCat);
      SetCatSize();
      ApplyRotation();
      Canvas.SetLeft(WPFCatRectangle, CatRectangle.Position.X);
      Canvas.SetTop(WPFCatRectangle, CatRectangle.Position.Y);
    }

    /// <summary>
    /// Установка размера кота
    /// </summary>
    private void SetCatSize()
    {
      WPFCatRectangle.Width = CatRectangle.Size.Width;
      WPFCatRectangle.Height = CatRectangle.Size.Height;
    }

    /// <summary>
    /// Применение вращения кота
    /// </summary>
    private void ApplyRotation()
    {
      RotateTransform rotateTransform = new RotateTransform
      {
        Angle = CatRectangle.Rotation.Angle,
        CenterX = WPFCatRectangle.Width / 2,
        CenterY = WPFCatRectangle.Height / 2
      };

      WPFCatRectangle.RenderTransform = rotateTransform;
    }

    /// <summary>
    /// Добавление кота в канвас
    /// </summary>
    public void AddChildren()
    {
      MainWindow.Instance.Canvas.Children.Add(WPFCatRectangle);
    }

    /// <summary>
    /// Увеличение размера кота
    /// </summary>
    public override void IncreasedCatSize()
    {
      CatRectangle.Size.Width += (CatRectangle.Size.Width / 4);
      CatRectangle.Size.Height += (CatRectangle.Size.Height / 4);
    }
  }
}
