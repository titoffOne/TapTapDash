using CommonResources;
using Model.Game.Levels;
using Model.Geometry;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using View.Game.Levels;
using ViewWPF.Texture;

namespace ViewWPF.Game.Levels
{
  /// <summary>
  /// WPF представление ячейки игрового уровня
  /// </summary>
  public class ViewTileWPF : ViewTile, IAddChildren
  {
    /// <summary>
    /// WPF прямоугольник для отображения ячейки
    /// </summary>
    public Rectangle WPFTileRectangle { get; set; } = new();

    /// <summary>
    /// Конструктор WPF представления ячейки
    /// </summary>
    /// <param name="parTile">Объект ячейки</param>
    /// <param name="parTileRectengle">Размер и позиция ячейки</param>
    public ViewTileWPF(Tile parTile, Rectangle<int> parTileRectengle) : base(parTile, parTileRectengle)
    {
      InitTileRectangle();
    }

    /// <summary>
    /// Отрисовка ячейки на игровом поле
    /// </summary>
    public override void Draw()
    {
      SetTilePosition();
      WPFTileRectangle.Fill = InitFillTileRectangle(Tile.Type);
    }

    /// <summary>
    /// Инициализация прямоугольника для отображения ячейки
    /// </summary>
    private void InitTileRectangle()
    {
      WPFTileRectangle.Fill = InitFillTileRectangle(Tile.Type);
      WPFTileRectangle.Width = TileRectangle.Size.Width + 1;
      WPFTileRectangle.Height = TileRectangle.Size.Height + 1;

      SetTilePosition();
      ApplyTileRotation();
    }

    /// <summary>
    /// Установка позиции прямоугольника ячейки
    /// </summary>
    private void SetTilePosition()
    {
      Canvas.SetLeft(WPFTileRectangle, TileRectangle.Position.X);
      Canvas.SetTop(WPFTileRectangle, TileRectangle.Position.Y);
    }

    /// <summary>
    /// Применение поворота к прямоугольнику ячейки
    /// </summary>
    private void ApplyTileRotation()
    {
      RotateTransform rotateTransform = new RotateTransform();
      rotateTransform.Angle = TileRectangle.Rotation.Angle;

      // Центр вращения — центр прямоугольника
      rotateTransform.CenterX = WPFTileRectangle.Width / 2;
      rotateTransform.CenterY = WPFTileRectangle.Height / 2;

      WPFTileRectangle.RenderTransform = rotateTransform;
    }

    /// <summary>
    /// Инициализация заполнения прямоугольника в зависимости от типа ячейки
    /// </summary>
    /// <param name="parTileTypes">Тип ячейки</param>
    /// <returns>Образец для отображения типа ячейки</returns>
    private ImageBrush InitFillTileRectangle(TileTypes parTileTypes)
    {
      switch (parTileTypes)
      {
        case TileTypes.Empty:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileEmpty);

        case TileTypes.Coin:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileCoin);

        case TileTypes.Start:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileStart);

        case TileTypes.End:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileEnd);

        case TileTypes.Forward:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileForward);

        case TileTypes.TurnLeft:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileTurnLeft);

        case TileTypes.TurnRight:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileTurnRight);

        case TileTypes.Abyss:
          return null;

        default:
          return TextureHandler.CreateImageBrush(TextConstants.MenuGameImgFilePathTileEmpty);
      }
    }

    /// <summary>
    /// Добавление прямоугольника в канву окна
    /// </summary>
    public void AddChildren()
    {
      MainWindow.Instance.Canvas.Children.Add(WPFTileRectangle);
    }
  }
}
