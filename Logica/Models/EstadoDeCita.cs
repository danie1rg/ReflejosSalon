using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class EstadoDeCita
    {

        public int CodigoEstadoCita { get; set; }

        public String Descripcion { get; set; }

        //Funciones
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Services.Conexion MiCnn = new Services.Conexion();

            R = MiCnn.EjecutarSELECT("SPEstadoDeCitaListar");

            return R;
        }

    }
}
