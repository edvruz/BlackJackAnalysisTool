using System;
using System.Collections.Generic;

namespace BJAT.Data.Entities
{
    public class Deal
    {
        public Guid DealId { get; set; }
        public Guid UserId { get; set; }
        public double InitialBet { get; set; }
        public double TotalBet { get; set; }
        public double TotalPayout { get; set; }
        public double Profit { get; set; }
        public int Mistakes { get; set; }

        public virtual List<Hand> HeroHands { get; set; } = new List<Hand>();
        public virtual List<Card> DealerCards { get; set; } = new List<Card>();
        public virtual List<Mistake> HeroMistakes { get; set; } = new List<Mistake>();
    }
}
