namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Printer_IoT_Computer_Notification_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatingSystemId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.IoTComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IoTSetComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IoTSetId = c.Int(nullable: false),
                        IoTComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IoTComponent", t => t.IoTComponentId, cascadeDelete: true)
                .ForeignKey("dbo.IoTSet", t => t.IoTSetId, cascadeDelete: true)
                .Index(t => t.IoTSetId)
                .Index(t => t.IoTComponentId);
            
            CreateTable(
                "dbo.IoTSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                        IssuedDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        IsReturned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        AttachmentPath = c.String(),
                        AttachmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Printer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserComputer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComputerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        ValidFrom = c.DateTime(),
                        ValidTo = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computer", t => t.ComputerId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ComputerId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPrinter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PrinterId = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        AllowedPlasticTypes = c.String(),
                        AllowedPlasticQuantity = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPrinter", "UserId", "dbo.User");
            DropForeignKey("dbo.UserComputer", "UserId", "dbo.User");
            DropForeignKey("dbo.UserComputer", "ComputerId", "dbo.Computer");
            DropForeignKey("dbo.IoTSetComponent", "IoTSetId", "dbo.IoTSet");
            DropForeignKey("dbo.IoTSetComponent", "IoTComponentId", "dbo.IoTComponent");
            DropForeignKey("dbo.Computer", "RoomId", "dbo.Room");
            DropIndex("dbo.UserPrinter", new[] { "UserId" });
            DropIndex("dbo.UserComputer", new[] { "UserId" });
            DropIndex("dbo.UserComputer", new[] { "ComputerId" });
            DropIndex("dbo.IoTSetComponent", new[] { "IoTComponentId" });
            DropIndex("dbo.IoTSetComponent", new[] { "IoTSetId" });
            DropIndex("dbo.Computer", new[] { "RoomId" });
            DropTable("dbo.UserPrinter");
            DropTable("dbo.UserComputer");
            DropTable("dbo.Printer");
            DropTable("dbo.Notification");
            DropTable("dbo.IoTSet");
            DropTable("dbo.IoTSetComponent");
            DropTable("dbo.IoTComponent");
            DropTable("dbo.Computer");
        }
    }
}
