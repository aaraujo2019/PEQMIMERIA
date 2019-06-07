using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.LiquidacionDBMETAL
{
    public partial class Frm_Reporte_Liquidacion : Form
    {
        #region Variables
        int TipoReporte { get; set; }
        private ReporteLiquidacionTableAdapters.Reporte_Mineras_DetalleTableAdapter Reporte_Mineras_DetalleTableAdapter;
        private ReporteLiquidacionTableAdapters.Reporte_Mineras_Detalle1TableAdapter Reporte_Mineras_Detalle1TableAdapter;

        private ReporteLiquidacionTableAdapters.Reporte_Mineras_Resumen_DiaTableAdapter Reporte_Mineras_Resumen_DiaTableAdapter;
        private ReporteLiquidacionTableAdapters.Reporte_Muestreo_DetalleTableAdapter Reporte_Muestreo_DetalleTableAdapter;
        private ReporteLiquidacionTableAdapters.Reporte_MuestreoFaltante_DetalleTableAdapter Reporte_MuestreoFaltante_DetalleTableAdapter;
        private ReporteLiquidacionTableAdapters.Reporte_Liquidacion_PeriodoTableAdapter Reporte_Liquidacion_PeriodoTableAdapter;
        private ReporteLiquidacionTableAdapters.Reporte_Onzas_RecuperadasTableAdapter Reporte_Onzas_RecuperadasTableAdapter;
        private ReporteLiquidacionTableAdapters.Vm_GetUsetForRolesTableAdapter Vm_GetUsetForRoles;


        private ReporteLiquidacionTableAdapters.Reporte_MuestreoFaltante_Detalle1TableAdapter Reporte_MuestreoFaltante_Detalle1TableAdapter;

        public object[] argumentGeneric;
        #endregion Variables

        #region Constructor
        public Frm_Reporte_Liquidacion(int tipoReporte)
        {
            InitializeComponent();
            this.TipoReporte = tipoReporte;
        }

        public Frm_Reporte_Liquidacion()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Eventos
        private void Reprote2_Load(object sender, EventArgs e)
        {
            switch (this.TipoReporte)
            {
                case 1:
                    this.Reporte_Mineras_DetalleTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_DetalleTableAdapter();
                    this.Reporte_Mineras_DetalleTableAdapter.ClearBeforeFill = true;

                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Mineras_Detalle";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Detalle_Rango.rdlc";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Detalle_Rango_For_Name.rdlc";

                    this.Reporte_Mineras_DetalleTableAdapter.FillData(this.ReporteLiquidacion.Reporte_Mineras_Detalle, "17/05/2018 00:00", "20/05/2018 00:00");
                    this.reportViewer1.RefreshReport();
                    break;
                case 2:

                    this.Reporte_Mineras_Resumen_DiaTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_Resumen_DiaTableAdapter();
                    this.Reporte_Mineras_Resumen_DiaTableAdapter.ClearBeforeFill = true; ;


                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Mineras_Resumen_Dia";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.rpt_Detalle_Dia.rdlc";

                    this.Reporte_Mineras_Resumen_DiaTableAdapter.FillDataDay(this.ReporteLiquidacion.Reporte_Mineras_Resumen_Dia, "16/05/2018", "16/05/2018");
                    this.reportViewer1.RefreshReport();

                    break;
                case 3:

                    this.Reporte_Muestreo_DetalleTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Muestreo_DetalleTableAdapter();
                    this.Reporte_Muestreo_DetalleTableAdapter.ClearBeforeFill = true; ;


                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Muestreo_DetalleDataTable";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Muestra_Detalle.rdlc";

                    this.Reporte_Muestreo_DetalleTableAdapter.FillReportDetail(this.ReporteLiquidacion.Reporte_Muestreo_Detalle, "16/05/2018", "");
                    this.reportViewer1.RefreshReport();

                    break;
                case 5:

                    this.Reporte_Liquidacion_PeriodoTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Liquidacion_PeriodoTableAdapter();
                    this.Reporte_Liquidacion_PeriodoTableAdapter.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Rpt_Liquidacion_Periodo";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Liquidacion_Periodo.rdlc";
                    this.Reporte_Liquidacion_PeriodoTableAdapter.FillPeriodo(this.ReporteLiquidacion.Reporte_Liquidacion_Periodo, "");
                    this.reportViewer1.RefreshReport();


                    break;

                default:
                    break;
            }
        }
        #endregion Constructor

        #region Metodos
        public void EjecucionReportes(object[] argument)
        {
            argumentGeneric = argument;
            switch (Convert.ToInt32(argument[0]))
            {
                case 1:
                    DateTime fechaInicial = Convert.ToDateTime(argument[1]);
                    DateTime fechaFinal = Convert.ToDateTime(argument[2]);
                    bool OrdenNom = Convert.ToBoolean(argument[3]);

                    this.Reporte_Mineras_Detalle1TableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_Detalle1TableAdapter();
                    this.Reporte_Mineras_Detalle1TableAdapter.ClearBeforeFill = true;

                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Mineras_Detalle1";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";


                    if (OrdenNom)
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Detalle_Rango_For_Name1.rdlc";
                    else
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Detalle_Rango1.rdlc";

                    if (String.IsNullOrEmpty(argument[4].ToString()))
                        this.Reporte_Mineras_Detalle1TableAdapter.FillData(this.ReporteLiquidacion.Reporte_Mineras_Detalle1, argument[1].ToString(), argument[2].ToString());
                    else
                        this.Reporte_Mineras_Detalle1TableAdapter.FillDataParam(this.ReporteLiquidacion.Reporte_Mineras_Detalle1, argument[1].ToString(), argument[2].ToString(), argument[4].ToString());



                    this.reportViewer1.RefreshReport();
                    break;
                case 2:

                    fechaInicial = Convert.ToDateTime(argument[1]);
                    fechaFinal = Convert.ToDateTime(argument[2]);

                    OrdenNom = Convert.ToBoolean(argument[3]);

                    this.Reporte_Mineras_Resumen_DiaTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_Resumen_DiaTableAdapter();
                    this.Reporte_Mineras_Resumen_DiaTableAdapter.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Mineras_Resumen_Dia";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";

                    if (!OrdenNom)
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.rpt_Detalle_Dia_Detallado.rdlc";
                    
                        //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.rpt_Detalle_Dia.rdlc";
                    else
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.rpt_Detalle_Dia_For_Name.rdlc";


                    //var value = this.ReporteLiquidacion.Reporte_Mineras_Resumen_Dia.OrderBy(pet => pet.FechaProceso);

                    if (String.IsNullOrEmpty(argument[4].ToString()))

                        this.Reporte_Mineras_Resumen_DiaTableAdapter.FillDataDay(this.ReporteLiquidacion.Reporte_Mineras_Resumen_Dia, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));
                    else
                        this.Reporte_Mineras_Resumen_DiaTableAdapter.FillDataParam(this.ReporteLiquidacion.Reporte_Mineras_Resumen_Dia, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"), argument[4].ToString());

                    var value1 = this.ReporteLiquidacion.Reporte_Mineras_Resumen_Dia.OrderBy(Reporte_Mineras_Resumen_Dia => Reporte_Mineras_Resumen_Dia.FechaProceso).AsEnumerable();
                    this.reportViewer1.RefreshReport();

                    break;
                case 3:
                    fechaInicial = Convert.ToDateTime(argument[1]);
                    if (argument.Count() > 3)
                    {
                        fechaFinal = Convert.ToDateTime(argument[2]);
                        OrdenNom = Convert.ToBoolean(argument[3]);
                    }
                    else
                    {
                        fechaFinal = Convert.ToDateTime(argument[1]);
                        OrdenNom = Convert.ToBoolean(argument[2]);

                    }


                    this.Reporte_Muestreo_DetalleTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Muestreo_DetalleTableAdapter();
                    this.Reporte_Muestreo_DetalleTableAdapter.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Muestreo_Detalle";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";

                    if (!OrdenNom)
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Muestra_Detalle.rdlc";
                    else
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Muestra_Detalle_For_Name.rdlc";

                    if (argument.Length > 3)
                    {
                        if (String.IsNullOrEmpty(argument[4].ToString().Trim()))

                            this.Reporte_Muestreo_DetalleTableAdapter.FillReportDetail(this.ReporteLiquidacion.Reporte_Muestreo_Detalle, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));
                        else
                            this.Reporte_Muestreo_DetalleTableAdapter.FillDataParamet(this.ReporteLiquidacion.Reporte_Muestreo_Detalle, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"), argument[4].ToString());
                    }
                    else
                        this.Reporte_Muestreo_DetalleTableAdapter.FillReportDetail(this.ReporteLiquidacion.Reporte_Muestreo_Detalle, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));

                    this.reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

                    this.reportViewer1.RefreshReport();

                    break;

                case 4:
                    fechaInicial = Convert.ToDateTime(argument[1]);


                    this.Reporte_MuestreoFaltante_DetalleTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_MuestreoFaltante_DetalleTableAdapter();
                    this.Reporte_MuestreoFaltante_DetalleTableAdapter.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_MuestreoFaltante_Detalle";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.rpt_Faltante_Muestro_Faltante.rdlc";
                    this.Reporte_MuestreoFaltante_DetalleTableAdapter.FillDataFaltantes(this.ReporteLiquidacion.Reporte_MuestreoFaltante_Detalle, fechaInicial.ToString("dd/MM/yyyy"));
                    this.reportViewer1.RefreshReport();

                    break;

                case 5:
                    this.Reporte_Liquidacion_PeriodoTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Liquidacion_PeriodoTableAdapter();
                    this.Reporte_Liquidacion_PeriodoTableAdapter.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Liquidacion_Periodo";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Liquidacion_Periodo.rdlc";
                    this.Reporte_Liquidacion_PeriodoTableAdapter.FillPeriodo(this.ReporteLiquidacion.Reporte_Liquidacion_Periodo, argument[1].ToString().Trim());
                    this.reportViewer1.RefreshReport();
                    break;
                case 6:
                    string ano = argument[1].ToString().Trim();
                    string mes = argument[2].ToString().Trim();
                    string periodo = argument[3].ToString().Trim();
                    this.Reporte_Onzas_RecuperadasTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Onzas_RecuperadasTableAdapter();
                    this.Reporte_Onzas_RecuperadasTableAdapter.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Reporte_Onzas_Recuperadas";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Onzas_Recuperados.rdlc";

                    try
                    {
                        this.Reporte_Onzas_RecuperadasTableAdapter.FillOnzasRecup(this.ReporteLiquidacion.Reporte_Onzas_Recuperadas, ano, mes, periodo);

                    }
                    catch
                    {

                    }
                    this.reportViewer1.RefreshReport();
                    break;
                case 7:

                    string nameUser = argument[1].ToString().Trim();
                    this.Vm_GetUsetForRoles = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Vm_GetUsetForRolesTableAdapter();
                    this.Vm_GetUsetForRoles.ClearBeforeFill = true;
                    this.Reporte_Mineras_DetalleBindingSource.DataMember = "Vm_GetUsetForRoles";
                    this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
                    this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Rpt_Permisos_Por_Usuarios.rdlc";
                    if (nameUser == "TODOS")
                        this.Vm_GetUsetForRoles.FillByAll(this.ReporteLiquidacion.Vm_GetUsetForRoles);
                    else
                        this.Vm_GetUsetForRoles.FillGetUser(this.ReporteLiquidacion.Vm_GetUsetForRoles, nameUser);
                    this.reportViewer1.RefreshReport();

                    break;
                default:
                    break;
            }
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            DateTime fechaInicial = Convert.ToDateTime(argumentGeneric[1]);

            if (argumentGeneric.Length > 3)
            {
                DateTime fechaFinal = Convert.ToDateTime(argumentGeneric[2]);

                //this.Reporte_MuestreoFaltante_DetalleTableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_MuestreoFaltante_DetalleTableAdapter();
                //this.Reporte_MuestreoFaltante_DetalleTableAdapter.FillDataFaltantes(this.ReporteLiquidacion.Reporte_MuestreoFaltante_Detalle, fechaInicial.ToString("dd/MM/yyyy"));

                this.Reporte_MuestreoFaltante_Detalle1TableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_MuestreoFaltante_Detalle1TableAdapter();

                if (String.IsNullOrEmpty(argumentGeneric[4].ToString().Trim()))
                    this.Reporte_MuestreoFaltante_Detalle1TableAdapter.FillByFaltant12(this.ReporteLiquidacion.Reporte_MuestreoFaltante_Detalle1, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));
                else
                    this.Reporte_MuestreoFaltante_Detalle1TableAdapter.FillDataParam(this.ReporteLiquidacion.Reporte_MuestreoFaltante_Detalle1, fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"), argumentGeneric[4].ToString().Trim());
            }
            else
            {
                this.Reporte_MuestreoFaltante_Detalle1TableAdapter = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_MuestreoFaltante_Detalle1TableAdapter();

                this.Reporte_MuestreoFaltante_Detalle1TableAdapter.FillByFaltant1(this.ReporteLiquidacion.Reporte_MuestreoFaltante_Detalle1, fechaInicial.ToString("dd/MM/yyyy"));
            }



            e.DataSources.Add(new ReportDataSource("DataSet1", ReporteLiquidacion.Reporte_MuestreoFaltante_Detalle1 as DataTable));
        }
        #endregion Constructor
    }
}
