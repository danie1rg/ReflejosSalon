using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflejosSalon
{
    public class Globales
    {
        public static Form MiFormPrincipal = new Forms.FrmMDI();

        public static Forms.FrmGestionUsuario MiGestionUsaurio = new Forms.FrmGestionUsuario();

        public static Forms.FrmGestionCliente MiGestionCliente = new Forms.FrmGestionCliente();

        public static Forms.FrmGestionTipoProfesional MiGestionTipoProfesional = new Forms.FrmGestionTipoProfesional();

        public static Forms.FrmGestionProfesional MiGestionProfesional = new Forms.FrmGestionProfesional();

        public static Forms.FrmGestionServicio MiGestionServicio = new Forms.FrmGestionServicio();

        public static Forms.FrmAgregarCita MiAgregarCita = new Forms.FrmAgregarCita();

        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();

        public static Logica.Models.Cita MiCitaGlobal = new Logica.Models.Cita();


    }
}
