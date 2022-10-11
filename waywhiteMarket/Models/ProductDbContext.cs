using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace waywhiteMarket.Models
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TMember> TMembers { get; set; } = null!;
        public virtual DbSet<TProduct> TProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#作品集\\waywhiteMarket\\waywhiteMarket\\App_Data\\dbProduct.mdf;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.FAccount)
                    .HasName("PK__tmp_ms_x__E12994621C287BB5");

                entity.ToTable("tMember");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FMail)
                    .HasMaxLength(50)
                    .HasColumnName("fMail")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FName)
                    .HasMaxLength(10)
                    .HasColumnName("fName")
                    .IsFixedLength()
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FPower).HasColumnName("fPower");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.FName)
                    .HasName("PK__tProduct__2EB51151516ED676");

                entity.ToTable("tProduct");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FDay)
                    .HasColumnType("date")
                    .HasColumnName("fDay");

                entity.Property(e => e.FDescription)
                    .HasColumnName("fDescription")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FOwner)
                    .HasMaxLength(10)
                    .HasColumnName("fOwner")
                    .IsFixedLength()
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FPath)
                    .HasColumnName("fPath")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FPrice).HasColumnName("fPrice");

                entity.Property(e => e.FType)
                    .HasMaxLength(10)
                    .HasColumnName("fType")
                    .IsFixedLength()
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
