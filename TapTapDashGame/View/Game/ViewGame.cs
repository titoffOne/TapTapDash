using View.Game.Levels;

namespace View.Game
{
  /// <summary>
  /// Представление игры
  /// </summary>
  public abstract class ViewGame : ViewBase
  {
    /// <summary>
    /// Игра
    /// </summary>
    public Model.Game.Game Game { get; private set; }

    /// <summary>
    /// Представлние уровня
    /// </summary>
    public ViewLevel ViewLevel { get; private set; }

    /// <summary>
    /// Представлние кота (игровго персонажа)
    /// </summary>
    public ViewCat ViewCat { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGame">Игра</param>
    public ViewGame(Model.Game.Game parGame) 
    { 
      Game = parGame;

      ViewLevel = CreateViewLevel();
      ViewCat = CreateViewCat();

      Game.NeedRedraw += Draw;

     }

    /// <summary>
    /// Рисовать
    /// </summary>
    public override void Draw()
    {
      ViewLevel.Draw();
      ViewCat.Draw();
    }

    /// <summary>
    /// Создать представление уровня
    /// </summary>
    /// <returns>Представление уровня</returns>
    public abstract ViewLevel CreateViewLevel();

    /// <summary>
    /// Создать представление кота
    /// </summary>
    /// <returns>Представлние кота</returns>
    public abstract ViewCat CreateViewCat();
  }
}
