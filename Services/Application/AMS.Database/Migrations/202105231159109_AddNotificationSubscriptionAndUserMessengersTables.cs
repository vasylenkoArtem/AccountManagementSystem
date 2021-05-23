namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationSubscriptionAndUserMessengersTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificationSubscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserMessengerId = c.Int(nullable: false),
                        ActionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserMessenger", t => t.UserMessengerId, cascadeDelete: true)
                .Index(t => t.UserMessengerId);
            
            CreateTable(
                "dbo.UserMessenger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessengerId = c.Int(nullable: false),
                        UserIndetifier = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationSubscription", "UserMessengerId", "dbo.UserMessenger");
            DropForeignKey("dbo.UserMessenger", "User_Id", "dbo.User");
            DropIndex("dbo.UserMessenger", new[] { "User_Id" });
            DropIndex("dbo.NotificationSubscription", new[] { "UserMessengerId" });
            DropTable("dbo.UserMessenger");
            DropTable("dbo.NotificationSubscription");
        }
    }
}
