﻿using OXO.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXO.GameAccountTypes
{
    internal class StandartAccount : GameAccount
    {
        public StandartAccount(GameAccountService service, int Id, string userName, string password, int gamesCount = 0) : base(service, Id, userName, password, gamesCount) { }
        public override int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
