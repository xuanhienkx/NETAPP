using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CS.Domain.Data.Migrations
{
    public partial class Settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAccountCurrent",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "CustomerAccountFrom",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "CustomerAccountTo",
                table: "Branches");

            migrationBuilder.CreateTable(
                name: "BranchSetting",
                columns: table => new
                {
                    BranchId = table.Column<long>(nullable: false),
                    Key = table.Column<string>(type: "varchar(250)", nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchSetting", x => new { x.BranchId, x.Key });
                    table.ForeignKey(
                        name: "FK_BranchSetting_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchSetting");

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountCurrent",
                table: "Branches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountFrom",
                table: "Branches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountTo",
                table: "Branches",
                nullable: false,
                defaultValue: 0);
        }
    }
}
