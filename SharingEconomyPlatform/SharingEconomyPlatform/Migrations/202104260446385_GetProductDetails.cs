namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetProductDetails : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "GetProductDetail",
                p => new {},
                @"select Products.*,Categories.Name as CatName, AspNetUsers.FirstName, AspNetUsers.LastName, AspNetUsers.Address,AspNetUsers.City,AspNetUsers.State,AspNetUsers.PhoneNumber,AspNetUsers.Email
                    from Products
                    join Categories on Products.Category_Id = Categories.Id
                    join AspNetUsers on Products.Vendor_Id = AspNetUsers.Id"
                );
        }
        
        public override void Down()
        {
            DropStoredProcedure("GetProductDetail");
        }
    }
}
