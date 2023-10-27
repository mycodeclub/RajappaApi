using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "RolePermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLEID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALIDFROM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALIDTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePermission");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission",
                column: "Id");
        }
    }
}
