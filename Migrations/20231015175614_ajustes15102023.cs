using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Child.Growth.Migrations
{
    /// <inheritdoc />
    public partial class ajustes15102023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_responsible_users_UserId",
                table: "responsible");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "responsible",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_responsible_UserId",
                table: "responsible",
                newName: "IX_responsible_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "observations",
                table: "patient_consultation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_responsible_users_user_id",
                table: "responsible",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_responsible_users_user_id",
                table: "responsible");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "responsible",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_responsible_user_id",
                table: "responsible",
                newName: "IX_responsible_UserId");

            migrationBuilder.AlterColumn<float>(
                name: "observations",
                table: "patient_consultation",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_responsible_users_UserId",
                table: "responsible",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
