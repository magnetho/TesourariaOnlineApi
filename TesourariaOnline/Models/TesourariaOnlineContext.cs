using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TesourariaOnline.Models
{
    public partial class TesourariaOnlineContext : DbContext
    {
        public TesourariaOnlineContext()
        {
        }

        public TesourariaOnlineContext(DbContextOptions<TesourariaOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cedula> Cedula { get; set; }
        public virtual DbSet<ContagemCedula> ContagemCedula { get; set; }
        public virtual DbSet<ContagemCheque> ContagemCheque { get; set; }
        public virtual DbSet<ContagemResumo> ContagemResumo { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }
        public virtual DbSet<TipoCedula> TipoCedula { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.91.142.186;Database=TesourariaOnline;user id=Admin;password=Admin321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Cedula>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.TipoCedula)
                    .WithMany(p => p.Cedula)
                    .HasForeignKey(d => d.TipoCedulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cedula_TipoCedula");
            });

            modelBuilder.Entity<ContagemCedula>(entity =>
            {
                entity.HasOne(d => d.Cedula)
                    .WithMany(p => p.ContagemCedula)
                    .HasForeignKey(d => d.CedulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContagemItem_Cedula");

                entity.HasOne(d => d.ContagemResumo)
                    .WithMany(p => p.ContagemCedula)
                    .HasForeignKey(d => d.ContagemResumoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContagemItem_ContagemResumo");
            });

            modelBuilder.Entity<ContagemCheque>(entity =>
            {
                entity.Property(e => e.Doador)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorDoacao).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ContageResumo)
                    .WithMany(p => p.ContagemCheque)
                    .HasForeignKey(d => d.ContageResumoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CotagemCheque_ContagemResumo");
            });

            modelBuilder.Entity<ContagemResumo>(entity =>
            {
                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.DataAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValorSistema).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Movimento)
                    .WithMany(p => p.ContagemResumo)
                    .HasForeignKey(d => d.MovimentoId)
                    .HasConstraintName("FK_ContagemResumo_Movimento");
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.DataAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCedula>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Simbolo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
