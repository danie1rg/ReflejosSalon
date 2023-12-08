using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflejosSalon.Forms
{
    public partial class FrmProfesionalBuscar : Form
    {
        private Logica.Models.Profesional MiProfesionalLocal { get; set; }
        private DataTable ListaProfesionales { get; set; }

        public FrmProfesionalBuscar()
        {
            InitializeComponent();
            MiProfesionalLocal = new Logica.Models.Profesional();
            ListaProfesionales = new DataTable();
        }

        private void CargarListaDeProfesionales()
        {
            ListaProfesionales = new DataTable();
            string FiltroBusqueda = "";

            if (TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
            }

            ListaProfesionales = MiProfesionalLocal.ListarActivos(FiltroBusqueda);

            DtVista.DataSource = ListaProfesionales;
            DtVista.ClearSelection();
        }

        private void FrmProfesionalBuscar_Load(object sender, EventArgs e)
        {
            CargarListaDeProfesionales();
        }



        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int Id = Convert.ToInt32(Mifila.Cells["CcodigoProfesional"].Value);
                String Nombre = Convert.ToString(Mifila.Cells["CNombre"].Value);
                String Apellido = Convert.ToString(Mifila.Cells["CApellido"].Value);

                Globales.MiAgregarCita.MiCitaLocal.MiProfesional.CodigoProfesional = Id;
                Globales.MiAgregarCita.MiCitaLocal.MiProfesional.Nombre = Nombre;
                Globales.MiAgregarCita.MiCitaLocal.MiProfesional.Apellido = Apellido;
                DialogResult = DialogResult.OK;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
