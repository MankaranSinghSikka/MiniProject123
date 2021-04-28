namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Service_Id = c.Int(),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Vendor_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.Vendor_Id);
            
            AddColumn("dbo.ProductOrders", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.ProductOrders", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceOrders", "Vendor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ServiceOrders", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceOrders", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ServiceOrders", new[] { "Vendor_Id" });
            DropIndex("dbo.ServiceOrders", new[] { "Service_Id" });
            DropIndex("dbo.ServiceOrders", new[] { "Customer_Id" });
            DropColumn("dbo.ProductOrders", "Time");
            DropColumn("dbo.ProductOrders", "Amount");
            DropTable("dbo.ServiceOrders");
        }
    }
}
