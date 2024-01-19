using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXO
{
    internal class GameResult
    {
        public string Player { get; set; }
        public string Opponent { get; set; }
        public string Winner { get; set; }
        public int Rating { get; set; }
        public int GameIndex { get; set; }

        public GameResult(string player, string opponent, string winner, int rating, int gameIndex)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            GameIndex = gameIndex;
        }
        public GameResult() { }
    }
}
