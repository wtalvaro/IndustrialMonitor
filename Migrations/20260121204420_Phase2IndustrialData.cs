using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialMonitor.Migrations
{
    /// <inheritdoc />
    public partial class Phase2IndustrialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ConsumoEnergia",
                table: "Maquinas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MomentoProcesso",
                table: "Maquinas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoFuncionamento",
                table: "Maquinas",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumoEnergia",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "MomentoProcesso",
                table: "Maquinas");

            migrationBuilder.DropColumn(
                name: "TempoFuncionamento",
                table: "Maquinas");
        }
    }
}
