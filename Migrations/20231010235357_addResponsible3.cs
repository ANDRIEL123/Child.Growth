using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Child.Growth.Migrations
{
    /// <inheritdoc />
    public partial class addResponsible3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_children_Responsible_ResponsibleId",
                table: "children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsible",
                table: "Responsible");

            migrationBuilder.RenameTable(
                name: "Responsible",
                newName: "responsible");

            migrationBuilder.AddPrimaryKey(
                name: "PK_responsible",
                table: "responsible",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_children_responsible_ResponsibleId",
                table: "children",
                column: "ResponsibleId",
                principalTable: "responsible",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_children_responsible_ResponsibleId",
                table: "children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_responsible",
                table: "responsible");

            migrationBuilder.RenameTable(
                name: "responsible",
                newName: "Responsible");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsible",
                table: "Responsible",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_children_Responsible_ResponsibleId",
                table: "children",
                column: "ResponsibleId",
                principalTable: "Responsible",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
