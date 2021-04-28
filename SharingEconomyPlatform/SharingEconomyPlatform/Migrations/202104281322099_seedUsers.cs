namespace SharingEconomyPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4d7f5a27-b962-4183-8217-6e8aa5913a1b', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd2c9f962-ed75-4180-add2-539b0212843e', N'Customer')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'477c265b-bbd6-4142-811c-667d9ad4413b', N'Vendor')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DOB], [Address], [City], [State], [Zip]) VALUES (N'344de462-e076-400b-b05f-b86a83cead8e', N'Bharat@admin.com', 0, N'AEYfZWLvwm2Cc85RAnbm3wEaNO4rPjFQh2zvVtk48qTeipRMc1d3+C+AiWC17OMhgQ==', N'599373ef-b2a8-4882-ab39-a493f9365775', N'7558534463', 0, 0, NULL, 1, 0, N'Bharat@admin.com', N'Bharat', N'Khairanar', N'Male', N'2021-04-17 00:00:00', N'Jay Gayatri Nagar 2', N'Surat', N'Gujrat', N'394210')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'344de462-e076-400b-b05f-b86a83cead8e', N'4d7f5a27-b962-4183-8217-6e8aa5913a1b')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
