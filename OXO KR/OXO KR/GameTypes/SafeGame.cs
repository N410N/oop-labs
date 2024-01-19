using OXO.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OXO.GameTypes
{
    class SafeGame : Game
    {
        public SafeGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName && player.UserName == winner)
            { return playRating; }
            else if (player.UserName == player1.UserName && player.UserName != winner)
            { return 0; }

            if (player.UserName == player2.UserName && player.UserName == winner)
            { return playRating; }
            else if (player.UserName == player2.UserName && player.UserName != winner)
            { return 0; }

            return 0;
        }
    }
}
