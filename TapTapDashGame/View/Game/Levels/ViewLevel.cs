using Model.Game.Levels;
using Model.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game.Levels
{
  /// <summary>
  /// Представление уровн
  /// </summary>
  public abstract class ViewLevel : ViewBase
  {
    /// <summary>
    /// Уровень
    /// </summary>
    public Level Level { get; private set; }

    /// <summary>
    /// Список представления шагов уровня
    /// </summary>
    public List<ViewStep> ViewSteps { get; private set; } = new List<ViewStep>();

    /// <summary>
    /// Начальная позиция ячейки
    /// </summary>
    public Position<int> TilePosition { get; set; }

    /// <summary>
    /// Начальный размер ячейки
    /// </summary>
    public Size<int> TileSize { get; set; }

    /// <summary>
    /// Начальный поворот ячейки
    /// </summary>
    public Rotation<int> TileRotation { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parLevel">Уровень</param>
    /// <param name="parTilePosition">Начальная позиция ячейки</param>
    /// <param name="parTileSize">Начальный размер ячейки</param>
    /// <param name="parTileRotation">Начальный поворот ячейки</param>
    public ViewLevel(Level parLevel, Position<int> parTilePosition, Size<int> parTileSize, Rotation<int> parTileRotation) 
    { 
      Level = parLevel;
      TilePosition = parTilePosition;
      TileSize = parTileSize;
      TileRotation = parTileRotation; 
      InitSteps();
    }

    /// <summary>
    /// Инициализировать представление шагов
    /// </summary>
    private void InitSteps()
    {
      for(int i = 0; i < Level.Steps.Count; i++)
      {
        ViewSteps.Add(CreateViewStep(Level.Steps[i], new Rectangle<int>(TilePosition, TileSize, TileRotation)));
      }
    }

    /// <summary>
    /// Рисовать
    /// </summary>
    public override void Draw()
    {
      foreach (var step in ViewSteps)
      {
        step.Draw();
      }
    }

    /// <summary>
    /// Создать представление шага уровня
    /// </summary>
    /// <param name="parStep">Шаг</param>
    /// <param name="parRectangle">Прямоугольник</param>
    /// <returns>Представлние шага уровня</returns>
    public abstract ViewStep CreateViewStep(Step parStep, Rectangle<int> parRectangle);
  }
}
