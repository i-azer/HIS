using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HIS.Infrastructure.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MidName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Suffix = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: false),
                    POBox = table.Column<string>(nullable: true),
                    PatientGender = table.Column<string>(nullable: false),
                    PatientDateOfBirth = table.Column<DateTime>(nullable: false),
                    PassportNo = table.Column<string>(nullable: false),
                    EmirateId = table.Column<string>(nullable: false),
                    PatientWorkTitle = table.Column<string>(nullable: true),
                    MailAddress = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: false),
                    Home = table.Column<string>(nullable: true),
                    Work = table.Column<string>(nullable: true),
                    GuardianFirstName = table.Column<string>(nullable: true),
                    GuardianMidName = table.Column<string>(nullable: true),
                    GuardianLastName = table.Column<string>(nullable: true),
                    GuardianSuffix = table.Column<string>(nullable: true),
                    GuardianMobile = table.Column<string>(nullable: true),
                    GuardianHome = table.Column<string>(nullable: true),
                    GuardianWork = table.Column<string>(nullable: true),
                    GuardianAddressLine1 = table.Column<string>(nullable: true),
                    GuardianAddressLine2 = table.Column<string>(nullable: true),
                    GuardianPOBox = table.Column<string>(nullable: true),
                    GuardianRelation = table.Column<string>(nullable: false),
                    PatientNationality = table.Column<string>(nullable: false),
                    PatientInsurance = table.Column<string>(nullable: false),
                    PatientMaritalStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
