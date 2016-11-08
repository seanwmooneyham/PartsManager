namespace PartsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeIdToIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeId", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmployeeId");
        }
    }
}
