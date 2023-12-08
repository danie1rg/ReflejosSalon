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
    public class Profesional
    {
        public int CodigoProfesional { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public bool Estado { get; set; }

        public TipoProfesional MiTipoProfesional { get; set; }


        public Profesional() 
        {
            MiTipoProfesional = new TipoProfesional();
        }

        public bool Agregar()
        {
            bool respuesta = false;

            Conexion MiCnn = new Conexion();


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Apellidos", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDTipoProfesional", this.MiTipoProfesional.CodigoTipoProfesional));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProfesionalAgregar");

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
            consulta = MiCnn.EjecutarSELECT("SPProfesionalConsultarPorCorreo");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@cedula", this.Cedula));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPProfesionalConsultarPorCedula");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool DesactivarProfesional()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoProfesional));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProfesionalDesactivar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }


        public bool ActivarProfesional()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoProfesional));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProfesionalActivar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            Crypto MiEncrip = new Crypto();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Apellidos", this.Apellido));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDTipoProfesional", MiTipoProfesional.CodigoTipoProfesional));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoProfesional));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProfesionalModificar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public DataTable ListarActivos(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@verActivos", true));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPProfesionalListar");

            return R;

        }
        public DataTable ListarInactivos(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@verActivos", false));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPProfesionalListar");

            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoProfesional));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPProfesionalConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;

            }

            return R;
        }

        public Profesional ConsultarPorIDRetornaProfesional()
        {
            Profesional R = new Profesional();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.CodigoProfesional));

            //necesito un datatable para capturar la info del usuario 
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPProfesionalConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.CodigoProfesional = Convert.ToInt32(dr["codigoProfesional"]);
                R.Cedula = Convert.ToString(dr["Cedula"]);
                R.Nombre = Convert.ToString(dr["Nombre"]);
                R.Apellido = Convert.ToString(dr["Apellido"]);

                R.Correo = Convert.ToString(dr["Correo"]);

                R.Telefono = Convert.ToString(dr["Telefono"]);

                //composiciones
                R.MiTipoProfesional.CodigoTipoProfesional = Convert.ToInt32(dr["CodigoTipoProfesional"]);
                R.MiTipoProfesional.Descripcion = Convert.ToString(dr["Descripcion"]);

            }


            return R;
        }





    }
}
