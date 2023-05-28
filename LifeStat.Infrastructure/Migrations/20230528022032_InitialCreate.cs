using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LifeStat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    StartTimeUtc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    EndTimeUtc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    StartTimeLocal = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    EndTimeLocal = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DailyPlanId = table.Column<int>(type: "int", nullable: true),
                    ActivityTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActivityTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTemplates", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyPlanActivityDurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ActivityTemplateId = table.Column<int>(type: "int", nullable: false),
                    DailyPlanTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPlanActivityDurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyPlanActivityDurations_ActivityTemplates_ActivityTemplat~",
                        column: x => x.ActivityTemplateId,
                        principalTable: "ActivityTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FulfillmentStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DailyPlanTemplateId = table.Column<int>(type: "int", nullable: false),
                    WeeklyPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPlans", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyPlanTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WeeklyPlanTemplateDLId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPlanTemplates", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InnerUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CurrentActivityId = table.Column<int>(type: "int", nullable: false),
                    CurrentDailyPlanId = table.Column<int>(type: "int", nullable: false),
                    CurrentWeeklyPlanId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnerUsers_Activities_CurrentActivityId",
                        column: x => x.CurrentActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerUsers_DailyPlans_CurrentDailyPlanId",
                        column: x => x.CurrentDailyPlanId,
                        principalTable: "DailyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeeklyPlanTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanTemplates_InnerUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InnerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeeklyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FulfillmentStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    WeeklyPlanTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlans_InnerUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "InnerUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeeklyPlans_WeeklyPlanTemplates_WeeklyPlanTemplateId",
                        column: x => x.WeeklyPlanTemplateId,
                        principalTable: "WeeklyPlanTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTemplateId",
                table: "Activities",
                column: "ActivityTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DailyPlanId",
                table: "Activities",
                column: "DailyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTemplates_UserId",
                table: "ActivityTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlanActivityDurations_ActivityTemplateId",
                table: "DailyPlanActivityDurations",
                column: "ActivityTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlanActivityDurations_DailyPlanTemplateId",
                table: "DailyPlanActivityDurations",
                column: "DailyPlanTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlans_DailyPlanTemplateId",
                table: "DailyPlans",
                column: "DailyPlanTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlans_UserId",
                table: "DailyPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlans_WeeklyPlanId",
                table: "DailyPlans",
                column: "WeeklyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlanTemplates_UserId",
                table: "DailyPlanTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPlanTemplates_WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates",
                column: "WeeklyPlanTemplateDLId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerUsers_ApplicationUserId",
                table: "InnerUsers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InnerUsers_CurrentActivityId",
                table: "InnerUsers",
                column: "CurrentActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerUsers_CurrentDailyPlanId",
                table: "InnerUsers",
                column: "CurrentDailyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerUsers_CurrentWeeklyPlanId",
                table: "InnerUsers",
                column: "CurrentWeeklyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlans_UserId",
                table: "WeeklyPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlans_WeeklyPlanTemplateId",
                table: "WeeklyPlans",
                column: "WeeklyPlanTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanTemplates_UserId",
                table: "WeeklyPlanTemplates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTemplates_ActivityTemplateId",
                table: "Activities",
                column: "ActivityTemplateId",
                principalTable: "ActivityTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_DailyPlans_DailyPlanId",
                table: "Activities",
                column: "DailyPlanId",
                principalTable: "DailyPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_InnerUsers_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "InnerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTemplates_InnerUsers_UserId",
                table: "ActivityTemplates",
                column: "UserId",
                principalTable: "InnerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlanActivityDurations_DailyPlanTemplates_DailyPlanTempl~",
                table: "DailyPlanActivityDurations",
                column: "DailyPlanTemplateId",
                principalTable: "DailyPlanTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlans_DailyPlanTemplates_DailyPlanTemplateId",
                table: "DailyPlans",
                column: "DailyPlanTemplateId",
                principalTable: "DailyPlanTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlans_InnerUsers_UserId",
                table: "DailyPlans",
                column: "UserId",
                principalTable: "InnerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlans_WeeklyPlans_WeeklyPlanId",
                table: "DailyPlans",
                column: "WeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlanTemplates_InnerUsers_UserId",
                table: "DailyPlanTemplates",
                column: "UserId",
                principalTable: "InnerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyPlanTemplates_WeeklyPlanTemplates_WeeklyPlanTemplateDLId",
                table: "DailyPlanTemplates",
                column: "WeeklyPlanTemplateDLId",
                principalTable: "WeeklyPlanTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InnerUsers_WeeklyPlans_CurrentWeeklyPlanId",
                table: "InnerUsers",
                column: "CurrentWeeklyPlanId",
                principalTable: "WeeklyPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTemplates_ActivityTemplateId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_DailyPlans_DailyPlanId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerUsers_DailyPlans_CurrentDailyPlanId",
                table: "InnerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_InnerUsers_UserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyPlans_InnerUsers_UserId",
                table: "WeeklyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyPlanTemplates_InnerUsers_UserId",
                table: "WeeklyPlanTemplates");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DailyPlanActivityDurations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ActivityTemplates");

            migrationBuilder.DropTable(
                name: "DailyPlans");

            migrationBuilder.DropTable(
                name: "DailyPlanTemplates");

            migrationBuilder.DropTable(
                name: "InnerUsers");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WeeklyPlans");

            migrationBuilder.DropTable(
                name: "WeeklyPlanTemplates");
        }
    }
}
