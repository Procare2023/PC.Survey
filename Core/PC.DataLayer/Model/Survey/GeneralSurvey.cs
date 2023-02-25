using PC.DataLayer.Enum;
using PC.External.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC.DataLayer.Model.Survey
{
    public class GeneralSurvey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ApptCopyGenSurveyId { get; set; }
        public long ApptId { get; set; }
        public string ApptNo { get; set; }
        public DateTime? ApptDate { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string MRN { get; set; }
        public string PatientName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string Specialty { get; set; }
        public string Doctor { get; set; }
        public int? OverallRating { get; set; }
        public int? DoctorRating { get; set; }
        public int? NurseRating { get; set; }
        public int? RecommendedRating { get; set; }
        public string RecommendComment { get; set; }
        public int? ReceptionRating { get; set; }

        public GeneralSurveyReason GeneralSurveyReason { get; set; }
        public GeneralSurveySatisfiedReason GeneralSurveySatisfiedReason { get; set; }

        public DoctorSurveyReason DoctorSurveyReason { get; set; }
        public DoctorSurveySatisfiedReason DoctorSurveySatisfiedReason { get; set; }

        public NursesAndStaffReason NursesAndStaffReason { get; set; }
        public NursesAndStaffSatisfiedReason NursesAndStaffSatisfiedReason { get; set; }

        public ReceptionStaffNotSatisfied ReceptionStaffNotSatisfied { get; set; }
        public ReceptionStaffSatisfied ReceptionStaffSatisfied { get; set; }

        public string OverallSatisfiedComment { get; set; }
        public string NursesAndStaffSatisfiedComment { get; set; }
        public string DoctorSatisfiedComment { get; set; }

        public string OverallNotSatisfiedComment { get; set; }
        public string NursesAndStaffNotSatisfiedComment { get; set; }
        public string DoctorNotSatisfiedComment { get; set; }

        public string ReceptionStaffNotSatisfiedComment { get; set; }
        public string ReceptionStaffSatisfiedComment { get; set; }

        public SurveyStatus SurveyStatus { get; set; }
        public string UrlOriginal { get; set; }
        public string UrlBitly { get; set; }
        public DateTime? RespondedDate { get; set; }

        public long? CreateTimeTick { get; set; }

        public DateTime? CreateStamp { get; set; }
        public DateTime? UpdateStamp { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }

        public bool? IsContactedByServiceTeam { get; set; }

        public ComplaintorGeneralFeedback complainFeedbacks { get; set; }
    }
}
