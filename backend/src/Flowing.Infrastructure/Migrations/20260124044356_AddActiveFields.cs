using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flowing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Actions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Actions");
        }
    }
}
