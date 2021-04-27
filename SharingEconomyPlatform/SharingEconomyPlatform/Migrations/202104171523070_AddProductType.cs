namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ProductPrice = c.Int(nullable: false),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "ProductTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ProductType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "ProductType_Id");
            AddForeignKey("dbo.Customers", "ProductType_Id", "dbo.ProductTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProductType_Id", "dbo.ProductTypes");
            DropIndex("dbo.Customers", new[] { "ProductType_Id" });
            DropColumn("dbo.Customers", "ProductType_Id");
            DropColumn("dbo.Customers", "ProductTypeId");
            DropTable("dbo.ProductTypes");
        }
    }
}
