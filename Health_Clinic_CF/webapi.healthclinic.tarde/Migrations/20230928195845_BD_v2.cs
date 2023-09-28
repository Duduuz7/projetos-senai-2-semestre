using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.tarde.Migrations
{
    /// <inheritdoc />
    public partial class BD_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Paciente",
                type: "CHAR(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(7)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Paciente",
                type: "CHAR(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(9)");
        }
    }
}
