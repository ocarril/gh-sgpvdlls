using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using CROM.Tools.Comun.entities;

namespace CROM.Tools.Comun
{
    public static class HelpImages
    {
        public static byte[] GetFotografias(String FotoFilePath)
        {
            if (FotoFilePath != null)
            {
                FileStream stream = new FileStream(FotoFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                byte[] Foto = reader.ReadBytes((int)stream.Length);
                reader.Close();
                return (Foto);
            }
            else
                return (null);
        }

        public static Image FotoTraeDeBaseDato(byte[] Photo_DBO)
        {
            Image img = null;
            if (Photo_DBO != null)  // if (dr["Foto"] != DBNull.Value)
            {
                img = DeBytesBD_aImagen((byte[])(Photo_DBO));
                if (img != null)
                {
                    return (img);
                }
            }
            return (img);
        }

        public static Image DeBytesBD_aImagen(byte[] bytesIMG)
        {
            if (bytesIMG == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytesIMG);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bm;
        }

        public static byte[] DeImagenBD_aBytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            // Cerrarlo y volverlo a abrir o posicionarlo en el primer byte
            //fs.Close();
            //fs = new FileStream(sTemp, FileMode.Open, FileAccess.Read);
            fs.Position = 0;
            //
            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        public static byte[] StreamReadToEndByte(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        // Crear en tiempo de ejecución una imagen transparente de 16x16
        public static Image ImagenDefault()
        {
            Bitmap bmp = new Bitmap(16, 16);
            for (int bmp_i = 0; bmp_i < bmp.Width; bmp_i++)
            {
                for (int bmp_j = 0; bmp_j < bmp.Height; bmp_j++)
                {
                    bmp.SetPixel(bmp_i, bmp_j, Color.FromArgb(255, 255, 255, 255));
                }
            }
            Image imagen = bmp as Image;
            return imagen;
        }

        public static ReturnValor CrearArchivoDesdeBinario(string Nombre, byte[] Archivo, bool ABRIR_ARCHIVO)
        {
            ReturnValor oReturn = new ReturnValor();
            try
            {
                string sTemp1 = Nombre;
                FileStream fs = new FileStream(sTemp1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Flush();
                fs.Write(Archivo, 0, Archivo.Length);
                fs.Close();
                if (ABRIR_ARCHIVO)
                {
                    Process MiProceso = new Process();
                    MiProceso.StartInfo.FileName = sTemp1;
                    MiProceso.StartInfo.CreateNoWindow = true;
                    MiProceso.Start();
                    MiProceso.Close();
                    MiProceso.Dispose();
                }
                oReturn.Exitosa = true;
                oReturn.Message = HelpMessages.Evento_NEW;
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }
    }
}
