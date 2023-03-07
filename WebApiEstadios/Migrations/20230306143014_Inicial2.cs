using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEstadios.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "Estadios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Entidad",
                table: "Estadios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "Estadios");

            migrationBuilder.DropColumn(
                name: "Entidad",
                table: "Estadios");
        }
    }
}
