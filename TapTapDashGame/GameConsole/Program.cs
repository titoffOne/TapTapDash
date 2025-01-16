using ControllerConsole.Menu;

namespace GameConsole
{
  /// <summary>
  /// Программа
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Метод запуска приложения
    /// </summary>
    /// <param name="args">Аргументы</param>
    public static void Main(string[] args)
    {
      new UsernameMenuControllerConsole().Start();
    }
  }
}
