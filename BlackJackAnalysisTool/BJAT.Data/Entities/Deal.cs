using System.Collections.Generic;
using BJAT.Common.Enums;

namespace BJAT.Data.Entities
{
    public class Deal
    {
        public int DealId { get; set; }
        public double InitialBet { get; set; }
        public int CountOfHands { get; set; }
        public double TotalBet { get; set; }
        public double TotalPayout { get; set; }
        public double Profit { get; set; }
        public int Mistakes { get; set; }

        public virtual List<Hand> HeroHands { get; set; } = new List<Hand>();
        public virtual List<Card> DealerCards { get; set; } = new List<Card>();
        public virtual List<Hand> OtherHands { get; set; } = new List<Hand>();
        public virtual List<HeroActionsEnum> HeroActions { get; set; } = new List<HeroActionsEnum>();
    }
}
