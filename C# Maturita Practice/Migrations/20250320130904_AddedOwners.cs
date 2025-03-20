using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Maturita_Practice.Migrations
{
    /// <inheritdoc />
    public partial class AddedOwners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Owner",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Notes");
        }
    }
}
