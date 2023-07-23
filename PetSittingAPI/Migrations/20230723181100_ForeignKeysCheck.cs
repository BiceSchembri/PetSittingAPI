using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetSittingAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Owners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PetId",
                table: "Owners",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Pets_PetId",
                table: "Owners",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Pets_PetId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PetId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Owners");
        }
    }
}
