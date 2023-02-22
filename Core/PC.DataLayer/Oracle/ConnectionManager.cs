using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Oracle
{
    public static class ConnectionManager
    {
        private static string connString = "Data Source=" +
                                            "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                            "(HOST=192.168.1.3)(PORT=1521)))" +
                                            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=kcs)));" +
                                            "User Id = kcs; " +
                                            "Password = kcs; ";

        public static IDbConnection GetConnection()
        {
            var conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
            {
                conn.Close();
            }
        }
    }
}
