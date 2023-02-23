using PC.DataLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Model.Survey
{
    public class GeneralSurveyReport
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
        public int? ReceptionRating { get; set; }
        public int? RecommendedRating { get; set; }
        public string RecommendComment { get; set; }

        public string OverallComment { get; set; }
        public string NursesAndStaffComment { get; set; }
        public string DoctorComment { get; set; }
        public string ReceptionStaffComment { get; set; }

        public int? OverallSubAnswer { get; set; }
        public int? DoctorSubAnswer { get; set; }
        public int? NursesAndStaffSubAnswer { get; set; }

        public int? ReceptionStaffSubAnswer { get; set; }
        public SurveyStatus SurveyStatus { get; set; }
        public DateTime? RespondedDate { get; set; }

        public DateTime? CreateStamp { get; set; }
        public DateTime? UpdateStamp { get; set; }

        public int? complainOrFeedback { get; set; }

        public bool? IsContactedByServiceTeam { get; set; }
        public string InsuranceProvider { get; set; }
    }
}
