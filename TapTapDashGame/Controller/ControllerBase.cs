using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  /// <summary>
  /// Базовый контроллер
  /// </summary>
  public abstract class ControllerBase
  {
    /// <summary>
    /// Указывает, активен ли контроллер
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Запуск контроллера
    /// </summary>
    public abstract void Start();

    /// <summary>
    /// Завершить работу контроллера
    /// </summary>
    public abstract void Stop();

    /// <summary>
    /// Обрабатывать нажатие клавиш
    /// </summary>
    public abstract void HandleKey();
  }
}
