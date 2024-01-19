using OXO.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXO.GameTypes
{
    class StandartGame : Game
    {
        public StandartGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName)
            { return playRating; }
            if (player.UserName == player2.UserName)
            { return playRating; }
            return 0;
        }
    }
}
