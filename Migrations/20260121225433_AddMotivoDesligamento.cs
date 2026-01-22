using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialMonitor.Migrations
{
    /// <inheritdoc />
    public partial class AddMotivoDesligamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MotivoDesligamento",
                table: "Maquinas",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotivoDesligamento",
                table: "Maquinas");
        }
    }
}
