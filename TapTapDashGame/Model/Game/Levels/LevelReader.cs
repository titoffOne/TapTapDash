using Model.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Model.Game.Levels
{
  /// <summary>
  /// Считыватель уровня
  /// </summary>
  public static class LevelReader
  {
    /// <summary>
    /// Считать уровень из JSON-файла
    /// </summary>
    /// <param name="parFilePath">Путь к JSON-файлу</param>
    /// <returns>Объект уровня</returns>
    public static Level ReadLevelFromFile(string parFilePath)
    {
      if (string.IsNullOrWhiteSpace(parFilePath))
        throw new ArgumentException("Путь к файлу не может быть пустым.", nameof(parFilePath));

      if (!File.Exists(parFilePath))
        throw new FileNotFoundException("Файл не найден.", parFilePath);

      try
      {
        var jsonData = File.ReadAllText(parFilePath);

        var levelData = JsonConvert.DeserializeObject<JObject>(jsonData);

        if (levelData == null)
          throw new InvalidOperationException("Некорректный формат JSON.");

        var level = new Level(
          parNumber: levelData["LevelNumber"]?.Value<int>() ?? throw new InvalidOperationException("Не указан номер уровня."),
          parSteps: levelData["Steps"]?.Select(ParseStep).ToList() ?? new List<Step>()
        );

        return level;
      }
      catch (JsonException ex)
      {
        Console.WriteLine("Ошибка при разборе JSON - файла.");
        throw new InvalidOperationException("Ошибка при разборе JSON-файла.", ex);
      }
    }

    /// <summary>
    /// Парсить шаг лабиринта
    /// </summary>
    /// <param name="parStepData">Объект шага в формате JObject</param>
    /// <returns>Объект шага</returns>
    private static Step ParseStep(JToken parStepData)
    {
      return new Step(
        parDirection: ParseDirection(parStepData["Direction"]?.Value<string>()),
        parTiles: parStepData["Tiles"]?.Select(ParseTile).ToList() ?? new List<Tile>()
      );
    }

    /// <summary>
    /// Парсить ячейку
    /// </summary>
    /// <param name="parTileData">Объект ячейки в формате JObject</param>
    /// <returns>Объект ячейки</returns>
    private static Tile ParseTile(JToken parTileData)
    {
      return new Tile(
          parType: ParseTileType(parTileData["TileType"]?.Value<string>())
      );
    }

    /// <summary>
    /// Преобразовать строку в тип направления
    /// </summary>
    /// <param name="parDirection">Строковое представление направления</param>
    /// <returns>Тип направления</returns>
    private static DirectionType ParseDirection(string? parDirection)
    {
      return parDirection switch
      {
        "U" => DirectionType.Up,
        "D" => DirectionType.Down,
        "L" => DirectionType.Left,
        "R" => DirectionType.Right,
        _ => throw new InvalidOperationException($"Некорректное направление: {parDirection}")
      };
    }

    /// <summary>
    /// Преобразовать строку в тип ячейки
    /// </summary>
    /// <param name="parTileType">Строковое представление типа ячейки</param>
    /// <returns>Тип ячейки</returns>
    private static TileTypes ParseTileType(string? parTileType)
    {
      return parTileType switch
      {
        "Empty" => TileTypes.Empty,
        "Coin" => TileTypes.Coin,
        "Start" => TileTypes.Start,
        "End" => TileTypes.End,
        "TurnLeft" => TileTypes.TurnLeft,
        "TurnRight" => TileTypes.TurnRight,
        "Forward" => TileTypes.Forward,
        "Abyss" => TileTypes.Abyss,
        _ => throw new InvalidOperationException($"Некорректный тип ячейки: {parTileType}")
      };
    }
  }
}
