using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralSurveyReport",
                columns: table => new
                {
                    ApptCopyGenSurveyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApptId = table.Column<int>(type: "int", nullable: false),
                    ApptNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    MRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallRating = table.Column<int>(type: "int", nullable: true),
                    DoctorRating = table.Column<int>(type: "int", nullable: true),
                    NurseRating = table.Column<int>(type: "int", nullable: true),
                    ReceptionRating = table.Column<int>(type: "int", nullable: true),
                    RecommendedRating = table.Column<int>(type: "int", nullable: true),
                    RecommendComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NursesAndStaffComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceptionStaffComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallSubAnswer = table.Column<int>(type: "int", nullable: true),
                    DoctorSubAnswer = table.Column<int>(type: "int", nullable: true),
                    NursesAndStaffSubAnswer = table.Column<int>(type: "int", nullable: true),
                    ReceptionStaffSubAnswer = table.Column<int>(type: "int", nullable: true),
                    SurveyStatus = table.Column<int>(type: "int", nullable: false),
                    RespondedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    complainOrFeedback = table.Column<int>(type: "int", nullable: true),
                    IsContactedByServiceTeam = table.Column<bool>(type: "bit", nullable: true),
                    InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSurveyReport", x => x.ApptCopyGenSurveyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralSurveyReport");
        }
    }
}
