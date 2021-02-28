namespace SmartLab.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAvaliableColumnToUserRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoom", "IsAvaliable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoom", "IsAvaliable");
        }
    }
}
