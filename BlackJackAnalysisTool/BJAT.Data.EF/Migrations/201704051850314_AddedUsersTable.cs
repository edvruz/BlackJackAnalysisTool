namespace BJAT.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        LoginName = c.String(),
                        PasswordHash = c.String(),
                        Email = c.String(),
                        DisplayName = c.String(),
                        Role = c.Int(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        FailedAttemptsToConnect = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
