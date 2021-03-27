namespace CROM.Tools.Comun.azure
{
    using CROM.Tools.Comun.settings;

    using Microsoft.WindowsAzure.Storage;
    using System;
    using System.IO;
    using System.Net;


    public class StorageUtils
    {
        public static CloudStorageAccount StorageAccount
        {
            get
            {
                //string account = CloudConfigurationManager.GetSetting("StorageAccountName");
                string account = GlobalSettings.GetDEFAULT_AccountAzure();
                // This enables the storage emulator when running locally using the Azure compute emulator.
                if (account == "{StorageAccountName}")
                {
                    return CloudStorageAccount.DevelopmentStorageAccount; 
                }

                //string key = CloudConfigurationManager.GetSetting("StorageAccountAccessKey");
                string key = GlobalSettings.GetDEFAULT_KeyAzure();
                string connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
                return CloudStorageAccount.Parse(connectionString);
            }
        }

        public static Stream getUrl(string URL, out int ReturnaTotalKb)
        {
            HttpWebRequest request = ((HttpWebRequest)WebRequest.Create(URL));
            Stream StreamArchivo;
            int totalBytes = 0;
            try
            {
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                using (StreamArchivo = response.GetResponseStream())
                {
                    //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(string.Format(file, rutaDocumento, documentoPanel.NOMBRE_ARCHIVO));
                    //WebResponse myResp = myReq.GetResponse();
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

                            } while (stream.CanRead && count > 0);
                            b = ms.ToArray();
                            totalBytes = ms.ReadByte();
                        }
                        totalBytes = StreamArchivo.Read(b, 0, (int)b.Length);
                        totalBytes = stream.Read(b, 0, (int)b.Length);
                        int tota = stream.ReadByte();
                        totalBytes = (int)b.Length;
                    }
                    // totalBytes = StreamArchivo.Read(b, 0, (int)b.Length);
                }
            }
            catch (Exception ex)
            {
                ReturnaTotalKb = totalBytes;
                return null;
            }
            ReturnaTotalKb = totalBytes;
            return StreamArchivo;
        }

        public static Stream getUrlFoto(string URL)
        {
            HttpWebRequest request = ((HttpWebRequest)WebRequest.Create(URL));
            try
            {
                HttpWebResponse response = ((HttpWebResponse)request.GetResponse());
                return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool ThumbnailCallback()
        {

            return true;

        }

    }
}
