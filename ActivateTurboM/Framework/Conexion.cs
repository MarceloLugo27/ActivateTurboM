using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ActivateTurboM.Framework;

namespace ActivateTurboM.Framework
{
    public class Conexion
    {
        static String ConnectionString = "Server=tcp:mslservercloud.database.windows.net,1433;Initial Catalog=dbActivateTurbo;" +
        "Persist Security Info=False;User ID=MarceloLugo;Password=SWcrbyGLin77;" +
        "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";

        public static DataSet execute_sp(string query, List<SqlParameter> ListParameters)
        {
            SqlCommand command;
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    String cadena = ConnectionString;
                    connection.ConnectionString = cadena;
                    connection.Open();
                    command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.CommandTimeout = 120000;
                    foreach (SqlParameter item in ListParameters)
                    {
                        command.Parameters.AddWithValue(item.ParameterName, item.SqlDbType).Value = item.Value;
                    }
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                adapter = null;
            }
            return ds;
        }

        public static DataSet SysLogin(String Username, String Password)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pStrUsername", SqlDbType = SqlDbType.VarChar, Value = Username });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrPassword", SqlDbType = SqlDbType.VarChar, Value = Password });

            try
            {
                ds = Conexion.execute_sp("SysLogin", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectEstados()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();

            try
            {
                ds = Conexion.execute_sp("SelectEstados", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectCiudad(int IDEstado)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDEstado", SqlDbType = SqlDbType.Int, Value = IDEstado });

            try
            {
                ds = Conexion.execute_sp("SelectCiudad", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }


}