using System.Collections.Generic;
using BJAT.Common.Enums;

namespace BJAT.Data.Entities
{
    public class Hand
    {
        public int HandId { get; set; }
        public int HeroValue { get; set; }
        public int DealerValue { get; set; }
        public HandResultEnum HandResult { get; set; }

        public virtual List<Card> HeroCards { get; set; } = new List<Card>();
        public virtual List<Card> DealerCards { get; set; } = new List<Card>();
        public virtual List<Card> OtherCards { get; set; } = new List<Card>();
    }
}
