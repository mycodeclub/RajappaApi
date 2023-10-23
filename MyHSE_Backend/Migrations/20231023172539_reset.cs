using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAILID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELMB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USTYP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USGRP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUTHORITIES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EXTERNAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REGISTER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOCK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APPLOGS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LPASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LANGUAGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIMEZONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DCPFM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATFM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIMEFM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORGID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLANT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WKCTR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPLANT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PGROUP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARVW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AVALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVICEPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVICETYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVICEID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVICESNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UDID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOKENID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHKDEVICEID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFIEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODIFIEDON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIVISION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESIGNATION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEPARTMENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GRADE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USGRP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODIFIEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODIFIEDON = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGroups", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "userGroups");
        }
    }
}
