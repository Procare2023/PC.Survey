using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Oracle
{
    public static class QueryBuilder<T>
    {
        public static IEnumerable<T> GetListCustom(T entity, string tableName, string patCode)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            string sql = @"select * from (select * from  " + tableName + " order by rownum desc) where rownum < 10 and pat_code ='" + patCode + "'";

            var result = connection.Query<T>(sql);

            ConnectionManager.CloseConnection(connection);

            return result;
        }
        public static IEnumerable<T> GetList(T entity)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            //const string sql = @"SELECT * FROM CUSTM_CLASS";

            var result = connection.Query<T>(GetColumnList(entity));
            //var result = connection.Query<T>(sql);

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static IEnumerable<T> GetListAppoint(T entity, string ClinicCode, string branch)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.Query<T>(GetColumnListAppoint(entity, ClinicCode, branch));

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static IEnumerable<T> GetListAppointByDrCode(T entity, string ClinicCode)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.Query<T>(GetColumnListAppointByDrCode(entity, ClinicCode));

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static IEnumerable<T> GetListAppoint(T entity, int app_id)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.Query<T>(GetColumnListAppoint(entity, app_id));

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static T SingleOrDefault(T entity, string identity_no)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.QueryFirstOrDefault<T>(GetColumnListSingle(entity, identity_no));

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static T SingleOrDefaultInvoice(T entity, string PAT_CODE)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.QueryFirstOrDefault<T>(GetColumnListSingleInvoice(entity, PAT_CODE));

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static T SingleOrDefault(T entity, string identity_no, DateTime T_DATE, DateTime T_TIME)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.QueryFirstOrDefault<T>(GetColumnListSingle(entity, identity_no, T_DATE, T_TIME));

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        public static int? ExecuteAction(string query)
        {
            IDbConnection connection = ConnectionManager.GetConnection();

            var result = connection.Execute(query);

            ConnectionManager.CloseConnection(connection);

            return result;
        }

        private static string GetColumnList(T entity)
        {
            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            return selectedColumns + " From " + entity.GetType().Name.ToUpper();
        }

        private static string GetColumnListAppoint(T entity, string clinicCode, string branch)
        {
            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            return selectedColumns + " From " + entity.GetType().Name.ToUpper() + " Where PAT_NAME  IS NULL and DR_CODE = '" + clinicCode + "' and BRANCH = '" + branch + "' and ACTIVE = 1 ORDER BY 2,3";
        }

        private static string GetColumnListAppointByDrCode(T entity, string clinicCode)
        {
            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            return selectedColumns + " From " + entity.GetType().Name.ToUpper() + " Where PAT_NAME  IS NULL and DR_CODE = '" + clinicCode + "' and ACTIVE = 1 ORDER BY 2,3";
        }

        private static string GetColumnListAppoint(T entity, int app_id)
        {
            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            return selectedColumns + " From " + entity.GetType().Name.ToUpper() + " Where ACTIVE = 1 and PAT_NAME IS NULL and SER_NO = " + app_id;
        }

        private static string GetColumnListSingle(T entity, string identity_no)
        {
            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            return selectedColumns + " From " + entity.GetType().Name.ToUpper() + " Where ID_CARD = '" + identity_no + "'";
        }

        private static string GetColumnListSingleInvoice(T entity, string PAT_CODE)
        {
            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            return selectedColumns + " From " + entity.GetType().Name.ToUpper() + " Where PAT_CODE = '" + PAT_CODE + "'";
        }

        private static string GetColumnListSingle(T entity, string identity_no, DateTime T_DATE, DateTime T_TIME)
        {
            var tdate = T_DATE.ToString("MMM/dd/yyyy");
            var ttime = T_TIME.ToString("MMM/dd/yyyy HH:mm");

            string selectedColumns = @"Select ";
            int count = entity.GetType().GetProperties().Length;

            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.Name == entity.GetType().GetProperties()[count - 1].Name)
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name; //+ ",";
                }
                else
                {
                    selectedColumns = selectedColumns + prop.Name + " AS " + prop.Name + ",";
                }
            }
            selectedColumns = selectedColumns + " From " + entity.GetType().Name.ToUpper() + " Where CLIN_CODE = " + identity_no + " and RES_DATE = TO_DATE('" + tdate + "', 'Mon-dd-yyyy') and RES_TIME = TO_DATE('" + ttime + "', 'Mon-dd-yyyy hh24:mi')";

            return selectedColumns;
        }
    }
}
