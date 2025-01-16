using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Интерфейс необходимости перерисовки
  /// </summary>
  public interface INeedRedraw
  {
    /// <summary>
    /// Событие необходимости перерисовки
    /// </summary>
    public event Action? NeedRedraw;
  }
}
