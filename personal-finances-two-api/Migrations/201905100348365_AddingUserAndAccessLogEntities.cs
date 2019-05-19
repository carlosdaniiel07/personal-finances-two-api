namespace personal_finances_two_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserAndAccessLogEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nickname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Token = c.String(),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccessLogs", "UserId", "dbo.Users");
            DropIndex("dbo.AccessLogs", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.AccessLogs");
        }
    }
}
