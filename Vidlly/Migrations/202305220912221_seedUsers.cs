namespace Vidlly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8aa9011c-d76b-4543-ace8-49bd750b509a', N'guest@vidly.com', 0, N'ABHgZvXxeVm1LEINB8V4HVw3t65MEn6eqdSFCGbz5+QnKc5CXrRG0X+fdYW3Iy7rEg==', N'fd132b49-d718-435d-a21c-49f9d2dd0bcd', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9e69f0be-8671-4cfb-99cf-04cadd3dac6f', N'admin@vidly.com', 0, N'AI/kD1CpS51JtMncPnF3L2c69P5rFLO55uSKzjDct5Q0v+8GObElpg0Zvg7xxsNUqA==', N'd0cfbfb1-001b-42be-b151-c0ce504d71d5', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1b664e37-a5c5-43e5-b5b0-41b1e094add4', N'CanManageMovie')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3a2de04e-9d49-48bb-a59a-985b60cc69ff', N'CanManageMovies')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8aa9011c-d76b-4543-ace8-49bd750b509a', N'3a2de04e-9d49-48bb-a59a-985b60cc69ff')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e69f0be-8671-4cfb-99cf-04cadd3dac6f', N'3a2de04e-9d49-48bb-a59a-985b60cc69ff')

");
        }
        
        public override void Down()
        {
        }
    }
}
