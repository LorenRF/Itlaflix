using Itlaflix.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlaflix.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
        {
        
        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            modelBuilder.Entity<Producer>().ToTable("Producers");

            #endregion

            #region "primary keys"
            modelBuilder.Entity<Serie>().HasKey(serie => serie.Id);
            modelBuilder.Entity<Movie>().HasKey(movie => movie.Id);
            modelBuilder.Entity<Gender>().HasKey(gender => gender.Id);
            modelBuilder.Entity<Producer>().HasKey(producer => producer.Id);
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
            #endregion

            #endregion
        }
    }
}
