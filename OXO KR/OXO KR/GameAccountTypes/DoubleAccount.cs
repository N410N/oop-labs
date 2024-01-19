using OXO.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXO.GameAccountTypes
{
    class DoubleAccount : GameAccount
    {
        public DoubleAccount(GameAccountService service, int Id, string userName, string password, int gamesCount = 0) : base(service, Id, userName, password, gamesCount) { }
        public override int RatingCalc(int rating)
        {
            return rating * 2;
        }
    }
}
