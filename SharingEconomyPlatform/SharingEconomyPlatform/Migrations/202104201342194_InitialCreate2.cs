namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddService = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Products", "AddCategory", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "AddCategory", c => c.String(nullable: false));
            DropTable("dbo.Services");
        }
    }
}
