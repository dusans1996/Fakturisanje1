using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fakturisanje.Models
{
    public partial class FakturisanjeContext : DbContext
    {      

        public FakturisanjeContext(DbContextOptions<FakturisanjeContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Faktura> Fakture { get; set; }
        public virtual DbSet<Kupac> Kupci { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Faktura>(entity =>
            {
                entity.Property(e => e.DatumFakture).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Fakture)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Faktura__KupacId__76969D2E");
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.Property(e => e.KupacId).ValueGeneratedNever();

                entity.Property(e => e.Drzava).HasDefaultValueSql("('Srbija')");

                entity.Property(e => e.Grad).HasDefaultValueSql("('Beograd')");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasIndex(e => e.RedniBroj)
                    .HasName("UQ__Stavka__863A8DE7E2DC4327")
                    .IsUnique();

                entity.HasOne(d => d.Faktura)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.FakturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka__FakturaI__7B5B524B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}