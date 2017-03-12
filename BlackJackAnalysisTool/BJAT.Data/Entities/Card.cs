using BJAT.Common.Enums;

namespace BJAT.Data.Entities
{
    public class Card
    {
        public int CardId { get; set; }
        public int Value  { get; set; }
        public CardSuitEnum Suit { get; set; }
        public string Image { get; set; }
        public string Image4Colors { get; set; }

        public virtual Hand Hand { get; set; }
    }
}
