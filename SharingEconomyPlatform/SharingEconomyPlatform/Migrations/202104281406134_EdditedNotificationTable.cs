namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdditedNotificationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Notifications", "Read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Read");
            DropColumn("dbo.Notifications", "Time");
        }
    }
}
