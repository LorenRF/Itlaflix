using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itlaflix.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoElAtributoEpisodeNumberALaEntidadEpisode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "episodeNumber",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "episodeNumber",
                table: "Episodes");
        }
    }
}
