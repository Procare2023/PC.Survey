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
        public async Task<List<AppointmentBase>> GetAppointmentsByDay(DateTime appointmentDate)
        {


            List<AppointmentBase> appointments = new();
            try
            {
                var rawList = QueryBuilder<AppointmentBase>.GetList(new AppointmentBase());
                //var dpBasket = new DataParameter[] { new DataParameter(SqlDbType.DateTime, DbConstants.SP.Params.PARAM_AppointmentDate, appointmentDate, ParameterDirection.Input) };

                //DataManager.ForwardOnlySProcResults = AppointmentExtendedParser.Parse;
                //var rawList = DataManager.ExecuteStoredProcedureForwardOnlyReturn(base.ConnectionString, DbConstants.SP.Names.SP_AX_ApptGetByAppointmentDate, ref dpBasket, base.DbTimeoutSeconds);
                //if (rawList != null & rawList.Count() > 0)
                //appointments = (List<AppointmentExtended>)rawList;
            }
            catch (Exception ex)
            {
                throw;
            }
            return appointments;
        }
    }
}
