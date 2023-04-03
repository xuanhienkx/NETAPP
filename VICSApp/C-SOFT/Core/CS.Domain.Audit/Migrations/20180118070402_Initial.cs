using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CS.Domain.Audit.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustodyRequestHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<string>(maxLength: 125, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContentClrType = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Priority = table.Column<byte>(nullable: false),
                    RequestType = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustodyRequestHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSources",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeviceId = table.Column<string>(maxLength: 256, nullable: true),
                    Path = table.Column<string>(maxLength: 512, nullable: true),
                    RequestSource = table.Column<string>(maxLength: 512, nullable: true),
                    UserLoginId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSources", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Address = table.Column<string>(maxLength: 65, nullable: false),
                    AuditType = table.Column<byte>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    BrokerId = table.Column<Guid>(nullable: true),
                    CardIdentity = table.Column<string>(type: "varchar(30)", nullable: false),
                    CardIssuedDate = table.Column<DateTime>(nullable: false),
                    CardIssuer = table.Column<string>(maxLength: 65, nullable: false),
                    CardType = table.Column<byte>(nullable: false),
                    City = table.Column<string>(maxLength: 35, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: true),
                    CustomerNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    FullName = table.Column<string>(maxLength: 140, nullable: false),
                    FullNameLocal = table.Column<string>(maxLength: 140, nullable: false),
                    Genere = table.Column<byte>(nullable: false),
                    NationalityCode = table.Column<string>(maxLength: 2, nullable: true),
                    Notes = table.Column<string>(maxLength: 350, nullable: true),
                    PinCode = table.Column<string>(type: "varchar(max)", nullable: true),
                    SignatureImage1 = table.Column<byte[]>(nullable: true),
                    SignatureImage2 = table.Column<byte[]>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    TaxCode = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAudits_EventSources_Id",
                        column: x => x.Id,
                        principalTable: "EventSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginRequests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    LoginType = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginRequests_EventSources_Id",
                        column: x => x.Id,
                        principalTable: "EventSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageQueues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    ClrType = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    PublishedDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageQueues_EventSources_Id",
                        column: x => x.Id,
                        principalTable: "EventSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSources_CreatedDate",
                table: "EventSources",
                column: "CreatedDate")
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustodyRequestHistory");

            migrationBuilder.DropTable(
                name: "CustomerAudits");

            migrationBuilder.DropTable(
                name: "LoginRequests");

            migrationBuilder.DropTable(
                name: "MessageQueues");

            migrationBuilder.DropTable(
                name: "EventSources");
        }
    }
}
