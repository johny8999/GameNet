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
                name: "FK_CustomerAccounting_EntityGameNet_SubEntityGameNetId",
                table: "CustomerAccounting");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_GameNet_GameNetId",
                table: "EntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityGameNet_TblSubEntity_SubEntityId",
                table: "EntityGameNet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityGameNet",
                table: "EntityGameNet");

            migrationBuilder.RenameTable(
                name: "EntityGameNet",
                newName: "SubEntityGameNet");

            migrationBuilder.RenameIndex(
                name: "IX_EntityGameNet_SubEntityId",
                table: "SubEntityGameNet",
                newName: "IX_SubEntityGameNet_SubEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityGameNet_GameNetId",
                table: "SubEntityGameNet",
                newName: "IX_SubEntityGameNet_GameNetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubEntityGameNet",
                table: "SubEntityGameNet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounting_SubEntityGameNet_SubEntityGameNetId",
                table: "CustomerAccounting",
                column: "SubEntityGameNetId",
                principalTable: "SubEntityGameNet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubEntityGameNet_GameNet_GameNetId",
                table: "SubEntityGameNet",
                column: "GameNetId",
                principalTable: "GameNet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubEntityGameNet_TblSubEntity_SubEntityId",
                table: "SubEntityGameNet",
                column: "SubEntityId",
                principalTable: "TblSubEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounting_SubEntityGameNet_SubEntityGameNetId",
                table: "CustomerAccounting");

            migrationBuilder.DropForeignKey(
                name: "FK_SubEntityGameNet_GameNet_GameNetId",
                table: "SubEntityGameNet");

            migrationBuilder.DropForeignKey(
                name: "FK_SubEntityGameNet_TblSubEntity_SubEntityId",
                table: "SubEntityGameNet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubEntityGameNet",
                table: "SubEntityGameNet");

            migrationBuilder.RenameTable(
                name: "SubEntityGameNet",
                newName: "EntityGameNet");

            migrationBuilder.RenameIndex(
                name: "IX_SubEntityGameNet_SubEntityId",
                table: "EntityGameNet",
                newName: "IX_EntityGameNet_SubEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_SubEntityGameNet_GameNetId",
                table: "EntityGameNet",
                newName: "IX_EntityGameNet_GameNetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityGameNet",
                table: "EntityGameNet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounting_EntityGameNet_SubEntityGameNetId",
                table: "CustomerAccounting",
                column: "SubEntityGameNetId",
                principalTable: "EntityGameNet",
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
        }
    }
}
