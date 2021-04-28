namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Product_Id = c.Int(),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Vendor_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Vendor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "Vendor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProductOrders", new[] { "Vendor_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Customer_Id" });
            DropTable("dbo.ProductOrders");
        }
    }
}
