using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  /// <summary>
  /// Стек контроллеров
  /// </summary>
  public static class ControllersStack
  {
    /// <summary>
    /// Стек контроллеров
    /// </summary>
    public static Stack<ControllerBase> Stack { get; set; } = new();
  }
}
