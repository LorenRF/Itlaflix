using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itlaflix.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_auditable_Propierties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Episodes",
                newName: "modificateBy");

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Series",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Series",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modificateBy",
                table: "Series",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Series",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Seasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Seasons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modificateBy",
                table: "Seasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Seasons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Producers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modificateBy",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Producers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modificateBy",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Genders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modificateBy",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Genders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Episodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Episodes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createBy",
                table: "Director",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Director",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modificateBy",
                table: "Director",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modificated",
                table: "Director",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "modificateBy",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "modificateBy",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "modificateBy",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "modificateBy",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "modificateBy",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "createBy",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "modificateBy",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "modificated",
                table: "Director");

            migrationBuilder.RenameColumn(
                name: "modificateBy",
                table: "Episodes",
                newName: "Title");
        }
    }
}
