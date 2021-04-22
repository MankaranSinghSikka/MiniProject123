namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdditedServiesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Services", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "AvailableLocation", c => c.String(nullable: false));
            AddColumn("dbo.Services", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Services", "Category_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "Vendor_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Services", "Category_Id");
            CreateIndex("dbo.Services", "Vendor_Id");
            AddForeignKey("dbo.Services", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Services", "Vendor_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Services", "AddService");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "AddService", c => c.String());
            DropForeignKey("dbo.Services", "Vendor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Services", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Services", new[] { "Vendor_Id" });
            DropIndex("dbo.Services", new[] { "Category_Id" });
            DropColumn("dbo.Services", "Vendor_Id");
            DropColumn("dbo.Services", "Category_Id");
            DropColumn("dbo.Services", "Price");
            DropColumn("dbo.Services", "AvailableLocation");
            DropColumn("dbo.Services", "Available");
            DropColumn("dbo.Services", "Name");
        }
    }
}
