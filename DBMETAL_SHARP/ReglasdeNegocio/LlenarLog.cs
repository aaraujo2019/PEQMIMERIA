using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    public static class LlenarLog
    {
        public static bool Registro(DateTime Fecha, string Usuario, string IpLocal, string IpPublica, string SerialHDD, string Maquina,  string Proceso, string Tipo)
        {
            try
            {
                SqlParameter[] ParamLog = new SqlParameter[8];
                ParamLog[0] = new SqlParameter("@Fecha", Fecha);
                ParamLog[1] = new SqlParameter("@Usuario", Usuario);
                ParamLog[2] = new SqlParameter("@IpLocal", IpLocal);
                ParamLog[3] = new SqlParameter("@IpPublica", IpPublica);
                ParamLog[4] = new SqlParameter("@SerialHDD", SerialHDD);
                ParamLog[5] = new SqlParameter("@Maquina", Maquina);
                ParamLog[6] = new SqlParameter("@Proceso", Proceso);
                ParamLog[7] = new SqlParameter("@Tipo", Tipo);

                GuardarDatos Guardar = new GuardarDatos();
                Guardar.booleano("LogOperaciones", ParamLog);
            }
            catch (Exception Exc)
            {
                MessageBox.Show("Error al Guardar LogProceso. " + Exc.Message, "Mensaje controlado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        public static bool RegistroLocalizacion(DateTime Fecha, string Usuario, string IpLocal, string IpPublica, string SerialHDD, string Maquina, string Proceso, string Tipo)
        {
            try
            {
                SqlParameter[] ParamLog = new SqlParameter[8];
                ParamLog[0] = new SqlParameter("@Fecha", Fecha);
                ParamLog[1] = new SqlParameter("@Usuario", Usuario);
                ParamLog[2] = new SqlParameter("@IpLocal", IpLocal);
                ParamLog[3] = new SqlParameter("@IpPublica", IpPublica);
                ParamLog[4] = new SqlParameter("@SerialHDD", SerialHDD);
                ParamLog[5] = new SqlParameter("@Maquina", Maquina);
                ParamLog[6] = new SqlParameter("@Proceso", Proceso);
                ParamLog[7] = new SqlParameter("@Tipo", Tipo);

                GuardarDatos Guardar = new GuardarDatos();
                Guardar.booleano("LogOperaciones", ParamLog);
            }
            catch (Exception Exc)
            {
                MessageBox.Show("Error al Guardar LogProceso. " + Exc.Message, "Mensaje controlado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }


    }
}
