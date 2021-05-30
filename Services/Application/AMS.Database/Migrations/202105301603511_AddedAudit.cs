namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAudit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditEntry",
                c => new
                    {
                        AuditEntryID = c.Int(nullable: false, identity: true),
                        EntitySetName = c.String(maxLength: 255),
                        EntityTypeName = c.String(maxLength: 255),
                        State = c.Int(nullable: false),
                        StateName = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.AuditEntryProperty",
                c => new
                    {
                        AuditEntryPropertyID = c.Int(nullable: false, identity: true),
                        AuditEntryID = c.Int(nullable: false),
                        RelationName = c.String(maxLength: 255),
                        PropertyName = c.String(maxLength: 255),
                        OldValue = c.String(),
                        NewValue = c.String(),
                    })
                .PrimaryKey(t => t.AuditEntryPropertyID)
                .ForeignKey("dbo.AuditEntry", t => t.AuditEntryID, cascadeDelete: true)
                .Index(t => t.AuditEntryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditEntryProperty", "AuditEntryID", "dbo.AuditEntry");
            DropIndex("dbo.AuditEntryProperty", new[] { "AuditEntryID" });
            DropTable("dbo.AuditEntryProperty");
            DropTable("dbo.AuditEntry");
        }
    }
}
