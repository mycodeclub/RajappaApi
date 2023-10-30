using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class WorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WFApprovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kostl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusObjType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFLvlName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WFApprovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WFApprXs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusObjType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFLvlName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REditMode = table.Column<bool>(type: "bit", nullable: true),
                    NEditMode = table.Column<bool>(type: "bit", nullable: true),
                    MEditMode = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WFApprXs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WFContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusObjType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WFContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WFGenerals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kostl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusMType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusObjType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WFEsct = table.Column<bool>(type: "bit", nullable: true),
                    WFRemd = table.Column<bool>(type: "bit", nullable: true),
                    WFTSla = table.Column<float>(type: "real", nullable: true),
                    WFTRmd = table.Column<float>(type: "real", nullable: true),
                    Outlook = table.Column<bool>(type: "bit", nullable: true),
                    Inbox = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WFGenerals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WFApprovers");

            migrationBuilder.DropTable(
                name: "WFApprXs");

            migrationBuilder.DropTable(
                name: "WFContents");

            migrationBuilder.DropTable(
                name: "WFGenerals");
        }
    }
}
