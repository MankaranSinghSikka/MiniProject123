namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdditedProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Products", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "AvailableLocation", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Vendor_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Products", "Vendor_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Vendor_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "AddCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "AddCategory", c => c.String());
            DropForeignKey("dbo.Products", "Vendor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Vendor_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "Vendor_Id");
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "AvailableLocation");
            DropColumn("dbo.Products", "Stock");
            DropColumn("dbo.Products", "Name");
        }
    }
}
