namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.inventory", "Product_ProductId", "dbo.product");
            DropIndex("dbo.inventory", new[] { "Product_ProductId" });
            DropColumn("dbo.inventory", "ProductId");
            RenameColumn(table: "dbo.inventory", name: "Product_ProductId", newName: "ProductId");
            DropPrimaryKey("dbo.inventory");
            AddColumn("dbo.customer", "SiteUserId", c => c.Int(nullable: false));
            AddColumn("dbo.employee", "SiteUserId", c => c.Int(nullable: false));
            AddColumn("dbo.inventory", "InventoryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.inventory", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.inventory", "ProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.inventory", "InventoryId");
            CreateIndex("dbo.inventory", "ProductId");
            CreateIndex("dbo.customer", "SiteUserId");
            CreateIndex("dbo.employee", "SiteUserId");
            AddForeignKey("dbo.customer", "SiteUserId", "dbo.site_user", "SiteUserId", cascadeDelete: true);
            AddForeignKey("dbo.employee", "SiteUserId", "dbo.site_user", "SiteUserId", cascadeDelete: true);
            AddForeignKey("dbo.inventory", "ProductId", "dbo.product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.inventory", "ProductId", "dbo.product");
            DropForeignKey("dbo.employee", "SiteUserId", "dbo.site_user");
            DropForeignKey("dbo.customer", "SiteUserId", "dbo.site_user");
            DropIndex("dbo.employee", new[] { "SiteUserId" });
            DropIndex("dbo.customer", new[] { "SiteUserId" });
            DropIndex("dbo.inventory", new[] { "ProductId" });
            DropPrimaryKey("dbo.inventory");
            AlterColumn("dbo.inventory", "ProductId", c => c.Int());
            AlterColumn("dbo.inventory", "ProductId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.inventory", "InventoryId");
            DropColumn("dbo.employee", "SiteUserId");
            DropColumn("dbo.customer", "SiteUserId");
            AddPrimaryKey("dbo.inventory", "ProductId");
            RenameColumn(table: "dbo.inventory", name: "ProductId", newName: "Product_ProductId");
            AddColumn("dbo.inventory", "ProductId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.inventory", "Product_ProductId");
            AddForeignKey("dbo.inventory", "Product_ProductId", "dbo.product", "ProductId");
        }
    }
}
