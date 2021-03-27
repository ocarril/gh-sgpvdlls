namespace CROM.Tools.Comun.azure
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class BlobStorageServiceFile
    {
        async public void CreateAndConfigureAsync(int pcodEmpresa,string pUserLogin)
        {
            try
            {
                CloudStorageAccount storageAccount = StorageUtils.StorageAccount;

                // Create a blob client and retrieve reference to images container
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("DOCUMENTOS");

                // Create the "images" container if it doesn't already exist.
                if (await container.CreateIfNotExistsAsync())
                {
                    // Enable public access on the newly created "images" container
                    await container.SetPermissionsAsync(new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });

                    HelpLogging.Write(TraceLevel.Info, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                    "Creó con éxito el Blob Storage Images Container y lo hizo público", pUserLogin, pcodEmpresa.ToString());
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  ex, pUserLogin, pcodEmpresa.ToString());
                throw new Exception("Error al crear o configurar el contenedor de imágenes en el Servicio de almacenamiento de blobs");
            }
        }

        async public Task<string> UploadFileAsync(HttpPostedFileBase FileToUpload, string NombreArchivo, string Contenedor)
        {
            if (FileToUpload == null || FileToUpload.ContentLength == 0)
            {
                return null;
            }
            string fullPath = null;
            Stopwatch timespan = Stopwatch.StartNew();
            try
            {
                CloudStorageAccount storageAccount = StorageUtils.StorageAccount;

                // Create the blob client and reference the container
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(Contenedor);

                // Upload image to Blob Storage
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(NombreArchivo);
                blockBlob.Properties.ContentType = FileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync((FileToUpload.InputStream));
                fullPath = blockBlob.Uri.ToString();
                timespan.Stop();
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat(this.GetType().Name, ".UploadFileAsync", "Error upload file blob to storage"), ex);
                return string.Empty;
            }
            return fullPath;
        }

        public static Stream StringToStream(string src)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(src);
            return new MemoryStream(byteArray);
        }

        public Stream GetSizeFileUrl(string URL,int pcodEmpresa, string pUserLogin, out int ReturnaTotalKb)
        {
            HttpWebRequest request = ((HttpWebRequest)WebRequest.Create(URL));
            Stream StreamArchivo;
            int totalBytes = 0;
            try
            {
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                using (StreamArchivo = response.GetResponseStream())
                {
                    using (Stream stream = StreamArchivo)
                    {
                        byte[] b = null;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            int count = 0;
                            do
                            {
                                byte[] buf = new byte[1024];
                                count = stream.Read(buf, 0, 1024);
                                ms.Write(buf, 0, count);
                                totalBytes += count;

                            }
                            while (stream.CanRead && count > 0);
                            b = ms.ToArray();
                            totalBytes = ms.ReadByte();
                        }
                        totalBytes = StreamArchivo.Read(b, 0, (int)b.Length);
                        totalBytes = stream.Read(b, 0, (int)b.Length);
                        int tota = stream.ReadByte();
                        totalBytes = (int)b.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                 ex, pUserLogin, pcodEmpresa.ToString());
                ReturnaTotalKb = totalBytes;
                return null;
            }

            ReturnaTotalKb = totalBytes;

            return StreamArchivo;

        }

    }
}

