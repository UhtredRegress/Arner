using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arner.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdjustItemTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemType_Items_ItemsId",
                table: "ItemType");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemType_Types_TypesId",
                table: "ItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType");

            migrationBuilder.RenameColumn(
                name: "TypesId",
                table: "ItemType",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "ItemType",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemType_TypesId",
                table: "ItemType",
                newName: "IX_ItemType_TypeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_ItemId",
                table: "ItemType",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemType_Items_ItemId",
                table: "ItemType",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemType_Types_TypeId",
                table: "ItemType",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemType_Items_ItemId",
                table: "ItemType");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemType_Types_TypeId",
                table: "ItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType");

            migrationBuilder.DropIndex(
                name: "IX_ItemType_ItemId",
                table: "ItemType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemType");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "ItemType",
                newName: "TypesId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemType",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemType_TypeId",
                table: "ItemType",
                newName: "IX_ItemType_TypesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType",
                columns: new[] { "ItemsId", "TypesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemType_Items_ItemsId",
                table: "ItemType",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemType_Types_TypesId",
                table: "ItemType",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
