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
        Ent_MinaSello ConsultaSello = new Ent_MinaSello();
        Ent_DatosExcelSGS DatosExcelSGS = new Ent_DatosExcelSGS();
        Ent_AdjuntosSGS Adjuntos = new Ent_AdjuntosSGS();
        Ent_Vehiculo Vehiculos = new Ent_Vehiculo();
        Ent_Propietarios Propietario = new Ent_Propietarios();
        Ent_VehiculoTecnoMecanica VehiculoTecno = new Ent_VehiculoTecnoMecanica();
        Ent_VehiculosSeguros VehiculoSegu = new Ent_VehiculosSeguros();
        Ent_DatosAdjuntos DatAdjunto = new Ent_DatosAdjuntos();
        Ent_Minas Mina = new Ent_Minas();
        Ent_TiposMineral TipoMineral = new Ent_TiposMineral();
        Ent_Destino Destinos = new Ent_Destino();
        Ent_Origen Origenes = new Ent_Origen();
        Ent_RelacionTipoOrigenDestino RelacionTipo = new Ent_RelacionTipoOrigenDestino();
        Ent_Motos Motos = new Ent_Motos();
        Ent_Contratistas Contratista = new Ent_Contratistas();
        Ent_Conductores Conductor = new Ent_Conductores();
        Ent_SubTipos Subtipo = new Ent_SubTipos();
        Ent_VwMinas VwMinas = new Ent_VwMinas();
        Ent_Contenedores Contenedores = new Ent_Contenedores();
        Ent_TiposDeEmpresa TiposDeEmpresa = new Ent_TiposDeEmpresa();
        Ent_TblMinas TblMinas = new Ent_TblMinas();
        Ent_Plazas Plaza = new Ent_Plazas();
        Ent_Esquemas Esquema = new Ent_Esquemas();
        Ent_VwContratistas VwContratista = new Ent_VwContratistas();
        Ent_TblMinasContratos MinaContrato = new Ent_TblMinasContratos();
        Ent_Periodos Periodo = new Ent_Periodos();
        Ent_ImagenPublicidad Logo = new Ent_ImagenPublicidad();
        Ent_PersonalMuestreo PersonalDeMuestreo = new Ent_PersonalMuestreo();

        public Ent_Propietarios Propietarios(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                string identificacion = Reader["Identificacion"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                string apellido = Reader["Apellido"].ToString().Trim();
                string telfijo = Reader["TelFijo"].ToString().Trim();
                string extension = Reader["Extension"].ToString().Trim();
                string celular = Reader["Celular"].ToString().Trim();
                string email = Reader["Email"].ToString().Trim();
                bool deshabilitado = Convert.ToBoolean(Reader["Deshabilitado"].ToString().Trim());
                DateTime fechacreacion = Convert.ToDateTime(Reader["FechaCreacion"].ToString().Trim());

                Propietario.Id = id;
                Propietario.Identificacion = identificacion;
                Propietario.Nombre = nombre;
                Propietario.Apellido = apellido;
                Propietario.TelFijo = telfijo;
                Propietario.Extension = extension;
                Propietario.Celular = celular;
                Propietario.Email = email;
                Propietario.Deshabilitado = deshabilitado;
                Propietario.FechaCreacion = fechacreacion;
            }
            ConexionDB.CloseConexion(Command);
            return Propietario;
        }
        
       public static List<Roles_Permisos> GetPermisosRoles(string SP_Consulta, string nameUser, string PageMaster)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[2];


            Parametros_Consulta[0] = new SqlParameter("@Name", nameUser);
            Parametros_Consulta[1] = new SqlParameter("@FKPage", PageMaster);

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Roles_Permisos> permisosRoles = new List<Roles_Permisos>();
                IList<Roles_Permisos> list = permisosRoles;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }

            ConexionDB.CloseConexion(Command);
            return null;
        }

        public Ent_Contratistas Contratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                int tipoidentificacion = Convert.ToInt32(Reader["TipoIdentificacion"].ToString().Trim());
                string identificacion = Reader["Identificacion"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                string razoncial = Reader["RazonCial"].ToString().Trim();
                string apellido = Reader["Apellido"].ToString().Trim();
                string telfijo = Reader["TelFijo"].ToString().Trim();
                string extension = Reader["Extension"].ToString().Trim();
                string celular = Reader["Celular"].ToString().Trim();
                string email = Reader["Email"].ToString().Trim();
                bool deshabilitado = Convert.ToBoolean(Reader["Deshabilitado"].ToString().Trim());
                DateTime fechacreacion = Convert.ToDateTime(Reader["FechaCreacion"].ToString().Trim());

                Contratista.Id = id;
                Contratista.TipoIdentificacion = tipoidentificacion;
                Contratista.Identificacion = identificacion;
                Contratista.RazonCial = razoncial;
                Contratista.Nombre = nombre;
                Contratista.Apellido = apellido;
                Contratista.TelFijo = telfijo;
                Contratista.Extension = extension;
                Contratista.Celular = celular;
                Contratista.Email = email;
                Contratista.Deshabilitado = deshabilitado;
                Contratista.FechaCreacion = fechacreacion;
            }
            ConexionDB.CloseConexion(Command);
            return Contratista;
        }

        public Ent_MinaSello MinaSello(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int consecutivo = Convert.ToInt32(Reader["Consecutivo"]);
                    DateTime fecha = Convert.ToDateTime(Reader["Fecha"]);
                    string mina = Reader["Mina"].ToString().Trim();

                    ConsultaSello.Consecutivo = consecutivo;
                    ConsultaSello.Fecha = fecha;
                    ConsultaSello.Mina = mina;
                }
                else
                {
                    ConsultaSello.Consecutivo = 0;
                    ConsultaSello.Fecha = DateTime.Now.Date;
                    ConsultaSello.Mina = "SELLO NO REPORTADO";
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return ConsultaSello;
        }

        public Ent_DatosExcelSGS TablaExcel(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    bool incluir = Convert.ToBoolean(Reader["Incluir"]);
                    int id = Convert.ToInt32(Reader["Id"]);
                    string selloh = Reader["SelloH"].ToString().Trim();
                    string sellop = Reader["SelloP"].ToString().Trim();
                    double humedad = Convert.ToDouble(Reader["Humedad"]);
                    double tenor = Convert.ToDouble(Reader["Tenor"]);
                    int peso = Convert.ToInt32(Reader["Peso"]);
                    string cliente = Reader["Cliente"].ToString().Trim();
                    string Orden = Reader["Orden"].ToString().Trim();
                    string muestra = Reader["Muestra"].ToString().Trim();
                    string referencia = Reader["Referencia"].ToString().Trim();
                    string lugar = Reader["Lugar"].ToString().Trim();
                    string recepcion = Reader["Recepcion"].ToString().Trim();
                    string reporte = Reader["Reporte"].ToString().Trim();

                    DatosExcelSGS.Incluir = incluir;
                    DatosExcelSGS.Id = id;
                    DatosExcelSGS.SelloH = selloh;
                    DatosExcelSGS.SelloP = sellop;
                    DatosExcelSGS.Humedad = humedad;
                    DatosExcelSGS.Tenor = tenor;
                    DatosExcelSGS.Peso = peso;
                    DatosExcelSGS.Cliente = cliente;
                    DatosExcelSGS.Orden = Orden;
                    DatosExcelSGS.Muestra = muestra;
                    DatosExcelSGS.Referencia = referencia;
                    DatosExcelSGS.Lugar = lugar;
                    DatosExcelSGS.Recepcion = recepcion;
                    DatosExcelSGS.Reporte = reporte;
                }

            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return DatosExcelSGS;
        }

        public Ent_Vehiculo Vehiculo(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    bool estado = Convert.ToBoolean(Reader["Estado"]);
                    string placa = Reader["Placa"].ToString().Trim();
                    string descripcion = Reader["Descripcion"].ToString().Trim();
                    string proyecto = Reader["Proyecto"].ToString().Trim();
                    string nombreproyecto = Reader["NombreProyecto"].ToString().Trim();
                    string licencia = Reader["Licencia"].ToString().Trim();
                    double peso = Convert.ToDouble(Reader["Peso"]);
                    int idPropietario = Convert.ToInt32(Reader["IdPropietario"]);
                    string identificacion = Reader["Identificacion"].ToString().Trim();
                    string nombrepropietario = Reader["NombrePropietario"].ToString().Trim();
                    string modelo = Reader["Modelo"].ToString().Trim();
                    string marca = Reader["Marca"].ToString().Trim();
                    string linea = Reader["Linea"].ToString().Trim();
                    string servicio = Reader["Servicio"].ToString().Trim();
                    double cilindraje = Convert.ToDouble(Reader["Cilindraje"]);
                    string color = Reader["Color"].ToString().Trim();
                    string combustible = Reader["Combustible"].ToString().Trim();
                    string clase = Reader["Clase"].ToString().Trim();
                    string carroceria = Reader["Carroceria"].ToString().Trim();
                    int capacidad = Convert.ToInt32(Reader["Capacidad"]);
                    string motor = Reader["Motor"].ToString().Trim();
                    string reg1 = Reader["Reg1"].ToString().Trim();
                    string vin = Reader["Vin"].ToString().Trim();
                    string serie = Reader["Serie"].ToString().Trim();
                    string reg2 = Reader["Reg2"].ToString().Trim();
                    string chasis = Reader["Chasis"].ToString().Trim();
                    string reg3 = Reader["Reg3"].ToString().Trim();
                    int tipoVehiculo = Convert.ToInt32(Reader["TipoVehiculo"]);
                    string restriccionmovilidad = Reader["RestriccionMovilidad"].ToString().Trim();
                    string blindaje = Reader["Blindaje"].ToString().Trim();
                    string potencia = Reader["Potencia"].ToString().Trim();
                    string declaracionImportacion = Reader["DeclaracionImportacion"].ToString().Trim();
                    string ie = Reader["IE"].ToString().Trim();
                    DateTime fechaImportacion = Convert.ToDateTime(Reader["FechaImportacion"]);
                    int puertas = Convert.ToInt32(Reader["Puertas"]);
                    string limitacionPropiedad = Reader["LimitacionPropiedad"].ToString().Trim();
                    DateTime fechaMatricula = Convert.ToDateTime(Reader["FechaMatricula"]);
                    DateTime fechaExpLicTTO = Convert.ToDateTime(Reader["FechaExpLicTTO"]);
                    DateTime fechaVencimiento = Convert.ToDateTime(Reader["FechaVencimiento"]);
                    string organismoTransito = Reader["OrganismoTransito"].ToString().Trim();
                    string stiker = Reader["Stiker"].ToString().Trim();
                    int cubicacion = Convert.ToInt32(Reader["Cubicacion"]);
                    byte[] foto = (byte[])Reader["Foto"];

                    Vehiculos.Id = id;
                    Vehiculos.Estado = estado;
                    Vehiculos.Placa = placa;
                    Vehiculos.Descripcion = descripcion;
                    Vehiculos.Proyecto = proyecto;
                    Vehiculos.NombreProyecto = nombreproyecto;
                    Vehiculos.Licencia = licencia;
                    Vehiculos.Peso = peso;
                    Vehiculos.IdPropietario = idPropietario;
                    Vehiculos.IdentiPropietrio = identificacion;
                    Vehiculos.NombrePropietario = nombrepropietario;
                    Vehiculos.Modelo = modelo;
                    Vehiculos.Marca = marca;
                    Vehiculos.Linea = linea;
                    Vehiculos.Servicio = servicio;
                    Vehiculos.Cilindraje = cilindraje;
                    Vehiculos.Color = color;
                    Vehiculos.Combustible = combustible;
                    Vehiculos.Clase = clase;
                    Vehiculos.Carroceria = carroceria;
                    Vehiculos.Capacidad = capacidad;
                    Vehiculos.Motor = motor;
                    Vehiculos.Reg1 = reg1;
                    Vehiculos.Vin = vin;
                    Vehiculos.Serie = serie;
                    Vehiculos.Reg2 = reg2;
                    Vehiculos.Chasis = chasis;
                    Vehiculos.Reg3 = reg3;
                    Vehiculos.TipoVehiculo = tipoVehiculo;
                    Vehiculos.RestriccionMovilidad = restriccionmovilidad;
                    Vehiculos.Blindaje = blindaje;
                    Vehiculos.Potencia = potencia;
                    Vehiculos.DeclaracionImportacion = declaracionImportacion;
                    Vehiculos.IE = ie;
                    Vehiculos.FechaImportacion = fechaImportacion;
                    Vehiculos.Puertas = puertas;
                    Vehiculos.LimitacionPropiedad = limitacionPropiedad;
                    Vehiculos.FechaMatricula = fechaMatricula;
                    Vehiculos.FechaExpLicTTO = fechaExpLicTTO;
                    Vehiculos.FechaVencimiento = fechaVencimiento;
                    Vehiculos.OrganismoTransito = organismoTransito;
                    Vehiculos.Stiker = stiker;
                    Vehiculos.Cubicacion = cubicacion;
                    Vehiculos.Foto = foto;
                }

            }
            catch (Exception Vehiculo)
            {
                MessageBox.Show(Vehiculo.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Vehiculos;
        }

        public Ent_Conductores Conductores(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    bool estado = Convert.ToBoolean(Reader["Estado"]);
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();
                    string apellido = Reader["Apellido"].ToString().Trim();
                    string direccion = Reader["Direccion"].ToString().Trim();
                    string telfijo = Reader["TelFijo"].ToString().Trim();
                    string email = Reader["Email"].ToString().Trim();
                    string telefono = Reader["Telefono"].ToString().Trim();
                    DateTime nacimiento = Convert.ToDateTime(Reader["Nacimiento"]);
                    int rh = Convert.ToInt32(Reader["RH"]);
                    int idContratista = Convert.ToInt32(Reader["IdContratista"]);
                    string identificacionContratista = Reader["IdentificacionContratista"].ToString().Trim();
                    string nombreContratista = Reader["NombreContratista"].ToString().Trim();
                    string apellidoContratista = Reader["ApellidoContratista"].ToString().Trim();
                    int idvehiculo = Convert.ToInt32(Reader["IdVehiculo"]);
                    string placa = Reader["Placa"].ToString().Trim();
                    byte[] foto = (byte[])Reader["Foto"];


                    Conductor.Id = id;
                    Conductor.Estado = estado;
                    Conductor.Codigo = codigo;
                    Conductor.Nombre = nombre;
                    Conductor.Apellido = apellido;
                    Conductor.Direccion = direccion;
                    Conductor.TelFijo = telfijo;
                    Conductor.Telefono = telefono;
                    Conductor.Email = email;
                    Conductor.Nacimiento = nacimiento;
                    Conductor.RH = rh;
                    Conductor.IdContratista = idContratista;
                    Conductor.IdentificacionContratista = identificacionContratista;
                    Conductor.NombreContratista = nombreContratista;
                    Conductor.ApellidoContratista = apellidoContratista;
                    Conductor.IdVehiculo = idvehiculo;
                    Conductor.Placa = placa;
                    Conductor.Foto = foto;
                }

            }
            catch (Exception Vehiculo)
            {
                MessageBox.Show(Vehiculo.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Conductor;
        }

        public static List<Ent_OrdenesMuestra> ObtenerHistorialSec(string SP_Consulta, string Op, string ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;
            
            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_OrdenesMuestra> pesajeMineral = new List<Ent_OrdenesMuestra>();
                IList<Ent_OrdenesMuestra> list = pesajeMineral;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }

            ConexionDB.CloseConexion(Command);
            return null;
        }
        public static List<Ent_Detalle_Periodo> DetallePeriodos(string SP_Consulta, string Op, string ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Detalle_Periodo> pesajeMineral = new List<Ent_Detalle_Periodo>();
                IList<Ent_Detalle_Periodo> list = pesajeMineral;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }

            ConexionDB.CloseConexion(Command);
            return null;
        }

        public static List<Ent_LiquidacionPeriodos> ObtenerPeriodos(string SP_Consulta, string Op, string ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_LiquidacionPeriodos> pesajeMineral = new List<Ent_LiquidacionPeriodos>();
                IList<Ent_LiquidacionPeriodos> list = pesajeMineral;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }

            ConexionDB.CloseConexion(Command);
            return null;
        }
        public static List<Ent_Localizacion> ObtenerLocalizacion(string SP_Consulta, string Op, string ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "recuLocalizacion");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", "");
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Localizacion> pesajeMineral = new List<Ent_Localizacion>();
                IList<Ent_Localizacion> list = pesajeMineral;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }

            ConexionDB.CloseConexion(Command);
            return null;
        }

        public static List<Ent_Usuario> ObtenerUsuario(string SP_Consulta, string Op, string NombreUsuario)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[2];
            Parametros_Consulta[0] = new SqlParameter("@Oper", Op);
            Parametros_Consulta[1] = new SqlParameter("@NombreUsuario", NombreUsuario);
            
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Usuario> usuario = new List<Ent_Usuario>();
                IList<Ent_Usuario> list = usuario;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }
            ConexionDB.CloseConexion(Command);
            return null;
        }
        public static List<Ent_Usuario> ObtenerUsuarioPorRoles(string SP_Consulta,string NombreUsuario)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[1];
            Parametros_Consulta[0] = new SqlParameter("@NombreUsuario", NombreUsuario);

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Usuario> usuario = new List<Ent_Usuario>();
                IList<Ent_Usuario> list = usuario;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }
            ConexionDB.CloseConexion(Command);
            return null;
        }

        public static List<Ent_Muestreo> ObtenerMuestreo(string SP_Consulta, string Op, int ParametroChar,string ParametroInt)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Muestreo> usuario = new List<Ent_Muestreo>();
                IList<Ent_Muestreo> list = usuario;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }
            ConexionDB.CloseConexion(Command);
            return null;
        }

        public static List<Ent_CalidadMuestro> ObtenerMuestroDia(string SP_Consulta, string Op, object ParametroChar, Int64 ParametroInt, string ParametroNumeric)
            {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");


            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_CalidadMuestro> muestroCalidad = new List<Ent_CalidadMuestro>();
                IList<Ent_CalidadMuestro> list = muestroCalidad;
                list.LoadFromReader(reader);

                    ConexionDB.CloseConexion(Command);
                return list.ToList();
            }
            ConexionDB.CloseConexion(Command);
            return null;
        }


        public static Ent_Fecha ObtenerFechas(string SP_Consulta, string Op, object ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");


            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Fecha> muestroCalidad = new List<Ent_Fecha>();
                IList<Ent_Fecha> list = muestroCalidad;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list[0];
            }
            ConexionDB.CloseConexion(Command);
            return null;
        }

        public static List<Ent_PesajeMineral> ObtenerPesoMinas(string SP_Consulta, string Op, string ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");


            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_PesajeMineral> pesajeMineral = new List<Ent_PesajeMineral>();
                IList<Ent_PesajeMineral> list = pesajeMineral;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }
            ConexionDB.CloseConexion(Command);
            return null;
        }

        public Ent_Contratistas NombreContratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    string identificacion = Reader["Identificacion"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();
                    string apellido = Reader["Apellido"].ToString().Trim();

                    Contratista.Identificacion = identificacion;
                    Contratista.Nombre = nombre;
                    Contratista.Apellido = apellido;

                }

            }
            catch (Exception Vehiculo)
            {
                MessageBox.Show(Vehiculo.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Contratista;
        }

        public Ent_AdjuntosSGS AdjuntosSGS(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            System.Text.ASCIIEncoding Texto = new System.Text.ASCIIEncoding();
            Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString());
                string orden = Reader["Orden"].ToString();
                string ruta = Reader["Ruta"].ToString();
                string nombre = Reader["Nombre"].ToString();
                byte[] archivo = (byte[])Reader["Archivo"];
                string extension = Reader["Extension"].ToString();
                string detalle = Reader["Maquina"].ToString();

                Adjuntos.Id = id;
                Adjuntos.Orden = orden;
                Adjuntos.Nombre = nombre;
                Adjuntos.Archivo = archivo;
                Adjuntos.Extension = extension;
                Adjuntos.Maquina = detalle.Trim();
            }
            ConexionDB.CloseConexion(Command);

            return Adjuntos;
        }

        public Ent_VehiculoTecnoMecanica VehiculoTecnos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    int idPlaca = Convert.ToInt32(Reader["IdPlaca"]);
                    string nroControl = Reader["NroControl"].ToString();
                    DateTime fechaexpedicion = Convert.ToDateTime(Reader["FechaExpedicion"]);
                    DateTime fechavencimiento = Convert.ToDateTime(Reader["FechaVencimiento"]);
                    int idpropietario = Convert.ToInt32(Reader["IdPropietario"]);
                    string nombrepropietario = Reader["NombrePropietario"].ToString().Trim();
                    string nitAutomotor = Reader["NitAutomotor"].ToString().Trim();
                    string nombreAutomotor = Reader["NombreAutomotor"].ToString().Trim();
                    string consecutivorunt = Reader["ConsecutivoRunt"].ToString().Trim();
                    string certificadoacreditacion = Reader["CertificadoAcreditacion"].ToString().Trim();

                    VehiculoTecno.NroControl = nroControl;
                    VehiculoTecno.IdPlaca = idPlaca;
                    VehiculoTecno.FechaExpedicion = fechaexpedicion;
                    VehiculoTecno.FechaVencimiento = fechavencimiento;
                    VehiculoTecno.IdPropietario = idpropietario;
                    VehiculoTecno.NombrePropietario = nombrepropietario;
                    VehiculoTecno.NitAutomotor = nitAutomotor;
                    VehiculoTecno.NombreAutomotor = nombreAutomotor;
                    VehiculoTecno.ConsecutivoRunt = consecutivorunt;
                    VehiculoTecno.CertificadoAcreditacion = certificadoacreditacion;
                }

            }
            catch (Exception Vehiculo)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Vehiculo.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return VehiculoTecno;
        }

        public Ent_VehiculosSeguros VehiculoSeguros(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    int idplaca = Convert.ToInt32(Reader["IdPlaca"]);
                    string proveedor = Reader["Proveedor"].ToString().Trim();
                    string idtomador = Reader["IdTomador"].ToString().Trim();
                    string nombretomador = Reader["Nombretomador"].ToString().Trim();
                    DateTime fechaexpedicion = Convert.ToDateTime(Reader["FechaExpedicion"]);
                    DateTime fechainicial = Convert.ToDateTime(Reader["FechaInicial"]);
                    DateTime fechafinal = Convert.ToDateTime(Reader["Fechafinal"]);
                    string telefono = Reader["Telefono"].ToString().Trim();
                    string codigosucursal = Reader["CodigoSucursal"].ToString().Trim();
                    string claveproductor = Reader["ClaveProductor"].ToString().Trim();
                    string ciudadexpedicion = Reader["CiudadExpe"].ToString().Trim();
                    string direccion = Reader["Direccion"].ToString().Trim();
                    string ciudadresidencia = Reader["CiudadResidencia"].ToString().Trim();
                    string Poliza = Reader["Poliza"].ToString().Trim();
                    string reemplaza = Reader["Reemplaza"].ToString().Trim();
                    string clasevehiculo = Reader["ClaseVehiculo"].ToString().Trim();
                    string pasajeros = Reader["Pasajeros"].ToString().Trim();
                    string tarifa = Reader["Tarifa"].ToString().Trim();

                    VehiculoSegu.IdPlaca = idplaca;
                    VehiculoSegu.Proveedor = proveedor;
                    VehiculoSegu.IdTomador = idtomador;
                    VehiculoSegu.Nombretomador = nombretomador;
                    VehiculoSegu.FechaExpedicion = fechaexpedicion;
                    VehiculoSegu.FechaInicial = fechainicial;
                    VehiculoSegu.FechaFinal = fechafinal;
                    VehiculoSegu.CodigoSucursal = codigosucursal;
                    VehiculoSegu.ClaveProductor = claveproductor;
                    VehiculoSegu.Telefono = telefono;
                    VehiculoSegu.Direccion = direccion;
                    VehiculoSegu.CiudadExpedicion = ciudadexpedicion;
                    VehiculoSegu.CiudadResidencia = ciudadresidencia;
                    VehiculoSegu.Poliza = Poliza;
                    VehiculoSegu.Reemplaza = reemplaza;
                    VehiculoSegu.ClaseVehiculo = clasevehiculo;
                    VehiculoSegu.Pasajeros = pasajeros;
                    VehiculoSegu.Tarifa = tarifa;
                }

            }
            catch (Exception Vehiculo)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Vehiculo.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return VehiculoSegu;
        }

        public Ent_DatosAdjuntos Adjunto(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString());
                string nombre = Reader["Nombre"].ToString();
                byte[] archivo = (byte[])Reader["Archivo"];
                string extension = Reader["Extension"].ToString();
                string detalle = Reader["Detalle"].ToString();

                DatAdjunto.Id = id;
                DatAdjunto.Nombre = nombre;
                DatAdjunto.Archivo = archivo;
                DatAdjunto.Extension = extension;
                DatAdjunto.Detalle = detalle;
            }
            ConexionDB.CloseConexion(Command);

            return DatAdjunto;
        }

        public Ent_Minas Minas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();

                    Mina.Codigo = codigo;
                    Mina.Nombre = nombre;
                }

            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return Mina;
        }

        public static List<Ent_Minas> MinasReader(string SP_Consulta, string Op, string ParametroChar, Int64 ParametroInt, string ParametroNumeric)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", Op);
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");


            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros_Consulta)
                Command.Parameters.Add(item).Value = item.Value;

            using (IDataReader reader = Command.ExecuteReader())
            {
                List<Ent_Minas> pesajeMineral = new List<Ent_Minas>();
                IList<Ent_Minas> list = pesajeMineral;
                list.LoadFromReader(reader);

                ConexionDB.CloseConexion(Command);
                return list.ToList();
            }
            ConexionDB.CloseConexion(Command);
            return null;

        }

        public Ent_TblMinas TblMina(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string codigopm = Reader["CodigoPM"].ToString().Trim();
                    int idmina = Convert.ToInt32(Reader["IdMina"].ToString().Trim());
                    string nombrevwmina = Reader["NombreVwMina"].ToString().Trim();
                    string nombremina = Reader["NombreMina"].ToString().Trim();
                    int idexpediente = Convert.ToInt32(Reader["IdExpediente"].ToString().Trim());
                    string expediente = Reader["Expediente"].ToString().Trim();
                    string codigocontenedor = Reader["CodigoContenedor"].ToString().Trim();
                    string nombrecontenedor = Reader["NombreContenedor"].ToString().Trim();
                    int idtipocontrato = Convert.ToInt32(Reader["IdTipoContrato"].ToString().Trim());
                    string nombretipocontrato = Reader["NombreTipoContrato"].ToString().Trim();
                    bool tenorpromedio = Convert.ToBoolean(Reader["TenorPromedio"].ToString().Trim());
                    double area = Convert.ToDouble(Reader["Area"].ToString().Trim());
                    string este = Reader["Este"].ToString().Trim();
                    string norte = Reader["Norte"].ToString().Trim();
                    string elevacion = Reader["Elevacion"].ToString().Trim();
                    int idtipoempresa = Convert.ToInt32(Reader["IdTipoEmpresa"].ToString().Trim());
                    string nombretipoempresa = Reader["NombreTipoEmpresa"].ToString().Trim();
                    string detalle = Reader["Detalle"].ToString().Trim();
                    string codigoplaza = Reader["CodigoPlaza"].ToString().Trim();
                    string nombreplaza = Reader["NombrePlaza"].ToString().Trim();
                    string email = Reader["Email"].ToString().Trim();
                    bool mostrareninformes = Convert.ToBoolean(Reader["MostrarEnInformes"].ToString().Trim());
                    bool recuperacionplanta = Convert.ToBoolean(Reader["RecuperacionPlanta"].ToString().Trim());
                    bool estado = Convert.ToBoolean(Reader["Estado"].ToString().Trim());

                    TblMinas.Id = id;
                    TblMinas.Codigo = codigo;
                    TblMinas.CodigoPM = codigopm;
                    TblMinas.IdMina = idmina;
                    TblMinas.NombreVwMina = nombrevwmina;
                    TblMinas.NombreMina = nombremina;
                    TblMinas.IdExpediente = idexpediente;
                    TblMinas.Expediente = expediente;
                    TblMinas.CodigoContenedor = codigocontenedor;
                    TblMinas.NombreContenedor = nombrecontenedor;
                    TblMinas.IdTipoContrato = idtipocontrato;
                    TblMinas.NombreTipoContrato = nombretipocontrato;
                    TblMinas.TenorPromedio = tenorpromedio;
                    TblMinas.Area = area;
                    TblMinas.Este = este;
                    TblMinas.Norte = norte;
                    TblMinas.Elevacion = elevacion;
                    TblMinas.IdTipoEmpresa = idtipoempresa;
                    TblMinas.NombreTipoEmpresa = nombretipoempresa;
                    TblMinas.Detalle = detalle;
                    TblMinas.CodigoPlaza = codigoplaza;
                    TblMinas.NombrePlaza = nombreplaza;
                    TblMinas.Email = email;
                    TblMinas.MostrarEnInformes = mostrareninformes;
                    TblMinas.RecuperacionPlanta = recuperacionplanta;
                    TblMinas.Estado = estado;
                }

            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return TblMinas;
        }

        public Ent_TiposMineral TiposMineral(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();
                    string descripcion = Reader["Descripcion"].ToString().Trim();

                    TipoMineral.Id = id;
                    TipoMineral.Codigo = codigo;
                    TipoMineral.Nombre = nombre;
                    TipoMineral.Descripcion = descripcion;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return TipoMineral;
        }

        public Ent_Origen Origen(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();
                    string descripcion = Reader["Descripcion"].ToString().Trim();

                    Origenes.Id = id;
                    Origenes.Codigo = codigo;
                    Origenes.Nombre = nombre;
                    Origenes.Descripcion = descripcion;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return Origenes;
        }

        public Ent_Destino Destino(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();
                    string descripcion = Reader["Descripcion"].ToString().Trim();

                    Destinos.Id = id;
                    Destinos.Codigo = codigo;
                    Destinos.Nombre = nombre;
                    Destinos.Descripcion = descripcion;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);

            return Destinos;
        }

        public Ent_SubTipos Subtipos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Codigo"].ToString().Trim());
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                string detalle = Reader["Detalle"].ToString().Trim();

                Subtipo.Id = id;
                Subtipo.Codigo = codigo;
                Subtipo.Nombre = nombre;
                Subtipo.Detalle = detalle;
            }
            ConexionDB.CloseConexion(Command);

            return Subtipo;
        }

        public Ent_Motos Moto(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    bool estado = Convert.ToBoolean(Reader["Estado"]);
                    string placa = Reader["Placa"].ToString().Trim();
                    string descripcion = Reader["Descripcion"].ToString().Trim();
                    string licencia = Reader["Licencia"].ToString().Trim();
                    int idPropietario = Convert.ToInt32(Reader["IdPropietario"]);
                    string identificacionPropietario = Reader["IdentificacionPropietario"].ToString().Trim();
                    string nombrepropietario = Reader["NombrePropietario"].ToString().Trim();
                    string modelo = Reader["Modelo"].ToString().Trim();
                    string marca = Reader["Marca"].ToString().Trim();
                    string linea = Reader["Linea"].ToString().Trim();
                    string servicio = Reader["Servicio"].ToString().Trim();
                    double cilindraje = Convert.ToDouble(Reader["Cilindraje"]);
                    string color = Reader["Color"].ToString().Trim();
                    string combustible = Reader["Combustible"].ToString().Trim();
                    string clase = Reader["Clase"].ToString().Trim();
                    string carroceria = Reader["Carroceria"].ToString().Trim();
                    int capacidad = Convert.ToInt32(Reader["Capacidad"]);
                    string motor = Reader["Motor"].ToString().Trim();
                    string reg1 = Reader["Reg1"].ToString().Trim();
                    string vin = Reader["Vin"].ToString().Trim();
                    string serie = Reader["Serie"].ToString().Trim();
                    string reg2 = Reader["Reg2"].ToString().Trim();
                    string chasis = Reader["Chasis"].ToString().Trim();
                    string reg3 = Reader["Reg3"].ToString().Trim();
                    int tipoVehiculo = Convert.ToInt32(Reader["TipoVehiculo"]);
                    string restriccionmovilidad = Reader["RestriccionMovilidad"].ToString().Trim();
                    string blindaje = Reader["Blindaje"].ToString().Trim();
                    string potencia = Reader["Potencia"].ToString().Trim();
                    string declaracionImportacion = Reader["DeclaracionImportacion"].ToString().Trim();
                    string ie = Reader["IE"].ToString().Trim();
                    DateTime fechaImportacion = Convert.ToDateTime(Reader["FechaImportacion"]);
                    int puertas = Convert.ToInt32(Reader["Puertas"]);
                    string limitacionPropiedad = Reader["LimitacionPropiedad"].ToString().Trim();
                    DateTime fechaMatricula = Convert.ToDateTime(Reader["FechaMatricula"]);
                    DateTime fechaExpLicTTO = Convert.ToDateTime(Reader["FechaExpLicTTO"]);
                    DateTime fechaVencimiento = Convert.ToDateTime(Reader["FechaVencimiento"]);
                    string organismoTransito = Reader["OrganismoTransito"].ToString().Trim();
                    byte[] foto = (byte[])Reader["Foto"];

                    Motos.Id = id;
                    Motos.Estado = estado;
                    Motos.Placa = placa;
                    Motos.Descripcion = descripcion;
                    Motos.Licencia = licencia;
                    Motos.IdPropietario = idPropietario;
                    Motos.IdentificacionPropietrio = identificacionPropietario;
                    Motos.NombrePropietario = nombrepropietario;
                    Motos.Modelo = modelo;
                    Motos.Marca = marca;
                    Motos.Linea = linea;
                    Motos.Servicio = servicio;
                    Motos.Cilindraje = cilindraje;
                    Motos.Color = color;
                    Motos.Combustible = combustible;
                    Motos.Clase = clase;
                    Motos.Carroceria = carroceria;
                    Motos.Capacidad = capacidad;
                    Motos.Motor = motor;
                    Motos.Reg1 = reg1;
                    Motos.Vin = vin;
                    Motos.Serie = serie;
                    Motos.Reg2 = reg2;
                    Motos.Chasis = chasis;
                    Motos.Reg3 = reg3;
                    Motos.TipoVehiculo = tipoVehiculo;
                    Motos.RestriccionMovilidad = restriccionmovilidad;
                    Motos.Blindaje = blindaje;
                    Motos.Potencia = potencia;
                    Motos.DeclaracionImportacion = declaracionImportacion;
                    Motos.IE = ie;
                    Motos.FechaImportacion = fechaImportacion;
                    Motos.Puertas = puertas;
                    Motos.LimitacionPropiedad = limitacionPropiedad;
                    Motos.FechaMatricula = fechaMatricula;
                    Motos.FechaExpLicTTO = fechaExpLicTTO;
                    Motos.FechaVencimiento = fechaVencimiento;
                    Motos.OrganismoTransito = organismoTransito;
                    Motos.Foto = foto;
                }

            }
            catch (Exception Moto)
            {
                MessageBox.Show(Moto.Message, "Error del Sistema - Instancia - Consulta Entidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Motos;
        }

        public Ent_Plazas Plazas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"]);
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();
                    string descripcion = Reader["Descripcion"].ToString().Trim();

                    Plaza.Id = id;
                    Plaza.Codigo = codigo;
                    Plaza.Nombre = nombre;
                    Plaza.Descripcion = descripcion;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Plaza;
        }

        public Ent_Esquemas Esquemas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    string codigo = Reader["Codigo"].ToString().Trim();
                    string nombre = Reader["Nombre"].ToString().Trim();

                    Esquema.Codigo = codigo;
                    Esquema.Nombre = nombre;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConexionDB.CloseConexion(Command);
            return Esquema;
        }

        public Ent_VwContratistas VwContratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Codigo"].ToString().Trim());
                    string nombre = Reader["Nombre"].ToString().Trim();

                    VwContratista.Id = id;
                    VwContratista.Nombre = nombre;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConexionDB.CloseConexion(Command);
            return VwContratista;
        }

        public Ent_TblMinasContratos ContratosMinas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                    int idmina = Convert.ToInt32(Reader["IdMina"].ToString().Trim());
                    int codigoesquema = Convert.ToInt32(Reader["CodigoEsquema"].ToString().Trim());
                    int idcontratista = Convert.ToInt32(Reader["IdContratista"].ToString().Trim());
                    string detalle = Reader["Detalle"].ToString().Trim();
                    DateTime fecha = Convert.ToDateTime(Reader["Fecha"].ToString().Trim());
                    DateTime inscripcion = Convert.ToDateTime(Reader["Inscripcion"].ToString().Trim());
                    DateTime vencimiento = Convert.ToDateTime(Reader["Vencimiento"].ToString().Trim());
                    double recuperacion = Convert.ToDouble(Reader["Recuperacion"].ToString().Trim());
                    double fondo = Convert.ToDouble(Reader["Fondo"].ToString().Trim());
                    double impuesto = Convert.ToDouble(Reader["Impuestos"].ToString().Trim());
                    int duracion = Convert.ToInt32(Reader["Duracion"].ToString().Trim());
                    bool tenores = Convert.ToBoolean(Reader["Tenores"].ToString().Trim());
                    bool anexoseguridad = Convert.ToBoolean(Reader["AnexoSeguridad"].ToString().Trim());
                    bool explosivos = Convert.ToBoolean(Reader["Explosivos"].ToString().Trim());
                    bool devolucionfondo = Convert.ToBoolean(Reader["DevolucionFondo"].ToString().Trim());
                    DateTime realizado = Convert.ToDateTime(Reader["Realizado"].ToString().Trim());
                    string maquina = Reader["Maquina"].ToString().Trim();
                    int usuario = Convert.ToInt32(Reader["Usuario"].ToString().Trim());

                    MinaContrato.Id = id;
                    MinaContrato.IdMina = idmina;
                    MinaContrato.CodigoEsquema = codigoesquema;
                    MinaContrato.IdContratista = idcontratista;
                    MinaContrato.Detalle = detalle;
                    MinaContrato.Fecha = fecha;
                    MinaContrato.Inscripcion = inscripcion;
                    MinaContrato.Vencimiento = vencimiento;
                    MinaContrato.Recuperacion = recuperacion;
                    MinaContrato.Fondo = fondo;
                    MinaContrato.Impuestos = impuesto;
                    MinaContrato.Duracion = duracion;
                    MinaContrato.Tenores = tenores;
                    MinaContrato.AnexoSeguridad = anexoseguridad;
                    MinaContrato.Explosivos = explosivos;
                    MinaContrato.DevolucionFondo = devolucionfondo;
                    MinaContrato.Realizado = realizado;
                    MinaContrato.Maquina = maquina;
                    MinaContrato.Usuario = usuario;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return MinaContrato;
        }

        public Ent_Periodos Periodos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                if (Reader.Read())
                {
                    int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                    string fechainicial = Reader["FechaInicial"].ToString().Trim();
                    string fechafinal = Reader["FechaFinal"].ToString().Trim();
                    int estado = Convert.ToInt32(Reader["Estado"].ToString().Trim());
                    double trm = Convert.ToDouble(Reader["TRM"].ToString().Trim());
                    double oro = Convert.ToDouble(Reader["ORO"].ToString().Trim());
                    int trmespecial = Convert.ToInt32(Reader["TrmEspecial"].ToString().Trim());
                    double recuperacionreportada = Convert.ToDouble(Reader["RecuperacionReportada"].ToString().Trim());
                    double recuperacioncalculada = Convert.ToDouble(Reader["RecuperacionCalculada"].ToString().Trim());
                    double costoplanta = Convert.ToDouble(Reader["CostoPlanta"].ToString().Trim());
                    double ozcircuito = Convert.ToDouble(Reader["OzCircuito"].ToString().Trim());
                    double regalias = Convert.ToDouble(Reader["Regalias"].ToString().Trim());
                    string titulo = Reader["Titulo"].ToString().Trim();

                    Periodo.Id = id;
                    Periodo.FechaInicial = fechainicial;
                    Periodo.FechaFinal = fechafinal;
                    Periodo.Estado = estado;
                    Periodo.TRM = trm;
                    Periodo.ORO = oro;
                    Periodo.TRMEspecial = trmespecial;
                    Periodo.RecuperacionReportada = recuperacionreportada;
                    Periodo.RecuperacionCalculada = recuperacioncalculada;
                    Periodo.CostoPlanta = costoplanta;
                    Periodo.OzCircuito = ozcircuito;
                    Periodo.Regalias = regalias;
                    Periodo.Titulo = titulo;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Periodo;
        }

        public Ent_ImagenPublicidad ImagenPublicidad()
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", "ImagenPublicidad");
            ParamSQL[1] = new SqlParameter("@ParametroChar", string.Empty);
            ParamSQL[2] = new SqlParameter("@ParametroInt", "0");
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", "0.00");

            SqlCommand Command = new SqlCommand("SpConsulta_Tablas", Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in ParamSQL)
                Command.Parameters.Add(item).Value = item.Value;

            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            try
            {
                if (Reader.Read())
                {
                    byte[] logo1 = (byte[])Reader["Logo1"];
                    byte[] logo2 = (byte[])Reader["Logo2"];

                    Logo.Logo1 = logo1;
                    Logo.Logo2 = logo2;
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexionDB.CloseConexion(Command);
            return Logo;

        }

        public static Ent_PersonalMuestreo PersonalMuestreo(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] Parametros = new SqlParameter[4];
            Parametros[0] = new SqlParameter("@Op", Op);
            Parametros[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            Ent_PersonalMuestreo Return = new Ent_PersonalMuestreo();

            SqlCommand Command = new SqlCommand("SpConsulta_Tablas", Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            System.Text.ASCIIEncoding Texto = new System.Text.ASCIIEncoding();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString());
                string identificacacion = Reader["Identificacacion"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                string apellido = Reader["Apellido"].ToString().Trim();
                string direccion = Reader["Direccion"].ToString().Trim();
                string telfijo = Reader["TelFijo"].ToString().Trim();
                string celular = Reader["Celular"].ToString().Trim();
                string email = Reader["Email"].ToString().Trim();
                int rol = Convert.ToInt32(Reader["Rol"].ToString());
                DateTime Create = Convert.ToDateTime(Reader["Creado"].ToString());
                bool estate= Convert.ToBoolean(Reader["Estado"].ToString());

                Return.Id = id;
                Return.Identificacacion = identificacacion;
                Return.Nombre = nombre;
                Return.Apellido = apellido;
                Return.Direccion = direccion;
                Return.TelFijo = telfijo;
                Return.Celular = celular;
                Return.Email = email;
                Return.Rol= rol;
                Return.Create = Create;
                Return.Estado = estate;

            }
            ConexionDB.CloseConexion(Command);
            return Return;
        }


        public static List<Ent_Localizacion> ObtenerLocalizacion(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            if (!String.IsNullOrEmpty(ParametroChar.Trim()))
            {
                SqlParameter[] Parametros = new SqlParameter[4];
                Parametros[0] = new SqlParameter("@Op", Op);
                Parametros[1] = new SqlParameter("@ParametroChar", ParametroChar);
                Parametros[2] = new SqlParameter("@ParametroInt", ParametroInt);
                Parametros[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
                Ent_PersonalMuestreo Return = new Ent_PersonalMuestreo();

                SqlCommand Command = new SqlCommand("SpConsulta_Tablas", Conexion.OpenConexion());
                Command.CommandType = CommandType.StoredProcedure;
                foreach (var item in Parametros)
                    Command.Parameters.Add(item).Value = item.Value;
                System.Text.ASCIIEncoding Texto = new System.Text.ASCIIEncoding();
                using (IDataReader reader = Command.ExecuteReader())
                {
                    List<Ent_Localizacion> pesajeMineral = new List<Ent_Localizacion>();
                    IList<Ent_Localizacion> list = pesajeMineral;
                    list.LoadFromReader(reader);

                    ConexionDB.CloseConexion(Command);
                    return list.ToList();
                }
                ConexionDB.CloseConexion(Command);
                return null;

            }
            else
                return new List<Ent_Localizacion>();
        }

        public List<Ent_RelacionTipoOrigenDestino> TipoOrigenDestino(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_RelacionTipoOrigenDestino> ListReturn = new List<Ent_RelacionTipoOrigenDestino>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    int idtipo = Convert.ToInt32(Reader["IdTipo"]);
                    string codigotipomineral = Reader["CodigoTipoMineral"].ToString().Trim();
                    string nombretipomineral = Reader["NombreTipoMineral"].ToString().Trim();
                    int idorigen = Convert.ToInt32(Reader["IdOrigen"]);
                    string codigoorigen = Reader["CodigoOrigen"].ToString().Trim();
                    string nombreorigen = Reader["NombreOrigen"].ToString().Trim();
                    int iddestino = Convert.ToInt32(Reader["IdDestino"]);
                    string codigodestino = Reader["CodigoDestino"].ToString().Trim();
                    string nombredestino = Reader["NombreDestino"].ToString().Trim();
                    bool estado = Convert.ToBoolean(Reader["Estado"].ToString().Trim());
                    Ent_RelacionTipoOrigenDestino RelTipo = new Ent_RelacionTipoOrigenDestino();

                    RelTipo.IdTipo = idtipo;
                    RelTipo.CodigoTipoMineral = codigotipomineral;
                    RelTipo.NombreTipoMineral = nombretipomineral;
                    RelTipo.IdOrigen = idorigen;
                    RelTipo.CodigoOrigen = codigoorigen;
                    RelTipo.NombreOrigen = nombreorigen;
                    RelTipo.IdDestino = iddestino;
                    RelTipo.CodigoDestino = codigodestino;
                    RelTipo.NombreDestino = nombredestino;
                    RelTipo.Estado = estado;
                    ListReturn.Add(RelTipo);
                }
            }
            catch (Exception Sello)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Sello.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_Minas> ListMinas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Minas> ListReturn = new List<Ent_Minas>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                Ent_Minas Mina = new Ent_Minas();

                Mina.Codigo = codigo;
                Mina.Nombre = nombre;
                ListReturn.Add(Mina);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_VwMinas> ListVwMinas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_VwMinas> ListReturn = new List<Ent_VwMinas>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                int idexpediente = Convert.ToInt32(Reader["IdExpediente"].ToString().Trim());
                string expediente = Reader["Expediente"].ToString().Trim();
                double este = Convert.ToDouble(Reader["Este"].ToString().Trim());
                double norte = Convert.ToDouble(Reader["Norte"].ToString().Trim());
                double elevacion = Convert.ToDouble(Reader["Elevacion"].ToString().Trim());
                bool deshabilitado = Convert.ToBoolean(Reader["deshabilitado"].ToString().Trim());
                DateTime fechacreacion = Convert.ToDateTime(Reader["FechaCreacion"].ToString().Trim());

                Ent_VwMinas VwMina = new Ent_VwMinas();

                VwMina.Id = id;
                VwMina.Codigo = codigo;
                VwMina.Nombre = nombre;
                VwMina.IdExpediente = idexpediente;
                VwMina.Expediente = expediente;
                VwMina.Este = este;
                VwMina.Norte = norte;
                VwMina.Elevacion = elevacion;
                VwMina.Deshabilitado = deshabilitado;
                VwMina.FechaCreacion = fechacreacion;

                ListReturn.Add(VwMina);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_VwTipoContrato> ListVwTipoContrato(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_VwTipoContrato> ListReturn = new List<Ent_VwTipoContrato>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                bool deshabilitado = Convert.ToBoolean(Reader["deshabilitado"].ToString().Trim());
                DateTime fechacreacion = Convert.ToDateTime(Reader["FechaCreacion"].ToString().Trim());
                Ent_VwTipoContrato VwTipoContrato = new Ent_VwTipoContrato();

                VwTipoContrato.Id = id;
                VwTipoContrato.Codigo = codigo;
                VwTipoContrato.Nombre = nombre;
                VwTipoContrato.Deshabilitado = deshabilitado;
                VwTipoContrato.FechaCreacion = fechacreacion;
                ListReturn.Add(VwTipoContrato);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_Contenedores> ListContenedores(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Contenedores> ListReturn = new List<Ent_Contenedores>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;

            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                Ent_Contenedores Contenedor = new Ent_Contenedores();

                Contenedor.Codigo = codigo;
                Contenedor.Nombre = nombre;
                ListReturn.Add(Contenedor);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_TiposDeEmpresa> ListaTiposDeEmpresa(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_TiposDeEmpresa> ListReturn = new List<Ent_TiposDeEmpresa>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                Ent_TiposDeEmpresa TiposDeEmpresa = new Ent_TiposDeEmpresa();

                TiposDeEmpresa.Id = id;
                TiposDeEmpresa.Codigo = codigo;
                TiposDeEmpresa.Nombre = nombre;
                ListReturn.Add(TiposDeEmpresa);
            }

            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_Esquemas> ListaEsquemas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Esquemas> ListReturn = new List<Ent_Esquemas>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                string codigo = Reader["Codigo"].ToString().Trim();
                string nombre = Reader["Nombre"].ToString().Trim();
                Ent_Esquemas Esquema = new Ent_Esquemas();

                Esquema.Codigo = codigo;
                Esquema.Nombre = nombre;
                ListReturn.Add(Esquema);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_VwContratistas> ListaVwContratistas(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_VwContratistas> ListReturn = new List<Ent_VwContratistas>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                string nombre = Reader["Nombre"].ToString().Trim();
                Ent_VwContratistas Contratista = new Ent_VwContratistas();

                Contratista.Id = id;
                Contratista.Nombre = nombre;
                ListReturn.Add(Contratista);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }

        public List<Ent_Periodos> ListPeriodos(string SP_Consulta, SqlParameter[] SP_Parametros)
        {
            List<Ent_Periodos> ListReturn = new List<Ent_Periodos>();
            SqlCommand Command = new SqlCommand(SP_Consulta, Conexion.OpenConexion());
            Command.CommandType = CommandType.StoredProcedure;
            foreach (var item in SP_Parametros)
                Command.Parameters.Add(item).Value = item.Value;
            SqlDataReader Reader;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                int id = Convert.ToInt32(Reader["Id"].ToString().Trim());
                //string fechainicial = Reader["FechaInicial"].ToString().Trim();
                //string fechafinal = Reader["FechaFinal"].ToString().Trim();
                //int estado = Convert.ToInt32(Reader["Estado"].ToString().Trim());
                //double trm = Convert.ToDouble(Reader["TRM"].ToString().Trim());
                //double oro = Convert.ToDouble(Reader["ORO"].ToString().Trim());
                //int trmespecial = Convert.ToInt32(Reader["TrmEspecial"].ToString().Trim());
                //double recuperacionreportada = Convert.ToDouble(Reader["RecuperacionReportada"].ToString().Trim());
                //double recuperacioncalculada = Convert.ToDouble(Reader["RecuperacionCalculada"].ToString().Trim());
                //double costoplanta = Convert.ToDouble(Reader["CostoPlanta"].ToString().Trim());
                //double ozcircuito = Convert.ToDouble(Reader["OzCircuito"].ToString().Trim());
                //double regalias = Convert.ToDouble(Reader["Regalias"].ToString().Trim());
                string titulo = Reader["Titulo"].ToString().Trim();
                Ent_Periodos Periodo = new Ent_Periodos();

                Periodo.Id = id;
                //Periodo.FechaInicial = fechainicial;
                //Periodo.FechaFinal = fechafinal;
                //Periodo.Estado = estado;
                //Periodo.TRM = trm;
                //Periodo.ORO = oro;
                //Periodo.TRMEspecial = trmespecial;
                //Periodo.RecuperacionReportada = recuperacionreportada;
                //Periodo.RecuperacionCalculada = recuperacioncalculada;
                //Periodo.CostoPlanta = costoplanta;
                //Periodo.OzCircuito = ozcircuito;
                //Periodo.Regalias = regalias;
                Periodo.Titulo = titulo;

                ListReturn.Add(Periodo);
            }
            ConexionDB.CloseConexion(Command);
            return ListReturn;
        }


    }
}
