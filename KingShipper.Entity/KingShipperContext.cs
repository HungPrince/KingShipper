namespace KingShipper.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KingShipperContext : DbContext
    {
        public KingShipperContext()
            : base("name=KingShipperContext")
        {
        }

        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Digital> Digitals { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBusiness> UserBusinesses { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<ProductDigital> ProductDigitals { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>()
                .Property(e => e.BusinessID)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.Name)
                .IsUnicode(false);

            //modelBuilder.Entity<Business>()
            //    .HasMany(e => e.UserBusinesses)
            //    .WithRequired(e => e.Business)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Created)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.Updated)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Updated)
                .IsFixedLength();

            modelBuilder.Entity<Material>()
                .Property(e => e.Created)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.BusinessID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProductDigital)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithRequired(e => e.Role)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Avartar)
                .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Orders)
            //    .WithOptional(e => e.User)
            //    .HasForeignKey(e => e.CustomerID);

            //modelBuilder.Entity<User>()
            //    .HasOptional(e => e.Banner)
            //    .WithRequired(e => e.User);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.UserBusinesses)
            //    .WithRequired(e => e.User)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasOptional(e => e.UserPermission)
            //    .WithRequired(e => e.User);

            modelBuilder.Entity<UserBusiness>()
                .Property(e => e.BusinessID)
                .IsUnicode(false);

            modelBuilder.Entity<Banner>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);
        }
    }
}
