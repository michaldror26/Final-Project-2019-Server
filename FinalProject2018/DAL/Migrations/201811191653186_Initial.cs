namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.authentication_type",
                c => new
                    {
                        AuthenticationTypeId = c.Int(nullable: false, identity: true),
                        AuthName = c.String(),
                    })
                .PrimaryKey(t => t.AuthenticationTypeId);
            
            CreateTable(
                "dbo.site_user",
                c => new
                    {
                        SiteUserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        AuthenticationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SiteUserId)
                .ForeignKey("dbo.authentication_type", t => t.AuthenticationTypeId, cascadeDelete: true)
                .Index(t => t.AuthenticationTypeId);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.category", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SellingPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.customer_payment",
                c => new
                    {
                        CustomerPaymentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        amount = c.Single(nullable: false),
                        circulationMedium = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerPaymentId)
                .ForeignKey("dbo.customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        SiteUserId = c.Int(nullable: true),
                        RegisteredDate = c.DateTime(nullable: false),
                        DiscountPercentage = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        Telephone = c.String(),
                        City = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.site_user", t => t.SiteUserId, cascadeDelete: true)
                .Index(t => t.SiteUserId);
            
            CreateTable(
                "dbo.sale_order",
                c => new
                    {
                        SaleOrderId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.SaleOrderId)
                .ForeignKey("dbo.customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.sale_order_product",
                c => new
                    {
                        SaleOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleOrderId, t.ProductId })
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.sale_order", t => t.SaleOrderId, cascadeDelete: true)
                .Index(t => t.SaleOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.sale_shipping_certificate",
                c => new
                    {
                        SaleShippingCertificateId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.SaleShippingCertificateId)
                .ForeignKey("dbo.customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.sale_shipping_certificate_product",
                c => new
                    {
                        SaleShippingCertificateId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PricePerProduct = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleShippingCertificateId, t.ProductId })
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.sale_shipping_certificate", t => t.SaleShippingCertificateId, cascadeDelete: true)
                .Index(t => t.SaleShippingCertificateId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        SiteUserId = c.Int(nullable: true),
                        Role = c.String(),
                        Salary = c.Single(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        Telephone = c.String(),
                        City = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.site_user", t => t.SiteUserId, cascadeDelete: true)
                .Index(t => t.SiteUserId);
            
            CreateTable(
                "dbo.employee_schedule",
                c => new
                    {
                        EmployeeScheduleId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EnterDateTime = c.DateTime(nullable: false),
                        ExitDateTime = c.DateTime(nullable: false),
                        EnterPlace = c.String(),
                        Exitaplace = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeScheduleId)
                .ForeignKey("dbo.employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.mailbox_message",
                c => new
                    {
                        MailboxMessageId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        From = c.String(),
                        Topic = c.String(nullable: false),
                        Content = c.String(),
                        Link = c.String(),
                        IsReaden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MailboxMessageId);
            
            CreateTable(
                "dbo.provider",
                c => new
                    {
                        ProviderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        Telephone = c.String(),
                        City = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProviderId);
            
            CreateTable(
                "dbo.purchase_order",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.provider", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.purchase_order_product",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseOrderId, t.ProductId })
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.purchase_order", t => t.PurchaseOrderId, cascadeDelete: true)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.purchase_shipping_certificate",
                c => new
                    {
                        PurchaseShippingCertificateId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseShippingCertificateId)
                .ForeignKey("dbo.provider", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.purchase_shipping_certificate_product",
                c => new
                    {
                        PurchaseShippingCertificateId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PricePerProduct = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseShippingCertificateId, t.ProductId })
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.purchase_shipping_certificate", t => t.PurchaseShippingCertificateId, cascadeDelete: true)
                .Index(t => t.PurchaseShippingCertificateId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchase_shipping_certificate_product", "PurchaseShippingCertificateId", "dbo.purchase_shipping_certificate");
            DropForeignKey("dbo.purchase_shipping_certificate_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.purchase_shipping_certificate", "ProviderId", "dbo.provider");
            DropForeignKey("dbo.purchase_order_product", "PurchaseOrderId", "dbo.purchase_order");
            DropForeignKey("dbo.purchase_order_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.purchase_order", "ProviderId", "dbo.provider");
            DropForeignKey("dbo.inventory", "ProductId", "dbo.product");
            DropForeignKey("dbo.employee", "SiteUserId", "dbo.site_user");
            DropForeignKey("dbo.employee_schedule", "EmployeeId", "dbo.employee");
            DropForeignKey("dbo.customer_payment", "CustomerId", "dbo.customer");
            DropForeignKey("dbo.customer", "SiteUserId", "dbo.site_user");
            DropForeignKey("dbo.sale_shipping_certificate_product", "SaleShippingCertificateId", "dbo.sale_shipping_certificate");
            DropForeignKey("dbo.sale_shipping_certificate_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.sale_shipping_certificate", "CustomerId", "dbo.customer");
            DropForeignKey("dbo.sale_order_product", "SaleOrderId", "dbo.sale_order");
            DropForeignKey("dbo.sale_order_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.sale_order", "CustomerId", "dbo.customer");
            DropForeignKey("dbo.product", "CategoryId", "dbo.category");
            DropForeignKey("dbo.category", "ParentCategoryId", "dbo.category");
            DropForeignKey("dbo.site_user", "AuthenticationTypeId", "dbo.authentication_type");
            DropIndex("dbo.purchase_shipping_certificate_product", new[] { "ProductId" });
            DropIndex("dbo.purchase_shipping_certificate_product", new[] { "PurchaseShippingCertificateId" });
            DropIndex("dbo.purchase_shipping_certificate", new[] { "ProviderId" });
            DropIndex("dbo.purchase_order_product", new[] { "ProductId" });
            DropIndex("dbo.purchase_order_product", new[] { "PurchaseOrderId" });
            DropIndex("dbo.purchase_order", new[] { "ProviderId" });
            DropIndex("dbo.inventory", new[] { "ProductId" });
            DropIndex("dbo.employee_schedule", new[] { "EmployeeId" });
            DropIndex("dbo.employee", new[] { "SiteUserId" });
            DropIndex("dbo.sale_shipping_certificate_product", new[] { "ProductId" });
            DropIndex("dbo.sale_shipping_certificate_product", new[] { "SaleShippingCertificateId" });
            DropIndex("dbo.sale_shipping_certificate", new[] { "CustomerId" });
            DropIndex("dbo.sale_order_product", new[] { "ProductId" });
            DropIndex("dbo.sale_order_product", new[] { "SaleOrderId" });
            DropIndex("dbo.sale_order", new[] { "CustomerId" });
            DropIndex("dbo.customer", new[] { "SiteUserId" });
            DropIndex("dbo.customer_payment", new[] { "CustomerId" });
            DropIndex("dbo.product", new[] { "CategoryId" });
            DropIndex("dbo.category", new[] { "ParentCategoryId" });
            DropIndex("dbo.site_user", new[] { "AuthenticationTypeId" });
            DropTable("dbo.purchase_shipping_certificate_product");
            DropTable("dbo.purchase_shipping_certificate");
            DropTable("dbo.purchase_order_product");
            DropTable("dbo.purchase_order");
            DropTable("dbo.provider");
            DropTable("dbo.mailbox_message");
            DropTable("dbo.inventory");
            DropTable("dbo.employee_schedule");
            DropTable("dbo.employee");
            DropTable("dbo.sale_shipping_certificate_product");
            DropTable("dbo.sale_shipping_certificate");
            DropTable("dbo.sale_order_product");
            DropTable("dbo.sale_order");
            DropTable("dbo.customer");
            DropTable("dbo.customer_payment");
            DropTable("dbo.product");
            DropTable("dbo.category");
            DropTable("dbo.site_user");
            DropTable("dbo.authentication_type");
        }
    }
}
