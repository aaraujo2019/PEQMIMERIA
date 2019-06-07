using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DBMETAL_SHARP
{
    public partial class Frm_Estadisticas : Form
    {
        public Frm_Estadisticas(string login)
        {
            InitializeComponent();
        }

        private void Frm_Estadisticas_Load(object sender, EventArgs e)
        {

        }



        private void RdbMes_Enter(object sender, EventArgs e)
        {


        }

        private void CmbSeleccion_Leave(object sender, EventArgs e)
        {
            if (this.CmbSeleccion.SelectedIndex == 0)
            {
                this.CmbOpcion.Items.Clear();
                this.CmbOpcion.Items.Add("Toneladas pesadas en el mes / operador");
                this.CmbOpcion.Items.Add("Toneladas pesadas en el año / operador");
                this.CmbOpcion.Items.Add("Toneladas pesadas en el mes / agrupada");
                this.CmbOpcion.Items.Add("Toneladas pesadas por dia / mes");
                this.CmbOpcion.Items.Add("Toneladas pesadas dia (Transacciones Cerradas)");
                this.CmbOpcion.Items.Add("Toneladas pesadas mes / Año");
                this.CmbOpcion.Items.Add("Toneladas pesadas semana / mes / Año");
                this.CmbOpcion.Items.Add("Toneladas pesadas semana / Año");
            }
            if (this.CmbSeleccion.SelectedIndex == 1)
            {
                this.CmbOpcion.Items.Clear();
                this.CmbOpcion.Items.Add("Toneladas pesadas en el Mes / Tipo");
                this.CmbOpcion.Items.Add("Toneladas pesadas en el Año / Tipo");
                this.CmbOpcion.Items.Add("Toneladas pesadas Semana / Año / Mes - Tipo");
                this.CmbOpcion.Items.Add("Toneladas pesadas Semana / Año - Tipo");
            }

        }

        private void CmbOpcion_Leave(object sender, EventArgs e)
        {
            if (this.CmbSeleccion.SelectedIndex == 0)
            {
                switch (this.CmbOpcion.SelectedIndex)
                {
                    #region Casos Bascula Planta
                    case 0:
                        #region Caso 0 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[2];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            ParametrosGrid[1] = new SqlParameter("@Mes", this.DtpAñoMes.Value.Month);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_MesesPlanta", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Mejores Pesos por Operadores");
                            double SeparadorX = 0;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["NombreProyecto"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0");
                                SerieChart.Points.AddXY(SeparadorX, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["NombreProyecto"].ToString().Trim() + " / " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                SeparadorX += 0.25;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 1:
                        #region Caso 1 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[1];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_AñoPlanta", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Mejores Pesos por Operadores");
                            double SeparadorX = 0;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["NombreProyecto"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0");
                                SerieChart.Points.AddXY( SeparadorX, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["NombreProyecto"].ToString().Trim() + " / " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                 SeparadorX += 0.25;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 2:
                        #region Caso 2 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[2];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            ParametrosGrid[1] = new SqlParameter("@Mes", this.DtpAñoMes.Value.Month);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_MesesPlantaAgrupada", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");


                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas en el mes / agrupada");
                            for (int i = 0; i < 2; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["NombreContenedor"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0");
                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["NombreContenedor"].ToString().Trim() + " / " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;

                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 3:
                        #region Caso 3 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[2];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            ParametrosGrid[1] = new SqlParameter("@Mes", this.DtpAñoMes.Value.Month);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_MesesPlantaDia", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");


                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas por dia / mes");
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add("Dia " + DS.Tables[0].Rows[i]["Dia"].ToString());
                                //SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0");
                                SerieChart.Label = DS.Tables[0].Rows[i]["Dia"].ToString().Trim() + " : " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");

                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = "Dia: " + DS.Tables[0].Rows[i]["Dia"].ToString().Trim() + " = " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                SerieChart.ChartType = SeriesChartType.BoxPlot;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 4:
                        #region Caso 4 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[1];
                            ParametrosGrid[0] = new SqlParameter("@Dia", this.DtpAñoMes.Value.ToShortDateString());
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_PlantaDia", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");


                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas del dia");
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["NombreProyecto"].ToString());
                                SerieChart.Label = "(" + DS.Tables[0].Rows[i]["Codigo"].ToString() + ") " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");

                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["NombreProyecto"].ToString().Trim() + " = " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                //SerieChart.ChartType = SeriesChartType.BoxPlot;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 5:
                        #region Caso 5 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[1];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_PlantaMesAño", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");


                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas mes / año");
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["Mes"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");

                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["Mes"].ToString().Trim() + " = " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                //SerieChart.ChartType = SeriesChartType.BoxPlot;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 6:
                        #region Caso 6 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[2];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            ParametrosGrid[1] = new SqlParameter("@Mes", this.DtpAñoMes.Value.Month);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_PlantaSemanaMes", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");


                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas semanas / mes / año");

                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add("Semana " + DS.Tables[0].Rows[i]["Semana"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");

                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = "Semana " + DS.Tables[0].Rows[i]["Semana"].ToString().Trim() + " = " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                //SerieChart.ChartType = SeriesChartType.BoxPlot;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    case 7:
                        #region Caso 6 Bascula
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[1];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_PlantaSemanaAño", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas semanas / mes / año");

                            double y = 0;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add("Semana " + DS.Tables[0].Rows[i]["Semana"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");

                                SerieChart.Points.AddXY(y, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = "Semana " + DS.Tables[0].Rows[i]["Semana"].ToString().Trim() + " = " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                                y += 0.05;
                                //SerieChart.ChartType = SeriesChartType.BoxPlot;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    #endregion
                }

            }
            if (this.CmbSeleccion.SelectedIndex == 1)
            {
                switch (this.CmbOpcion.SelectedIndex)
                {
                    #region Casos Bascula Otros Pesajes
                    case 0:
                        #region Caso 0 Otros Pesajes
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[2];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            ParametrosGrid[1] = new SqlParameter("@Mes", this.DtpAñoMes.Value.Month);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_TipoMineralAñoMes", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas en el Mes / Tipo");
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["TipoMineral"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0");
                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["TipoMineral"].ToString().Trim() + " / " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion

                    case 1:
                        #region Caso 0 Otros Pesajes
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[1];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_TipoMineralAño", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas en el Año / Tipo");
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["TipoMineral"].ToString());
                                SerieChart.Label = Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0");
                                SerieChart.Points.AddXY(i + 1, Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString()));
                                SerieChart.ToolTip = DS.Tables[0].Rows[i]["TipoMineral"].ToString().Trim() + " / " + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]).ToString("###,###,##0.#0");
                                SerieChart.BorderWidth = 2;
                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion

                    case 2:
                        #region Caso 0 Otros Pesajes
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[2];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            ParametrosGrid[1] = new SqlParameter("@Mes", this.DtpAñoMes.Value.Month);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_TipoMineralSemanaAñoMes", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas Semana / Año / Mes - Tipo");
                            string SerieActual = DS.Tables[0].Rows[0]["Semana"].ToString();
                            string SerieAnterior = DS.Tables[0].Rows[0]["Semana"].ToString();
                            Peso = 0;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                SerieActual = DS.Tables[0].Rows[i]["Semana"].ToString();
                                Peso += Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString());
                                if (SerieActual.Trim() != SerieAnterior.Trim())
                                {

                                    Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["Semana"].ToString());
                                    SerieChart.Label = Peso.ToString("###,###,##0");
                                    SerieChart.Points.Add(Peso);
                                    SerieChart.ToolTip = DS.Tables[0].Rows[i]["Semana"].ToString().Trim() + " / " + Peso.ToString("###,###,##0.#0");
                                    SerieChart.BorderWidth = 2;
                                    Peso = 0;
                                }
                                SerieAnterior = DS.Tables[0].Rows[i]["Semana"].ToString();

                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion

                    case 3:
                        #region Caso 0 Otros Pesajes
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[1];
                            ParametrosGrid[0] = new SqlParameter("@Año", this.DtpAñoMes.Value.Year);
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpChart_TipoMineralSemanaAño", ParametrosGrid);

                            double Peso = 0.00;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                                Peso = Peso + Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"]);

                            this.LblPesos.Text = "Peso Total: " + Peso.ToString("###,###,##0.#0");

                            this.dataGridView1.DataSource = null;
                            this.dataGridView1.DataSource = DS;
                            this.dataGridView1.DataMember = "Result";
                            this.dataGridView1.AutoResizeColumns();
                            chart1.Series.Clear();
                            chart1.Titles.Clear();
                            chart1.Titles.Add("Toneladas pesadas Semana / Año / Mes - Tipo");
                            string SerieActual = DS.Tables[0].Rows[0]["Semana"].ToString();
                            string SerieAnterior = DS.Tables[0].Rows[0]["Semana"].ToString();
                            Peso = 0;
                            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                            {
                                SerieActual = DS.Tables[0].Rows[i]["Semana"].ToString();
                                Peso += Convert.ToDouble(DS.Tables[0].Rows[i]["Peso"].ToString());
                                if (SerieActual.Trim() != SerieAnterior.Trim())
                                {

                                    Series SerieChart = chart1.Series.Add(DS.Tables[0].Rows[i]["Semana"].ToString());
                                    SerieChart.Label = Peso.ToString("###,###,##0");
                                    SerieChart.Points.Add(Peso);
                                    SerieChart.ToolTip = DS.Tables[0].Rows[i]["Semana"].ToString().Trim() + " / " + Peso.ToString("###,###,##0.#0");
                                    SerieChart.BorderWidth = 2;
                                    Peso = 0;
                                }
                                SerieAnterior = DS.Tables[0].Rows[i]["Semana"].ToString();

                            }
                            chart1.DataBind();

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message); ;
                        }
                        break;
                        #endregion
                    #endregion
                }
            }
        }

        private void CmbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
