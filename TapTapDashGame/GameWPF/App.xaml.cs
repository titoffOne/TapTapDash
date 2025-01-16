using ControllerWPF.Menu;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GameWPF
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    /// <summary>
    /// Запуск приложения
    /// </summary>
    /// <param name="parE"></param>
    protected override void OnStartup(StartupEventArgs parE)
    {
      base.OnStartup(parE);
      new UsernameMenuControllerWPF().Start();
    }
  }
}


