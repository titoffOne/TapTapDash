using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ViewWPF.Texture
{
  /// <summary>
  /// Помощник для инициализации текстур
  /// </summary>
  public static class TextureHandler
  {
    /// <summary>
    /// Создать ImageBrush из указанного пути к изображению
    /// </summary>
    /// <param name="imagePath">Путь к файлу изображения</param>
    /// <returns>Объект ImageBrush с указанным изображением</returns>
    public static ImageBrush CreateImageBrush(string imagePath)
    {
      if (string.IsNullOrEmpty(imagePath))
        throw new ArgumentException("Путь к изображению не может быть пустым.", nameof(imagePath));

      try
      {
        var bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));

        return new ImageBrush(bitmap)
        {
          Stretch = Stretch.UniformToFill 
        };
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException($"Ошибка при загрузке изображения из {imagePath}.", ex);
      }
    }
  }
}
