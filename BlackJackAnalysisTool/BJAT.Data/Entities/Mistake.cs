using System;
using BJAT.Common.Enums;

namespace BJAT.Data.Entities
{
    public class Mistake
    {
        public Guid MistakeId { get; set; }
        public Guid DealId { get; set; }
        public double StandPercent { get; set; }
        public double HitPercent { get; set; }
        public double DoublePercent { get; set; }
        public double SplitPercent { get; set; }
        public HeroActionsEnum HeroAction { get; set; }
        public HeroActionsEnum CorrectAction { get; set; }
    }
}
