namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.customer", "SiteUserId", "dbo.site_user");
            DropForeignKey("dbo.employee", "SiteUserId", "dbo.site_user");
            DropIndex("dbo.customer", new[] { "SiteUserId" });
            DropIndex("dbo.employee", new[] { "SiteUserId" });
            AlterColumn("dbo.customer", "SiteUserId", c => c.Int());
            AlterColumn("dbo.employee", "SiteUserId", c => c.Int());
            CreateIndex("dbo.customer", "SiteUserId");
            CreateIndex("dbo.employee", "SiteUserId");
            AddForeignKey("dbo.customer", "SiteUserId", "dbo.site_user", "SiteUserId");
            AddForeignKey("dbo.employee", "SiteUserId", "dbo.site_user", "SiteUserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.employee", "SiteUserId", "dbo.site_user");
            DropForeignKey("dbo.customer", "SiteUserId", "dbo.site_user");
            DropIndex("dbo.employee", new[] { "SiteUserId" });
            DropIndex("dbo.customer", new[] { "SiteUserId" });
            AlterColumn("dbo.employee", "SiteUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.customer", "SiteUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.employee", "SiteUserId");
            CreateIndex("dbo.customer", "SiteUserId");
            AddForeignKey("dbo.employee", "SiteUserId", "dbo.site_user", "SiteUserId", cascadeDelete: true);
            AddForeignKey("dbo.customer", "SiteUserId", "dbo.site_user", "SiteUserId", cascadeDelete: true);
        }
    }
}
