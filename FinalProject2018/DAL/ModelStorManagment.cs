
using System;
using System.Data.Entity;
using System.Linq;
using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class ModelStorManagment : DbContext
    {
        // Your context has been configured to use a 'Model2' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.Model2' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model2' 
        // connection string in the application configuration file.
        public ModelStorManagment() : base()
            //https://www.codeproject.com/Articles/821439/Getting-started-with-ASP-Net-Web-API-using-CodeF
           // : base("Data Source=DESKTOP-V2MV35R/SQLEXPRESS;Initial Catalog=CleverManager;Integrated Security=True")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<AuthenticationType> AuthenticationTypes { get; set; }
        public virtual DbSet<SiteUser> SiteUsers { get; set; }       

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

        public virtual DbSet<MailboxMessage> MailboxMessages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }

        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }

        public virtual DbSet<PurchaseShippingCertificate> PurchaseShippingCertificates { get; set; }
        public virtual DbSet<PurchaseShippingCertificateProduct> PurchaseShippingCertificateProducts { get; set; }

        public virtual DbSet<SaleOrder> SaleOrders { get; set; }
        public virtual DbSet<SaleOrderProduct> SaleOrderProducts { get; set; }

        public virtual DbSet<SaleShippingCertificate> SaleShippingCertificates { get; set; }
        public virtual DbSet<SaleShippingCertificateProduct> SaleShippingCertificateProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()  
           .HasRequired<Category>(c=>c.Category)  
           .WithMany(c =>c.Products)  
           .HasForeignKey(c =>c.CategoryId);  
        }

    }
}
