using System;
using System.Collections.Generic;
using BJAT.Common.Enums;

namespace BJAT.Data.Entities
{
    public class Hand
    {
        public Guid HandId { get; set; }
        public Guid DealId { get; set; }
        public HandTypeEnum HandType { get; set; }
        public string Cards { get; set; }
        public int HeroValue { get; set; }
        public int DealerValue { get; set; }
        public HeroActionsEnum HeroAction { get; set; }
        public HeroActionsEnum CorrectAction { get; set; }

        public virtual List<Card> HeroCards { get; set; } = new List<Card>();
        public virtual List<Card> DealerCards { get; set; } = new List<Card>();
    }
}
