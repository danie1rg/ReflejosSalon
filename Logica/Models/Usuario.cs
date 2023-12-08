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
    public class Usuario
    {
        public int UserId { get; set; }
        public String Correo { get; set; }
        public String Password { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public bool Estado { get; set; }
        public UsuarioRol MiUsuarioRol { get; set; }

        public Usuario()
        {
            MiUsuarioRol = new UsuarioRol();
        }

        public bool Agregar()
        {
            bool respuesta = false;

            Conexion MiCnn = new Conexion();

            Crypto MiEncrip = new Crypto();

            string ContrasenniaEncriptada = MiEncrip.EncriptarEnUnSentido(this.Password);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Password", ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDRol", this.MiUsuarioRol.UserRolID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioAgregar");

            if (resultado > 0)
            {
                respuesta = true;
            }

            return respuesta;

        }

        public Usuario ValidarUsuario(string pCorreo, string pPassword)
        {

            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            Crypto crypto = new Crypto();
            string ContrasenniaEncriptada = crypto.EncriptarEnUnSentido(pPassword);

            MiCnn.ListaDeParametros.Add(new SqlParameter("@correo", pCorreo));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@password", ContrasenniaEncriptada));

            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioValidarIngreso");

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                R.UserId = Convert.ToInt32(dr["UserID"]);
                R.Nombre = Convert.ToString(dr["Nombre"]);
                R.Correo = Convert.ToString(dr["Correo"]);

                R.Password = string.Empty;

                //composiciones
                R.MiUsuarioRol.UserRolID = Convert.ToInt32(dr["UserRoleID"]);
                R.MiUsuarioRol.Descripcion = Convert.ToString(dr["Descripcion"]);

            }

            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@correo", this.Correo));

            DataTable consulta = new DataTable();
            consulta = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorCorreo");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool DesactivarUsuario()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UserId));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioDesactivar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }


        public bool ActivarUsuario()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UserId));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioActivar");

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

            string ContrasenniaEncriptada = MiEncrip.EncriptarEnUnSentido(this.Password);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDRol", this.MiUsuarioRol.UserRolID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UserId));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioModificar");

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

            R = MiCnn.EjecutarSELECT("SPUsuarioListar");

            return R;

        }
        public DataTable ListarInactivos(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@verActivos", false));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPUsuarioListar");

            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UserId));


            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;

            }

            return R;
        }

        public Usuario ConsultarPorIDRetornaUsuario()
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UserId));

            //necesito un datatable para capturar la info del usuario 
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                R.UserId = Convert.ToInt32(dr["UserID"]);
                R.Nombre = Convert.ToString(dr["Nombre"]);


                R.Correo = Convert.ToString(dr["Correo"]);

                R.Telefono = Convert.ToString(dr["Telefono"]);

                R.Password = string.Empty;

                //composiciones
                R.MiUsuarioRol.UserRolID= Convert.ToInt32(dr["UserRoleID"]);
                R.MiUsuarioRol.Descripcion = Convert.ToString(dr["Descripcion"]);

            }


            return R;
        }


    }
}
