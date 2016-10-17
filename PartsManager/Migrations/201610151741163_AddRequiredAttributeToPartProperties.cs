namespace PartsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAttributeToPartProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parts", "PartName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Parts", "PartNumber", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Parts", "ManufacturerCode", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parts", "ManufacturerCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.Parts", "PartNumber", c => c.String(maxLength: 255));
            AlterColumn("dbo.Parts", "PartName", c => c.String(maxLength: 255));
        }
    }
}
