using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RolePemissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userGroups",
                table: "userGroups");

            migrationBuilder.RenameTable(
                name: "userGroups",
                newName: "UserGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ROLEID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUSMTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUSFTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "userGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userGroups",
                table: "userGroups",
                column: "Id");
        }
    }
}
