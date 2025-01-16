using CommonResources;
using System.IO;
using System.Text.Json;

namespace Model.Game.Records
{
  public static class Rating
  {
    /// <summary>
    /// Путь до файла рекордов
    /// </summary>
    private static string FilePath { get; set; } = TextConstants.MenuRatingFilePath;

    /// <summary>
    /// Настройка json
    /// </summary>
    private static JsonSerializerOptions JsonOptions { get; set; } = new()
    {
      WriteIndented = true
    };

    /// <summary>
    /// Список рекордов
    /// </summary>
    public static List<RatingInfo> ListRecord { get; private set; } = new();

    public static RatingInfo CurrentPlayer { get; set; } = new();

    /// <summary>
    /// Статический конструктор
    /// </summary>
    static Rating()
    {
      ReadFromFile();
    }

    /// <summary>
    /// Записать в файл
    /// </summary>
    public static void WriteInFile()
    {
      string json = JsonSerializer.Serialize(ListRecord, JsonOptions);

      if (!File.Exists(FilePath))
      {
        File.Create(FilePath).Dispose();
      }

      File.WriteAllText(FilePath, json);
    }

    /// <summary>
    /// Считать из файла
    /// </summary>
    public static void ReadFromFile()
    {
      if (File.Exists(FilePath))
      {
        string json = File.ReadAllText(FilePath);
        if (json.Length > 0)
        {
          var listRecord = JsonSerializer.Deserialize<List<RatingInfo>>(json);
          if (listRecord != null)
          {
            ListRecord = new(listRecord);
          }
        }
      }
    }

    public static void SortByTotalScoreDesc()
    {
      ListRecord = ListRecord.OrderByDescending(record => record.TotalScore).ToList();
    }


    /// <summary>
    /// Добавить рекорд
    /// </summary>
    /// <param name="parRecordInfo">Информация о рекорде</param>
    public static void Add(RatingInfo parRecordInfo)
    {
      // Поиск игрока в существующем списке
      var existingRecord = ListRecord.FirstOrDefault(record => record.PlayerName.Equals(parRecordInfo.PlayerName));

      if (existingRecord != null)
      {
        CurrentPlayer = existingRecord;
      }
      else
      {
        ListRecord.Add(parRecordInfo);
        CurrentPlayer = parRecordInfo;
      }
    }

    /// <summary>
    /// Обновить текущий рекорд игрока и общий рекорд
    /// </summary>
    public static void UpdateRecord()
    {
      CurrentPlayer.TotalScore += CurrentPlayer.CurrentScore;

      var existingRecord = ListRecord.FirstOrDefault(record => record.PlayerName.Equals(CurrentPlayer.PlayerName));

      if (existingRecord != null)
      {
        existingRecord.TotalScore = CurrentPlayer.TotalScore;
      }

      CurrentPlayer.CurrentScore = 0;
      WriteInFile();
    }

  }
}
