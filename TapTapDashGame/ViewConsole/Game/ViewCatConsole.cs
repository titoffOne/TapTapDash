using CommonResources;
using Model.Game;
using Model.Geometry;
using View.Game;

namespace ViewConsole.Game
{
  /// <summary>
  /// Представление кота в консольном приложении
  /// </summary>
  public class ViewCatConsole : ViewCat
  {
    /// <summary>
    /// Конструктор для инициализации кота с заданной позицией, размером и вращением
    /// </summary>
    public ViewCatConsole(Cat parCat, Position<int> parPosition, Size<int> parSize, Rotation<int> parRotation) : base(parCat, parPosition, parSize, parRotation)
    {
    }

    /// <summary>
    /// Отобразить кошку в пределах экрана
    /// </summary>
    public override void Draw()
    {
      if (CatRectangle.Position.X > 0 && CatRectangle.Position.Y > 0
        && CatRectangle.Position.X < Properties.CONSOLE_APPLICATION_WIDTH
        && CatRectangle.Position.Y < Properties.CONSOLE_APPLICATION_HEIGHT)
        ConsoleWriter.Frame.Fill(CatRectangle, ' ', Colors.Black, Colors.Red);
    }

    /// <summary>
    /// Увеличить размер кота
    /// </summary>
    public override void IncreasedCatSize()
    {
      CatRectangle.Size.Width += 1;
      CatRectangle.Size.Height += 1;
    }
  }
}
