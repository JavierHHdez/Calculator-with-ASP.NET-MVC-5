using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace P2.Models
{
    public class dbconfig
    {
        private static dbconfig instance = null;
        private static string _stringconnection = null;
        public static SqlConnection _sqlConnection = null;

        public static dbconfig GetInstance {
            get {
                lock(typeof(dbconfig)){
                    return instance ?? (instance = new dbconfig());
                }
            }
        }

        private dbconfig(){
            try
            {
                _stringconnection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
                _sqlConnection = new SqlConnection(_stringconnection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public SqlConnection getSqlConneciton {
            get{
                if (_sqlConnection.State == System.Data.ConnectionState.Closed) {
                    _sqlConnection.Open();
                }
                return _sqlConnection;
            }
        }

        public void closeConnection(){
            _sqlConnection.Close();
        }
    }
}