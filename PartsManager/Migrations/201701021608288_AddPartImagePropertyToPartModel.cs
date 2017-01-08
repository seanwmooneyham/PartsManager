namespace PartsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartImagePropertyToPartModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "PartImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "PartImage");
        }
    }
}
