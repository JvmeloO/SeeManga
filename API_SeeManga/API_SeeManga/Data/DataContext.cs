using API_SeeManga.DTO;
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
        public DbSet<DTOCapitulos> CAPITULOS { get; set; }

        public DbSet<DTOComentarios> COMENTARIOS { get; set; }

        public DbSet<DTOMangas> MANGAS { get; set; }

        public DbSet<DTOPaginas> PAGINAS { get; set; }

        public DbSet<DTOSituacoes> SITUACOES { get; set; }

        public DbSet<DTOGeneros> GENEROS { get; set; }
        
        public DbSet<DTOManga_Generos> MANGA_GENEROS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SeeManga;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DTOCapitulos>(entity =>
            {
                entity.HasOne(c => c.Manga)
                      .WithMany(s => s.Capitulos)
                      .HasForeignKey(c => c.ID_MANGA)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_CAPITULOS_MANGA");

            });

            modelBuilder.Entity<DTOComentarios>(entity =>
            {
                entity.HasOne(m => m.Manga)
                      .WithMany(c => c.Comentarios)
                      .HasForeignKey(m => m.ID_MANGA)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_COMENTARIOS_MANGA");
            });

            modelBuilder.Entity<DTOMangas>(entity =>
            {
                entity.HasOne(s => s.Situacao)
                      .WithMany(m => m.Mangas)
                      .HasForeignKey(s => s.ID_SITUACAO)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MANGA_SITUACAO");
            });

            modelBuilder.Entity<DTOPaginas>(entity =>
            {
                entity.HasOne(c => c.Capitulo)
                      .WithMany(p => p.Paginas)
                      .HasForeignKey(c => c.ID_CAPITULOS)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_PAGINAS_CAPITULO");
            });

            modelBuilder.Entity<DTOManga_Generos>(entity =>
            {
                entity.HasKey(i => new { i.ID_GENERO, i.ID_MANGA });

                entity.HasOne(g => g.Genero)
                      .WithMany(m => m.Manga_generos)
                      .HasForeignKey(g => g.ID_GENERO)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MANGA_GENEROS_GENERO");

                entity.HasOne(m => m.Manga)
                      .WithMany(m => m.Manga_generos)
                      .HasForeignKey(m => m.ID_MANGA)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_MANGA_GENEROS_MANGA");
            });


        }
    }
}
