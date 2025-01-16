using Model.Game.Levels;

namespace Model.Game
{
  /// <summary>
  /// Строитель игры
  /// </summary>
  public class GameBuilder
  {
    /// <summary>
    /// Кот (игровой персонаж)
    /// </summary>
    private Cat Cat { get; set; }

    /// <summary>
    /// Направление движения кота
    /// </summary>
    private DirectionType CatDirection { get; set; }

    /// <summary>
    /// Кол-во собранных котом монет
    /// </summary>
    private int CatCoinsCollected { get; set; }

    /// <summary>
    /// Жив ли кот
    /// </summary>
    private bool IsCatAlive { get; set; }

    /// <summary>
    /// Уровень
    /// </summary>
    private Level Level { get; set; }

    /// <summary>
    /// Установить направление кота
    /// </summary>
    /// <param name="parCatDirection">Направлние кота</param>
    /// <returns>Строитель игры</returns>
    public GameBuilder SetCatDirection(DirectionType parCatDirection)
    {
      CatDirection = parCatDirection;
      return this;
    }

    /// <summary>
    /// Установить кол-во собранных котом монет
    /// </summary>
    /// <param name="parCatCoinsCollected">Собранные котом монеты</param>
    /// <returns>Строитель игры</returns>
    public GameBuilder SetCatCoinsCollected(int parCatCoinsCollected)
    {
      CatCoinsCollected = parCatCoinsCollected;
      return this;
    }

    /// <summary>
    /// Установить, жив ли кот
    /// </summary>
    /// <param name="parIsCatAlive">Жив ли кот</param>
    /// <returns>Строитель игры</returns>
    public GameBuilder SetIsCatAlive(bool parIsCatAlive)
    {
      IsCatAlive = parIsCatAlive;
      return this;
    }

    /// <summary>
    /// Установить кота
    /// </summary>
    /// <returns>Строитель игры</returns>
    public GameBuilder SetCat()
    {
      if (Cat == null)
        Cat = new(CatDirection, CatCoinsCollected, IsCatAlive);
      return this;
    }

    /// <summary>
    /// Установить уровень
    /// </summary>
    /// <param name="parLevel">Уровень</param>
    /// <returns>Строитель игры</returns>
    public GameBuilder SetLevel(Level parLevel)
    {
      Level = parLevel;
      return this;
    }

    /// <summary>
    /// Построить
    /// </summary>
    /// <returns>Игра</returns>
    public Game Build()
    {
      if (Cat == null)
      {
        Cat = new();
      }

      return new Game(
          Level,
          Cat
        );
    }
  }
}
