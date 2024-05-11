using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameNetSeller");

            migrationBuilder.DropTable(
                name: "TblRoleGameNet");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Debt",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerAccounting",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebt",
                table: "Debt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "TblDebtId",
                table: "CustomerAccounting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblUserId",
                table: "CustomerAccounting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblUserGameNet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameNetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TblGameNetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserGameNet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUserGameNet_AspNetUsers_TblUserId",
                        column: x => x.TblUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblUserGameNet_GameNet_TblGameNetId",
                        column: x => x.TblGameNetId,
                        principalTable: "GameNet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounting_TblDebtId",
                table: "CustomerAccounting",
                column: "TblDebtId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounting_TblUserId",
                table: "CustomerAccounting",
                column: "TblUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserGameNet_TblGameNetId",
                table: "TblUserGameNet",
                column: "TblGameNetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserGameNet_TblUserId",
                table: "TblUserGameNet",
                column: "TblUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounting_AspNetUsers_TblUserId",
                table: "CustomerAccounting",
                column: "TblUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounting_Debt_TblDebtId",
                table: "CustomerAccounting",
                column: "TblDebtId",
                principalTable: "Debt",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounting_AspNetUsers_TblUserId",
                table: "CustomerAccounting");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounting_Debt_TblDebtId",
                table: "CustomerAccounting");

            migrationBuilder.DropTable(
                name: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounting_TblDebtId",
                table: "CustomerAccounting");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounting_TblUserId",
                table: "CustomerAccounting");

            migrationBuilder.DropColumn(
                name: "DateDebt",
                table: "Debt");

            migrationBuilder.DropColumn(
                name: "TblDebtId",
                table: "CustomerAccounting");

            migrationBuilder.DropColumn(
                name: "TblUserId",
                table: "CustomerAccounting");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Debt",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CustomerAccounting",
                newName: "CustomerId");

            migrationBuilder.CreateTable(
                name: "GameNetSeller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameNetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameNetSeller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRoleGameNet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblGameNetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TblRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameNetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoleGameNet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRoleGameNet_AspNetRoles_TblRoleId",
                        column: x => x.TblRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRoleGameNet_GameNet_TblGameNetId",
                        column: x => x.TblGameNetId,
                        principalTable: "GameNet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblRoleGameNet_TblGameNetId",
                table: "TblRoleGameNet",
                column: "TblGameNetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRoleGameNet_TblRoleId",
                table: "TblRoleGameNet",
                column: "TblRoleId");
        }
    }
}
