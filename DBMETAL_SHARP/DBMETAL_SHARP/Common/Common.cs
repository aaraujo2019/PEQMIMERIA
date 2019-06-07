
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMETAL_SHARP.Common
{
    public class Common
    {
        public static string Dominio = "grancolombia.local";
        //Aquí va el path URL del servicio de directorio LDAP

        public static string path = "LDAP://grancolombia.local/DC=grancolombia, DC=local";
        public static List<Entidades.Ent_Usuario> User{ get; set; }


        public static List<Roles_Permisos> Permissions;

        public static class ImageConvert
        {
            public static byte[] imageToByte(System.Drawing.Image imageIn)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                ms.Close();
                return arrImg;
            }
            public static System.Drawing.Image byteToImage(byte[] byteArrayIn)
            {
                if (byteArrayIn != null)
                {
                    MemoryStream ms = new MemoryStream(byteArrayIn);
                    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                    return returnImage;
                }
                return null;
            }


        }
    }
}
