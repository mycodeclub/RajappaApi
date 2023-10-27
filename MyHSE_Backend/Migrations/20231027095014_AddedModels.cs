using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BUSMTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessObjects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BUSMTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessObjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLASS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHARID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHARNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLASSNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOCID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FILENAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FILETYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FILESIZE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FILEPATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    SYST = table.Column<bool>(type: "bit", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ORGID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURRENCY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LANG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARNRID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PARFUNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BPARFUNCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUSTODIAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STREET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOUSE_NUM1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOUSE_NUM2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STREET2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STREET3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STREET4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LANDMARK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLOOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUILDING = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MOBNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAILADDR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USR01 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USR02 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USR03 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USR04 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USR05 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PLANT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORGID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOUSENUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STREET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPLOGO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WEBSITE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIMEZONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLOGO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasingGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PDGRP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasingOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PDORG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORGID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LGOTP = table.Column<bool>(type: "bit", nullable: false),
                    LGDOMAIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIMEOUT = table.Column<int>(type: "int", nullable: false),
                    LGCOUNT = table.Column<int>(type: "int", nullable: false),
                    CAPTCHA = table.Column<bool>(type: "bit", nullable: false),
                    PWLENGTH = table.Column<int>(type: "int", nullable: false),
                    PWUPPERCASE = table.Column<bool>(type: "bit", nullable: false),
                    PWSPCHAR = table.Column<bool>(type: "bit", nullable: false),
                    PWNUMBER = table.Column<bool>(type: "bit", nullable: false),
                    IPASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSOURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAPUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAPPW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMSAPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WHATSAPPAPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GFCMKEY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AFCMKEY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UOMID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WFID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUSOBJTYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEQUENCE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POSITION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WFSTATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WFAPPR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUSERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RUSERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDDATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CHANGEDTIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessModules");

            migrationBuilder.DropTable(
                name: "BusinessObjects");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "ObjectStatus");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "ProfileSettings");

            migrationBuilder.DropTable(
                name: "PurchasingGroups");

            migrationBuilder.DropTable(
                name: "PurchasingOrganizations");

            migrationBuilder.DropTable(
                name: "Security");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "WorkflowLog");
        }
    }
}
