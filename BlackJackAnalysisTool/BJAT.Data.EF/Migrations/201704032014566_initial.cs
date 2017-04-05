namespace BJAT.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Suit = c.Int(nullable: false),
                        Image = c.String(),
                        Image4Colors = c.String(),
                        Deal_DealId = c.Guid(),
                        Hand_HandId = c.Guid(),
                        Hand_HandId1 = c.Guid(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Deals", t => t.Deal_DealId)
                .ForeignKey("dbo.Hands", t => t.Hand_HandId)
                .ForeignKey("dbo.Hands", t => t.Hand_HandId1)
                .Index(t => t.Deal_DealId)
                .Index(t => t.Hand_HandId)
                .Index(t => t.Hand_HandId1);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        DealId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        InitialBet = c.Double(nullable: false),
                        TotalBet = c.Double(nullable: false),
                        TotalPayout = c.Double(nullable: false),
                        Profit = c.Double(nullable: false),
                        Mistakes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealId);
            
            CreateTable(
                "dbo.Hands",
                c => new
                    {
                        HandId = c.Guid(nullable: false),
                        DealId = c.Guid(nullable: false),
                        HandType = c.Int(nullable: false),
                        Cards = c.String(),
                        HeroValue = c.Int(nullable: false),
                        DealerValue = c.Int(nullable: false),
                        HeroAction = c.Int(nullable: false),
                        CorrectAction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HandId)
                .ForeignKey("dbo.Deals", t => t.DealId, cascadeDelete: true)
                .Index(t => t.DealId);
            
            CreateTable(
                "dbo.Mistakes",
                c => new
                    {
                        MistakeId = c.Guid(nullable: false),
                        DealId = c.Guid(nullable: false),
                        StandPercent = c.Double(nullable: false),
                        HitPercent = c.Double(nullable: false),
                        DoublePercent = c.Double(nullable: false),
                        SplitPercent = c.Double(nullable: false),
                        HeroAction = c.Int(nullable: false),
                        CorrectAction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MistakeId)
                .ForeignKey("dbo.Deals", t => t.DealId, cascadeDelete: true)
                .Index(t => t.DealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mistakes", "DealId", "dbo.Deals");
            DropForeignKey("dbo.Hands", "DealId", "dbo.Deals");
            DropForeignKey("dbo.Cards", "Hand_HandId1", "dbo.Hands");
            DropForeignKey("dbo.Cards", "Hand_HandId", "dbo.Hands");
            DropForeignKey("dbo.Cards", "Deal_DealId", "dbo.Deals");
            DropIndex("dbo.Mistakes", new[] { "DealId" });
            DropIndex("dbo.Hands", new[] { "DealId" });
            DropIndex("dbo.Cards", new[] { "Hand_HandId1" });
            DropIndex("dbo.Cards", new[] { "Hand_HandId" });
            DropIndex("dbo.Cards", new[] { "Deal_DealId" });
            DropTable("dbo.Mistakes");
            DropTable("dbo.Hands");
            DropTable("dbo.Deals");
            DropTable("dbo.Cards");
        }
    }
}
