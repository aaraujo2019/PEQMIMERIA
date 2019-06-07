using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    public class Safe
    {
        public string[] SubmitAdd = { "G", "H", "I", "J", "k", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" ,"Ç","ü","é","â","ä","à","å","ç","ê",
                                   "ë","è","ï","î","ì","Ä","Å","É","æ","Æ","ô","ö","ò","û","ù","ÿ","Ö","Ü","ø","£","Ø","×","ƒ","á","í","ó","ú","ñ","Ñ","ª","º","¿","®","¬","½",
                                   "¼","¡","«","»","░","▒","@","©"};
        protected internal int Getsal()
        {
            Random Ran = new Random();
            int Millisecond = DateTime.Now.Millisecond;
            int Second = 0;
            do
                Second = DateTime.Now.Second;
            while (Second == 0);
            string NumTex = Math.Abs(Ran.GetHashCode() * Millisecond / Second).ToString().Substring(0, 4);
            return Convert.ToInt32(NumTex);
        }
        protected internal string ConvertCharAscii(string Letter, int Sal)
        {
            int CharAscci = Convert.ToInt32(Encoding.ASCII.GetBytes(Letter[0].ToString())[0].ToString()) * Sal;
            return CharAscci.ToString().Trim();
        }
        protected internal string ConvertCharAscii(string Letter)
        {
            int CharAscci = Convert.ToInt32(Encoding.ASCII.GetBytes(Letter.ToString()).ToString());
            return CharAscci.ToString().Trim();
        }
        protected internal string ConvertHex(string word, int Type, int Sal)
        {
            string Result = string.Empty;
            Safe Enc = new Safe();
            Random ramdom = new Random();
            switch (Type)
            {
                case 1:
                    Result = string.Concat(Convert.ToString(int.Parse(word.Trim()), 16).Trim(), SubmitAdd[ramdom.Next(1, 20)].Trim(), SubmitAdd[ramdom.Next(21, 35)].Trim(), SubmitAdd[ramdom.Next(40, 60)].Trim());
                    break;
                case 2:
                    Result = string.Concat(Convert.ToString(int.Parse(word.Trim()), 16).Trim(), SubmitAdd[ramdom.Next(1, 15)].Trim(), SubmitAdd[ramdom.Next(16, 30)].Trim(), SubmitAdd[ramdom.Next(31, 40)].Trim(), SubmitAdd[ramdom.Next(50, 70)].Trim());
                    break;
                case 3:
                    Result = Convert.ToString(int.Parse(Enc.ConvertCharAscii(word.Trim(), Sal)), 16).Trim();
                    break;
            }


            return Result.Trim();
        }
        protected internal int ConvertInt(string word)
        {
            return Convert.ToInt32(word, 16);
        }
        protected internal string ConvertHexChar(string word, int sal)
        {
            int HexToInt = Convert.ToInt32(word, 16);
            int IntToAscii = HexToInt / sal;
            char Char = (char)IntToAscii;
            return Char.ToString().Trim();
        }
        protected internal string[] SubmitVector(string[] Vector)
        {
            Safe Enc = new Safe();
            Random ramdom = new Random();
            for (int i = 2; i < Vector.Length; i++)
            {
                if (i % 2 == 0)
                    Vector[i] = string.Concat(Vector[i].Trim(), SubmitAdd[ramdom.Next(1, 20)].Trim(), SubmitAdd[ramdom.Next(21, 40)].Trim(), SubmitAdd[ramdom.Next(41, 55)].Trim(), SubmitAdd[ramdom.Next(56, 70)].Trim());
                else
                    Vector[i] = string.Concat(Vector[i].Trim(), SubmitAdd[ramdom.Next(1, 15)].Trim(), SubmitAdd[ramdom.Next(16, 30)].Trim(), SubmitAdd[ramdom.Next(36, 60)].Trim());
            }
            return Vector;
        }
        protected internal string ReturnString(string[] Vector)
        {
            string Resultado = string.Empty;
            for (int i = 0; i < Vector.Length; i++)
                Resultado = string.Concat(Resultado.Trim(), Vector[i].Trim());

            return Resultado;
        }
        public static string Bring(string Clave)
        {
            Safe Enc = new Safe();
            int SalEncripInt = Enc.Getsal();
            string SalEncripSt = Enc.ConvertHex(SalEncripInt.ToString().Trim(), 1, 0);

            string SizeVectSt = Enc.ConvertHex(Clave.Trim().Length.ToString(), 2, 0);
            int SizeVectInt = Clave.Trim().Length;
            string[] VectorEnc = new string[SizeVectInt + 3];
            VectorEnc[0] = Enc.Getsal().ToString().Trim();
            VectorEnc[1] = SalEncripSt;
            VectorEnc[2] = SizeVectSt;
            char[] VectorClave = new char[Clave.Trim().Length];
            VectorClave = Clave.Trim().ToCharArray();

            for (int i = 0; i < VectorClave.Length; i++)
            {
                string Letra = Clave.Trim().Substring(i, 1);
                string DataEnc = Enc.ConvertHex(Letra, 3, SalEncripInt);
                VectorEnc[i + 3] = DataEnc;
            }

            VectorEnc = Enc.SubmitVector(VectorEnc);
            string ClaveEncript = Enc.ReturnString(VectorEnc);

            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(ClaveEncript);
            return Convert.ToBase64String(encryted);
        }
        public static string Turn(string Encript)
        {
            string Clave = string.Empty;
            string Letra = string.Empty;
            bool Control = true;
            Safe Enc = new Safe();
            int Sal = 0;
            int Starindex = 0;
            int Len = 0;

            byte[] encryted = Convert.FromBase64String(Encript);
            Encript = System.Text.Encoding.Unicode.GetString(encryted);

            string TextEncript = Encript.Substring(4, Encript.Length - 4);
            char[] VectorEncript = TextEncript.Trim().ToCharArray();
            string CadenaHex = "0123456789abcdef";
            for (int i = 0; i < VectorEncript.Length; i++)
            {
                Starindex = i;
                Letra = TextEncript.Trim().Substring(i, 1);
                if (CadenaHex.Contains(Letra))
                {
                    do
                    {
                        Letra = TextEncript.Trim().Substring(i, 1);
                        i += 1;
                    } while (CadenaHex.Contains(Letra));
                    i -= 1;
                    Len = i - Starindex;

                    if (Starindex == 0)
                        Sal = Enc.ConvertInt(TextEncript.Trim().Substring(0, i));
                    else
                    {
                        if (Control)
                            Control = false;
                        else
                            Clave = string.Concat(Clave.Trim(), Enc.ConvertHexChar(TextEncript.Trim().Substring(Starindex, Len), Sal).ToString().Trim());
                    }
                }
            }
            return Clave;
        }
        public static SqlConnection Conexion(string Sesion)
        {
            SqlConnection Conn = new SqlConnection();
            string[] FileTextConection = System.IO.File.ReadAllLines(@"C:\Windows\FileTextConection.ini");
            int Indice = 0;
            foreach (string line in FileTextConection)
            {
                if (line.Trim() == Sesion.Trim())
                    break;
                Indice += 1;
            }
            string servidor = FileTextConection[Indice + 2].Substring(7, FileTextConection[Indice + 2].Length - 7);
            string dbase = FileTextConection[Indice + 3].Substring(9, FileTextConection[Indice + 3].Length - 9);
            string usuario = FileTextConection[Indice + 4].Substring(8, FileTextConection[Indice + 4].Length - 8);
            string pws = Safe.Turn(FileTextConection[Indice + 5].Substring(9, FileTextConection[Indice + 5].Length - 9));
            Conn.ConnectionString = "Server=" + servidor + ";Database=" + dbase + ";User Id=" + usuario + ";Password=" + pws + ";";
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
            else
                Conn.Open();
            return Conn;
        }
        public static void Conexion(SqlConnection ObjConexion)
        {
            if (ObjConexion.State == ConnectionState.Open)
                ObjConexion.Close();
        }
        public static string ServerConexion(string Sesion)
        {
            string ServerReturn = string.Empty;
            try
            {
                string[] FileTextConection = System.IO.File.ReadAllLines(@"C:\Windows\FileTextConection.ini");
                int Indice = 0;
                foreach (string line in FileTextConection)
                {
                    if (line.Trim() == Sesion.Trim())
                        break;
                    Indice += 1;
                }

                ServerReturn = FileTextConection[Indice + 2].Substring(7, FileTextConection[Indice + 2].Length - 7);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Generando StringServer del Archivo de Conexion: Class ServerConexion. " + Ex.Message);
            }
            return ServerReturn;
        }
        public static List<string> SesionConexion(string Aplicacion)
        {
            List<string> ReturnSesion = new List<string>();
            string[] FileTextConection = System.IO.File.ReadAllLines(@"C:\Windows\FileTextConection.ini");
            int Indice = 0;
            foreach (string line in FileTextConection)
            {
                if (line.Trim() == "Aplicacion=" + Aplicacion.Trim())
                    ReturnSesion.Add(FileTextConection[Indice - 1]);
                Indice += 1;
            }
            return ReturnSesion;
        }
        public static bool FormaSeguridad(string App, string edition)
        {
            Frm_SeguridadAcceso Forma = new Frm_SeguridadAcceso();
            Forma.Aplicacion = App;
            Forma.Version = edition;

            Forma.ShowDialog();
            return Forma.Validado;
        }
        public static bool ValidaUsuario(string App, string Usuario, string PassUser)
        {
            bool Resultado = false;
            try
            {
                SqlParameter[] ParamSQL = new SqlParameter[4];
                ParamSQL[0] = new SqlParameter("@Op", "UsuariosLogin");
                ParamSQL[1] = new SqlParameter("@ParametroChar", Usuario.Trim());
                ParamSQL[2] = new SqlParameter("@ParametroInt", "0");
                ParamSQL[3] = new SqlParameter("@ParametroNumeric", "0");

                SqlConnection objconexion = Safe.Conexion(App);
                SqlCommand cmd;
                cmd = new SqlCommand("SpConsulta_Tablas", objconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in ParamSQL)
                    cmd.Parameters.Add(item).Value = item.Value;
                SqlDataReader Reader;
                Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    string login = Reader["Login"].ToString();
                    byte[] password = (byte[])Reader["Password"];
                    string PassString = Encoding.ASCII.GetString(password);
                    if (PassString.Trim() == PassUser.Trim())
                        Resultado = true;
                }
                else
                    Resultado = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error generando la validacion del usuario: Class ValidaUsuario. " + Environment.NewLine + Ex.Message);
            }
            return Resultado;
        }
        public static void AppSettingUser(string User)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("user_activo");
            config.AppSettings.Settings.Add("user_activo", User);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void AppSettingdbase(string dbase)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("dbase");
            config.AppSettings.Settings.Add("dbase", dbase);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static Ent_SeguridadUsuario UsuarioActivo()
        {
            Ent_SeguridadUsuario UsuarioActivo = new Ent_SeguridadUsuario();
            try
            {
                string Login = ConfigurationManager.AppSettings["user_activo"];

                string dbase = ConfigurationManager.AppSettings["dbase"];
                string Servidor = Safe.ServerConexion(dbase);
                string Aplicacion = ConfigurationManager.AppSettings["aplicacion"];


                SqlParameter[] ParamSQL = new SqlParameter[4];
                ParamSQL[0] = new SqlParameter("@Op", "SeguridadUsuario");
                ParamSQL[1] = new SqlParameter("@ParametroChar", Login.Trim());
                ParamSQL[2] = new SqlParameter("@ParametroInt", "0");
                ParamSQL[3] = new SqlParameter("@ParametroNuemric", "0");

                SqlConnection objconexion = Safe.Conexion(dbase);
                SqlCommand cmd;
                cmd = new SqlCommand("SpConsulta_Tablas", objconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in ParamSQL)
                    cmd.Parameters.Add(item).Value = item.Value;
                SqlDataReader Reader;
                Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    UsuarioActivo.Id = Convert.ToInt32(Reader["Id"]);
                    UsuarioActivo.Login = Reader["Login"].ToString();
                    UsuarioActivo.NombreUsuario = Reader["Nombre"].ToString();
                    UsuarioActivo.IdPerfil = Convert.ToInt32(Reader["IdPerfil"]);
                    UsuarioActivo.NombrePerfil = Reader["NombrePerfil"].ToString();
                    UsuarioActivo.Foto = (byte[])Reader["Foto"];
                    UsuarioActivo.dbase = dbase.Trim();
                    UsuarioActivo.Servidor = Servidor.Trim();
                    UsuarioActivo.Aplicacion = Aplicacion.Trim();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error generando nombre del usuario: Class UsuarioActivo. " + Ex.Message);
            }
            return UsuarioActivo;
        }

        //Case que retorna las listas de enticades

        #region MyRegion

        public static List<T> ListaEntidad<T>(string App, string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlConnection Conexion = Safe.Conexion(App);
            SqlParameter[] Parametros = new SqlParameter[4];
            Parametros[0] = new SqlParameter("@Op", Op);
            Parametros[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros[3] = new SqlParameter("@ParametroNumeric", ParametroNumeric);

            SqlCommand Command = new SqlCommand("SpConsulta_Tablas", Conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            foreach (var item in Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            System.Text.ASCIIEncoding Texto = new System.Text.ASCIIEncoding();
            Reader = Command.ExecuteReader();

            List<T> Return = Llenar<T>(Reader);
            ZandorConn.Safe.Conexion(Conexion);
            return Return;
        }
        public static List<T> Llenar<T>(SqlDataReader lector)
        {
            try
            {
                // Si el lector no es nulo.
                if (lector != null)
                {
                    // Si el lector tiene registros.
                    if (lector.HasRows)
                    {
                        // Se obtienen las propiedades del objeto que llena la lista
                        PropertyInfo[] propiedades = typeof(T).GetProperties();

                        // Se mapean las propiedades con los campos obtenidos.
                        // Para que el mapeo sea correcto, los campos obtenidos tienen
                        // que coincidir en el nombre de la propiedad.
                        Dictionary<string, int> ubicacion = new Dictionary<string, int>();
                        foreach (PropertyInfo propiedad in propiedades)
                        {
                            for (int indice = 0; indice < lector.FieldCount; indice++)
                                if ((propiedad.Name == lector.GetName(indice)) && (propiedad.CanWrite))
                                    ubicacion.Add(propiedad.Name, indice);
                        }

                        // Se crea la lista que será la respuesta del método.
                        List<T> respuesta = new List<T>();

                        // Se recorren los registros del lector.
                        while (lector.Read())
                        {
                            // Para cada registro se instancia un nuevo objeto del
                            // tipo que llenará la lista.
                            T instancia = (T)Activator.CreateInstance<T>();
                            foreach (PropertyInfo propiedad in propiedades)
                            {
                                // Usando el mapeo que se hizo anteriormente, se ubica la columna
                                // a la que se le asignará el valor desde el lector.
                                int columna = -1;
                                if (ubicacion.TryGetValue(propiedad.Name, out columna))
                                {
                                    try
                                    {
                                        // Si se ubicó la columna y esta tiene un valor,
                                        // se asigna dicho valor a la propiedad, en la
                                        // instancia que se está llenando
                                        if (!lector.IsDBNull(columna))
                                            propiedad.SetValue(instancia, lector.GetValue(columna), null);
                                    }
                                    catch { }
                                    // El cachado de error se incluye, para los casos en los que
                                    // el valor obtenido no sea compatible con el tipo de dato de la
                                    // propiedad.
                                }
                            }
                            // Se incluye la instancia dentro de la respuesta a enviar.
                            respuesta.Add(instancia);
                        }
                        // Se cierra el lector y se envía la respuesta.
                        lector.Close();
                        return respuesta;
                    }
                    else
                    {
                        // En caso de que el lector no tenga registros,
                        // se cierra el lector y se regresa una lista vacía.
                        lector.Close();
                        return new List<T>();
                    }
                }
                else
                {
                    // En caso de que el lector no se haya construido,
                    // se regresa un valor nulo.
                    return null;
                }
            }
            catch (Exception)
            {
                /* Manejo de error */
                return null;
            }
        }
        #endregion


    }
}
