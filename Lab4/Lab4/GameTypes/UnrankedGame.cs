using Lab4.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.GameTypes
{
    class UnrankedGame : Game
    {
        public UnrankedGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName)
            { return 0; }
            if (player.UserName == player2.UserName)
            { return 0; }
            return 0;
        }
    }
}
