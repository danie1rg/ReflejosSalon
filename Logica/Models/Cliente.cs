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
    public class Cliente
    {
        public int CodigoCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public bool Estado { get; set; }

        public bool Agregar()
        {
            bool respuesta = false;

            Conexion MiCnn = new Conexion();

           
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Apellidos", this.Apellidos));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Celular", this.Telefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPClienteAgregar");

            if (resultado > 0)
            {
                respuesta = true;
            }

            return respuesta;

        }

        public bool ConsultarPorEmail()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@correo", this.Correo));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPClienteConsultarPorCorreo");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Apellidos", this.Apellidos));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Celular", this.Telefono));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoCliente));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPClienteModificar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoCliente));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPClienteConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;

            }

            return R;
        }

        public Cliente ConsultarPorIDRetornaCliente()
        {
            Cliente R = new Cliente();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoCliente));

            //necesito un datatable para capturar la info del usuario 
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPClienteConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.CodigoCliente = Convert.ToInt32(dr["CodigoCliente"]);
                R.Nombre = Convert.ToString(dr["Nombre"]);
                R.Apellidos = Convert.ToString(dr["Apellidos"]);

                R.Correo = Convert.ToString(dr["Correo"]);

                R.Telefono = Convert.ToString(dr["Celular"]);

                
            }


            return R;
        }

        public DataTable Listar(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPClienteListar");

            return R;

        }

    }
}
