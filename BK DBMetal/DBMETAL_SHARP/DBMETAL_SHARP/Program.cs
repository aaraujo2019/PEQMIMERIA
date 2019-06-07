using DBMETAL_SHARP.Liquidacion;
using Reportes;
using Reportes;
using Reportes.LiquidacionDBMETAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
          
            int Op = 24;

            if (args.Count() > 0)
            {

                string[] arguments = args[0].Split('|');

                string Login = arguments[1];
                Op = Convert.ToInt32(arguments[0]);


                string Placa = arguments[2];

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                switch (Op)
                {
                    case 1:
                        Application.Run(new Principal());
                        break;
                    case 2:
                        Application.Run(new Frm_Vehiculo(Login));
                        break;
                    case 3:
                        Application.Run(new Frm_PropietarioVehiculos(Login));
                        break;
                    case 4:
                        Application.Run(new Frm_VistaVehiculos(Login, Placa));
                        break;
                    case 5:
                        Application.Run(new Frm_RelacionTransporteOtrosPesajes(Login));
                        break;
                    case 6:
                        Application.Run(new Frm_Estadisticas(Login));
                        break;
                    case 7:
                        Application.Run(new Frm_Motos(Login));
                        break;
                    case 8:
                        Application.Run(new Frm_Contratistas(Login));
                        break;
                    case 9:
                        Application.Run(new Frm_Conductores(Login));
                        break;
                    case 10:
                        Application.Run(new Frm_Subtipos(Login));
                        break;
                    case 11:
                        Application.Run(new FrmRptProyeccionMineral(Login, Placa));
                        break;
                    case 12:
                        Application.Run(new Frm_Minas(Login));
                        break;
                    case 13:
                        Application.Run(new Frm_DetalleLiquidacion());
                        break;
                    case 14:
                        Application.Run(new Frm_MuestreoPM(Login, false));
                        break;
                    case 15:
                        Application.Run(new Frm_PersonalMuestreo(Login));
                        break;
                    case 16:
                        Application.Run(new Frm_PesajesMineraPlanta(Login));
                        break;
                    case 17:
                        Application.Run(new Frm_Localizacion(Login));
                        break;
                    case 18:
                        Application.Run(new TextConcept());
                        break;
                    case 19:
                        Application.Run(new Frm_ControlCalidadMuestras(Login));
                        break;
                    case 20:
                        Application.Run(new Frm_TenorCalidadMuestras(Login));
                        break;
                    case 21:
                        Application.Run(new Frm_CargaAnalisis(Login));
                        break;
                    case 22:
                        Application.Run(new Frm_Periodo(Login));
                        break;
                    case 23:
                        DateTime date1 = Convert.ToDateTime(arguments[4].ToString());
                        DateTime date2 = Convert.ToDateTime(arguments[5].ToString());

                        object[] argument = new object[] { Convert.ToInt32(arguments[3]), date1, date2 };
                        Application.Run(new Frm_Reporte_Liquidacion(Convert.ToInt32(arguments[3])));
                        //Frm_Reporte_Liquidacion report= new Frm_Reporte_Liquidacion();



                        //report.EjecucionReportes(argument);
                        //report.Show();

                        break;

                    case 24:
                        Application.Run(new frmLogin());
                        break;

                    case 25:
                        Application.Run(new ManageRoles());
                        break;
                    case 26:
                        Application.Run(new ManagePermissions(Login));
                        break;


                }
            }
            else
            {
                switch (Op)
                {
                    case 24:
                        Application.Run(new frmLogin());
                        break;

                    case 25:
                        Application.Run(new ManageRoles());
                        break;
                }
            }
        }
    }
}
