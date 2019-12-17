using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectGym.Infraestructure.Migrations
{
    public partial class InscriptionPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlanId",
                table: "Inscriptions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_PlanId",
                table: "Inscriptions",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscription_Plan",
                table: "Inscriptions",
                column: "PlanId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscription_Plan",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_PlanId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Inscriptions");
        }
    }
}
