using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class TMP_DEMOContext : DbContext
    {
        public TMP_DEMOContext()
        {
        }

        public TMP_DEMOContext(DbContextOptions<TMP_DEMOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPassword> UserPassword { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=52.142.14.253\\TECNODEMOS\\MSSQLSERVER2012,1434;initial catalog=TMP_DEMO;persist security info=True;user id=yespinoza;password=12345678;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.PkCategory)
                    .HasName("PK__Category__55D073BD159B2568");

                entity.Property(e => e.PkCategory).HasColumnName("PK_Category");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.PkOrder)
                    .HasName("PK__Order__A8E270CBB79B180C");

                entity.Property(e => e.PkOrder).HasColumnName("PK_Order");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FkStatus).HasColumnName("FK_Status");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.HasOne(d => d.FkStatusNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FkStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__FK_Status__22AA2996");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FkUser)
                    .HasConstraintName("FK__Order__FK_User__21B6055D");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.PkOrderDetail)
                    .HasName("PK__OrderDet__7130CDAE12C1068D");

                entity.Property(e => e.PkOrderDetail).HasColumnName("PK_OrderDetail");

                entity.Property(e => e.FkOrder).HasColumnName("FK_Order");

                entity.Property(e => e.FkProduct).HasColumnName("FK_Product");

                entity.HasOne(d => d.FkOrderNavigation)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.FkOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__FK_Or__25869641");

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.FkProduct)
                    .HasConstraintName("FK__OrderDeta__FK_Pr__267ABA7A");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PkProduct)
                    .HasName("PK__Product__E5E6F73B44E71EE0");

                entity.Property(e => e.PkProduct).HasColumnName("PK_Product");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.FkCategory).HasColumnName("FK_Category");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.FkCategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.FkCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__FK_Cate__145C0A3F");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.PkProductReview)
                    .HasName("PK__ProductR__C130EA4EC5609438");

                entity.Property(e => e.PkProductReview).HasColumnName("PK_ProductReview");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Detail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkProduct).HasColumnName("FK_Product");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.FkProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductRe__FK_Pr__2C3393D0");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductRe__FK_Us__2D27B809");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.PkStatus)
                    .HasName("PK__Status__DDA9BD531B44CAD2");

                entity.Property(e => e.PkStatus).HasColumnName("PK_Status");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PkUser)
                    .HasName("PK__User__472050576B8488B8");

                entity.Property(e => e.PkUser).HasColumnName("PK_User");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalIdentification)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.HasKey(e => e.UserPassword1)
                    .HasName("PK__UserPass__5DF58B80253B7C56");

                entity.Property(e => e.UserPassword1).HasColumnName("UserPassword");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.UserPassword)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPassw__FK_Us__1B0907CE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
