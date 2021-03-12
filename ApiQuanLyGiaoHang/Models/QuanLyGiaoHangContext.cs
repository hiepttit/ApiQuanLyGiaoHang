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
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<RoleRelationShip> RoleRelationShips { get; set; }
        public virtual DbSet<StockOrder> StockOrders { get; set; }
        public virtual DbSet<TheOrder> TheOrders { get; set; }
        public virtual DbSet<TheRole> TheRoles { get; set; }
        public virtual DbSet<TheUser> TheUsers { get; set; }
        public virtual DbSet<TheUserView> TheUserViews { get; set; }
        public virtual DbSet<TokenUser> TokenUsers { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyGiaoHang;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DeliveryOrder>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdTheOrder })
                    .HasName("PK__Delivery__3213E83FF855B7AA");

                entity.ToTable("DeliveryOrder");

                entity.Property(e => e.Id)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdTheOrder)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("idTheOrder");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.DateDeliveryOrder)
                    .HasColumnType("datetime")
                    .HasColumnName("dateDeliveryOrder");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.IdStaff)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("idStaff");

                entity.Property(e => e.TheStatus).HasColumnName("theStatus");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.DeliveryOrders)
                    .HasForeignKey(d => d.IdStaff)
                    .HasConstraintName("FK__DeliveryO__idSta__47DBAE45");

                entity.HasOne(d => d.IdTheOrderNavigation)
                    .WithMany(p => p.DeliveryOrders)
                    .HasForeignKey(d => d.IdTheOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DeliveryO__idThe__46E78A0C");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.LatiLongTude)
                    .HasMaxLength(50)
                    .HasComment("Kinh độ, vĩ độ");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Province");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.ZipCode).HasMaxLength(20);
            });

            modelBuilder.Entity<RoleRelationShip>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__RoleRela__3717C98277813BAC");

                entity.ToTable("RoleRelationShip");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("idUser");

                entity.Property(e => e.IdMainRole).HasColumnName("idMainRole");

                entity.HasOne(d => d.IdMainRoleNavigation)
                    .WithMany(p => p.RoleRelationShips)
                    .HasForeignKey(d => d.IdMainRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoleRelat__idMai__3D5E1FD2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.RoleRelationShip)
                    .HasForeignKey<RoleRelationShip>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoleRelat__idUse__3E52440B");
            });

            modelBuilder.Entity<StockOrder>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdTheOrder })
                    .HasName("PK__StockOrd__3213E83FFB5BD49E");

                entity.ToTable("StockOrder");

                entity.Property(e => e.Id)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdTheOrder)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("idTheOrder");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.DateReturnToShop)
                    .HasColumnType("datetime")
                    .HasColumnName("dateReturnToShop");

                entity.Property(e => e.Delaydate)
                    .HasColumnType("datetime")
                    .HasColumnName("delaydate");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deletedAt");

                entity.Property(e => e.TheStatus)
                    .HasColumnName("theStatus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.HasOne(d => d.IdTheOrderNavigation)
                    .WithMany(p => p.StockOrders)
                    .HasForeignKey(d => d.IdTheOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StockOrde__idThe__4AB81AF0");
            });

            modelBuilder.Entity<TheOrder>(entity =>
            {
                entity.ToTable("TheOrder");

                entity.Property(e => e.Id)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("id");

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

                entity.Property(e => e.IdShop)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("idShop");

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

                entity.Property(e => e.TheAddress)
                    .HasMaxLength(300)
                    .HasColumnName("theAddress");

                entity.Property(e => e.TheStatus).HasColumnName("theStatus");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.HasOne(d => d.IdShopNavigation)
                    .WithMany(p => p.TheOrders)
                    .HasForeignKey(d => d.IdShop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TheOrder__idShop__4316F928");
            });

            modelBuilder.Entity<TheRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMainRole).HasColumnName("isMainRole");

                entity.Property(e => e.RoleName).HasMaxLength(1000);
            });

            modelBuilder.Entity<TheUser>(entity =>
            {
                entity.ToTable("TheUser");

                entity.HasIndex(e => e.UserName, "UQ__TheUser__66DCF95CE31022E7")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("id");

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

            modelBuilder.Entity<TheUserView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TheUser_View");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("bankAccountNumber");

                entity.Property(e => e.BankName)
                    .HasMaxLength(500)
                    .HasColumnName("bankName");

                entity.Property(e => e.DateOfIssueIdNumber)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfIssueIdNumber");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("idNumber");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PlaceOfIssueIdNumber)
                    .HasMaxLength(40)
                    .HasColumnName("placeOfIssueIdNumber");

                entity.Property(e => e.TheAddress)
                    .HasMaxLength(300)
                    .HasColumnName("theAddress");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<TokenUser>(entity =>
            {
                entity.HasKey(e => e.IdToken)
                    .HasName("PK__TokenUse__FEFE350D761D2D3B");

                entity.ToTable("TokenUser");

                entity.Property(e => e.IdToken)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("idToken");

                entity.Property(e => e.Roles)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("roles");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("Ward");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.IsPublished).HasDefaultValueSql("((1))");

                entity.Property(e => e.LatiLongTude).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ward_District");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
