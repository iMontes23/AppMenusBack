using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Navistar.Utils.Logger;
using log4net;

namespace Navistar.Utils.Core
{
    public class FileUtility
    {
        /**
         * Método que recibe una ruta, válida si existe, de no existir la crea
         * <paramref name="ruta"/>
         */
        public static void CrearDirectorioVacio(String ruta)
        {
            if (!System.IO.Directory.Exists(ruta))
            {
                System.IO.Directory.CreateDirectory(ruta);
            }
        }

        /**
         * Método que recibe la ruta del archivo y valida si esta existe
         * <param name="rutaArchivo"/>
         * <param name="rutaTem"/>
         */
        public static bool ExisteArchivo(String rutaArchivo, String rutaTem)
        {
            try
            {
                return (System.IO.File.Exists(rutaArchivo) || System.IO.File.Exists(rutaTem));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }


        public static bool ExisteArchivo(String rutaArchivo)
        {
            try
            {
                return (System.IO.File.Exists(rutaArchivo));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }


        public static async Task<bool> GuardarArchivo(IFormFile file, String ruta)
        {
            try
            {
                CrearDirectorioVacio(ruta);
                var path = Path.Combine(ruta, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }

        public static async Task<bool> GuardarArchivo(IFormFile file, String ruta, String nombre, ILog _log)
        {
            try
            {
                CrearDirectorioVacio(ruta);
                var path = Path.Combine(ruta, nombre);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return true;
            }
            catch (Exception e)
            {
                _log.Error("FileUtility: " + e.Message);
                return false;
            }
        }


        public static void MoverArchivo(String rutaTemp, String rutaDestino, String nombreArchivo)
        {
            try
            {
                CrearDirectorioVacio(rutaDestino);
                System.IO.File.Copy(rutaTemp, rutaDestino + nombreArchivo, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public static void EliminarArchivo(String ruta)
        {
            try
            {
                if (System.IO.File.Exists(ruta))
                {
                    System.IO.File.Delete(ruta);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Se elimina la carpeta aunque esta contenga archivos
        /// </summary>
        /// <param name="ruta"></param>
        public static void EliminarDirectorio(String ruta)
        {
            try
            {
                if (!String.IsNullOrEmpty(ruta) && System.IO.Directory.Exists(ruta))
                {
                    System.IO.Directory.Delete(ruta, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Se elimina el contenido del directorio
        /// </summary>
        /// <param name="ruta"></param>
        public static void EliminarContenidoDirectorio(String ruta)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(ruta);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using MemoryStream ms = new MemoryStream();
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }

        public static bool ValidarTipoArchivo(String tipo) {
            switch (tipo.ToLower())
            {
                case "application/pdf": return true; //pdf
                case "application/msword": return true; // doc
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document": return true; //docx
                case "application/vnd.ms-powerpoint": return true; //ppt
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation": return true; //pptx
                case "application/vnd.ms-excel": return true; // xls
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet": return true; // xlsx
                case "image/jpeg": return true; // jpg
                case "image/png": return true; // png
                default:break;
            }
            return false;
        }

        public static String ObtenerExtension(String tipo)
        {
            switch (tipo.ToLower())
            {
                case "application/pdf": return ".pdf";
                case "application/msword": return ".doc";
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document": return ".docx";
                case "application/vnd.ms-powerpoint": return ".ppt";
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation": return ".pptx";
                case "application/vnd.ms-excel": return ".xls";
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet": return ".xlsx";
                case "image/jpeg": return ".jpg";
                case "image/png": return ".png";
                default: break;
            }
            return "";
        }

        public static String ObtenerContentType(String nombreArchivo)
        {
            if(nombreArchivo == null || String.IsNullOrEmpty(nombreArchivo.Trim()))
            {
                return "application/pdf";
            }

            String[] cadena = nombreArchivo.Split(".");
            String tipo = cadena.Length > 1 ? cadena[1] : "pdf";

            switch (tipo.ToLower())
            {
                case "pdf": return "application/pdf";
                case "doc": return "application/msword";
                case "docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case "ppt": return "application/vnd.ms-powerpoint";
                case "pptx": return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case "xls": return "application/vnd.ms-excel";
                case "xlsx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case "jpg": return "image/jpeg";
                case "png": return "image/png";
                default: break;
            }
            return "";
        }
    }
}
