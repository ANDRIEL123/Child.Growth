using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Child.Growth.Migrations
{
    /// <inheritdoc />
    public partial class addResponsible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ResponsibleId",
                table: "children",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Responsible",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsible", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_children_ResponsibleId",
                table: "children",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_children_Responsible_ResponsibleId",
                table: "children",
                column: "ResponsibleId",
                principalTable: "Responsible",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_children_Responsible_ResponsibleId",
                table: "children");

            migrationBuilder.DropTable(
                name: "Responsible");

            migrationBuilder.DropIndex(
                name: "IX_children_ResponsibleId",
                table: "children");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "children");
        }
    }
}
