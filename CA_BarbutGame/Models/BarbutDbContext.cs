using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_BarbutGame.Models;

public partial class BarbutDbContext : DbContext
{
    public BarbutDbContext()
    {
    }

    public BarbutDbContext(DbContextOptions<BarbutDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=BarbutDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.ToTable("Bank");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Money).HasColumnType("money");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Bank)
                .HasForeignKey<Bank>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bank_Player");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.ToTable("Log");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Loser).HasMaxLength(50);
            entity.Property(e => e.PlayerCurrentBalance).HasColumnType("money");
            entity.Property(e => e.PlayerEarnings).HasColumnType("money");
            entity.Property(e => e.PlayerLoss).HasColumnType("money");
            entity.Property(e => e.Winner).HasMaxLength(50);

            entity.HasOne(d => d.Player).WithMany(p => p.Logs)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Player");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Point).HasColumnType("money");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
