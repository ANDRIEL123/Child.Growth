using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Child.Growth.Migrations
{
    /// <inheritdoc />
    public partial class addResponsible5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_children_responsible_ResponsibleId",
                table: "children");

            migrationBuilder.RenameColumn(
                name: "ResponsibleId",
                table: "children",
                newName: "responsible_id");

            migrationBuilder.RenameIndex(
                name: "IX_children_ResponsibleId",
                table: "children",
                newName: "IX_children_responsible_id");

            migrationBuilder.AddForeignKey(
                name: "FK_children_responsible_responsible_id",
                table: "children",
                column: "responsible_id",
                principalTable: "responsible",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_children_responsible_responsible_id",
                table: "children");

            migrationBuilder.RenameColumn(
                name: "responsible_id",
                table: "children",
                newName: "ResponsibleId");

            migrationBuilder.RenameIndex(
                name: "IX_children_responsible_id",
                table: "children",
                newName: "IX_children_ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_children_responsible_ResponsibleId",
                table: "children",
                column: "ResponsibleId",
                principalTable: "responsible",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
