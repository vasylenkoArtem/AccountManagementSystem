namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNotificationTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserPrinter", "AllowedPlasticQuantity", c => c.Int());
            DropTable("dbo.Notification");
        }
        
        public override void Down()
        {
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
            
            AlterColumn("dbo.UserPrinter", "AllowedPlasticQuantity", c => c.String());
        }
    }
}
