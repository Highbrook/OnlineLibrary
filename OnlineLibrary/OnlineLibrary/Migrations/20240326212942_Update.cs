using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_parentCategoryId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_parentCategoryId",
                table: "categories");

            migrationBuilder.AlterColumn<string>(
                name: "parentCategoryId",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "parentCategoryId",
                table: "categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_categories_parentCategoryId",
                table: "categories",
                column: "parentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_parentCategoryId",
                table: "categories",
                column: "parentCategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
