namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHelpTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Helprequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Time = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Helprequests", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Helprequests", new[] { "User_Id" });
            DropTable("dbo.Helprequests");
        }
    }
}
