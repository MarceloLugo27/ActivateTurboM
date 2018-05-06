using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivateTurboM.Framework
{
    public class Nodo
    {
        public static DataSet SelectNodoPadreDDL(int IDUsuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuario", SqlDbType = SqlDbType.VarChar, Value = IDUsuario });

            try
            {
                ds = Conexion.execute_sp("SelectNodoPadre", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectInfoNodoPadre(int IDNodoPadre)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDNodoPadre", SqlDbType = SqlDbType.VarChar, Value = IDNodoPadre });

            try
            {
                ds = Conexion.execute_sp("SelectInfoNodoPadre", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectInfoNodoVendido(int IDNodoPadre)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDNodoPadre", SqlDbType = SqlDbType.VarChar, Value = IDNodoPadre });

            try
            {
                ds = Conexion.execute_sp("SelectInfoNodoVendido", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectInfoNodoDescendiente(int IDUsuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuario", SqlDbType = SqlDbType.VarChar, Value = IDUsuario });

            try
            {
                ds = Conexion.execute_sp("SelectInfoNodoDescendiente", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

    }
}