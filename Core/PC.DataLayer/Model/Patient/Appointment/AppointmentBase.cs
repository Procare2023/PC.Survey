using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Model.Patient.Appointment
{
    public class AppointmentBase : MyBase
    {
        public DateTime Session_Date { get; set; }
        public string session_year { get; set; }
        public string session_month { get; set; }

        public string description { get; set; }

        public int doctor_id { get; set; }
        public string doctor_name { get; set; }
        public DateTime appt_time { get; set; }

        public string appt_type { get; set; }
        public string? visit_type { get; set; }
        public DateTime arrived_time { get; set; }
        public string mrn_no { get; set; }
        public string patient_id { get; set; }
        public string NAME { get; set; }

        public string mobile { get; set; }
        public string insurance_provider { get; set; }
        public int? by_staff_id { get; set; }
        public string by_staff_name { get; set; }
        public int appointment_id { get; set; }
        public string outcome_code { get; set; }
        public int episode_no { get; set; }
        public DateTime time_seen { get; set; }
        public DateTime? time_complete { get; set; }
    }
}
