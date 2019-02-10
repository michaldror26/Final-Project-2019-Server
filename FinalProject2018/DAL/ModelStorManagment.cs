
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
        public ModelStorManagment() : base()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        
        public virtual DbSet<AuthenticationType> AuthenticationTypes { get; set; }
        public virtual DbSet<SiteUser> SiteUsers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }

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
    }
}
