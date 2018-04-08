using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace P2.Models
{
    public class ModelResultado
    {
        private static dbconfig _conn = null;
        protected SqlConnection _sqlConnection = null;
        private static SqlCommand _sqlCommand = null;
        private static List<property> _listResult = null;
        private static property _property = null;
        private static SqlDataReader _sqlDataReader = null;

        public bool save(property _property){
            try {
                _conn = dbconfig.GetInstance;
                _sqlConnection = _conn.getSqlConneciton;
                _sqlCommand = new SqlCommand("addResult", _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@num1", _property.num1);
                _sqlCommand.Parameters.AddWithValue("@num2", _property.num2);
                _sqlCommand.Parameters.AddWithValue("@result", _property.resultado);
                _sqlCommand.Parameters.AddWithValue("@operador", _property.operador);
                _sqlCommand.ExecuteNonQuery();
            } catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            } finally {
                _conn.closeConnection();
            }
            return true;
        }

        public List<property> findAll()
        {
            try {
                _listResult = new List<property>();
                _conn = dbconfig.GetInstance;
                _sqlConnection = _conn.getSqlConneciton;
                _sqlCommand = new SqlCommand("getAllResultados", _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlDataReader = _sqlCommand.ExecuteReader();

                while (_sqlDataReader.Read()) {
                    _property = new property();
                    _property.id = Convert.ToInt32(_sqlDataReader["id"].ToString());
                    _property.num1 = Convert.ToDouble(_sqlDataReader["num1"].ToString());
                    _property.num2 = Convert.ToDouble(_sqlDataReader["num2"].ToString());
                    _property.operador = _sqlDataReader["operador"].ToString();
                    _property.resultado = Convert.ToDouble(_sqlDataReader["resultado"].ToString());
                    _listResult.Add(_property);
                }
                _sqlDataReader.Close();
            } catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            } finally {
                _conn.closeConnection();
            }

            return _listResult;
        }

        public bool delete(int id) {
            try {
                _conn = dbconfig.GetInstance;
                _sqlConnection =  _conn.getSqlConneciton;
                _sqlCommand = new SqlCommand("deleteResult", _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@id", id);
                _sqlCommand.ExecuteNonQuery();
            } catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }finally{
                _conn.closeConnection();
            }
            return true;
        }
    }
}