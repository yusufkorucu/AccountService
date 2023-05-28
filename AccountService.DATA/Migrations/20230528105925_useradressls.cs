using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountService.Data.Migrations
{
    /// <inheritdoc />
    public partial class useradressls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId1",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserId1",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserAddress");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserAddress",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "UserAddress",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId1",
                table: "UserAddress",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId1",
                table: "UserAddress",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
