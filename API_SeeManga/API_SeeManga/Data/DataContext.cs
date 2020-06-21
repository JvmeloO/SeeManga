using API_SeeManga.Models.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SeeManga.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CapitulosModel> Capitulos { get; set; }

        public DbSet<ComentariosModel> Comentarios { get; set; }

        public DbSet<MangasModel> Mangas { get; set; }

        public DbSet<PaginasModel> Paginas { get; set; }

        public DbSet<SituacoesModel> Situacoes { get; set; }

        public DbSet<GenerosModel> Generos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SeeManga;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CapitulosModel>(entity =>
            {
                entity.HasOne(c => c.Manga)
                      .WithMany(s => s.Capitulos)
                      .HasForeignKey(c => c.ID_MANGA)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_CAPITULOS_MANGA");

            });

            modelBuilder.Entity<ComentariosModel>(entity =>
            {
                entity.HasOne(m => m.Manga)
                      .WithMany(c => c.Comentarios)
                      .HasForeignKey(m => m.ID_MANGA)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_COMENTARIOS_MANGA");
            });

            modelBuilder.Entity<MangasModel>(entity =>
            {
                entity.HasOne(s => s.Situacao)
                      .WithMany(m => m.Mangas)
                      .HasForeignKey(s => s.ID_SITUACAO)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MANGA_SITUACAO");

                entity.HasOne(s => s.Genero)
                      .WithMany(m => m.Mangas)
                      .HasForeignKey(s => s.ID_GENERO)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MANGA_GENERO");
            });

            modelBuilder.Entity<PaginasModel>(entity =>
            {
                entity.HasOne(c => c.Capitulo)
                      .WithMany(p => p.Paginas)
                      .HasForeignKey(c => c.ID_CAPITULOS)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_PAGINAS_CAPITULOS");
            });


        }
    }
}
