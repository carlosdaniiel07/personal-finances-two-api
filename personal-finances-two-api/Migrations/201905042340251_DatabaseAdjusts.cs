namespace personal_finances_two_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAdjusts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "TotalValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "TotalValue", c => c.Double(nullable: false));
        }
    }
}
