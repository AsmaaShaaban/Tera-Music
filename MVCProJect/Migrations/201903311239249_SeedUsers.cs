namespace MVCProJect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
			Sql(@"
			INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'05a80e9c-9c51-43dc-9d51-f2ef94e26808', N'Asmaa@domain.com', 0, N'AGwhSsHneqxtxFVWS2hxqPXjbUiWMZdVALQZ2+CxVxP+nCbMMc2tIvFUxWyAYRxJDA==', N'0adc7dc3-2ea6-4e4e-b447-86dd8a1c1c92', NULL, 0, 0, NULL, 1, 0, N'Asmaa@domain.com')

			INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'47c1e51b-cb67-44b8-87bf-71a04cb8e247', N'Admin@TeraMusic.com', 0, N'AGlMZKk2tu5MWHtlaxqu22LZMvx00q0BbKrtfo0B9HKIwLjHKdYbZnymcJlhmjsLQw==', N'e3dc597c-f7ca-482f-a115-5cf145f048a7', NULL, 0, 0, NULL, 1, 0, N'Admin@TeraMusic.com')
			INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4fbf853b-f83c-4389-a16e-10182a92811f', N'ManageActivities')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'47c1e51b-cb67-44b8-87bf-71a04cb8e247', N'4fbf853b-f83c-4389-a16e-10182a92811f')
");
		}
        
        public override void Down()
        {
        }
    }
}
