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
        String strTelefono;
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

        String strUsername;
        String strPassword;

        String strDireccionFotoPerfil;
        String strDireccionActaNacimiento;
        String strDireccionCURP;
        String strDireccionComprobanteDomicilio;


        public int IntIDUsuario { get => intIDUsuario; set => intIDUsuario = value; }
        public int IntIDCiudad { get => intIDCiudad; set => intIDCiudad = value; }
        public string StrNumeroReferencia { get => strNumeroReferencia; set => strNumeroReferencia = value; }
        public string StrNombres { get => strNombres; set => strNombres = value; }
        public string StrApellidoPaterno { get => strApellidoPaterno; set => strApellidoPaterno = value; }
        public string StrApellidoMaterno { get => strApellidoMaterno; set => strApellidoMaterno = value; }
        public string StrEmail { get => strEmail; set => strEmail = value; }
        public String StrTelefono { get => strTelefono; set => strTelefono = value; }
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
        public string StrPassword { get => strPassword; set => strPassword = value; }
        public string StrUsername { get => strUsername; set => strUsername = value; }
        public string StrDireccionFotoPerfil { get => strDireccionFotoPerfil; set => strDireccionFotoPerfil = value; }
        public string StrDireccionActaNacimiento { get => strDireccionActaNacimiento; set => strDireccionActaNacimiento = value; }
        public string StrDireccionCURP { get => strDireccionCURP; set => strDireccionCURP = value; }
        public string StrDireccionComprobanteDomicilio { get => strDireccionComprobanteDomicilio; set => strDireccionComprobanteDomicilio = value; }

        public static DataSet InsertarUsuarioTemporal(Usuario UsuarioTemporal)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pStrNumeroReferencia", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrNumeroReferencia });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrNombre", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrNombres });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrApellidoPaterno });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrApellidoMaterno });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrEmail", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrEmail });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrTelefono", SqlDbType = SqlDbType.Int, Value = UsuarioTemporal.StrTelefono });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrCelular", SqlDbType = SqlDbType.VarChar, Value = UsuarioTemporal.StrTelefono });
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

        public static DataSet SelectNombreCompletoUsuario(int IDUsuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuario", SqlDbType = SqlDbType.VarChar, Value = IDUsuario });

            try
            {
                ds = Conexion.execute_sp("NombreCompletoUsuario", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectDatosPerfilUsuario(int IDUsuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuario", SqlDbType = SqlDbType.VarChar, Value = IDUsuario });

            try
            {
                ds = Conexion.execute_sp("DatosUsuario", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet UpdatePerfilUsuario(Usuario Usuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuario", SqlDbType = SqlDbType.Int, Value = Usuario.IntIDUsuario });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrPassword", SqlDbType = SqlDbType.VarChar, Value = Usuario.strPassword });
            listParameters.Add(new SqlParameter { ParameterName = "@pIDCiudad", SqlDbType = SqlDbType.Int, Value = Usuario.IntIDCiudad });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrNombre", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrNombres });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrApellidoPaterno });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrApellidoMaterno });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrEmail", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrEmail });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrTelefono", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrTelefono });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrCelular", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrTelefono });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrRFC", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrRFC });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrCURP", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrCURP });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrSeguroSocial", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrSeguroSocial });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrCalle", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrCalle });
            listParameters.Add(new SqlParameter { ParameterName = "@pIntNumeroInterior", SqlDbType = SqlDbType.Int, Value = Usuario.IntNumeroInterior });
            listParameters.Add(new SqlParameter { ParameterName = "@pIntNumeroExterior", SqlDbType = SqlDbType.Int, Value = Usuario.IntNumeroExterior });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrColonia", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrColonia });
            listParameters.Add(new SqlParameter { ParameterName = "@pIntCodigoPostal", SqlDbType = SqlDbType.Int, Value = Usuario.intCodigoPostal });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrDireccionFotoPerfil", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrDireccionFotoPerfil });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrDireccionCURP", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrDireccionCURP });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrDireccionActaNacimiento", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrDireccionActaNacimiento });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrDireccionDomicilio", SqlDbType = SqlDbType.VarChar, Value = Usuario.strDireccionComprobanteDomicilio });

            try
            {
                ds = Conexion.execute_sp("UpdatePerfilUsuario", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet SelectDatosUsuarioTemp(int IDUsuario = 0)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuarioTemp", SqlDbType = SqlDbType.VarChar, Value = IDUsuario });

            try
            {
                ds = Conexion.execute_sp("SelectDatosUsuarioTemp", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet AsignarCuentaUsuario(Usuario Usuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuarioTemp", SqlDbType = SqlDbType.Int, Value = Usuario.IntIDUsuario });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrUsername", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrUsername });
            listParameters.Add(new SqlParameter { ParameterName = "@pStrOassword", SqlDbType = SqlDbType.VarChar, Value = Usuario.StrPassword });


            try
            {
                ds = Conexion.execute_sp("SelectDatosUsuarioTemp", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet DeleteIDUsuarioTemp(int IDUsuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter { ParameterName = "@pIDUsuarioTemp", SqlDbType = SqlDbType.VarChar, Value = IDUsuario });

            try
            {
                ds = Conexion.execute_sp("DeleteIDUsuarioTemp", listParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
