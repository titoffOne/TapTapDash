using Model.Game.Levels;
using Model.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game.Levels
{
  /// <summary>
  /// Представление шага уровня
  /// </summary>
  public abstract class ViewStep : ViewBase
  {
    /// <summary>
    /// Шаг уровня
    /// </summary>
    public Step Step { get; private set; }

    /// <summary>
    /// Список представлений ячеек
    /// </summary>
    public List<ViewTile> ViewTiles { get; private set; } = new List<ViewTile>();

    /// <summary>
    /// Прямоугольник ячейки
    /// </summary>
    public Rectangle<int> TileRectangle { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parStep">Шаг</param>
    /// <param name="parTileRectangle">Прямоугольник</param>
    public ViewStep(Step parStep, Rectangle<int> parTileRectangle) 
    { 
      Step = parStep;
      TileRectangle = parTileRectangle;
      InitViewTiles();
    }

    /// <summary>
    /// Инициализировать представления ячеек
    /// </summary>
    private void InitViewTiles()
    {

      for (int i = 0; i < Step.Tiles.Count; i++)
      {
        
        if (!Step.Tiles[i].Type.Equals(TileTypes.Start))
          SetTileRectangleInitParams();

        ViewTiles.Add(CreateViewTile(Step.Tiles[i], TileRectangle));    
      }
    }

    /// <summary>
    /// Установить начальные параметры прямоугольника ячейки
    /// </summary>
    private void SetTileRectangleInitParams()
    {
      TileRectangle.Rotation.Angle = 0;
      switch (Step.Direction)
      {
        case DirectionType.Up:
          TileRectangle.Position.Y -= TileRectangle.Size.Height;
          TileRectangle.Rotation.RotateRight(0);
          break;
        case DirectionType.Down:
          TileRectangle.Position.Y += TileRectangle.Size.Height;
          TileRectangle.Rotation.RotateRight(180);
          break;
        case DirectionType.Left:
          TileRectangle.Position.X -= TileRectangle.Size.Width;
          TileRectangle.Rotation.RotateRight(270);
          break;
        case DirectionType.Right:
          TileRectangle.Position.X += TileRectangle.Size.Width;
          TileRectangle.Rotation.RotateRight(90);
          break;
      }
    }

    /// <summary>
    /// Рисовать
    /// </summary>
    public override void Draw()
    {
      foreach (var viewTile in ViewTiles)
      {
        viewTile.Draw();
      }
    }

    /// <summary>
    /// Создать представление ячейки
    /// </summary>
    /// <param name="parTile">Ячейка</param>
    /// <param name="parRectangle">Прямоугольник</param>
    /// <returns>Представлние ячейки</returns>
    public abstract ViewTile CreateViewTile(Tile parTile, Rectangle<int> parRectangle);
  }
}
