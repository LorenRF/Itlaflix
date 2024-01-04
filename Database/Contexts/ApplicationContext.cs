using Itlaflix.Core.Domain.Common;
using Itlaflix.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase ApplicationContext
namespace Itlaflix.Infrastructure.Persistence.Contexts
{
    // Clase que representa el contexto de la base de datos
    public class ApplicationContext : DbContext
    {
        // Constructor que recibe opciones de contexto
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // Conjuntos de entidades representando las tablas en la base de datos
        public DbSet<Serie> Series { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<Producer> Producers { get; set; }

        // Método para guardar cambios asincrónicamente, también realiza la actualización de propiedades de auditoría
        // Método SaveChangesAsync
        // Se sobrescribe el método SaveChangesAsync para proporcionar funcionalidades adicionales de auditoría antes de guardar cambios en la base de datos.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // Itera sobre las entradas en el ChangeTracker (rastreador de cambios) del contexto
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                // Examina el estado de la entrada (Added, Modified, etc.)
                switch (entry.State)
                {
                    // Si la entidad está siendo agregada a la base de datos
                    case EntityState.Added:
                        // Establece la propiedad 'created' con la fecha y hora actuales
                        entry.Entity.created = DateTime.Now;
                        // Establece la propiedad 'createBy' con un valor predeterminado ("DefaultAppUser" en este caso)
                        entry.Entity.createdBy = "DefaultAppUser";
                        break;

                    // Si la entidad está siendo modificada en la base de datos
                    case EntityState.Modified:
                        // Establece la propiedad 'modificated' con la fecha y hora actuales
                        entry.Entity.modified = DateTime.Now;
                        // Establece la propiedad 'modifieBy' con un valor predeterminado ("DefaultAppUser" en este caso)
                        entry.Entity.modifiedBy = "DefaultAppUser";
                        break;
                }
            }

            // Llama al método SaveChangesAsync de la clase base para realizar el guardado real en la base de datos
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            modelBuilder.Entity<Season>().ToTable("Seasons");
            modelBuilder.Entity<Episode>().ToTable("Episodes");



            #endregion

            #region "primary keys"
            modelBuilder.Entity<Serie>().HasKey(serie => serie.Id);
            modelBuilder.Entity<Movie>().HasKey(movie => movie.Id);
            modelBuilder.Entity<Gender>().HasKey(gender => gender.Id);
            modelBuilder.Entity<Producer>().HasKey(producer => producer.Id);
            modelBuilder.Entity<Season>().HasKey(Season => Season.Id);
            modelBuilder.Entity<Episode>().HasKey(Episode => Episode.Id);
            modelBuilder.Entity<ProducerSerie>().HasKey(ps => new { ps.ProducerId, ps.SerieId });
            modelBuilder.Entity<ProducerMovie>().HasKey(pm => new { pm.ProducerId, pm.MovieId });
            #endregion

            #region retationships
            modelBuilder.Entity<SerieGender>()
           .HasKey(sg => new { sg.SerieId, sg.GenderId });

            modelBuilder.Entity<SerieGender>()
                .HasOne(sg => sg.Serie)
                .WithMany(s => s.SerieGenders)
                .HasForeignKey(sg => sg.SerieId);

            modelBuilder.Entity<SerieGender>()
                .HasOne(sg => sg.Gender)
                .WithMany(g => g.SerieGenders)
                .HasForeignKey(sg => sg.GenderId);

            modelBuilder.Entity<MovieGender>()
                .HasKey(mg => new { mg.MovieId, mg.GenderId });

            modelBuilder.Entity<MovieGender>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenders)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGender>()
                .HasOne(mg => mg.Gender)
                .WithMany(g => g.MovieGenders)
                .HasForeignKey(mg => mg.GenderId);

            modelBuilder.Entity<ProducerMovie>()
                .HasKey(pm => new { pm.MovieId, pm.ProducerId });

            modelBuilder.Entity<ProducerMovie>()
                .HasOne(pm => pm.Movie)
                .WithMany(pm => pm.ProducerMovies)
                .HasForeignKey(pm => pm.MovieId);

            modelBuilder.Entity<ProducerMovie>()
                .HasOne(pm => pm.Producer)
                .WithMany(pm => pm.ProducerMovies)
                .HasForeignKey(pm => pm.ProducerId);

            modelBuilder.Entity<ProducerSerie>()
                .HasKey(ps => new { ps.SerieId , ps.ProducerId });

            modelBuilder.Entity<ProducerSerie>()
                .HasOne(ps => ps.Serie)
                .WithMany(ps => ps.ProducerSerie)
                .HasForeignKey(ps => ps.SerieId);

            modelBuilder.Entity<ProducerSerie>()
                .HasOne(ps => ps.Producer)
                .WithMany(ps => ps.ProducerSeries)
                .HasForeignKey(ps => ps.ProducerId);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.director)
                .WithMany(d => d.DirectedSeries)
                .HasForeignKey(s => s.directorId);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.director)
                .WithMany(d => d.DirectedMovies)
                .HasForeignKey(m => m.directorId);

            modelBuilder.Entity<Season>()
                .HasOne(s => s.Serie)
                .WithMany(serie => serie.Seasons)
                .HasForeignKey(s => s.SerieId);


            modelBuilder.Entity<Episode>()
                .HasOne(e => e.Season)
                .WithMany(season => season.Episodes)
                .HasForeignKey(e => e.SeasonId);


            #endregion

            #region Property configurations

            #region Series
            modelBuilder.Entity<Serie>().Property(s => s.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Serie>().Property(s => s.imagePath).IsRequired();
            modelBuilder.Entity<Serie>().Property(s => s.year).IsRequired();
            modelBuilder.Entity<Serie>().Property(s => s.directorId).IsRequired();
            #endregion

            #region Genders
            modelBuilder.Entity<Gender>().Property(g => g.Name).IsRequired().HasMaxLength(150);
            #endregion

            #region Producers
            modelBuilder.Entity<Producer>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            #endregion

            #region Directors
            modelBuilder.Entity<Director>().Property(d => d.Name).IsRequired().HasMaxLength(200);
            #endregion

            #region Movies
            modelBuilder.Entity<Movie>().Property(m => m.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Movie>().Property(m => m.imagePath).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.year).IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.directorId).IsRequired();
            modelBuilder.Entity<Episode>().Property(m => m.url).IsRequired();
            #endregion

            #region Episode
            modelBuilder.Entity<Episode>().Property(e => e.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Episode>().Property(e => e.imagePath).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.ReleaseDate).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.url).IsRequired();
            #endregion

            #endregion
        }
    }
}
