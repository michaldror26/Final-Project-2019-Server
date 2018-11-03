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
                "dbo.user",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        Telephone = c.String(),
                        City = c.String(),
                        Email = c.String(nullable: false),
                        AuthenticationType_AuthenticationTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.authentication_type", t => t.AuthenticationType_AuthenticationTypeId)
                .Index(t => t.AuthenticationType_AuthenticationTypeId);
            
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
                .ForeignKey("dbo.customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
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
                .ForeignKey("dbo.customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.sale_order_product",
                c => new
                    {
                        SaleOrderId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SaleOrder_SaleOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleOrderId)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.sale_order", t => t.SaleOrder_SaleOrderId)
                .Index(t => t.ProductId)
                .Index(t => t.SaleOrder_SaleOrderId);
            
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
                "dbo.category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentCategoryId = c.Int(nullable: false),
                        ParentCategory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.category", t => t.ParentCategory_CategoryId)
                .Index(t => t.ParentCategory_CategoryId);
            
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
                .ForeignKey("dbo.customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.sale_shipping_certificate_product",
                c => new
                    {
                        SaleShippingCertificateId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PricePerProduct = c.Single(nullable: false),
                        SaleShippingCertificate_SaleShippingCertificateId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleShippingCertificateId)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.sale_shipping_certificate", t => t.SaleShippingCertificate_SaleShippingCertificateId)
                .Index(t => t.ProductId)
                .Index(t => t.SaleShippingCertificate_SaleShippingCertificateId);
            
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
                .ForeignKey("dbo.employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
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
                .ForeignKey("dbo.provider", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.purchase_order_product",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchaseOrder_PurchaseOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.purchase_order", t => t.PurchaseOrder_PurchaseOrderId)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseOrder_PurchaseOrderId);
            
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
                .ForeignKey("dbo.provider", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.purchase_shipping_certificate_product",
                c => new
                    {
                        PurchaseShippingCertificateId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PricePerProduct = c.Single(nullable: false),
                        PurchaseShippingCertificate_PurchaseShippingCertificateId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseShippingCertificateId)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.purchase_shipping_certificate", t => t.PurchaseShippingCertificate_PurchaseShippingCertificateId)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseShippingCertificate_PurchaseShippingCertificateId);
            
            CreateTable(
                "dbo.inventory",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
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
                "dbo.customer",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        DiscountPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Role = c.String(),
                        Salary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.provider",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.site_user",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserSiteId = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        AuthenticationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.user", t => t.UserId)
                .ForeignKey("dbo.authentication_type", t => t.AuthenticationTypeId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AuthenticationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.site_user", "AuthenticationTypeId", "dbo.authentication_type");
            DropForeignKey("dbo.site_user", "UserId", "dbo.user");
            DropForeignKey("dbo.provider", "UserId", "dbo.user");
            DropForeignKey("dbo.employee", "UserId", "dbo.user");
            DropForeignKey("dbo.customer", "UserId", "dbo.user");
            DropForeignKey("dbo.inventory", "Product_ProductId", "dbo.product");
            DropForeignKey("dbo.user", "AuthenticationType_AuthenticationTypeId", "dbo.authentication_type");
            DropForeignKey("dbo.purchase_shipping_certificate_product", "PurchaseShippingCertificate_PurchaseShippingCertificateId", "dbo.purchase_shipping_certificate");
            DropForeignKey("dbo.purchase_shipping_certificate_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.purchase_shipping_certificate", "ProviderId", "dbo.provider");
            DropForeignKey("dbo.purchase_order_product", "PurchaseOrder_PurchaseOrderId", "dbo.purchase_order");
            DropForeignKey("dbo.purchase_order_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.purchase_order", "ProviderId", "dbo.provider");
            DropForeignKey("dbo.employee_schedule", "EmployeeId", "dbo.employee");
            DropForeignKey("dbo.sale_shipping_certificate_product", "SaleShippingCertificate_SaleShippingCertificateId", "dbo.sale_shipping_certificate");
            DropForeignKey("dbo.sale_shipping_certificate_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.sale_shipping_certificate", "CustomerId", "dbo.customer");
            DropForeignKey("dbo.sale_order_product", "SaleOrder_SaleOrderId", "dbo.sale_order");
            DropForeignKey("dbo.sale_order_product", "ProductId", "dbo.product");
            DropForeignKey("dbo.product", "CategoryId", "dbo.category");
            DropForeignKey("dbo.category", "ParentCategory_CategoryId", "dbo.category");
            DropForeignKey("dbo.sale_order", "CustomerId", "dbo.customer");
            DropForeignKey("dbo.customer_payment", "CustomerId", "dbo.customer");
            DropIndex("dbo.site_user", new[] { "AuthenticationTypeId" });
            DropIndex("dbo.site_user", new[] { "UserId" });
            DropIndex("dbo.provider", new[] { "UserId" });
            DropIndex("dbo.employee", new[] { "UserId" });
            DropIndex("dbo.customer", new[] { "UserId" });
            DropIndex("dbo.inventory", new[] { "Product_ProductId" });
            DropIndex("dbo.purchase_shipping_certificate_product", new[] { "PurchaseShippingCertificate_PurchaseShippingCertificateId" });
            DropIndex("dbo.purchase_shipping_certificate_product", new[] { "ProductId" });
            DropIndex("dbo.purchase_shipping_certificate", new[] { "ProviderId" });
            DropIndex("dbo.purchase_order_product", new[] { "PurchaseOrder_PurchaseOrderId" });
            DropIndex("dbo.purchase_order_product", new[] { "ProductId" });
            DropIndex("dbo.purchase_order", new[] { "ProviderId" });
            DropIndex("dbo.employee_schedule", new[] { "EmployeeId" });
            DropIndex("dbo.sale_shipping_certificate_product", new[] { "SaleShippingCertificate_SaleShippingCertificateId" });
            DropIndex("dbo.sale_shipping_certificate_product", new[] { "ProductId" });
            DropIndex("dbo.sale_shipping_certificate", new[] { "CustomerId" });
            DropIndex("dbo.category", new[] { "ParentCategory_CategoryId" });
            DropIndex("dbo.product", new[] { "CategoryId" });
            DropIndex("dbo.sale_order_product", new[] { "SaleOrder_SaleOrderId" });
            DropIndex("dbo.sale_order_product", new[] { "ProductId" });
            DropIndex("dbo.sale_order", new[] { "CustomerId" });
            DropIndex("dbo.customer_payment", new[] { "CustomerId" });
            DropIndex("dbo.user", new[] { "AuthenticationType_AuthenticationTypeId" });
            DropTable("dbo.site_user");
            DropTable("dbo.provider");
            DropTable("dbo.employee");
            DropTable("dbo.customer");
            DropTable("dbo.mailbox_message");
            DropTable("dbo.inventory");
            DropTable("dbo.purchase_shipping_certificate_product");
            DropTable("dbo.purchase_shipping_certificate");
            DropTable("dbo.purchase_order_product");
            DropTable("dbo.purchase_order");
            DropTable("dbo.employee_schedule");
            DropTable("dbo.sale_shipping_certificate_product");
            DropTable("dbo.sale_shipping_certificate");
            DropTable("dbo.category");
            DropTable("dbo.product");
            DropTable("dbo.sale_order_product");
            DropTable("dbo.sale_order");
            DropTable("dbo.customer_payment");
            DropTable("dbo.user");
            DropTable("dbo.authentication_type");
        }
    }
}
