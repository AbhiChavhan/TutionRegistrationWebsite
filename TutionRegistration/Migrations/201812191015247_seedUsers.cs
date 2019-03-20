namespace TutionRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'272e02a5-82c1-46b3-97b3-c1435b7223f8', N'guest@vidly.com', 0, N'AKazr1ttWJGLO4YlbKH4YT9Fl7x9JT4YOgwE0+cWz/naCkqwb7GJpwcNMy2/uJ3A4g==', N'00d489ae-d31c-4db3-8042-a20469d994a4', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aaadfce5-0f48-4c05-a7c7-b1464ee9ddfc', N'admin@gmail.com', 0, N'AMiI8UWPEJPHA2x3P3FEvSjMJuNfnr5m5eH9BfBAC+cFbm3T2qahIACbcyhamiAJ3g==', N'f9e8ceca-b367-497e-ba84-01f37b849f62', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd55d7d2b-c874-46f3-ac3d-a6b600ae4e6e', N'CanHandleEverything')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aaadfce5-0f48-4c05-a7c7-b1464ee9ddfc', N'd55d7d2b-c874-46f3-ac3d-a6b600ae4e6e')


");
        }
        
        public override void Down()
        {
        }
    }
}
