using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Child.Growth.Migrations
{
    /// <inheritdoc />
    public partial class addPatientConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patient_consultation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    height = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    cephalic_perimeter = table.Column<float>(type: "real", nullable: false),
                    observations = table.Column<float>(type: "real", nullable: false),
                    children_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_consultation", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_consultation_children_children_id",
                        column: x => x.children_id,
                        principalTable: "children",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patient_consultation_children_id",
                table: "patient_consultation",
                column: "children_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patient_consultation");
        }
    }
}
