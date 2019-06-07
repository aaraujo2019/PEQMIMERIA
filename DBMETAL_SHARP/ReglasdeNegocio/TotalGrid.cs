using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    public class TotalGrid
    {
        public static string RegistrosSeleccionados(DataGridView Dgv)
        {
            string Resultado;
            int TotalRegistros = 0;
            int RegistrosSeleccionados = 0;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int index = row.Index;
                TotalRegistros += 1;
                if (Convert.ToInt32(row.Cells[0].Value) == 0)
                    RegistrosSeleccionados += 1;
            }
            Resultado = "Total Registros Seleccionados: " + (TotalRegistros - RegistrosSeleccionados).ToString().Trim() + " de " + TotalRegistros.ToString().Trim();

            return Resultado.Trim();
        }

        public static void MarcarSeleccion(DataGridView Dgv)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int index = row.Index;
                if (Convert.ToInt32(row.Cells[8].Value) == 0)
                {
                    row.Cells[0].Value = false;
                    Dgv.Rows[index].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                else
                    row.Cells[0].Value = true;
            }
        }

        public static void HabilitarCheck(DataGridView Dgv)
        {
            int I = 0;
            foreach (DataGridViewColumn Column in Dgv.Columns)
            {
                if (I == 0)
                    Column.ReadOnly = false;
                else
                    Column.ReadOnly = true;
                I += 1;
            }
        }

        public static string TotalLiquidacion(DataGridView Dgv)
        {
            double TonMolidas = 0.00;
            double OzMolino = 0.00;
            double OzRecuperadas = 0.00;
            double ValorLiquidacion = 0.00;
            double Tenor = 0.00;
            string Resultado;
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    TonMolidas += Convert.ToDouble(row.Cells[3].Value);
                    OzMolino += Convert.ToDouble(row.Cells[5].Value);
                    OzRecuperadas += Convert.ToDouble(row.Cells[6].Value);
                    if (Convert.ToString(row.Cells[7].Value).Trim().Length > 0)
                        ValorLiquidacion += Convert.ToDouble(row.Cells[7].Value);
                }
            }
            Tenor = OzMolino * 31.1035 / TonMolidas;
            Resultado = "TonMolidas " + TonMolidas.ToString("###,###,##0.#0").Trim() + " // Tenor Promedio " + Tenor.ToString("###,###,##0.#0").Trim() + " // Oz Al Molino " + OzMolino.ToString("###,###,##0.#0").Trim() + " // Oz Recuperadas " + OzRecuperadas.ToString("###,###,##0.#0").Trim() + " // Total " + ValorLiquidacion.ToString("###,###,##0.#0");
            return Resultado;
        }
    }
}
