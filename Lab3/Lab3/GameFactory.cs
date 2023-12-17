using Lab3.DB.Service;
using Lab3.GameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class GameFactory
    {
        public Game CreateStandartGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new StandartGame(player1, player2, service);
        }
        public Game CreateUnrankedGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new UnrankedGame(player1, player2, service);
        }
        public Game CreateSafeGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new SafeGame(player1, player2, service);
        }
    }
}
