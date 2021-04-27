namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Product_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropColumn("dbo.Carts", "Product_Id");
        }
    }
}
