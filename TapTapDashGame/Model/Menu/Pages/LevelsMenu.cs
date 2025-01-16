using CommonResources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu.Pages
{
  /// <summary>
  /// Меню выбора увроней
  /// </summary>
  public class LevelsMenu : Menu
  {
    /// <summary>
    /// Делегат выбора уровня
    /// </summary>
    /// <param name="parMapToPath">Путь до карты</param>
    public delegate void dSelectLevel(string parMapToPath);

    /// <summary>
    /// Событие выбора уровня
    /// </summary>
    public event dSelectLevel? SelectLevelEvent;

    /// <summary>
    /// Событие выбора выхода
    /// </summary>
    public event Action? SelectExitEvent;

    /// <summary>
    /// Путь до папки с уровнями
    /// </summary>
    private string PathToLevelsFolder { get; set; }

    /// <summary>
    /// Сокращенные и полные имена файлов
    /// Ключ - Сокращенное имя файла
    /// Значение - Полное имя файлов
    /// </summary>
    public Dictionary<string, string> FilesNames { get; set; } = new();

    /// <summary>
    /// Кол-во уровней
    /// </summary>
    private int LevelCount { get; set; } = 0;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTitle">Название (заголовок)</param>
    /// <param name="parFilePathToLevels">Путь до папки с уровнями</param>
    public LevelsMenu(string parTitle, string parFilePathToLevels) : base(parTitle)
    {
      PathToLevelsFolder = parFilePathToLevels;

      Init();
      
    }

    /// <summary>
    /// Инициализировать меню уровней
    /// </summary>
    private void Init()
    {
      if (Directory.Exists(PathToLevelsFolder))
      {
        string[] files = Directory.GetFiles(PathToLevelsFolder);

        foreach (string file in files)
        {
          string fileName = Path.GetFileNameWithoutExtension(file);
          FilesNames.Add(fileName, file);

          LevelCount++;
          MenuItem levelItem = new(MenuItem.Types.Button, TextConstants.MenuLevelsItemLevelName + LevelCount);
          levelItem.Selected += () => { SelectLevel(file); };
          
          AddItem(levelItem);
        }
      }

      MenuItem exit = new(MenuItem.Types.Button, TextConstants.MenuLevelsItemGoHome);
      exit.Selected += SelectExit;
      AddItem(exit);
    }

    /// <summary>
    /// Выбрать выход
    /// </summary>
    private void SelectExit()
    {
      SelectExitEvent?.Invoke();
    }

    /// <summary>
    /// Выбрать карту
    /// </summary>
    /// <param name="parPathToMap">Путь до карты</param>
    private void SelectLevel(string parPathToMap)
    {
      SelectLevelEvent?.Invoke(parPathToMap);
    }
  }
}
