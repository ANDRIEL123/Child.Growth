using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Child.Growth.Migrations
{
    /// <inheritdoc />
    public partial class updateResponsible3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "responsible",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_responsible_UserId",
                table: "responsible",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_responsible_users_UserId",
                table: "responsible",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_responsible_users_UserId",
                table: "responsible");

            migrationBuilder.DropIndex(
                name: "IX_responsible_UserId",
                table: "responsible");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "responsible");
        }
    }
}
