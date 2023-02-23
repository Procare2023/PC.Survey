using PC.DataLayer.Model.Patient.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Oracle
{
    public class PCOasisWrapperDb
    {
        public async Task<List<v_appointment_dump>> GetAppointmentsByDay(string appointmentDate)
        {            
            try
            {
                var rawList = QueryBuilder<v_appointment_dump>.GetListAppoint(new v_appointment_dump(), appointmentDate);                
                if (rawList != null & rawList.Count() > 0)
                    return rawList.ToList();               
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}
