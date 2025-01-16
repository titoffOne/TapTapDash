using Model.Game.Levels;
using Model.Geometry;

namespace Model.Game
{
  /// <summary>
  /// Тесты для игрового персонажа - кота
  /// </summary>
  [TestClass]
  public class CatTests
  {
    /// <summary>
    /// Проверяет, что конструктор без параметров корректно инициализирует объект Cat
    /// </summary>
    [TestMethod]
    public void Constructor_WithoutParameters_InitializesCorrectly()
    {
      var cat = new Cat();
      Assert.AreEqual(0, cat.Position.X);
      Assert.AreEqual(0, cat.Position.Y);
      Assert.AreEqual(DirectionType.Up, cat.Direction);
      Assert.IsTrue(cat.IsAlive);
      Assert.AreEqual(0, cat.CoinsCollected);
    }

    /// <summary>
    /// Проверяет, что конструктор с параметрами корректно инициализирует объект Cat
    /// </summary>
    [TestMethod]
    public void Constructor_WithParameters_InitializesCorrectly()
    {
      var cat = new Cat(DirectionType.Left, 5, true);
      Assert.AreEqual(DirectionType.Left, cat.Direction);
      Assert.AreEqual(5, cat.CoinsCollected);
      Assert.IsTrue(cat.IsAlive);
    }

    /// <summary>
    /// Проверяет, что конструктор с полным набором параметров корректно инициализирует объект Cat
    /// </summary>
    [TestMethod]
    public void Constructor_WithAllParameters_InitializesCorrectly()
    {
      var position = new Position<int>(2, 3);
      var size = new Size<int>(4, 5);
      var rotation = new Rotation<int>(90);

      var cat = new Cat(position, size, rotation, DirectionType.Right, 7, false);

      Assert.AreEqual(position, cat.Position);
      Assert.AreEqual(size, cat.Size);
      Assert.AreEqual(rotation, cat.Rotation);
      Assert.AreEqual(DirectionType.Right, cat.Direction);
      Assert.AreEqual(7, cat.CoinsCollected);
      Assert.IsFalse(cat.IsAlive);
    }

    /// <summary>
    /// Проверяет, что изменение направления вызывает событие DirectionChanged
    /// </summary>
    [TestMethod]
    public void ChangeDirection_InvokesDirectionChangedEvent()
    {
      var cat = new Cat();
      bool eventRaised = false;
      cat.DirectionChanged += () => eventRaised = true;

      cat.ChangeDirection(TileTypes.Forward);

      Assert.IsTrue(eventRaised);
    }

    /// <summary>
    /// Проверяет, что метод ChangeDirectionTurnLeft корректно меняет направление влево
    /// </summary>
    [TestMethod]
    public void ChangeDirectionTurnLeft_ChangesDirectionCorrectly()
    {
      var cat = new Cat();
      cat.Direction = DirectionType.Up;

      cat.ChangeDirectionTurnLeft();

      Assert.AreEqual(DirectionType.Left, cat.Direction);
    }

    /// <summary>
    /// Проверяет, что метод ChangeDirectionTurnRight корректно меняет направление вправо
    /// </summary>
    [TestMethod]
    public void ChangeDirectionTurnRight_ChangesDirectionCorrectly()
    {
      var cat = new Cat();
      cat.Direction = DirectionType.Up;

      cat.ChangeDirectionTurnRight();

      Assert.AreEqual(DirectionType.Right, cat.Direction);
    }

    /// <summary>
    /// Проверяет, что состояние кота обновляется при сборе монеты
    /// </summary>
    [TestMethod]
    public void CheckCatState_OnCoin_IncreasesCoinsCollected()
    {
      var cat = new Cat();
      var tile = new Tile(TileTypes.Coin);

      cat.CheckCatState(tile);

      Assert.AreEqual(1, cat.CoinsCollected);
      Assert.AreEqual(TileTypes.Empty, tile.Type);
    }

    /// <summary>
    /// Проверяет, что состояние кота обновляется при попадании в пропасть
    /// </summary>
    [TestMethod]
    public void CheckCatState_OnAbyss_SetsIsAliveToFalse()
    {
      var cat = new Cat();
      var tile = new Tile(TileTypes.Abyss);

      cat.CheckCatState(tile);

      Assert.IsFalse(cat.IsAlive);
    }

    /// <summary>
    /// Проверяет, что прыжок устанавливает флаг _jumpPerformed
    /// </summary>
    [TestMethod]
    public void ChangeDirection_OnForwardTile_SetsJumpPerformed()
    {
      var cat = new Cat();
      cat.ChangeDirection(TileTypes.Forward);

      Assert.IsTrue((bool)cat.GetType()
          .GetField("_jumpPerformed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
          ?.GetValue(cat)!);
    }

    /// <summary>
    /// Проверяет, что изменение направления на ячейке Forward вызывает событие SizeIncreased
    /// </summary>
    [TestMethod]
    public void ChangeDirection_OnForwardTile_InvokesSizeIncreased()
    {
      var cat = new Cat();
      bool eventRaised = false;
      cat.SizeIncreased += () => eventRaised = true;

      cat.ChangeDirection(TileTypes.Forward);

      Assert.IsTrue(eventRaised);
    }

    /// <summary>
    /// Проверяет, что направление меняется по часовой стрелке
    /// </summary>
    [TestMethod]
    [DataRow(DirectionType.Up, DirectionType.Right)]
    [DataRow(DirectionType.Right, DirectionType.Down)]
    [DataRow(DirectionType.Down, DirectionType.Left)]
    [DataRow(DirectionType.Left, DirectionType.Up)]
    public void ChangeDirection_ChangesDirectionClockwise(DirectionType initial, DirectionType expected)
    {
      var cat = new Cat { Direction = initial };
      cat.ChangeDirection();
      Assert.AreEqual(expected, cat.Direction);
    }

    /// <summary>
    /// Проверяет, что событие SizeDecreased вызывается при изменении состояния кота
    /// </summary>
    [TestMethod]
    public void CheckCatState_TriggersSizeDecreasedEvent()
    {
      var cat = new Cat();
      bool eventRaised = false;
      cat.SizeDecreased += () => eventRaised = true;

      cat.CheckCatState(new Tile(TileTypes.Forward));

      Assert.IsTrue(eventRaised);
    }

    /// <summary>
    /// Проверяет, что конструктор устанавливает позицию по умолчанию
    /// </summary>
    [TestMethod]
    public void Constructor_SetsDefaultPosition()
    {
      var cat = new Cat();
      Assert.AreEqual(0, cat.Position.X);
      Assert.AreEqual(0, cat.Position.Y);
    }

    /// <summary>
    /// Проверяет, что направление изменяется в зависимости от типа ячейки
    /// </summary>
    [TestMethod]
    [DataRow(TileTypes.TurnLeft, DirectionType.Up, DirectionType.Left)]
    [DataRow(TileTypes.TurnRight, DirectionType.Up, DirectionType.Right)]
    [DataRow(TileTypes.TurnLeft, DirectionType.Left, DirectionType.Down)]
    [DataRow(TileTypes.TurnRight, DirectionType.Left, DirectionType.Up)]
    public void ChangeDirection_OnTileType_ChangesDirection(TileTypes tileType, DirectionType initial, DirectionType expected)
    {
      var cat = new Cat { Direction = initial };
      cat.ChangeDirection(tileType);
      Assert.AreEqual(expected, cat.Direction);
    }

    /// <summary>
    /// Проверяет, что количество собранных монет увеличивается корректно
    /// </summary>
    [TestMethod]
    public void CoinsCollected_IncrementsCorrectly()
    {
      var cat = new Cat();
      cat.CoinsCollected = 5;
      cat.CheckCatState(new Tile(TileTypes.Coin));

      Assert.AreEqual(6, cat.CoinsCollected);
    }

    /// <summary>
    /// Проверяет, что состояние isAlive изменяется на false при попадании в пропасть
    /// </summary>
    [TestMethod]
    public void IsAlive_ChangesToFalseWhenFallingIntoAbyss()
    {
      var cat = new Cat { IsAlive = true };
      cat.CheckCatState(new(TileTypes.Abyss));

      Assert.IsFalse(cat.IsAlive);
    }

    /// <summary>
    /// Проверяет, что событие SizeDecreased вызывается после прыжка
    /// </summary>
    [TestMethod]
    public void CheckCatState_DecreasesSizeAfterJump()
    {
      var cat = new Cat();
      bool eventRaised = false;
      cat.SizeDecreased += () => eventRaised = true;

      cat.CheckCatState(new Tile(TileTypes.Forward));

      Assert.IsTrue(eventRaised);
    }

    /// <summary>
    /// Проверяет, что угол поворота обновляется корректно
    /// </summary>
    [TestMethod]
    public void Rotation_UpdatesCorrectly()
    {
      var cat = new Cat();
      cat.Rotation = new Rotation<int>(90);
      Assert.AreEqual(90, cat.Rotation.Angle);
    }
  }
}
