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
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=52.142.14.253\\TECNODEMOS\\MSSQLSERVER2012, 1434;initial catalog=TMP_DEMO;persist security info=True;user id=yespinoza;password=12345678;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.PkCategory)
                    .HasName("PK__Category__55D073BD0AAC5449");

                entity.Property(e => e.PkCategory).HasColumnName("PK_Category");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PkProduct)
                    .HasName("PK__Product__E5E6F73B154813CB");

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
                    .HasConstraintName("FK__Product__FK_Cate__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
