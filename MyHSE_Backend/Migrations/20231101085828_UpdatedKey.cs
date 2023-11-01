using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "RolePermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BUSOBJTYPE",
                table: "RolePermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BUSMTYPE",
                table: "RolePermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BUSFTYPE",
                table: "RolePermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Role",
                table: "Roles",
                column: "Role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_BUSFTYPE",
                table: "RolePermissions",
                column: "BUSFTYPE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_BUSMTYPE",
                table: "RolePermissions",
                column: "BUSMTYPE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_BUSOBJTYPE",
                table: "RolePermissions",
                column: "BUSOBJTYPE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_ROLEID",
                table: "RolePermissions",
                column: "ROLEID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_Role",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_BUSFTYPE",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_BUSMTYPE",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_BUSOBJTYPE",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_ROLEID",
                table: "RolePermissions");

            migrationBuilder.AlterColumn<string>(
                name: "ROLEID",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BUSOBJTYPE",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BUSMTYPE",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BUSFTYPE",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
