using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasdeNegocio
{
    public static class Convertir
    {
        public static byte[] ImagenEnByte(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            byte[] arrImg = ms.GetBuffer();
            ms.Flush();
            ms.Close();
            return arrImg;
        }

        public static System.Drawing.Image byteEnImagen(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

    }
}
