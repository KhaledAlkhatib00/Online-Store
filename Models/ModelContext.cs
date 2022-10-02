using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TUITY_STORE.Models;

#nullable disable

namespace TUITY_STORE.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutu> Aboutus { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Categoryy> Categoryys { get; set; }
        public virtual DbSet<Contactu> Contactus { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Orderr> Orderrs { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Productt> Productts { get; set; }
        public virtual DbSet<Rolee> Rolees { get; set; }
        public virtual DbSet<StorProduct> StorProducts { get; set; }
        public virtual DbSet<Storee> Storees { get; set; }
        public virtual DbSet<Testmonial> Testmonials { get; set; }
        public virtual DbSet<Userr> Userrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH14_USER120;PASSWORD=Khaled123;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH14_USER120")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Aboutu>(entity =>
            {
                entity.ToTable("ABOUTUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AboutText)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_TEXT");
            });


            modelBuilder.Entity<HomeImage>(entity =>
            {
                entity.ToTable("HOMEIMAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");
                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PICNAME");
            });


            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BANK_ACCOUNT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_NUMBER");

                entity.Property(e => e.AccountSnn)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_SNN");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("BANK_FK");
            });


         

            modelBuilder.Entity<Categoryy>(entity =>
            {
                entity.ToTable("CATEGORYY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYY_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.EMail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("E_MAIL");

                entity.Property(e => e.Locationn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LOCATIONN");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.UserMessege)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("USER_MESSEGE");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORDD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("CUST3_FK");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("ROLE3_FK");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("ORDER_PRODUCT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .IsUnicode(false)
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("ORDER_FK1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("PRODUCT1_FK1");
            });

            modelBuilder.Entity<Orderr>(entity =>
            {
                entity.ToTable("ORDERR");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.DATEFROM)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.DATETO)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("USER_PK2");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("PRODUCT_CATEGORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");
            });

            modelBuilder.Entity<Productt>(entity =>
            {
                entity.ToTable("PRODUCTT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Namee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAMEE");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_CATEGORY_ID");



                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Productts)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("PRU4_FK4");
                
               
            });

            modelBuilder.Entity<Rolee>(entity =>
            {
                entity.ToTable("ROLEE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<StorProduct>(entity =>
            {
                entity.ToTable("STOR_PRODUCT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.StoreId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STORE_ID");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STORE_NAME");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StorProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("PRU_F8K5");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StorProducts)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("PRUW_F8K5");
            });

            modelBuilder.Entity<Storee>(entity =>
            {
                entity.ToTable("STOREE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STORE_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");


                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Storees)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("F_CHAT_FK");
            });

            modelBuilder.Entity<Testmonial>(entity =>
            {
                entity.ToTable("TESTMONIAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserMassege)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("USER_MASSEGE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testmonials)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("USER_FK");
            });

            modelBuilder.Entity<Userr>(entity =>
            {
                entity.ToTable("USERR");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<TUITY_STORE.Models.HomeImage> HomeImage { get; set; }

    }
}
