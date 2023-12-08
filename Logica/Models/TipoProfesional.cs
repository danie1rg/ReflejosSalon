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
    public class TipoProfesional
    {
        public int CodigoTipoProfesional { get; set; }

        public string Descripcion { get; set; }

        

        public bool Agregar()
        {
            bool respuesta = false;

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));
            

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPTipoProfesionalAgregar");

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
            consulta = MiCnn.EjecutarSELECT("SPTipoProfesionalConsultarPorDescripcion");

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
            

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoTipoProfesional));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPTipoProfesionalModificar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoTipoProfesional));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPTipoProfesionalConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;

            }

            return R;
        }

        public TipoProfesional ConsultarPorIDRetornaTipoProfesional()
        {
            TipoProfesional R = new TipoProfesional();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoTipoProfesional));

            //necesito un datatable para capturar la info del usuario 
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPTipoProfesionalConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.CodigoTipoProfesional = Convert.ToInt32(dr["codigoTipoProfesional"]);
                R.Descripcion = Convert.ToString(dr["Descripcion"]);

            }


            return R;
        }

        public DataTable Listar(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPTipoProfesionalListar");

            return R;

        }




    }
}
