using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHSE_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addeduniquekeyforuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_USGRP",
                table: "UserGroups",
                column: "USGRP",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserGroups_USGRP",
                table: "UserGroups");
        }
    }
}
