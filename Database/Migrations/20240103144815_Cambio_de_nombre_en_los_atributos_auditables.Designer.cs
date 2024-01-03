﻿// <auto-generated />
using System;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Itlaflix.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240103144815_Cambio_de_nombre_en_los_atributos_auditables")]
    partial class Cambio_de_nombre_en_los_atributos_auditables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Director");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes", (string)null);
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders", (string)null);
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("directorId")
                        .HasColumnType("int");

                    b.Property<string>("imagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("directorId");

                    b.ToTable("Movies", (string)null);
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.MovieGender", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenderId");

                    b.HasIndex("GenderId");

                    b.ToTable("MovieGender");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers", (string)null);
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.ProducerMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("ProducerMovie");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.ProducerSerie", b =>
                {
                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("SerieId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("ProducerSerie");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Seasons", (string)null);
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Temporadas")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("directorId")
                        .HasColumnType("int");

                    b.Property<string>("imagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("directorId");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.SerieGender", b =>
                {
                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("SerieId", "GenderId");

                    b.HasIndex("GenderId");

                    b.ToTable("SerieGender");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Episode", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Movie", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Director", "director")
                        .WithMany("DirectedMovies")
                        .HasForeignKey("directorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("director");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.MovieGender", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Gender", "Gender")
                        .WithMany("MovieGenders")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itlaflix.Core.Domain.Entities.Movie", "Movie")
                        .WithMany("MovieGenders")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.ProducerMovie", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Movie", "Movie")
                        .WithMany("ProducerMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itlaflix.Core.Domain.Entities.Producer", "Producer")
                        .WithMany("ProducerMovies")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.ProducerSerie", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Producer", "Producer")
                        .WithMany("ProducerSeries")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itlaflix.Core.Domain.Entities.Serie", "Serie")
                        .WithMany("ProducerSerie")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producer");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Season", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Serie", "Serie")
                        .WithMany("Seasons")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Serie", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Director", "director")
                        .WithMany("DirectedSeries")
                        .HasForeignKey("directorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("director");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.SerieGender", b =>
                {
                    b.HasOne("Itlaflix.Core.Domain.Entities.Gender", "Gender")
                        .WithMany("SerieGenders")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itlaflix.Core.Domain.Entities.Serie", "Serie")
                        .WithMany("SerieGenders")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Director", b =>
                {
                    b.Navigation("DirectedMovies");

                    b.Navigation("DirectedSeries");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Gender", b =>
                {
                    b.Navigation("MovieGenders");

                    b.Navigation("SerieGenders");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Movie", b =>
                {
                    b.Navigation("MovieGenders");

                    b.Navigation("ProducerMovies");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Producer", b =>
                {
                    b.Navigation("ProducerMovies");

                    b.Navigation("ProducerSeries");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Season", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("Itlaflix.Core.Domain.Entities.Serie", b =>
                {
                    b.Navigation("ProducerSerie");

                    b.Navigation("Seasons");

                    b.Navigation("SerieGenders");
                });
#pragma warning restore 612, 618
        }
    }
}
