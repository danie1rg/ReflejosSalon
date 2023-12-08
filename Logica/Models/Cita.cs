using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cita
    {
      public int CitaID { get; set; }
      public DateTime Fecha { get; set; }
      public string Hora_Inicio { get; set; }
      public string  Hora_Fin { get; set; }
      public Usuario MiUsuario { get; set; }
      public Profesional MiProfesional { get; set; }
     public Cliente MiCliente { get; set; }
     public EstadoDeCita MiEstadoDeCita { get; set; }

        public Servicio MiServicio { get; set; }

        public Cita() 
        {
            MiUsuario = new Usuario();  
            MiCliente = new Cliente();
            MiServicio = new Servicio();
            MiProfesional = new Profesional();
            MiEstadoDeCita = new EstadoDeCita();

        }

        public bool Agregar()
        {
            bool respuesta = false;

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@HoraInicio", this.Hora_Inicio));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@HoraFin", this.Hora_Fin));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDUsuario", this.MiUsuario.UserId));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDCliente", this.MiCliente.CodigoCliente));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDProfesional", this.MiProfesional.CodigoProfesional));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDEstadoCita", this.MiEstadoDeCita.CodigoEstadoCita));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDServicio", this.MiServicio.CodigoServicio));



            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPCitaAgregar");

            if (resultado > 0)
            {
                respuesta = true;
            }

            return respuesta;

        }

        public DataTable ListarPorEstado(int codigoEstado)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@codigo", codigoEstado));

            R = MiCnn.EjecutarSELECT("SPCitaListarPorEstado");

            return R;
        }
        public DataTable ListarPorServicio(int codigoEstado)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@codigo", codigoEstado));

            R = MiCnn.EjecutarSELECT("SPCitaListarPorServicio");

            return R;
        }

        public DataTable ListarPorFecha(DateTime fecha)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@fecha", fecha));

            R = MiCnn.EjecutarSELECT("SPCitaListarPorFecha");

            return R;
        }

        public DataTable ListarPorDia()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSELECT("SPCitaListarPorDia");

            return R;
        }

        public DataTable ListarPorSemana()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSELECT("SPCitaListarPorSemana");

            return R;
        }

        public Cita ConsultarPorIDRetornaCita()
        {
            Cita R = new Cita();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CitaID));

            //necesito un datatable para capturar la info del usuario 
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPCitaConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.CitaID = Convert.ToInt32(dr["CitaID"]);
                R.Fecha = Convert.ToDateTime(dr["Fecha"]);
                R.Hora_Inicio = Convert.ToString(dr["Hora_Inicio"]);
                R.Hora_Fin = Convert.ToString(dr["Hora_Fin"]);
               
                //composiciones
                R.MiCliente.CodigoCliente = Convert.ToInt32(dr["CodigoCliente"]);
                R.MiCliente.Nombre = Convert.ToString(dr["NOMBRECLIENTE"]);
               
                R.MiProfesional.CodigoProfesional = Convert.ToInt32(dr["codigoProfesional"]);
                R.MiProfesional.Nombre = Convert.ToString(dr["NOMBREPROFESIONAL"]);

                R.MiEstadoDeCita.CodigoEstadoCita = Convert.ToInt32(dr["codigoEstadoCita"]);
                R.MiEstadoDeCita.Descripcion = Convert.ToString(dr["Descripcion"]);

                R.MiServicio.CodigoServicio = Convert.ToInt32(dr["CodigoServicio"]);
                R.MiServicio.Descripcion = Convert.ToString(dr["ServicioDescripcion"]);

            }


            return R;
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            Crypto MiEncrip = new Crypto();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));


            MiCnn.ListaDeParametros.Add(new SqlParameter("@HoraInicio", this.Hora_Inicio));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@HoraFin", this.Hora_Fin));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDCliente", this.MiCliente.CodigoCliente));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDProfesional", this.MiProfesional.CodigoProfesional));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDEstadoCita", this.MiEstadoDeCita.CodigoEstadoCita));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDServicio", this.MiServicio.CodigoServicio));


            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CitaID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPCitaModificar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }


    }
}
