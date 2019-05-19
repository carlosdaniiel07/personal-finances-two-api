namespace personal_finances_two_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        AccountType = c.Int(nullable: false),
                        InitialBalance = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 1),
                        Description = c.String(nullable: false),
                        Value = c.Double(nullable: false),
                        Increase = c.Double(),
                        Decrease = c.Double(),
                        InclusionDate = c.DateTime(nullable: false),
                        AccountingDate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        InvoiceId = c.Int(),
                        MovementStatus = c.Int(nullable: false),
                        Observation = c.String(),
                        CanEdit = c.Boolean(nullable: false),
                        AutomaticallyLaunch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.AccountId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubcategoryId)
                .Index(t => t.ProjectId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Type = c.String(nullable: false, maxLength: 1),
                        Enabled = c.Boolean(nullable: false),
                        CanEdit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        CategoryId = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CanEdit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(maxLength: 8),
                        MaturityDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(),
                        Closed = c.Boolean(nullable: false),
                        InvoiceStatus = c.Int(nullable: false),
                        TotalValue = c.Double(nullable: false),
                        CreditCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardId)
                .Index(t => t.CreditCardId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        InvoiceClosure = c.String(nullable: false, maxLength: 2),
                        PayDay = c.String(nullable: false, maxLength: 2),
                        Limit = c.Double(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(),
                        Budget = c.Double(),
                        Description = c.String(maxLength: 100),
                        ProjectStatus = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        OriginId = c.Int(nullable: false),
                        TargetId = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Tax = c.Double(),
                        InclusionDate = c.DateTime(nullable: false),
                        AccountingDate = c.DateTime(nullable: false),
                        TransferStatus = c.Int(nullable: false),
                        AutomaticallyLaunch = c.Boolean(nullable: false),
                        Observation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.OriginId)
                .ForeignKey("dbo.Accounts", t => t.TargetId)
                .Index(t => t.OriginId)
                .Index(t => t.TargetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "TargetId", "dbo.Accounts");
            DropForeignKey("dbo.Transfers", "OriginId", "dbo.Accounts");
            DropForeignKey("dbo.Movements", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Movements", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CreditCardId", "dbo.CreditCards");
            DropForeignKey("dbo.Movements", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Movements", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Movements", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Transfers", new[] { "TargetId" });
            DropIndex("dbo.Transfers", new[] { "OriginId" });
            DropIndex("dbo.Invoices", new[] { "CreditCardId" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.Movements", new[] { "InvoiceId" });
            DropIndex("dbo.Movements", new[] { "ProjectId" });
            DropIndex("dbo.Movements", new[] { "SubcategoryId" });
            DropIndex("dbo.Movements", new[] { "CategoryId" });
            DropIndex("dbo.Movements", new[] { "AccountId" });
            DropTable("dbo.Transfers");
            DropTable("dbo.Projects");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Invoices");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Movements");
            DropTable("dbo.Accounts");
        }
    }
}
