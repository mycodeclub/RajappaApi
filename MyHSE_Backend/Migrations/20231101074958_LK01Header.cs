using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class LK01Header : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropColumn(
                name: "DepType",
                table: "Departments");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "WFApprovers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DivisionId",
                table: "WFApprovers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "Victims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FYear",
                table: "Victims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoSickLeaves",
                table: "Victims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VictContractor",
                table: "Victims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DivisionId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusMType",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusObjType",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FYear",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LK01Headers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FYear = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    SumDuringInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumBeforeInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumAfterInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncClassificationId = table.Column<int>(type: "int", nullable: true),
                    IncCategoryId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LK01Headers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LK01Headers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "WFApprovers");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "WFApprovers");

            migrationBuilder.DropColumn(
                name: "FYear",
                table: "Victims");

            migrationBuilder.DropColumn(
                name: "NoSickLeaves",
                table: "Victims");

            migrationBuilder.DropColumn(
                name: "VictContractor",
                table: "Victims");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BusMType",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BusObjType",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FYear",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "Victims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DepType",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Financial = table.Column<int>(type: "int", nullable: true),
                    IncCategoryId = table.Column<int>(type: "int", nullable: true),
                    IncClassificationId = table.Column<int>(type: "int", nullable: true),
                    IncDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoSickLeaves = table.Column<int>(type: "int", nullable: true),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumAfterInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumBeforeInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumDuringInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VictNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                });
        }
    }
}
