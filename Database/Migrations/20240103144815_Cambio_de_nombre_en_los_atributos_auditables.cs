using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itlaflix.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Cambio_de_nombre_en_los_atributos_auditables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temporadas",
                table: "Series",
                newName: "Temporadas");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Series",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Series",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Series",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Seasons",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Seasons",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Seasons",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Producers",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Producers",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Producers",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Movies",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Movies",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Movies",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Genders",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Genders",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Genders",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Episodes",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Episodes",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Episodes",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "modificated",
                table: "Director",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Director",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Director",
                newName: "createdBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temporadas",
                table: "Series",
                newName: "temporadas");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Series",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Series",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Series",
                newName: "createBy");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Seasons",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Seasons",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Seasons",
                newName: "createBy");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Producers",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Producers",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Producers",
                newName: "createBy");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Movies",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Movies",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Movies",
                newName: "createBy");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Genders",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Genders",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Genders",
                newName: "createBy");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Episodes",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Episodes",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Episodes",
                newName: "createBy");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Director",
                newName: "modificateBy");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Director",
                newName: "modificated");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Director",
                newName: "createBy");
        }
    }
}
