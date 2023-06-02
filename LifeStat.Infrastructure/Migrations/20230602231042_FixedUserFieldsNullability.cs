using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeStat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserFieldsNullability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_Activities_CurrentActivityId",
                table: "InnerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_DailyPlans_CurrentDailyPlanId",
                table: "InnerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_WeeklyPlans_CurrentWeeklyPlanId",
                table: "InnerUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentWeeklyPlanId",
                table: "InnerUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentDailyPlanId",
                table: "InnerUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentActivityId",
                table: "InnerUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_Activities_CurrentActivityId",
                table: "InnerUsers",
                column: "CurrentActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_DailyPlans_CurrentDailyPlanId",
                table: "InnerUsers",
                column: "CurrentDailyPlanId",
                principalTable: "DailyPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_WeeklyPlans_CurrentWeeklyPlanId",
                table: "InnerUsers",
                column: "CurrentWeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_Activities_CurrentActivityId",
                table: "InnerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_DailyPlans_CurrentDailyPlanId",
                table: "InnerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_WeeklyPlans_CurrentWeeklyPlanId",
                table: "InnerUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentWeeklyPlanId",
                table: "InnerUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentDailyPlanId",
                table: "InnerUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentActivityId",
                table: "InnerUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_Activities_CurrentActivityId",
                table: "InnerUsers",
                column: "CurrentActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_DailyPlans_CurrentDailyPlanId",
                table: "InnerUsers",
                column: "CurrentDailyPlanId",
                principalTable: "DailyPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_WeeklyPlans_CurrentWeeklyPlanId",
                table: "InnerUsers",
                column: "CurrentWeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
