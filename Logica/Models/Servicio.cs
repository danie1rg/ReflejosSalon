using Logica.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Servicio
    {
        public int CodigoServicio { get; set; }

        public string Descripcion { get; set; }


        public bool Agregar()
        {
            bool respuesta = false;

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));


            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPServicioAgregar");

            if (resultado > 0)
            {
                respuesta = true;
            }

            return respuesta;

        }

        public bool ConsultarPorDescripcion()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPServicioConsultarPorDescripcion");

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



            MiCnn.ListaDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));


            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoServicio));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPServicioModificar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoServicio));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPServicioConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;

            }

            return R;
        }

        public Servicio ConsultarPorIDRetornaServicio()
        {
            Servicio R = new Servicio();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoServicio));

            //necesito un datatable para capturar la info del usuario 
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPServicioConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.CodigoServicio = Convert.ToInt32(dr["CodigoServicio"]);
                R.Descripcion = Convert.ToString(dr["Descripcion"]);

            }


            return R;
        }

        public DataTable Listar(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPServicioListar");

            return R;

        }

        public DataTable ListarServicio()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSELECT("SPServiciosListar");

            return R;

        }
    }
}
