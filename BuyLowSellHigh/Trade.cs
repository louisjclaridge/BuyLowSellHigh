using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyLowSellHigh
{
    public class Trade
    {
        public int BuyDay { get; set; }
        public float BuyAmount { get; set; }
        public int SellDay { get; set; }
        public float SellAmount { get; set; }
        public float Profit { get; set; }

        public Trade()
        {

        }
        public Trade(int buyDay, float buyAmount, int sellDay, float sellAmount,  float profit)
        {
            BuyDay = buyDay;
            BuyAmount = buyAmount;
            SellDay = sellDay;
            SellAmount = sellAmount;
            Profit = profit;
        }
    }
}
