using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.AccountTypes
{
    class DoubleAccount : GameAccount
    {
        public DoubleAccount(string userName) : base(userName) { }
        public override int RatingCalc(int rating)
        {
            return rating * 2;
        }
    }
}
