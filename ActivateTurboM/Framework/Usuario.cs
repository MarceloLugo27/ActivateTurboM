using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivateTurboM.Framework
{
    public class Usuario
    {
        int intIDUsuario;
        int intIDCiudad;
        String strNumeroReferencia;
        String strNombres;
        String strApellidoPaterno;
        String strApellidoMaterno;
        String strEmail;
        int intTelefono;
        String strCelular;
        int intTipoContrato;
        String strRFC;
        String strCURP;
        String strSeguroSocial;
        String strCalle;
        int intNumeroExterior;
        int intNumeroInterior;
        String strColonia;
        int intCodigoPostal;

        public int IntIDUsuario { get => intIDUsuario; set => intIDUsuario = value; }
        public int IntIDCiudad { get => intIDCiudad; set => intIDCiudad = value; }
        public string StrNumeroReferencia { get => strNumeroReferencia; set => strNumeroReferencia = value; }
        public string StrNombres { get => strNombres; set => strNombres = value; }
        public string StrApellidoPaterno { get => strApellidoPaterno; set => strApellidoPaterno = value; }
        public string StrApellidoMaterno { get => strApellidoMaterno; set => strApellidoMaterno = value; }
        public string StrEmail { get => strEmail; set => strEmail = value; }
        public int IntTelefono { get => intTelefono; set => intTelefono = value; }
        public String StrCelular { get => strCelular; set => strCelular = value; }
        public int IntTipoContrato { get => intTipoContrato; set => intTipoContrato = value; }
        public string StrRFC { get => strRFC; set => strRFC = value; }
        public string StrCURP { get => strCURP; set => strCURP = value; }
        public string StrSeguroSocial { get => strSeguroSocial; set => strSeguroSocial = value; }
        public string StrCalle { get => strCalle; set => strCalle = value; }
        public int IntNumeroExterior { get => intNumeroExterior; set => intNumeroExterior = value; }
        public int IntNumeroInterior { get => intNumeroInterior; set => intNumeroInterior = value; }
        public string StrColonia { get => strColonia; set => strColonia = value; }
        public int IntCodigoPostal { get => intCodigoPostal; set => intCodigoPostal = value; }

        public static DataSet InsertarUsuarioTemporal(Usuario UsuarioTemporal)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pStrNumeroReferencia", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrNumeroReferencia });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrNombre", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrNombres });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrApellidoPaterno });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrApellidoMaterno });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrEmail", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrEmail });
            listParameters.Add(new SqlParameter { ParameterName = "@pIntTelefono", SqlDbType = SqlDbType.Int, Value = UsuarioTemporal.IntTelefono });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrCelular", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.IntTelefono });
            listParameters.Add(new SqlParameter { ParameterName = "@pIntTipoContrato", SqlDbType = SqlDbType.Int, Value = UsuarioTemporal.IntTipoContrato });

            try
            {
                ds = Conexion.execute_sp("InsertUsuarioTemp", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
