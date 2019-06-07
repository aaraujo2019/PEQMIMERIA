using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entidades;

namespace ReglasdeNegocio
{
    public class LeerExcel
    {


        public static DataSet Datos(string ruta)
        {
            List<string> lista = new List<string>();

            // Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //Creamos el DataSet que se llena con los datos de la hoja de Excel
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("LimSupPadre");
            dt.Columns.Add("LimSupHijo");
            dt.Columns.Add("Humedad");
            dt.Columns.Add("G_TM");
            dt.Columns.Add("PesoMuestra");


            DataRow row = dt.NewRow();

            try
            {
                //  Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                //xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja 1"];
                xlHoja1 = xlLibro.ActiveSheet;     //(Microsoft.Office.Interop.Excel. ._Worksheet)xlHojas["Hoja 1"];

                int j = 17;
                int I = 0;
                string LimSupP = "";
                string LimSupH = "";
                string Humedad = "";
                string G_TM = "";
                string Peso = "";

                //recorremos las celdas que queremos 
                string Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                while (Seguir.IndexOf("*DUP") == -1 && Seguir.IndexOf("END") == -1)
                {
                    LimSupH = "";
                    LimSupP = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                    if (LimSupP.IndexOf("A") != -1)
                        LimSupH = LimSupP.Replace("A", "");
                    if (LimSupP.IndexOf("B") != -1)
                        LimSupH = LimSupP.Replace("B", "");
                    if (LimSupP.IndexOf("C") != -1)
                        LimSupH = LimSupP.Replace("C", "");
                    if (LimSupH.Length == 0)
                        LimSupH = LimSupP;

                    if (j == 17)
                    {
                        Humedad = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                        Peso = (string)xlHoja1.get_Range("E" + j, Missing.Value).Text;
                        I = 17;
                    }
                    else
                    {
                        Humedad = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                        Peso = (string)xlHoja1.get_Range("E" + j, Missing.Value).Text;
                        if (Humedad.Length == 2)
                        {
                            Humedad = (string)xlHoja1.get_Range("B" + I, Missing.Value).Text;
                            Peso = (string)xlHoja1.get_Range("E" + I, Missing.Value).Text;
                        }
                        else
                            I = j;
                    }
                    G_TM = (string)xlHoja1.get_Range("C" + j, Missing.Value).Text;

                    row["Id"] = j - 17 + 1;
                    row["LimSupPadre"] = LimSupP;
                    row["LimSupHijo"] = LimSupH;
                    row["Humedad"] = Humedad;
                    row["G_TM"] = G_TM;
                    row["PesoMuestra"] = Peso;
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                    j++;
                    Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                }
                DataSet DS = new DataSet();
                DS.Tables.Add(dt);
                return DS;
            }
            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }
        }

        public static Ent_EncabezadoExcel Encabezado(string ruta)
        {
            Ent_EncabezadoExcel EncabezadoExcel = new Ent_EncabezadoExcel();

            // Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            try
            {
                //  Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                //xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja 1"];
                xlHoja1 = xlLibro.ActiveSheet;     //(Microsoft.Office.Interop.Excel. ._Worksheet)xlHojas["Hoja 1"];

                //recorremos las celdas que queremos 
                string cliente = (string)xlHoja1.get_Range("B" + 6, Missing.Value).Text;
                string orden = (string)xlHoja1.get_Range("B" + 5, Missing.Value).Text;
                string lugar = (string)xlHoja1.get_Range("B" + 8, Missing.Value).Text;
                string reporte = (string)xlHoja1.get_Range("B" + 9, Missing.Value).Text;
                string recepcion = (string)xlHoja1.get_Range("C" + 8, Missing.Value).Text;
                string referencia = (string)xlHoja1.get_Range("B" + 10, Missing.Value).Text;
                string muestras = (string)xlHoja1.get_Range("B" + 7, Missing.Value).Text;
                EncabezadoExcel.Cliente = cliente;
                EncabezadoExcel.Orden = orden;
                EncabezadoExcel.Lugar = lugar;
                EncabezadoExcel.Reporte = reporte;
                EncabezadoExcel.Recepcion = recepcion;
                EncabezadoExcel.Referencia = referencia;
                EncabezadoExcel.Muestras = muestras;

            }
            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }
            return EncabezadoExcel;

        }

        public static DataSet DatosGQ15(string ruta)
        {
            List<string> lista = new List<string>();

            // Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //Creamos el DataSet que se llena con los datos de la hoja de Excel
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("LimSupPadre");
            dt.Columns.Add("LimSupHijo");
            dt.Columns.Add("G_TM");
            dt.Columns.Add("PesoMuestra");


            DataRow row = dt.NewRow();

            try
            {
                //  Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                //xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja 1"];
                xlHoja1 = xlLibro.ActiveSheet;     //(Microsoft.Office.Interop.Excel. ._Worksheet)xlHojas["Hoja 1"];

                int j = 10;
                int I = 0;
                string LimSupP = "";
                string LimSupH = "";
                string G_TM = "";
                string Peso = "";
                string Seguir = "";
                string CeldaPeso = "";

                #region Determinar la fila incial para recorrer el archivo
                Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                while (Seguir.IndexOf("STD") == -1)
                {
                    Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                    j = j + 1;
                }

                Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                if (Seguir.IndexOf("STD") != -1)
                    j = j + 1;

                I = j;
                #endregion

                Seguir = (string)xlHoja1.get_Range("E" + 12, Missing.Value).Text;

                if (Seguir.IndexOf("Peso") == -1)
                    CeldaPeso = "F";
                else
                    CeldaPeso = "E";

                //recorremos las celdas que queremos 
                Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                while (Seguir.IndexOf("*DUP") == -1 && Seguir.IndexOf("END") == -1)
                {

                    LimSupH = "";
                    LimSupP = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                    if (LimSupP.IndexOf("a") != -1)
                        LimSupH = LimSupP.Replace("a", "");
                    if (LimSupP.IndexOf("b") != -1)
                        LimSupH = LimSupP.Replace("b", "");
                    if (LimSupP.IndexOf("c") != -1)
                        LimSupH = LimSupP.Replace("c", "");
                    if (LimSupH.Length == 0)
                        LimSupH = LimSupP;

                    Peso = (string)xlHoja1.get_Range(CeldaPeso.Trim() + j, Missing.Value).Text;
                    G_TM = (string)xlHoja1.get_Range("C" + j, Missing.Value).Text;

                    if (G_TM == "<1")
                    {
                        G_TM = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                        if (G_TM == "--")
                            G_TM = "0";
                        double Tenor = Convert.ToDouble(G_TM) / 1000;
                        G_TM = Tenor.ToString();
                    }

                    row["Id"] = j - I + 1;
                    row["LimSupPadre"] = LimSupP.Trim();
                    row["LimSupHijo"] = LimSupH.Trim();
                    row["G_TM"] = G_TM.Trim();
                    row["PesoMuestra"] = Peso.Trim();
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                    j++;
                    Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                }
                DataSet DS = new DataSet();
                DS.Tables.Add(dt);
                return DS;
            }
            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }
        }

        public static Ent_EncabezadoHume EncabezadoHume(string ruta)
        {
            Ent_EncabezadoHume EncabezadoHume = new Ent_EncabezadoHume();

            // Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            try
            {
                //  Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                //xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja 1"];
                xlHoja1 = xlLibro.ActiveSheet;     //(Microsoft.Office.Interop.Excel. ._Worksheet)xlHojas["Hoja 1"];

                //recorremos las celdas que queremos 
                string fecha = (string)xlHoja1.get_Range("A" + 5, Missing.Value).Text;
                string muestras = (string)xlHoja1.get_Range("D" + 5, Missing.Value).Text;
                string cliente = (string)xlHoja1.get_Range("B" + 5, Missing.Value).Text;
                string auunidad = (string)xlHoja1.get_Range("B" + 43, Missing.Value).Text;
                string aumetodo = (string)xlHoja1.get_Range("B" + 44, Missing.Value).Text;
                string agunidad = (string)xlHoja1.get_Range("C" + 43, Missing.Value).Text;
                string agmetodo = (string)xlHoja1.get_Range("C" + 44, Missing.Value).Text;
                string humeunidad = (string)xlHoja1.get_Range("D" + 43, Missing.Value).Text;
                string humemetodo = (string)xlHoja1.get_Range("D" + 44, Missing.Value).Text;
                string tipomuestra = (string)xlHoja1.get_Range("B" + 9, Missing.Value).Text;
                string orden = (string)xlHoja1.get_Range("B" + 11, Missing.Value).Text;
                string clienteorden = (string)xlHoja1.get_Range("B" + 13, Missing.Value).Text;
                string nummuestras = (string)xlHoja1.get_Range("B" + 14, Missing.Value).Text;
                string fechamuestreo = (string)xlHoja1.get_Range("B" + 15, Missing.Value).Text;
                string fechareporte = (string)xlHoja1.get_Range("B" + 16, Missing.Value).Text;
                string notas = (string)xlHoja1.get_Range("A" + 32, Missing.Value).Text;
                string codigoprepa = (string)xlHoja1.get_Range("D" + 10, Missing.Value).Text;
                string descriprepa = (string)xlHoja1.get_Range("F" + 10, Missing.Value).Text;
                string codigoanalisis = (string)xlHoja1.get_Range("D" + 16, Missing.Value).Text;
                string descrianalisis = (string)xlHoja1.get_Range("F" + 16, Missing.Value).Text;


                EncabezadoHume.Fecha = fecha;
                EncabezadoHume.Muestras = muestras;
                EncabezadoHume.Cliente = cliente;
                EncabezadoHume.AuUnidad = auunidad;
                EncabezadoHume.AuMetodo = aumetodo;
                EncabezadoHume.AgUnidad = agunidad;
                EncabezadoHume.AgMetodo = agmetodo;
                EncabezadoHume.HumedadUnd = humeunidad;
                EncabezadoHume.HumedadMet = humemetodo;
                EncabezadoHume.TipoMuestras = tipomuestra;
                EncabezadoHume.Orden = orden;
                EncabezadoHume.ClienteOrden = clienteorden;
                EncabezadoHume.NumMuestras = nummuestras;
                EncabezadoHume.FechaMuestreo = fechamuestreo;
                EncabezadoHume.FechaReporte = fechareporte;
                EncabezadoHume.Notas = notas;
                EncabezadoHume.CodigoPrepa = codigoprepa;
                EncabezadoHume.DescripcionPrepa = descriprepa;
                EncabezadoHume.CodigoAnalisis = codigoanalisis;
                EncabezadoHume.DescripcionAnalisis = descrianalisis;


            }
            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }
            return EncabezadoHume;

        }

        public static DataSet DatoHumedad(string ruta)
        {
            List<string> lista = new List<string>();

            // Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //Creamos el DataSet que se llena con los datos de la hoja de Excel
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Sello");
            dt.Columns.Add("Humedad");
            DataRow row = dt.NewRow();

            try
            {
                //  Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                //xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja 1"];
                xlHoja1 = xlLibro.ActiveSheet;     //(Microsoft.Office.Interop.Excel. ._Worksheet)xlHojas["Hoja 1"];

                int j = 46;
                int I = 1;
                string sello = "";
                string humedad = "";
                string Seguir = "";


                //recorremos las celdas que queremos 
                Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                while (Seguir.Trim().Length != 0)
                {
                    sello = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                    humedad = (string)xlHoja1.get_Range("D" + j, Missing.Value).Text;

                    row["Id"] = I;
                    row["Sello"] = sello.Trim();
                    row["Humedad"] = humedad.Trim();
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                    j++;
                    I++;
                    Seguir = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                }
                DataSet DS = new DataSet();
                DS.Tables.Add(dt);
                return DS;
            }
            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }
        }


        public static DataSet TenorZandor(string ruta)
        {
            List<string> lista = new List<string>();

            // Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //Creamos el DataSet que se llena con los datos de la hoja de Excel
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Sello");
            dt.Columns.Add("Ley");
            dt.Columns.Add("Humedad");
            DataRow row = dt.NewRow();

            try
            {
                //  Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                //xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja 1"];
                xlHoja1 = xlLibro.ActiveSheet;     //(Microsoft.Office.Interop.Excel. ._Worksheet)xlHojas["Hoja 1"];

                int j = 2;
                int I = 1;
                string sello = "";
                string ley = "";
                string humedad = "";
                string Seguir = "";

                // Recorremos las celdas que queremos.
                Seguir = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                while (Seguir.Trim().Length != 0)
                {
                    sello = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                    ley = (string)xlHoja1.get_Range("C" + j, Missing.Value).Text;
                    humedad = (string)xlHoja1.get_Range("D" + j, Missing.Value).Text;                    

                    row["Id"] = I;
                    row["Sello"] = sello.Trim();
                    row["Ley"] = ley.Trim();
                    row["Humedad"] = humedad.Trim();
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                    j++;
                    I++;
                    Seguir = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                }
                DataSet DS = new DataSet();
                DS.Tables.Add(dt);
                return DS;
            }
            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }
        }

    }
}
