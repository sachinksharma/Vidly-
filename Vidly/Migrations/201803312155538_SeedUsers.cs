namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'7657d93d-f00f-4e48-864c-dfc0fd8cc548', N'admin@vidly.com', 0, N'ALz6WOQpjoOrTDr5G0AQYAEk7Ha9S1g14tSFcLC6Lvov8/73Qsa3iFg1tjS6spvopg==', N'3562ec5d-81b3-4594-b024-04d76e7dc97d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'd0e5de6a-feac-4241-baf9-7df368a1bc09', N'guest@vidly.com', 0, N'AEL2Ue+wVTz3+WyYCTuIEoxCArfASDsg6X/vsyWofPQgcvTirgdrBZ19a5xmNOjSOA==', N'e1aa7cb9-5d4f-4585-9512-1ef0948f0ed2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7657d93d-f00f-4e48-864c-dfc0fd8cc548', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')
            ");

        }

        public override void Down()
        {
        }
    }
}
