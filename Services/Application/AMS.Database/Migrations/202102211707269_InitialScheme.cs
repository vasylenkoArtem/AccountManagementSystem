namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialScheme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 10),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number, unique: true);
            
            CreateTable(
                "dbo.UserRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Users",
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
                .Index(t => t.Email, unique: true)
                .Index(t => t.IdentityLockUserId, name: "IdentityLockUserId_Index");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRooms", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRooms", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Users", "IdentityLockUserId_Index");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.UserRooms", new[] { "RoomId" });
            DropIndex("dbo.UserRooms", new[] { "UserId" });
            DropIndex("dbo.Rooms", new[] { "Number" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRooms");
            DropTable("dbo.Rooms");
        }
    }
}
