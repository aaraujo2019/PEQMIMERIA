using Entidades;
using ReglasdeNegocio.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    public class ConsultaEntidades
    {
        private Ent_MinaSello ConsultaSello = new Ent_MinaSello();
        private Ent_DatosExcelSGS DatosExcelSGS = new Ent_DatosExcelSGS();
        private Ent_AdjuntosSGS Adjuntos = new Ent_AdjuntosSGS();
        private Ent_Vehiculo Vehiculos = new Ent_Vehiculo();
        private Ent_Propietarios Propietario = new Ent_Propietarios();
        private Ent_VehiculoTecnoMecanica VehiculoTecno = new Ent_VehiculoTecnoMecanica();
        private Ent_VehiculosSeguros VehiculoSegu = new Ent_VehiculosSeguros();
        private Ent_DatosAdjuntos DatAdjunto = new Ent_DatosAdjuntos();
        private Ent_Minas Mina = new Ent_Minas();
        private Ent_TiposMineral TipoMineral = new Ent_TiposMineral();
        private Ent_Destino Destinos = new Ent_Destino();
        private Ent_Origen Origenes = new Ent_Origen();
        private Ent_RelacionTipoOrigenDestino RelacionTipo = new Ent_RelacionTipoOrigenDestino();
        private Ent_Motos Motos = new Ent_Motos();
        private Ent_Contratistas Contratista = new Ent_Contratistas();
        private Ent_Conductores Conductor = new Ent_Conductores();
        private Ent_SubTipos Subtipo = new Ent_SubTipos();
        private Ent_VwMinas VwMinas = new Ent_VwMinas();
        private Ent_Contenedores Contenedores = new Ent_Contenedores();
        private Ent_TiposDeEmpresa TiposDeEmpresa = new Ent_TiposDeEmpresa();
        private Ent_TblMinas TblMinas = new Ent_TblMinas();
        private Ent_Plazas Plaza = new Ent_Plazas();
        private Ent_Esquemas Esquema = new Ent_Esquemas();
        private Ent_VwContratistas VwContratista = new Ent_VwContratistas();
        private Ent_TblMinasContratos MinaContrato = new Ent_TblMinasContratos();
        private Ent_Periodos Periodo = new Ent_Periodos();
        private Ent_ImagenPublicidad Logo = new Ent_ImagenPublicidad();
        private Ent_PersonalMuestreo PersonalDeMuestreo = new Ent_PersonalMuestreo();
        public Ent_Propietarios Propietarios(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                string identificacion = sqlDataReader["Identificacion"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                string apellido = sqlDataReader["Apellido"].ToString().Trim();
                string telFijo = sqlDataReader["TelFijo"].ToString().Trim();
                string extension = sqlDataReader["Extension"].ToString().Trim();
                string celular = sqlDataReader["Celular"].ToString().Trim();
                string email = sqlDataReader["Email"].ToString().Trim();
                bool deshabilitado = Convert.ToBoolean(sqlDataReader["Deshabilitado"].ToString().Trim());
                DateTime fechaCreacion = Convert.ToDateTime(sqlDataReader["FechaCreacion"].ToString().Trim());
                this.Propietario.Id = id;
                this.Propietario.Identificacion = identificacion;
                this.Propietario.Nombre = nombre;
                this.Propietario.Apellido = apellido;
                this.Propietario.TelFijo = telFijo;
                this.Propietario.Extension = extension;
                this.Propietario.Celular = celular;
                this.Propietario.Email = email;
                this.Propietario.Deshabilitado = deshabilitado;
                this.Propietario.FechaCreacion = fechaCreacion;
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Propietario;
        }
        public static List<Roles_Permisos> GetPermisosRoles(string SP_Consulta, string nameUser, string PageMaster)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Name", nameUser),
                new SqlParameter("@FKPage", PageMaster)
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Roles_Permisos> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Roles_Permisos> list = new List<Roles_Permisos>();
                IList<Roles_Permisos> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Roles_Permisos>();
            }
            return result;
        }
        public Ent_Contratistas Contratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                int tipoIdentificacion = Convert.ToInt32(sqlDataReader["TipoIdentificacion"].ToString().Trim());
                string identificacion = sqlDataReader["Identificacion"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                string razonCial = sqlDataReader["RazonCial"].ToString().Trim();
                string apellido = sqlDataReader["Apellido"].ToString().Trim();
                string telFijo = sqlDataReader["TelFijo"].ToString().Trim();
                string extension = sqlDataReader["Extension"].ToString().Trim();
                string celular = sqlDataReader["Celular"].ToString().Trim();
                string email = sqlDataReader["Email"].ToString().Trim();
                bool deshabilitado = Convert.ToBoolean(sqlDataReader["Deshabilitado"].ToString().Trim());
                DateTime fechaCreacion = Convert.ToDateTime(sqlDataReader["FechaCreacion"].ToString().Trim());
                this.Contratista.Id = id;
                this.Contratista.TipoIdentificacion = tipoIdentificacion;
                this.Contratista.Identificacion = identificacion;
                this.Contratista.RazonCial = razonCial;
                this.Contratista.Nombre = nombre;
                this.Contratista.Apellido = apellido;
                this.Contratista.TelFijo = telFijo;
                this.Contratista.Extension = extension;
                this.Contratista.Celular = celular;
                this.Contratista.Email = email;
                this.Contratista.Deshabilitado = deshabilitado;
                this.Contratista.FechaCreacion = fechaCreacion;
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Contratista;
        }
        public Ent_MinaSello MinaSello(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int consecutivo = Convert.ToInt32(sqlDataReader["Consecutivo"]);
                    DateTime fecha = Convert.ToDateTime(sqlDataReader["Fecha"]);
                    string mina = sqlDataReader["Mina"].ToString().Trim();
                    this.ConsultaSello.Consecutivo = consecutivo;
                    this.ConsultaSello.Fecha = fecha;
                    this.ConsultaSello.Mina = mina;
                }
                else
                {
                    this.ConsultaSello.Consecutivo = 0;
                    this.ConsultaSello.Fecha = DateTime.Now.Date;
                    this.ConsultaSello.Mina = "SELLO NO REPORTADO";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.ConsultaSello;
        }
        public Ent_DatosExcelSGS TablaExcel(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    bool incluir = Convert.ToBoolean(sqlDataReader["Incluir"]);
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    string selloH = sqlDataReader["SelloH"].ToString().Trim();
                    string selloP = sqlDataReader["SelloP"].ToString().Trim();
                    double humedad = Convert.ToDouble(sqlDataReader["Humedad"]);
                    double tenor = Convert.ToDouble(sqlDataReader["Tenor"]);
                    int peso = Convert.ToInt32(sqlDataReader["Peso"]);
                    string cliente = sqlDataReader["Cliente"].ToString().Trim();
                    string orden = sqlDataReader["Orden"].ToString().Trim();
                    string muestra = sqlDataReader["Muestra"].ToString().Trim();
                    string referencia = sqlDataReader["Referencia"].ToString().Trim();
                    string lugar = sqlDataReader["Lugar"].ToString().Trim();
                    string recepcion = sqlDataReader["Recepcion"].ToString().Trim();
                    string reporte = sqlDataReader["Reporte"].ToString().Trim();
                    this.DatosExcelSGS.Incluir = incluir;
                    this.DatosExcelSGS.Id = id;
                    this.DatosExcelSGS.SelloH = selloH;
                    this.DatosExcelSGS.SelloP = selloP;
                    this.DatosExcelSGS.Humedad = humedad;
                    this.DatosExcelSGS.Tenor = tenor;
                    this.DatosExcelSGS.Peso = peso;
                    this.DatosExcelSGS.Cliente = cliente;
                    this.DatosExcelSGS.Orden = orden;
                    this.DatosExcelSGS.Muestra = muestra;
                    this.DatosExcelSGS.Referencia = referencia;
                    this.DatosExcelSGS.Lugar = lugar;
                    this.DatosExcelSGS.Recepcion = recepcion;
                    this.DatosExcelSGS.Reporte = reporte;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.DatosExcelSGS;
        }
        public Ent_Vehiculo Vehiculo(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    bool estado = Convert.ToBoolean(sqlDataReader["Estado"]);
                    string placa = sqlDataReader["Placa"].ToString().Trim();
                    string descripcion = sqlDataReader["Descripcion"].ToString().Trim();
                    string proyecto = sqlDataReader["Proyecto"].ToString().Trim();
                    string nombreProyecto = sqlDataReader["NombreProyecto"].ToString().Trim();
                    string licencia = sqlDataReader["Licencia"].ToString().Trim();
                    double peso = Convert.ToDouble(sqlDataReader["Peso"]);
                    int idPropietario = Convert.ToInt32(sqlDataReader["IdPropietario"]);
                    string identiPropietrio = sqlDataReader["Identificacion"].ToString().Trim();
                    string nombrePropietario = sqlDataReader["NombrePropietario"].ToString().Trim();
                    string modelo = sqlDataReader["Modelo"].ToString().Trim();
                    string marca = sqlDataReader["Marca"].ToString().Trim();
                    string linea = sqlDataReader["Linea"].ToString().Trim();
                    string servicio = sqlDataReader["Servicio"].ToString().Trim();
                    double cilindraje = Convert.ToDouble(sqlDataReader["Cilindraje"]);
                    string color = sqlDataReader["Color"].ToString().Trim();
                    string combustible = sqlDataReader["Combustible"].ToString().Trim();
                    string clase = sqlDataReader["Clase"].ToString().Trim();
                    string carroceria = sqlDataReader["Carroceria"].ToString().Trim();
                    int capacidad = Convert.ToInt32(sqlDataReader["Capacidad"]);
                    string motor = sqlDataReader["Motor"].ToString().Trim();
                    string reg = sqlDataReader["Reg1"].ToString().Trim();
                    string vin = sqlDataReader["Vin"].ToString().Trim();
                    string serie = sqlDataReader["Serie"].ToString().Trim();
                    string reg2 = sqlDataReader["Reg2"].ToString().Trim();
                    string chasis = sqlDataReader["Chasis"].ToString().Trim();
                    string reg3 = sqlDataReader["Reg3"].ToString().Trim();
                    int tipoVehiculo = Convert.ToInt32(sqlDataReader["TipoVehiculo"]);
                    string restriccionMovilidad = sqlDataReader["RestriccionMovilidad"].ToString().Trim();
                    string blindaje = sqlDataReader["Blindaje"].ToString().Trim();
                    string potencia = sqlDataReader["Potencia"].ToString().Trim();
                    string declaracionImportacion = sqlDataReader["DeclaracionImportacion"].ToString().Trim();
                    string iE = sqlDataReader["IE"].ToString().Trim();
                    DateTime fechaImportacion = Convert.ToDateTime(sqlDataReader["FechaImportacion"]);
                    int puertas = Convert.ToInt32(sqlDataReader["Puertas"]);
                    string limitacionPropiedad = sqlDataReader["LimitacionPropiedad"].ToString().Trim();
                    DateTime fechaMatricula = Convert.ToDateTime(sqlDataReader["FechaMatricula"]);
                    DateTime fechaExpLicTTO = Convert.ToDateTime(sqlDataReader["FechaExpLicTTO"]);
                    DateTime fechaVencimiento = Convert.ToDateTime(sqlDataReader["FechaVencimiento"]);
                    string organismoTransito = sqlDataReader["OrganismoTransito"].ToString().Trim();
                    string stiker = sqlDataReader["Stiker"].ToString().Trim();
                    int cubicacion = Convert.ToInt32(sqlDataReader["Cubicacion"]);
                    byte[] foto = (byte[])sqlDataReader["Foto"];
                    this.Vehiculos.Id = id;
                    this.Vehiculos.Estado = estado;
                    this.Vehiculos.Placa = placa;
                    this.Vehiculos.Descripcion = descripcion;
                    this.Vehiculos.Proyecto = proyecto;
                    this.Vehiculos.NombreProyecto = nombreProyecto;
                    this.Vehiculos.Licencia = licencia;
                    this.Vehiculos.Peso = peso;
                    this.Vehiculos.IdPropietario = idPropietario;
                    this.Vehiculos.IdentiPropietrio = identiPropietrio;
                    this.Vehiculos.NombrePropietario = nombrePropietario;
                    this.Vehiculos.Modelo = modelo;
                    this.Vehiculos.Marca = marca;
                    this.Vehiculos.Linea = linea;
                    this.Vehiculos.Servicio = servicio;
                    this.Vehiculos.Cilindraje = cilindraje;
                    this.Vehiculos.Color = color;
                    this.Vehiculos.Combustible = combustible;
                    this.Vehiculos.Clase = clase;
                    this.Vehiculos.Carroceria = carroceria;
                    this.Vehiculos.Capacidad = capacidad;
                    this.Vehiculos.Motor = motor;
                    this.Vehiculos.Reg1 = reg;
                    this.Vehiculos.Vin = vin;
                    this.Vehiculos.Serie = serie;
                    this.Vehiculos.Reg2 = reg2;
                    this.Vehiculos.Chasis = chasis;
                    this.Vehiculos.Reg3 = reg3;
                    this.Vehiculos.TipoVehiculo = tipoVehiculo;
                    this.Vehiculos.RestriccionMovilidad = restriccionMovilidad;
                    this.Vehiculos.Blindaje = blindaje;
                    this.Vehiculos.Potencia = potencia;
                    this.Vehiculos.DeclaracionImportacion = declaracionImportacion;
                    this.Vehiculos.IE = iE;
                    this.Vehiculos.FechaImportacion = fechaImportacion;
                    this.Vehiculos.Puertas = puertas;
                    this.Vehiculos.LimitacionPropiedad = limitacionPropiedad;
                    this.Vehiculos.FechaMatricula = fechaMatricula;
                    this.Vehiculos.FechaExpLicTTO = fechaExpLicTTO;
                    this.Vehiculos.FechaVencimiento = fechaVencimiento;
                    this.Vehiculos.OrganismoTransito = organismoTransito;
                    this.Vehiculos.Stiker = stiker;
                    this.Vehiculos.Cubicacion = cubicacion;
                    this.Vehiculos.Foto = foto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Vehiculos;
        }
        public Ent_Conductores Conductores(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    bool estado = Convert.ToBoolean(sqlDataReader["Estado"]);
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    string apellido = sqlDataReader["Apellido"].ToString().Trim();
                    string direccion = sqlDataReader["Direccion"].ToString().Trim();
                    string telFijo = sqlDataReader["TelFijo"].ToString().Trim();
                    string email = sqlDataReader["Email"].ToString().Trim();
                    string telefono = sqlDataReader["Telefono"].ToString().Trim();
                    DateTime nacimiento = Convert.ToDateTime(sqlDataReader["Nacimiento"]);
                    int rH = Convert.ToInt32(sqlDataReader["RH"]);
                    int idContratista = Convert.ToInt32(sqlDataReader["IdContratista"]);
                    string identificacionContratista = sqlDataReader["IdentificacionContratista"].ToString().Trim();
                    string nombreContratista = sqlDataReader["NombreContratista"].ToString().Trim();
                    string apellidoContratista = sqlDataReader["ApellidoContratista"].ToString().Trim();
                    int idVehiculo = Convert.ToInt32(sqlDataReader["IdVehiculo"]);
                    string placa = sqlDataReader["Placa"].ToString().Trim();
                    byte[] foto = (byte[])sqlDataReader["Foto"];
                    this.Conductor.Id = id;
                    this.Conductor.Estado = estado;
                    this.Conductor.Codigo = codigo;
                    this.Conductor.Nombre = nombre;
                    this.Conductor.Apellido = apellido;
                    this.Conductor.Direccion = direccion;
                    this.Conductor.TelFijo = telFijo;
                    this.Conductor.Telefono = telefono;
                    this.Conductor.Email = email;
                    this.Conductor.Nacimiento = nacimiento;
                    this.Conductor.RH = rH;
                    this.Conductor.IdContratista = idContratista;
                    this.Conductor.IdentificacionContratista = identificacionContratista;
                    this.Conductor.NombreContratista = nombreContratista;
                    this.Conductor.ApellidoContratista = apellidoContratista;
                    this.Conductor.IdVehiculo = idVehiculo;
                    this.Conductor.Placa = placa;
                    this.Conductor.Foto = foto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Conductor;
        }
        public static List<Ent_OrdenesMuestra> ObtenerHistorialSec(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ""),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_OrdenesMuestra> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_OrdenesMuestra> list = new List<Ent_OrdenesMuestra>();
                IList<Ent_OrdenesMuestra> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_OrdenesMuestra>();
            }
            return result;
        }
        public static List<Ent_Detalle_Periodo> DetallePeriodos(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_Detalle_Periodo> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Detalle_Periodo> list = new List<Ent_Detalle_Periodo>();
                IList<Ent_Detalle_Periodo> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_Detalle_Periodo>();
            }
            return result;
        }
        public static List<Ent_LiquidacionPeriodos> ObtenerPeriodos(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_LiquidacionPeriodos> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_LiquidacionPeriodos> list = new List<Ent_LiquidacionPeriodos>();
                IList<Ent_LiquidacionPeriodos> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_LiquidacionPeriodos>();
            }
            return result;
        }
        public static List<Ent_LiquidacionPeriodosString> ObtenerPeriodosAdviableString(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_LiquidacionPeriodosString> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_LiquidacionPeriodosString> list = new List<Ent_LiquidacionPeriodosString>();
                IList<Ent_LiquidacionPeriodosString> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_LiquidacionPeriodosString>();
            }
            return result;
        }
        public static List<Ent_Localizacion> ObtenerLocalizacion(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", "recuLocalizacion"),
                new SqlParameter("@ParametroChar", ""),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_Localizacion> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Localizacion> list = new List<Ent_Localizacion>();
                IList<Ent_Localizacion> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_Localizacion>();
            }
            return result;
        }
        public static List<Ent_Usuario> ObtenerUsuario(string SP_Consulta, string Op, string NombreUsuario)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Oper", Op),
                new SqlParameter("@NombreUsuario", NombreUsuario)
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_Usuario> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Usuario> list = new List<Ent_Usuario>();
                IList<Ent_Usuario> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_Usuario>();
            }
            return result;
        }
        public static List<Ent_Usuario> ObtenerUsuarioPorRoles(string SP_Consulta, string NombreUsuario)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", NombreUsuario)
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_Usuario> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Usuario> list = new List<Ent_Usuario>();
                IList<Ent_Usuario> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_Usuario>();
            }
            return result;
        }
        public static List<Ent_Muestreo> ObtenerMuestreo(string SP_Consulta, string Op, int ParametroChar, string ParametroInt)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_Muestreo> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Muestreo> list = new List<Ent_Muestreo>();
                IList<Ent_Muestreo> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_Muestreo>();
            }
            return result;
        }
        public static List<Ent_CalidadMuestro> ObtenerMuestroDia(string SP_Consulta, string Op, object ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_CalidadMuestro> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_CalidadMuestro> list = new List<Ent_CalidadMuestro>();
                IList<Ent_CalidadMuestro> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_CalidadMuestro>();
            }
            return result;
        }
        public static Ent_Fecha ObtenerFechas(string SP_Consulta, string Op, object ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            Ent_Fecha result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Fecha> list = new List<Ent_Fecha>();
                IList<Ent_Fecha> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2[0];
            }
            return result;
        }
        public static List<Ent_PesajeMineral> ObtenerPesoMinas(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_PesajeMineral> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_PesajeMineral> list = new List<Ent_PesajeMineral>();
                IList<Ent_PesajeMineral> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_PesajeMineral>();
            }
            return result;
        }
        public Ent_Contratistas NombreContratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    string identificacion = sqlDataReader["Identificacion"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    string apellido = sqlDataReader["Apellido"].ToString().Trim();
                    this.Contratista.Identificacion = identificacion;
                    this.Contratista.Nombre = nombre;
                    this.Contratista.Apellido = apellido;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Contratista;
        }
        public Ent_AdjuntosSGS AdjuntosSGS(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            new ASCIIEncoding();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString());
                string orden = sqlDataReader["Orden"].ToString();
                sqlDataReader["Ruta"].ToString();
                string nombre = sqlDataReader["Nombre"].ToString();
                byte[] archivo = (byte[])sqlDataReader["Archivo"];
                string extension = sqlDataReader["Extension"].ToString();
                string text = sqlDataReader["Maquina"].ToString();
                this.Adjuntos.Id = id;
                this.Adjuntos.Orden = orden;
                this.Adjuntos.Nombre = nombre;
                this.Adjuntos.Archivo = archivo;
                this.Adjuntos.Extension = extension;
                this.Adjuntos.Maquina = text.Trim();
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Adjuntos;
        }
        public Ent_VehiculoTecnoMecanica VehiculoTecnos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    int idPlaca = Convert.ToInt32(sqlDataReader["IdPlaca"]);
                    string nroControl = sqlDataReader["NroControl"].ToString();
                    DateTime fechaExpedicion = Convert.ToDateTime(sqlDataReader["FechaExpedicion"]);
                    DateTime fechaVencimiento = Convert.ToDateTime(sqlDataReader["FechaVencimiento"]);
                    int idPropietario = Convert.ToInt32(sqlDataReader["IdPropietario"]);
                    string nombrePropietario = sqlDataReader["NombrePropietario"].ToString().Trim();
                    string nitAutomotor = sqlDataReader["NitAutomotor"].ToString().Trim();
                    string nombreAutomotor = sqlDataReader["NombreAutomotor"].ToString().Trim();
                    string consecutivoRunt = sqlDataReader["ConsecutivoRunt"].ToString().Trim();
                    string certificadoAcreditacion = sqlDataReader["CertificadoAcreditacion"].ToString().Trim();
                    this.VehiculoTecno.NroControl = nroControl;
                    this.VehiculoTecno.IdPlaca = idPlaca;
                    this.VehiculoTecno.FechaExpedicion = fechaExpedicion;
                    this.VehiculoTecno.FechaVencimiento = fechaVencimiento;
                    this.VehiculoTecno.IdPropietario = idPropietario;
                    this.VehiculoTecno.NombrePropietario = nombrePropietario;
                    this.VehiculoTecno.NitAutomotor = nitAutomotor;
                    this.VehiculoTecno.NombreAutomotor = nombreAutomotor;
                    this.VehiculoTecno.ConsecutivoRunt = consecutivoRunt;
                    this.VehiculoTecno.CertificadoAcreditacion = certificadoAcreditacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.VehiculoTecno;
        }
        public Ent_VehiculosSeguros VehiculoSeguros(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    int idPlaca = Convert.ToInt32(sqlDataReader["IdPlaca"]);
                    string proveedor = sqlDataReader["Proveedor"].ToString().Trim();
                    string idTomador = sqlDataReader["IdTomador"].ToString().Trim();
                    string nombretomador = sqlDataReader["Nombretomador"].ToString().Trim();
                    DateTime fechaExpedicion = Convert.ToDateTime(sqlDataReader["FechaExpedicion"]);
                    DateTime fechaInicial = Convert.ToDateTime(sqlDataReader["FechaInicial"]);
                    DateTime fechaFinal = Convert.ToDateTime(sqlDataReader["Fechafinal"]);
                    string telefono = sqlDataReader["Telefono"].ToString().Trim();
                    string codigoSucursal = sqlDataReader["CodigoSucursal"].ToString().Trim();
                    string claveProductor = sqlDataReader["ClaveProductor"].ToString().Trim();
                    string ciudadExpedicion = sqlDataReader["CiudadExpe"].ToString().Trim();
                    string direccion = sqlDataReader["Direccion"].ToString().Trim();
                    string ciudadResidencia = sqlDataReader["CiudadResidencia"].ToString().Trim();
                    string poliza = sqlDataReader["Poliza"].ToString().Trim();
                    string reemplaza = sqlDataReader["Reemplaza"].ToString().Trim();
                    string claseVehiculo = sqlDataReader["ClaseVehiculo"].ToString().Trim();
                    string pasajeros = sqlDataReader["Pasajeros"].ToString().Trim();
                    string tarifa = sqlDataReader["Tarifa"].ToString().Trim();
                    this.VehiculoSegu.IdPlaca = idPlaca;
                    this.VehiculoSegu.Proveedor = proveedor;
                    this.VehiculoSegu.IdTomador = idTomador;
                    this.VehiculoSegu.Nombretomador = nombretomador;
                    this.VehiculoSegu.FechaExpedicion = fechaExpedicion;
                    this.VehiculoSegu.FechaInicial = fechaInicial;
                    this.VehiculoSegu.FechaFinal = fechaFinal;
                    this.VehiculoSegu.CodigoSucursal = codigoSucursal;
                    this.VehiculoSegu.ClaveProductor = claveProductor;
                    this.VehiculoSegu.Telefono = telefono;
                    this.VehiculoSegu.Direccion = direccion;
                    this.VehiculoSegu.CiudadExpedicion = ciudadExpedicion;
                    this.VehiculoSegu.CiudadResidencia = ciudadResidencia;
                    this.VehiculoSegu.Poliza = poliza;
                    this.VehiculoSegu.Reemplaza = reemplaza;
                    this.VehiculoSegu.ClaseVehiculo = claseVehiculo;
                    this.VehiculoSegu.Pasajeros = pasajeros;
                    this.VehiculoSegu.Tarifa = tarifa;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.VehiculoSegu;
        }
        public Ent_DatosAdjuntos Adjunto(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString());
                string nombre = sqlDataReader["Nombre"].ToString();
                byte[] archivo = (byte[])sqlDataReader["Archivo"];
                string extension = sqlDataReader["Extension"].ToString();
                string detalle = sqlDataReader["Detalle"].ToString();
                this.DatAdjunto.Id = id;
                this.DatAdjunto.Nombre = nombre;
                this.DatAdjunto.Archivo = archivo;
                this.DatAdjunto.Extension = extension;
                this.DatAdjunto.Detalle = detalle;
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.DatAdjunto;
        }
        public Ent_Minas Minas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    this.Mina.Codigo = codigo;
                    this.Mina.Nombre = nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Mina;
        }
        public static List<Ent_Minas> MinasReader(string SP_Consulta, string Op, string ParametroChar, long ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", "0")
            };
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            List<Ent_Minas> result;
            using (IDataReader dataReader = sqlCommand.ExecuteReader())
            {
                List<Ent_Minas> list = new List<Ent_Minas>();
                IList<Ent_Minas> list2 = list;
                list2.LoadFromReader(dataReader);
                ConexionDB.CloseConexion(sqlCommand);
                result = list2.ToList<Ent_Minas>();
            }
            return result;
        }
        public Ent_TblMinas TblMina(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string codigoPM = sqlDataReader["CodigoPM"].ToString().Trim();
                    int idMina = Convert.ToInt32(sqlDataReader["IdMina"].ToString().Trim());
                    string nombreVwMina = sqlDataReader["NombreVwMina"].ToString().Trim();
                    string nombreMina = sqlDataReader["NombreMina"].ToString().Trim();
                    int idExpediente = Convert.ToInt32(sqlDataReader["IdExpediente"].ToString().Trim());
                    string expediente = sqlDataReader["Expediente"].ToString().Trim();
                    string codigoContenedor = sqlDataReader["CodigoContenedor"].ToString().Trim();
                    string nombreContenedor = sqlDataReader["NombreContenedor"].ToString().Trim();
                    int idTipoContrato = Convert.ToInt32(sqlDataReader["IdTipoContrato"].ToString().Trim());
                    string nombreTipoContrato = sqlDataReader["NombreTipoContrato"].ToString().Trim();
                    bool tenorPromedio = Convert.ToBoolean(sqlDataReader["TenorPromedio"].ToString().Trim());
                    double area = Convert.ToDouble(sqlDataReader["Area"].ToString().Trim());
                    string este = sqlDataReader["Este"].ToString().Trim();
                    string norte = sqlDataReader["Norte"].ToString().Trim();
                    string elevacion = sqlDataReader["Elevacion"].ToString().Trim();
                    int idTipoEmpresa = Convert.ToInt32(sqlDataReader["IdTipoEmpresa"].ToString().Trim());
                    string nombreTipoEmpresa = sqlDataReader["NombreTipoEmpresa"].ToString().Trim();
                    string detalle = sqlDataReader["Detalle"].ToString().Trim();
                    string codigoPlaza = sqlDataReader["CodigoPlaza"].ToString().Trim();
                    string nombrePlaza = sqlDataReader["NombrePlaza"].ToString().Trim();
                    string email = sqlDataReader["Email"].ToString().Trim();
                    bool mostrarEnInformes = Convert.ToBoolean(sqlDataReader["MostrarEnInformes"].ToString().Trim());
                    bool recuperacionPlanta = Convert.ToBoolean(sqlDataReader["RecuperacionPlanta"].ToString().Trim());
                    bool estado = Convert.ToBoolean(sqlDataReader["Estado"].ToString().Trim());
                    this.TblMinas.Id = id;
                    this.TblMinas.Codigo = codigo;
                    this.TblMinas.CodigoPM = codigoPM;
                    this.TblMinas.IdMina = idMina;
                    this.TblMinas.NombreVwMina = nombreVwMina;
                    this.TblMinas.NombreMina = nombreMina;
                    this.TblMinas.IdExpediente = idExpediente;
                    this.TblMinas.Expediente = expediente;
                    this.TblMinas.CodigoContenedor = codigoContenedor;
                    this.TblMinas.NombreContenedor = nombreContenedor;
                    this.TblMinas.IdTipoContrato = idTipoContrato;
                    this.TblMinas.NombreTipoContrato = nombreTipoContrato;
                    this.TblMinas.TenorPromedio = tenorPromedio;
                    this.TblMinas.Area = area;
                    this.TblMinas.Este = este;
                    this.TblMinas.Norte = norte;
                    this.TblMinas.Elevacion = elevacion;
                    this.TblMinas.IdTipoEmpresa = idTipoEmpresa;
                    this.TblMinas.NombreTipoEmpresa = nombreTipoEmpresa;
                    this.TblMinas.Detalle = detalle;
                    this.TblMinas.CodigoPlaza = codigoPlaza;
                    this.TblMinas.NombrePlaza = nombrePlaza;
                    this.TblMinas.Email = email;
                    this.TblMinas.MostrarEnInformes = mostrarEnInformes;
                    this.TblMinas.RecuperacionPlanta = recuperacionPlanta;
                    this.TblMinas.Estado = estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.TblMinas;
        }
        public Ent_TiposMineral TiposMineral(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    string descripcion = sqlDataReader["Descripcion"].ToString().Trim();
                    this.TipoMineral.Id = id;
                    this.TipoMineral.Codigo = codigo;
                    this.TipoMineral.Nombre = nombre;
                    this.TipoMineral.Descripcion = descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.TipoMineral;
        }
        public Ent_Origen Origen(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    string descripcion = sqlDataReader["Descripcion"].ToString().Trim();
                    this.Origenes.Id = id;
                    this.Origenes.Codigo = codigo;
                    this.Origenes.Nombre = nombre;
                    this.Origenes.Descripcion = descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Origenes;
        }
        public Ent_Destino Destino(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    string descripcion = sqlDataReader["Descripcion"].ToString().Trim();
                    this.Destinos.Id = id;
                    this.Destinos.Codigo = codigo;
                    this.Destinos.Nombre = nombre;
                    this.Destinos.Descripcion = descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Destinos;
        }
        public Ent_SubTipos Subtipos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Codigo"].ToString().Trim());
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                string detalle = sqlDataReader["Detalle"].ToString().Trim();
                this.Subtipo.Id = id;
                this.Subtipo.Codigo = codigo;
                this.Subtipo.Nombre = nombre;
                this.Subtipo.Detalle = detalle;
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Subtipo;
        }
        public Ent_Motos Moto(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    bool estado = Convert.ToBoolean(sqlDataReader["Estado"]);
                    string placa = sqlDataReader["Placa"].ToString().Trim();
                    string descripcion = sqlDataReader["Descripcion"].ToString().Trim();
                    string licencia = sqlDataReader["Licencia"].ToString().Trim();
                    int idPropietario = Convert.ToInt32(sqlDataReader["IdPropietario"]);
                    string identificacionPropietrio = sqlDataReader["IdentificacionPropietario"].ToString().Trim();
                    string nombrePropietario = sqlDataReader["NombrePropietario"].ToString().Trim();
                    string modelo = sqlDataReader["Modelo"].ToString().Trim();
                    string marca = sqlDataReader["Marca"].ToString().Trim();
                    string linea = sqlDataReader["Linea"].ToString().Trim();
                    string servicio = sqlDataReader["Servicio"].ToString().Trim();
                    double cilindraje = Convert.ToDouble(sqlDataReader["Cilindraje"]);
                    string color = sqlDataReader["Color"].ToString().Trim();
                    string combustible = sqlDataReader["Combustible"].ToString().Trim();
                    string clase = sqlDataReader["Clase"].ToString().Trim();
                    string carroceria = sqlDataReader["Carroceria"].ToString().Trim();
                    int capacidad = Convert.ToInt32(sqlDataReader["Capacidad"]);
                    string motor = sqlDataReader["Motor"].ToString().Trim();
                    string reg = sqlDataReader["Reg1"].ToString().Trim();
                    string vin = sqlDataReader["Vin"].ToString().Trim();
                    string serie = sqlDataReader["Serie"].ToString().Trim();
                    string reg2 = sqlDataReader["Reg2"].ToString().Trim();
                    string chasis = sqlDataReader["Chasis"].ToString().Trim();
                    string reg3 = sqlDataReader["Reg3"].ToString().Trim();
                    int tipoVehiculo = Convert.ToInt32(sqlDataReader["TipoVehiculo"]);
                    string restriccionMovilidad = sqlDataReader["RestriccionMovilidad"].ToString().Trim();
                    string blindaje = sqlDataReader["Blindaje"].ToString().Trim();
                    string potencia = sqlDataReader["Potencia"].ToString().Trim();
                    string declaracionImportacion = sqlDataReader["DeclaracionImportacion"].ToString().Trim();
                    string iE = sqlDataReader["IE"].ToString().Trim();
                    DateTime fechaImportacion = Convert.ToDateTime(sqlDataReader["FechaImportacion"]);
                    int puertas = Convert.ToInt32(sqlDataReader["Puertas"]);
                    string limitacionPropiedad = sqlDataReader["LimitacionPropiedad"].ToString().Trim();
                    DateTime fechaMatricula = Convert.ToDateTime(sqlDataReader["FechaMatricula"]);
                    DateTime fechaExpLicTTO = Convert.ToDateTime(sqlDataReader["FechaExpLicTTO"]);
                    DateTime fechaVencimiento = Convert.ToDateTime(sqlDataReader["FechaVencimiento"]);
                    string organismoTransito = sqlDataReader["OrganismoTransito"].ToString().Trim();
                    byte[] foto = (byte[])sqlDataReader["Foto"];
                    this.Motos.Id = id;
                    this.Motos.Estado = estado;
                    this.Motos.Placa = placa;
                    this.Motos.Descripcion = descripcion;
                    this.Motos.Licencia = licencia;
                    this.Motos.IdPropietario = idPropietario;
                    this.Motos.IdentificacionPropietrio = identificacionPropietrio;
                    this.Motos.NombrePropietario = nombrePropietario;
                    this.Motos.Modelo = modelo;
                    this.Motos.Marca = marca;
                    this.Motos.Linea = linea;
                    this.Motos.Servicio = servicio;
                    this.Motos.Cilindraje = cilindraje;
                    this.Motos.Color = color;
                    this.Motos.Combustible = combustible;
                    this.Motos.Clase = clase;
                    this.Motos.Carroceria = carroceria;
                    this.Motos.Capacidad = capacidad;
                    this.Motos.Motor = motor;
                    this.Motos.Reg1 = reg;
                    this.Motos.Vin = vin;
                    this.Motos.Serie = serie;
                    this.Motos.Reg2 = reg2;
                    this.Motos.Chasis = chasis;
                    this.Motos.Reg3 = reg3;
                    this.Motos.TipoVehiculo = tipoVehiculo;
                    this.Motos.RestriccionMovilidad = restriccionMovilidad;
                    this.Motos.Blindaje = blindaje;
                    this.Motos.Potencia = potencia;
                    this.Motos.DeclaracionImportacion = declaracionImportacion;
                    this.Motos.IE = iE;
                    this.Motos.FechaImportacion = fechaImportacion;
                    this.Motos.Puertas = puertas;
                    this.Motos.LimitacionPropiedad = limitacionPropiedad;
                    this.Motos.FechaMatricula = fechaMatricula;
                    this.Motos.FechaExpLicTTO = fechaExpLicTTO;
                    this.Motos.FechaVencimiento = fechaVencimiento;
                    this.Motos.OrganismoTransito = organismoTransito;
                    this.Motos.Foto = foto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Motos;
        }
        public Ent_Plazas Plazas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    string descripcion = sqlDataReader["Descripcion"].ToString().Trim();
                    this.Plaza.Id = id;
                    this.Plaza.Codigo = codigo;
                    this.Plaza.Nombre = nombre;
                    this.Plaza.Descripcion = descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Plaza;
        }
        public Ent_Esquemas Esquemas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    string codigo = sqlDataReader["Codigo"].ToString().Trim();
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    this.Esquema.Codigo = codigo;
                    this.Esquema.Nombre = nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Esquema;
        }
        public Ent_VwContratistas VwContratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Codigo"].ToString().Trim());
                    string nombre = sqlDataReader["Nombre"].ToString().Trim();
                    this.VwContratista.Id = id;
                    this.VwContratista.Nombre = nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.VwContratista;
        }
        public Ent_TblMinasContratos ContratosMinas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                    int idMina = Convert.ToInt32(sqlDataReader["IdMina"].ToString().Trim());
                    int codigoEsquema = Convert.ToInt32(sqlDataReader["CodigoEsquema"].ToString().Trim());
                    int idContratista = Convert.ToInt32(sqlDataReader["IdContratista"].ToString().Trim());
                    string detalle = sqlDataReader["Detalle"].ToString().Trim();
                    DateTime fecha = Convert.ToDateTime(sqlDataReader["Fecha"].ToString().Trim());
                    DateTime inscripcion = Convert.ToDateTime(sqlDataReader["Inscripcion"].ToString().Trim());
                    DateTime vencimiento = Convert.ToDateTime(sqlDataReader["Vencimiento"].ToString().Trim());
                    double recuperacion = Convert.ToDouble(sqlDataReader["Recuperacion"].ToString().Trim());
                    double fondo = Convert.ToDouble(sqlDataReader["Fondo"].ToString().Trim());
                    double impuestos = Convert.ToDouble(sqlDataReader["Impuestos"].ToString().Trim());
                    int duracion = Convert.ToInt32(sqlDataReader["Duracion"].ToString().Trim());
                    bool tenores = Convert.ToBoolean(sqlDataReader["Tenores"].ToString().Trim());
                    bool anexoSeguridad = Convert.ToBoolean(sqlDataReader["AnexoSeguridad"].ToString().Trim());
                    bool explosivos = Convert.ToBoolean(sqlDataReader["Explosivos"].ToString().Trim());
                    bool devolucionFondo = Convert.ToBoolean(sqlDataReader["DevolucionFondo"].ToString().Trim());
                    DateTime realizado = Convert.ToDateTime(sqlDataReader["Realizado"].ToString().Trim());
                    string maquina = sqlDataReader["Maquina"].ToString().Trim();
                    int usuario = Convert.ToInt32(sqlDataReader["Usuario"].ToString().Trim());
                    this.MinaContrato.Id = id;
                    this.MinaContrato.IdMina = idMina;
                    this.MinaContrato.CodigoEsquema = codigoEsquema;
                    this.MinaContrato.IdContratista = idContratista;
                    this.MinaContrato.Detalle = detalle;
                    this.MinaContrato.Fecha = fecha;
                    this.MinaContrato.Inscripcion = inscripcion;
                    this.MinaContrato.Vencimiento = vencimiento;
                    this.MinaContrato.Recuperacion = recuperacion;
                    this.MinaContrato.Fondo = fondo;
                    this.MinaContrato.Impuestos = impuestos;
                    this.MinaContrato.Duracion = duracion;
                    this.MinaContrato.Tenores = tenores;
                    this.MinaContrato.AnexoSeguridad = anexoSeguridad;
                    this.MinaContrato.Explosivos = explosivos;
                    this.MinaContrato.DevolucionFondo = devolucionFondo;
                    this.MinaContrato.Realizado = realizado;
                    this.MinaContrato.Maquina = maquina;
                    this.MinaContrato.Usuario = usuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.MinaContrato;
        }
        public Ent_Periodos Periodos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                    string fechaInicial = sqlDataReader["FechaInicial"].ToString().Trim();
                    string fechaFinal = sqlDataReader["FechaFinal"].ToString().Trim();
                    int estado = Convert.ToInt32(sqlDataReader["Estado"].ToString().Trim());
                    double tRM = Convert.ToDouble(sqlDataReader["TRM"].ToString().Trim());
                    double oRO = Convert.ToDouble(sqlDataReader["ORO"].ToString().Trim());
                    int num = Convert.ToInt32(sqlDataReader["TrmEspecial"].ToString().Trim());
                    double recuperacionReportada = Convert.ToDouble(sqlDataReader["RecuperacionReportada"].ToString().Trim());
                    double recuperacionCalculada = Convert.ToDouble(sqlDataReader["RecuperacionCalculada"].ToString().Trim());
                    double costoPlanta = Convert.ToDouble(sqlDataReader["CostoPlanta"].ToString().Trim());
                    double ozCircuito = Convert.ToDouble(sqlDataReader["OzCircuito"].ToString().Trim());
                    double regalias = Convert.ToDouble(sqlDataReader["Regalias"].ToString().Trim());
                    string titulo = sqlDataReader["Titulo"].ToString().Trim();
                    this.Periodo.Id = id;
                    this.Periodo.FechaInicial = fechaInicial;
                    this.Periodo.FechaFinal = fechaFinal;
                    this.Periodo.Estado = estado;
                    this.Periodo.TRM = tRM;
                    this.Periodo.ORO = oRO;
                    this.Periodo.TRMEspecial = (double)num;
                    this.Periodo.RecuperacionReportada = recuperacionReportada;
                    this.Periodo.RecuperacionCalculada = recuperacionCalculada;
                    this.Periodo.CostoPlanta = costoPlanta;
                    this.Periodo.OzCircuito = ozCircuito;
                    this.Periodo.Regalias = regalias;
                    this.Periodo.Titulo = titulo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Periodo;
        }
        public Ent_ImagenPublicidad ImagenPublicidad()
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", "ImagenPublicidad"),
                new SqlParameter("@ParametroChar", string.Empty),
                new SqlParameter("@ParametroInt", "0"),
                new SqlParameter("@ParametroNuemric", "0.00")
            };
            SqlCommand sqlCommand = new SqlCommand("SpConsulta_Tablas", Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                if (sqlDataReader.Read())
                {
                    byte[] logo = (byte[])sqlDataReader["Logo1"];
                    byte[] logo2 = (byte[])sqlDataReader["Logo2"];
                    this.Logo.Logo1 = logo;
                    this.Logo.Logo2 = logo2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return this.Logo;
        }
        public static Ent_PersonalMuestreo PersonalMuestreo(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] array = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            Ent_PersonalMuestreo ent_PersonalMuestreo = new Ent_PersonalMuestreo();
            SqlCommand sqlCommand = new SqlCommand("SpConsulta_Tablas", Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                SqlParameter sqlParameter = array2[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            new ASCIIEncoding();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString());
                string identificacacion = sqlDataReader["Identificacacion"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                string apellido = sqlDataReader["Apellido"].ToString().Trim();
                string direccion = sqlDataReader["Direccion"].ToString().Trim();
                string telFijo = sqlDataReader["TelFijo"].ToString().Trim();
                string celular = sqlDataReader["Celular"].ToString().Trim();
                string email = sqlDataReader["Email"].ToString().Trim();
                int rol = Convert.ToInt32(sqlDataReader["Rol"].ToString());
                DateTime create = Convert.ToDateTime(sqlDataReader["Creado"].ToString());
                bool estado = Convert.ToBoolean(sqlDataReader["Estado"].ToString());
                ent_PersonalMuestreo.Id = id;
                ent_PersonalMuestreo.Identificacacion = identificacacion;
                ent_PersonalMuestreo.Nombre = nombre;
                ent_PersonalMuestreo.Apellido = apellido;
                ent_PersonalMuestreo.Direccion = direccion;
                ent_PersonalMuestreo.TelFijo = telFijo;
                ent_PersonalMuestreo.Celular = celular;
                ent_PersonalMuestreo.Email = email;
                ent_PersonalMuestreo.Rol = rol;
                ent_PersonalMuestreo.Create = create;
                ent_PersonalMuestreo.Estado = estado;
            }
            ConexionDB.CloseConexion(sqlCommand);
            return ent_PersonalMuestreo;
        }
        public static List<Ent_Localizacion> ObtenerLocalizacion(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            List<Ent_Localizacion> result;
            if (!string.IsNullOrEmpty(ParametroChar.Trim()))
            {
                SqlParameter[] array = new SqlParameter[]
                {
                    new SqlParameter("@Op", Op),
                    new SqlParameter("@ParametroChar", ParametroChar),
                    new SqlParameter("@ParametroInt", ParametroInt),
                    new SqlParameter("@ParametroNuemric", ParametroNumeric)
                };
                new Ent_PersonalMuestreo();
                SqlCommand sqlCommand = new SqlCommand("SpConsulta_Tablas", Conexion.OpenConexion());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    SqlParameter sqlParameter = array2[i];
                    sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
                }
                new ASCIIEncoding();
                using (IDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    List<Ent_Localizacion> list = new List<Ent_Localizacion>();
                    IList<Ent_Localizacion> list2 = list;
                    list2.LoadFromReader(dataReader);
                    ConexionDB.CloseConexion(sqlCommand);
                    result = list2.ToList<Ent_Localizacion>();
                    return result;
                }
            }
            result = new List<Ent_Localizacion>();
            return result;
        }
        public List<Ent_RelacionTipoOrigenDestino> TipoOrigenDestino(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_RelacionTipoOrigenDestino> list = new List<Ent_RelacionTipoOrigenDestino>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            try
            {
                while (sqlDataReader.Read())
                {
                    int idTipo = Convert.ToInt32(sqlDataReader["IdTipo"]);
                    string codigoTipoMineral = sqlDataReader["CodigoTipoMineral"].ToString().Trim();
                    string nombreTipoMineral = sqlDataReader["NombreTipoMineral"].ToString().Trim();
                    int idOrigen = Convert.ToInt32(sqlDataReader["IdOrigen"]);
                    string codigoOrigen = sqlDataReader["CodigoOrigen"].ToString().Trim();
                    string nombreOrigen = sqlDataReader["NombreOrigen"].ToString().Trim();
                    int idDestino = Convert.ToInt32(sqlDataReader["IdDestino"]);
                    string codigoDestino = sqlDataReader["CodigoDestino"].ToString().Trim();
                    string nombreDestino = sqlDataReader["NombreDestino"].ToString().Trim();
                    bool estado = Convert.ToBoolean(sqlDataReader["Estado"].ToString().Trim());
                    list.Add(new Ent_RelacionTipoOrigenDestino
                    {
                        IdTipo = idTipo,
                        CodigoTipoMineral = codigoTipoMineral,
                        NombreTipoMineral = nombreTipoMineral,
                        IdOrigen = idOrigen,
                        CodigoOrigen = codigoOrigen,
                        NombreOrigen = nombreOrigen,
                        IdDestino = idDestino,
                        CodigoDestino = codigoDestino,
                        NombreDestino = nombreDestino,
                        Estado = estado
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_Minas> ListMinas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Minas> list = new List<Ent_Minas>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                list.Add(new Ent_Minas
                {
                    Codigo = codigo,
                    Nombre = nombre
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_VwMinas> ListVwMinas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_VwMinas> list = new List<Ent_VwMinas>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                int idExpediente = Convert.ToInt32(sqlDataReader["IdExpediente"].ToString().Trim());
                string expediente = sqlDataReader["Expediente"].ToString().Trim();
                double este = Convert.ToDouble(sqlDataReader["Este"].ToString().Trim());
                double norte = Convert.ToDouble(sqlDataReader["Norte"].ToString().Trim());
                double elevacion = Convert.ToDouble(sqlDataReader["Elevacion"].ToString().Trim());
                bool deshabilitado = Convert.ToBoolean(sqlDataReader["deshabilitado"].ToString().Trim());
                DateTime fechaCreacion = Convert.ToDateTime(sqlDataReader["FechaCreacion"].ToString().Trim());
                list.Add(new Ent_VwMinas
                {
                    Id = id,
                    Codigo = codigo,
                    Nombre = nombre,
                    IdExpediente = idExpediente,
                    Expediente = expediente,
                    Este = este,
                    Norte = norte,
                    Elevacion = elevacion,
                    Deshabilitado = deshabilitado,
                    FechaCreacion = fechaCreacion
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_VwTipoContrato> ListVwTipoContrato(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_VwTipoContrato> list = new List<Ent_VwTipoContrato>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                bool deshabilitado = Convert.ToBoolean(sqlDataReader["deshabilitado"].ToString().Trim());
                DateTime fechaCreacion = Convert.ToDateTime(sqlDataReader["FechaCreacion"].ToString().Trim());
                list.Add(new Ent_VwTipoContrato
                {
                    Id = id,
                    Codigo = codigo,
                    Nombre = nombre,
                    Deshabilitado = deshabilitado,
                    FechaCreacion = fechaCreacion
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_Contenedores> ListContenedores(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Contenedores> list = new List<Ent_Contenedores>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                list.Add(new Ent_Contenedores
                {
                    Codigo = codigo,
                    Nombre = nombre
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_TiposDeEmpresa> ListaTiposDeEmpresa(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_TiposDeEmpresa> list = new List<Ent_TiposDeEmpresa>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                list.Add(new Ent_TiposDeEmpresa
                {
                    Id = id,
                    Codigo = codigo,
                    Nombre = nombre
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_Esquemas> ListaEsquemas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Esquemas> list = new List<Ent_Esquemas>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string codigo = sqlDataReader["Codigo"].ToString().Trim();
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                list.Add(new Ent_Esquemas
                {
                    Codigo = codigo,
                    Nombre = nombre
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_VwContratistas> ListaVwContratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_VwContratistas> list = new List<Ent_VwContratistas>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                string nombre = sqlDataReader["Nombre"].ToString().Trim();
                list.Add(new Ent_VwContratistas
                {
                    Id = id,
                    Nombre = nombre
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
        public List<Ent_Periodos> ListPeriodos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Periodos> list = new List<Ent_Periodos>();
            SqlCommand sqlCommand = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SP_Parametros.Length; i++)
            {
                SqlParameter sqlParameter = SP_Parametros[i];
                sqlCommand.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = Convert.ToInt32(sqlDataReader["Id"].ToString().Trim());
                string titulo = sqlDataReader["Titulo"].ToString().Trim();
                list.Add(new Ent_Periodos
                {
                    Id = id,
                    Titulo = titulo
                });
            }
            ConexionDB.CloseConexion(sqlCommand);
            return list;
        }
    }
}
