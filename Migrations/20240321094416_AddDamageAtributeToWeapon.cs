using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netCrash.Migrations
{
    /// <inheritdoc />
    public partial class AddDamageAtributeToWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Weapons");
        }
    }
}
