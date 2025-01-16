namespace Model.Game.Levels
{
  public class Step
  {
    /// <summary>
    /// Направление ячеек
    /// </summary>
    public DirectionType Direction { get; set; } = DirectionType.Up;

    /// <summary>
    /// Список ячеек
    /// </summary>
    public List<Tile> Tiles { get; set; } = new List<Tile>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parDirection">Направление ячеек</param>
    /// <param name="parTiles">Список ячеек</param>
    public Step(DirectionType parDirection, List<Tile> parTiles)
    {
      Direction = parDirection;
      Tiles = parTiles;
    }

  }
}
