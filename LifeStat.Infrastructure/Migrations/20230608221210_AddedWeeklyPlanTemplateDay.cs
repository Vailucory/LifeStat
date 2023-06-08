using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LifeStat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedWeeklyPlanTemplateDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyPlanTemplates_WeeklyPlanTemplates_WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates");

            migrationBuilder.DropIndex(
                name: "IX_DailyPlanTemplates_WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates");

            migrationBuilder.DropColumn(
                name: "WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates");

            migrationBuilder.CreateTable(
                name: "WeeklyPlanTemplateDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    DailyPlanTemplateId = table.Column<int>(type: "int", nullable: false),
                    WeeklyPlanTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanTemplateDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanTemplateDays_DailyPlanTemplates_DailyPlanTemplateId",
                        column: x => x.DailyPlanTemplateId,
                        principalTable: "DailyPlanTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanTemplateDays_WeeklyPlanTemplates_WeeklyPlanTemplat~",
                        column: x => x.WeeklyPlanTemplateId,
                        principalTable: "WeeklyPlanTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanTemplateDays_DailyPlanTemplateId",
                table: "WeeklyPlanTemplateDays",
                column: "DailyPlanTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanTemplateDays_WeeklyPlanTemplateId",
                table: "WeeklyPlanTemplateDays",
                column: "WeeklyPlanTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyPlanTemplateDays");

            migrationBuilder.AddColumn<int>(
                name: "WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlanTemplates_WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates",
                column: "WeeklyPlanTemplateDLId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlanTemplates_WeeklyPlanTemplates_WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates",
                column: "WeeklyPlanTemplateDLId",
                principalTable: "WeeklyPlanTemplates",
                principalColumn: "Id");
        }
    }
}
