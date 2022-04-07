using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore.Legado
{
    public partial class HeroAppContext : DbContext
    {
        public HeroAppContext()
        {
        }

        public HeroAppContext(DbContextOptions<HeroAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arma> Armas { get; set; }
        public virtual DbSet<Batalha> Batalhas { get; set; }
        public virtual DbSet<Heroi> Herois { get; set; }
        public virtual DbSet<HeroiBatalha> HeroiBatalhas { get; set; }
        public virtual DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Password=123456; Persist Security Info=False;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-3T92CQT\\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arma>(entity =>
            {
                entity.HasIndex(e => e.HeroiId, "IX_Armas_HeroiId");

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.Armas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });

                entity.HasIndex(e => e.HeroiId, "IX_HeroiBatalhas_HeroiId");

                entity.HasOne(d => d.Batalha)
                    .WithMany(p => p.HeroiBatalhas)
                    .HasForeignKey(d => d.BatalhaId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.HeroiBatalhas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<IdentidadeSecreta>(entity =>
            {
                entity.HasIndex(e => e.HeroiId, "IX_IdentidadeSecretas_HeroiId")
                    .IsUnique();

                entity.HasOne(d => d.Heroi)
                    .WithOne(p => p.IdentidadeSecreta)
                    .HasForeignKey<IdentidadeSecreta>(d => d.HeroiId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
