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
            migrationBuilder.DropForeignKey(
                name: "FK_Debt_AspNetUsers_TblUserId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_TblSubEntity_TblSubEntityId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_GameNet_TblGameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_TblSubEntity_TblSubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSubEntity_Entity_TblEntityId",
                table: "TblSubEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TblUserGameNet_AspNetUsers_TblUserId",
                table: "TblUserGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_TblUserGameNet_GameNet_TblGameNetId",
                table: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_TblUserGameNet_TblGameNetId",
                table: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_TblUserGameNet_TblUserId",
                table: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_TblSubEntity_TblEntityId",
                table: "TblSubEntity");

            migrationBuilder.DropIndex(
                name: "IX_EntityGameNet_TblGameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropIndex(
                name: "IX_EntityGameNet_TblSubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropIndex(
                name: "IX_Debt_TblSubEntityId",
                table: "Debt");

            migrationBuilder.DropIndex(
                name: "IX_Debt_TblUserId",
                table: "Debt");

            migrationBuilder.DropColumn(
                name: "TblGameNetId",
                table: "TblUserGameNet");

            migrationBuilder.DropColumn(
                name: "TblUserId",
                table: "TblUserGameNet");

            migrationBuilder.DropColumn(
                name: "TblEntityId",
                table: "TblSubEntity");

            migrationBuilder.DropColumn(
                name: "TblGameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropColumn(
                name: "TblSubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropColumn(
                name: "TblSubEntityId",
                table: "Debt");

            migrationBuilder.DropColumn(
                name: "TblUserId",
                table: "Debt");

            migrationBuilder.AddColumn<Guid>(
                name: "GameNetId",
                table: "TblUserGameNet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TblUserGameNet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "TblSubEntity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TblUserGameNet_GameNetId",
                table: "TblUserGameNet",
                column: "GameNetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserGameNet_UserId",
                table: "TblUserGameNet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSubEntity_EntityId",
                table: "TblSubEntity",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityGameNet_GameNetId",
                table: "EntityGameNet",
                column: "GameNetId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityGameNet_SubEntityId",
                table: "EntityGameNet",
                column: "SubEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_SubEntityId",
                table: "Debt",
                column: "SubEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_UserId",
                table: "Debt",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_AspNetUsers_UserId",
                table: "Debt",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_TblSubEntity_SubEntityId",
                table: "Debt",
                column: "SubEntityId",
                principalTable: "TblSubEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGameNet_GameNet_GameNetId",
                table: "EntityGameNet",
                column: "GameNetId",
                principalTable: "GameNet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGameNet_TblSubEntity_SubEntityId",
                table: "EntityGameNet",
                column: "SubEntityId",
                principalTable: "TblSubEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubEntity_Entity_EntityId",
                table: "TblSubEntity",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblUserGameNet_AspNetUsers_UserId",
                table: "TblUserGameNet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblUserGameNet_GameNet_GameNetId",
                table: "TblUserGameNet",
                column: "GameNetId",
                principalTable: "GameNet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debt_AspNetUsers_UserId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_Debt_TblSubEntity_SubEntityId",
                table: "Debt");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_GameNet_GameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_TblSubEntity_SubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSubEntity_Entity_EntityId",
                table: "TblSubEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TblUserGameNet_AspNetUsers_UserId",
                table: "TblUserGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_TblUserGameNet_GameNet_GameNetId",
                table: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_TblUserGameNet_GameNetId",
                table: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_TblUserGameNet_UserId",
                table: "TblUserGameNet");

            migrationBuilder.DropIndex(
                name: "IX_TblSubEntity_EntityId",
                table: "TblSubEntity");

            migrationBuilder.DropIndex(
                name: "IX_EntityGameNet_GameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropIndex(
                name: "IX_EntityGameNet_SubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropIndex(
                name: "IX_Debt_SubEntityId",
                table: "Debt");

            migrationBuilder.DropIndex(
                name: "IX_Debt_UserId",
                table: "Debt");

            migrationBuilder.DropColumn(
                name: "GameNetId",
                table: "TblUserGameNet");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblUserGameNet");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "TblSubEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "TblGameNetId",
                table: "TblUserGameNet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblUserId",
                table: "TblUserGameNet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblEntityId",
                table: "TblSubEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblGameNetId",
                table: "EntityGameNet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblSubEntityId",
                table: "EntityGameNet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblSubEntityId",
                table: "Debt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblUserId",
                table: "Debt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblUserGameNet_TblGameNetId",
                table: "TblUserGameNet",
                column: "TblGameNetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserGameNet_TblUserId",
                table: "TblUserGameNet",
                column: "TblUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSubEntity_TblEntityId",
                table: "TblSubEntity",
                column: "TblEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityGameNet_TblGameNetId",
                table: "EntityGameNet",
                column: "TblGameNetId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityGameNet_TblSubEntityId",
                table: "EntityGameNet",
                column: "TblSubEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_TblSubEntityId",
                table: "Debt",
                column: "TblSubEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_TblUserId",
                table: "Debt",
                column: "TblUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_AspNetUsers_TblUserId",
                table: "Debt",
                column: "TblUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debt_TblSubEntity_TblSubEntityId",
                table: "Debt",
                column: "TblSubEntityId",
                principalTable: "TblSubEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGameNet_GameNet_TblGameNetId",
                table: "EntityGameNet",
                column: "TblGameNetId",
                principalTable: "GameNet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityGameNet_TblSubEntity_TblSubEntityId",
                table: "EntityGameNet",
                column: "TblSubEntityId",
                principalTable: "TblSubEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubEntity_Entity_TblEntityId",
                table: "TblSubEntity",
                column: "TblEntityId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblUserGameNet_AspNetUsers_TblUserId",
                table: "TblUserGameNet",
                column: "TblUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblUserGameNet_GameNet_TblGameNetId",
                table: "TblUserGameNet",
                column: "TblGameNetId",
                principalTable: "GameNet",
                principalColumn: "Id");
        }
    }
}
