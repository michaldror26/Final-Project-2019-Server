namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.site_user", "UserId", "dbo.user");
            DropIndex("dbo.site_user", new[] { "UserId" });
            DropPrimaryKey("dbo.site_user");
            AddColumn("dbo.customer", "SiteUserId", c => c.Int(nullable: false));
            AddColumn("dbo.employee", "SiteUserId", c => c.Int(nullable: false));
            AddColumn("dbo.site_user", "SiteUserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.site_user", "SiteUserId");
            CreateIndex("dbo.customer", "SiteUserId");
            CreateIndex("dbo.employee", "SiteUserId");
            AddForeignKey("dbo.customer", "SiteUserId", "dbo.site_user", "SiteUserId", cascadeDelete: true);
            AddForeignKey("dbo.employee", "SiteUserId", "dbo.site_user", "SiteUserId", cascadeDelete: true);
            DropColumn("dbo.site_user", "UserId");
            DropColumn("dbo.site_user", "UserSiteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.site_user", "UserSiteId", c => c.Int(nullable: false));
            AddColumn("dbo.site_user", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.employee", "SiteUserId", "dbo.site_user");
            DropForeignKey("dbo.customer", "SiteUserId", "dbo.site_user");
            DropIndex("dbo.employee", new[] { "SiteUserId" });
            DropIndex("dbo.customer", new[] { "SiteUserId" });
            DropPrimaryKey("dbo.site_user");
            DropColumn("dbo.site_user", "SiteUserId");
            DropColumn("dbo.employee", "SiteUserId");
            DropColumn("dbo.customer", "SiteUserId");
            AddPrimaryKey("dbo.site_user", "UserId");
            CreateIndex("dbo.site_user", "UserId");
            AddForeignKey("dbo.site_user", "UserId", "dbo.user", "UserId");
        }
    }
}
