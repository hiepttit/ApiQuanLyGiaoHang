using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class QuanLyGiaoHangContext : DbContext
    {
        public QuanLyGiaoHangContext()
        {
        }

        public QuanLyGiaoHangContext(DbContextOptions<QuanLyGiaoHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public virtual DbSet<RoleRelationShip> RoleRelationShips { get; set; }
        public virtual DbSet<StockOrder> StockOrders { get; set; }
        public virtual DbSet<TheOrder> TheOrders { get; set; }
        public virtual DbSet<TheRole> TheRoles { get; set; }
        public virtual DbSet<TheUser> TheUsers { get; set; }
        public virtual DbSet<TokenUser> TokenUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QuanLyGiaoHang;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DeliveryOrder>(entity =>
            {
                entity.ToTable("DeliveryOrder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.DateDeliveryOrder)
                    .HasColumnType("datetime")
                    .HasColumnName("dateDeliveryOrder");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.IdStaff).HasColumnName("idStaff");

                entity.Property(e => e.IdTheOrder).HasColumnName("idTheOrder");

                entity.Property(e => e.TheStatus)
                    .HasMaxLength(30)
                    .HasColumnName("theStatus");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            modelBuilder.Entity<RoleRelationShip>(entity =>
            {
                entity.HasKey(e => new { e.IdMainRole, e.IdSubRole })
                    .HasName("PK__RoleRela__D1B7E2064BE771CF");

                entity.ToTable("RoleRelationShip");

                entity.Property(e => e.IdMainRole).HasColumnName("idMainRole");

                entity.Property(e => e.IdSubRole).HasColumnName("idSubRole");
            });

            modelBuilder.Entity<StockOrder>(entity =>
            {
                entity.ToTable("StockOrder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.DateReturnToShop)
                    .HasColumnType("datetime")
                    .HasColumnName("dateReturnToShop");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.IdTheOrder).HasColumnName("idTheOrder");

                entity.Property(e => e.TheStatus)
                    .HasColumnName("theStatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            modelBuilder.Entity<TheOrder>(entity =>
            {
                entity.ToTable("TheOrder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cod).HasColumnName("COD");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("customerName");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.IdShop).HasColumnName("idShop");

                entity.Property(e => e.IsInStock)
                    .HasColumnName("isInStock")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSuccess).HasColumnName("isSuccess");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.RealReceive).HasColumnName("realReceive");

                entity.Property(e => e.ShipFee).HasColumnName("shipFee");

                entity.Property(e => e.TheAddresss)
                    .HasMaxLength(300)
                    .HasColumnName("theAddresss");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            modelBuilder.Entity<TheRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMainRole).HasColumnName("isMainRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TheUser>(entity =>
            {
                entity.ToTable("TheUser");

                entity.HasIndex(e => e.UserName, "UQ__TheUser__66DCF95C43E3F35E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("bankAccountNumber");

                entity.Property(e => e.BankName)
                    .HasMaxLength(500)
                    .HasColumnName("bankName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.DateOfIssueIdNumber)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfIssueIdNumber");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("idNumber");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PlaceOfIssueIdNumber)
                    .HasMaxLength(40)
                    .HasColumnName("placeOfIssueIdNumber");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.TheAddress)
                    .HasMaxLength(300)
                    .HasColumnName("theAddress");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<TokenUser>(entity =>
            {
                entity.ToTable("TokenUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.Token)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
