using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace ActivateTurboM.Framework
{
    public class FTP
    {
        public static String MapPath = @"~\uploads\";

        public static bool SubirArchivoFTP(FileUpload uploadControl, String ServerMapPath, String Directorio, String NombreFinalArchivo, out string DireccionCompletaFTP)
        {
            if (uploadControl.HasFile)
            {
                String fileExtension = Path.GetExtension(uploadControl.FileName);
                String NombreArchivo = Path.Combine(ServerMapPath, Path.GetFileName(uploadControl.FileName));
                String FTPDirectory = String.Format("{0}/docs/{1}/{2}{3}", "ftp://turbo@multicomercialdelnorte.com", Directorio, NombreFinalArchivo, fileExtension);
                DireccionCompletaFTP = String.Format("http://multicomercialdelnorte.com/TURBO/docs/{0}/{1}{2}", Directorio, NombreFinalArchivo, fileExtension);
                uploadControl.SaveAs(NombreArchivo);

                try
                {
                    if (CrearDirectorioFTP(Directorio))
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.Credentials = new NetworkCredential("turbo@multicomercialdelnorte.com", "turbo1234");
                            client.UploadFile(FTPDirectory, "STOR", NombreArchivo);
                        }
                    }

                    else return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }
                File.Delete(NombreArchivo);
                return true;
            }
            else
            {
                DireccionCompletaFTP = "Error";
                return false;
            }

        }

        public static bool CrearDirectorioFTP(String Directorio)
        {
            String FTPDirectory = String.Format("{0}/docs/{1}", "ftp://multicomercialdelnorte.com", Directorio);

            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPDirectory);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential("turbo@multicomercialdelnorte.com", "turbo1234");
                request.UsePassive = true;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();

                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return true;
                }
                else
                {
                    response.Close();
                    return false;
                }
            }
        }

    }
}