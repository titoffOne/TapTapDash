namespace Model.Game.Levels
{
  /// <summary>
  /// Уровень
  /// </summary>
  public class Level
  {
    /// <summary>
    /// Номер уровня
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Список шагов лабиринта
    /// </summary>
    public List<Step> Steps { get; set; } = new List<Step>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parNumber">Номер уровня</param>
    /// <param name="parSteps">Список шагов</param>
    public Level(int parNumber, List<Step> parSteps)
    {
      Number = parNumber;
      Steps = parSteps;
    }
  }
}
