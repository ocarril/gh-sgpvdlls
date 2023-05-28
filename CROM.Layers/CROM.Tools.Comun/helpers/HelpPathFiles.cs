
namespace CROM.Tools.Comun.helpers
{
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Extensions;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.IO.Compression;
    using System.Reflection;

    public static class HelpPathFiles
    {

        /// <summary>
        ///     Permite verificare si un directorio existe
        /// </summary>
        /// <param name="path">Directorio a verificar si existe o no</param>
        /// <returns></returns>
        public static bool CheckExistPath(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                CheckPathAndCreate(path);
            }

            return new DirectoryInfo(path).Exists;
        }

        /// <summary>
        ///     Permite verificiar y crear un directorio
        /// </summary>
        /// <param name="path">path del directorio a crear</param>
        public static void CheckPathAndCreate(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path", "No especifico ninguno valor en el parametro");
            }
            DirectoryInfo info = new DirectoryInfo(path);
            try
            {
                if (info.Parent != null && !info.Exists)
                {
                    CheckPathAndCreate(info.Parent.FullName);
                }
                if (!info.Exists)
                {
                    info.Create();
                    info.Create();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error: Path no creado, revise lo siguiente:\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Permite guardar una imagen a partir de un base64 string format
        /// </summary>
        /// <param name="base64String">Base54 string a procesar</param>
        /// <param name="path">Ruta donde se almacenara la imagen</param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string Base64ToImage(string base64String, string path, string prefix)
        {
            CheckPathAndCreate(path);

            string fileName = string.Concat(prefix, "-", DateTimeExtensions.GetConcatTime(".jpg"));

            string filePath = Path.Combine(path, fileName);
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            try
            {
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    image.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                filePath = string.Empty;
                Debug.WriteLine(ex.ToString());
            }

            return filePath;
        }

        /// <summary>
        /// Permite convertir una imagen a un array de bytes
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Archivo de imagen no encontrado");
            }

            Image img = Image.FromFile(filePath);

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static ReturnValor ZipFile(string fileNameToAdd, string pathDestino, string pnameFileZip = "", bool FlagConvertToBase64String=false)
        {
            var returnZip = new ReturnValor();
            string[] Names = fileNameToAdd.Split('.');
            string FileZipName = string.IsNullOrWhiteSpace(pnameFileZip) ?
                string.Concat("FileZip_", HelpTime.ConvertHHMMSSMM(DateTime.Now), ".zip") :
                string.Concat(pnameFileZip, ".zip");

            try
            {
                using (FileStream fOrigen = File.OpenRead(fileNameToAdd))
                {
                    using (FileStream fDestino = File.Create(Path.Combine(pathDestino, FileZipName)))
                    {

                        byte[] buffer = new byte[fOrigen.Length];
                        fOrigen.Read(buffer, 0, buffer.Length);

                        using (GZipStream output = new GZipStream(fDestino, CompressionMode.Compress))
                        {
                            output.Write(buffer, 0, buffer.Length);

                        }

                        returnZip.Exitosa = true;
                        returnZip.CodigoRetorno = WebConstants.DEFAULT_OK;
                        returnZip.Message = FileZipName;

                        if (FlagConvertToBase64String)
                            returnZip.ErrorCode = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(pathDestino, FileZipName)));
                    }
                }
            }
            catch (Exception zp)
            {
                returnZip.Exitosa = false;
                returnZip.Message = "Error [Zip] " + zp.Message;
            }
            return returnZip;
        }


        /// <summary>
        /// This method erase the file if an exceptions ocurred
        /// and change the state of the process
        /// </summary>
        /// <param name="idProcessUpload"></param>
        public static void EraseFileAntiguos(string pPathFiles, string pComodin, double pnumDiasAnterioridad)
        {
            try
            {

                pPathFiles = !pPathFiles.EndsWith(@"\") ? string.Concat(pPathFiles, @"\\") : pPathFiles;
                double numDiasAnterioridad = pnumDiasAnterioridad * -1;
                DateTime fechaEliminaFilesHasta = DateTime.Now.AddDays(numDiasAnterioridad);

                string[] lstArchivos = Directory.GetFiles(pPathFiles, pComodin, SearchOption.AllDirectories);
                // Delete source files that were copied.
                foreach (string fileErase in lstArchivos)
                {
                    if (File.Exists(fileErase))
                    {
                        DateTime fechaDeCreacion = File.GetLastWriteTime(fileErase);
                        if (fechaDeCreacion < fechaEliminaFilesHasta)
                        {
                            File.Delete(fileErase);
                            HelpLogging.Write(TraceLevel.Info, "EraseFileAntiguos." + MethodBase.GetCurrentMethod().Name,
                                              "[" + fechaDeCreacion.ToString() + "] - Archivo de carga eliminado :[ " + fileErase + " ]");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
