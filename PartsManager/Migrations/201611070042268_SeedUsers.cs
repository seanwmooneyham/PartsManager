namespace PartsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], 
                        [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                        VALUES (N'34c965f8-452d-4042-a5e9-fb6c2de9230c', N'swmooneyham@gmail.com', 0, 
                        N'AOQwgebVLFhiWAD9CuL/kyVTydvLmPXAzB3qkzoX05Y1NLytiUk3vZTmKn3WHmtASA==', N'caeef3c5-1d20-453f-940f-82662c0a72e6', 
                        NULL, 0, 0, NULL, 1, 0, N'swmooneyham@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a33a3a19-9100-4425-ac73-f4d2fa1f4b14', N'guest1@fakeEmail.com', 0, N'AO8127M/KCX/xen8KAGk0tYt7MsOIir94m6r/B7ipzJad5Ulnn9u7ip6bbaD8/HwZg==', N'c105354f-70a2-4a0f-9faf-974732c9ea4b', NULL, 0, 0, NULL, 1, 0, N'guest1@fakeEmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dfd4f988-60f3-4762-974a-47da248a63be', N'admin@fakeEmail.com', 0, N'AEuJgZk5xkr4Ft5JiVwW0RDbdhQTf77iAQ6LrKzSvyqcQ77AJigRIOjc7J/0ai+BYA==', N'58b7e9b2-cb2c-4f0e-bdee-d4b2fba7f6c1', NULL, 0, 0, NULL, 1, 0, N'admin@fakeEmail.com')
                    
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2112b5c1-31b3-4ae3-a02a-35a69dac6b0f', N'CanManageParts')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34c965f8-452d-4042-a5e9-fb6c2de9230c', 
                        N'2112b5c1-31b3-4ae3-a02a-35a69dac6b0f')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dfd4f988-60f3-4762-974a-47da248a63be', N'2112b5c1-31b3-4ae3-a02a-35a69dac6b0f')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
