using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
    }
}