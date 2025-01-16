using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Geometry
{
  /// <summary>
  /// Размер
  /// </summary>
  public class Size<T>
  {
    /// <summary>
    /// Ширина
    /// </summary>
    public T Width { get; set; }

    /// <summary>
    /// Высота
    /// </summary>
    public T Height { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWidth">Ширина</param>
    /// <param name="parHeight">Высота</param>
    public Size(T parWidth, T parHeight)
    {
      Width = parWidth;
      Height = parHeight;
    }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parSize">Размер</param>
    public Size(Size<T> parSize)
    {
      Width = parSize.Width;
      Height = parSize.Height;
    }
  }
}
