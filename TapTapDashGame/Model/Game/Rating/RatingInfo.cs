using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Records
{
  public class RatingInfo
  {
    public string PlayerName { get; set; }

    public int TotalScore { get; set; }

    public int CurrentScore { get; set; }

    public RatingInfo() { }

    public RatingInfo(string parPlayerName) : this(parPlayerName, 0, 0)
    {
    }

    public RatingInfo(string parPlayerName, int parTotalScore, int parCurrentScore)
    {
      PlayerName = parPlayerName;
      TotalScore = parTotalScore;
      CurrentScore = parCurrentScore;
    }
  }
}
