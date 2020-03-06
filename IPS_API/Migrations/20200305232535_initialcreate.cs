using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPS_API.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CorporateAccount",
                columns: table => new
                {
                    CorporateAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ABN = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BSB = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateAccount", x => x.CorporateAccountId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAccount",
                columns: table => new
                {
                    PersonalAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TFN = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BSB = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccount", x => x.PersonalAccountId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOfficer",
                columns: table => new
                {
                    CompanyOfficerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(4)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CorporateAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOfficer", x => x.CompanyOfficerId);
                    table.ForeignKey(
                        name: "FK_CompanyOfficer_CorporateAccount_CorporateAccountId",
                        column: x => x.CorporateAccountId,
                        principalTable: "CorporateAccount",
                        principalColumn: "CorporateAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssociatedIndividual",
                columns: table => new
                {
                    AssociatedIndividualId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(4)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    CorporateAccountId = table.Column<int>(nullable: true),
                    PersonalAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociatedIndividual", x => x.AssociatedIndividualId);
                    table.ForeignKey(
                        name: "FK_AssociatedIndividual_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountType",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociatedIndividual_CorporateAccount_CorporateAccountId",
                        column: x => x.CorporateAccountId,
                        principalTable: "CorporateAccount",
                        principalColumn: "CorporateAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssociatedIndividual_PersonalAccount_PersonalAccountId",
                        column: x => x.PersonalAccountId,
                        principalTable: "PersonalAccount",
                        principalColumn: "PersonalAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociatedIndividual_AccountTypeId",
                table: "AssociatedIndividual",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociatedIndividual_CorporateAccountId",
                table: "AssociatedIndividual",
                column: "CorporateAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociatedIndividual_PersonalAccountId",
                table: "AssociatedIndividual",
                column: "PersonalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOfficer_CorporateAccountId",
                table: "CompanyOfficer",
                column: "CorporateAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociatedIndividual");

            migrationBuilder.DropTable(
                name: "CompanyOfficer");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropTable(
                name: "PersonalAccount");

            migrationBuilder.DropTable(
                name: "CorporateAccount");
        }
    }
}
