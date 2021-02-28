namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitilaScheme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 10),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number, unique: true);
            
            CreateTable(
                "dbo.UserRoom",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        UserTypeId = c.Int(nullable: false),
                        IdentityLockUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoom", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRoom", "RoomId", "dbo.Room");
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.UserRoom", new[] { "RoomId" });
            DropIndex("dbo.UserRoom", new[] { "UserId" });
            DropIndex("dbo.Room", new[] { "Number" });
            DropTable("dbo.User");
            DropTable("dbo.UserRoom");
            DropTable("dbo.Room");
        }
    }
}
