using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.GameTypes
{
    class SafeGame : Game
    {
        public SafeGame(GameAccount player1, GameAccount player2) : base(player1, player2) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName && player.UserName == winner) { return playRating; }
            else if (player.UserName == player1.UserName && player.UserName != winner) { return 0; }

            if (player.UserName == player2.UserName && player.UserName == winner) { return playRating; }
            else if (player.UserName == player2.UserName && player.UserName != winner) { return 0; }

            return 0;
        }
    }
}
