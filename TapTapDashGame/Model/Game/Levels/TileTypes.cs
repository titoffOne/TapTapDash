namespace Model.Game.Levels
{
  /// <summary>
  /// Тип ячейки
  /// </summary>
  public enum TileTypes
  {
    /// <summary>
    /// Пустая ячейка
    /// </summary>
    Empty,
    /// <summary>
    /// Ячейка с монетой
    /// </summary>
    Coin,
    /// <summary>
    /// Ячейка старта
    /// </summary>
    Start,
    /// <summary>
    /// Ячейка финиша
    /// </summary>
    End,
    /// <summary>
    /// Ячейка поворота налево
    /// </summary>
    TurnLeft,
    /// <summary>
    /// Ячейка поворота направо
    /// </summary>
    TurnRight,
    /// <summary>
    /// Ячейка движения вперед
    /// </summary>
    Forward,
    /// <summary>
    /// Ячейка пропасти
    /// </summary>
    Abyss
  }
}
