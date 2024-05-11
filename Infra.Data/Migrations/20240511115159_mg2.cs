using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_GameNet_TblGameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_TblSubEntity_TblSubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityGameNet",
                table: "EntityGameNet");

            migrationBuilder.RenameTable(
                name: "EntityGameNet",
                newName: "TblSubEntityGameNet");

            migrationBuilder.RenameIndex(
                name: "IX_EntityGameNet_TblSubEntityId",
                table: "TblSubEntityGameNet",
                newName: "IX_TblSubEntityGameNet_TblSubEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityGameNet_TblGameNetId",
                table: "TblSubEntityGameNet",
                newName: "IX_TblSubEntityGameNet_TblGameNetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSubEntityGameNet",
                table: "TblSubEntityGameNet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubEntityGameNet_GameNet_TblGameNetId",
                table: "TblSubEntityGameNet",
                column: "TblGameNetId",
                principalTable: "GameNet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubEntityGameNet_TblSubEntity_TblSubEntityId",
                table: "TblSubEntityGameNet",
                column: "TblSubEntityId",
                principalTable: "TblSubEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSubEntityGameNet_GameNet_TblGameNetId",
                table: "TblSubEntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSubEntityGameNet_TblSubEntity_TblSubEntityId",
                table: "TblSubEntityGameNet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSubEntityGameNet",
                table: "TblSubEntityGameNet");

            migrationBuilder.RenameTable(
                name: "TblSubEntityGameNet",
                newName: "EntityGameNet");

            migrationBuilder.RenameIndex(
                name: "IX_TblSubEntityGameNet_TblSubEntityId",
                table: "EntityGameNet",
                newName: "IX_EntityGameNet_TblSubEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_TblSubEntityGameNet_TblGameNetId",
                table: "EntityGameNet",
                newName: "IX_EntityGameNet_TblGameNetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityGameNet",
                table: "EntityGameNet",
                column: "Id");

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
        }
    }
}
