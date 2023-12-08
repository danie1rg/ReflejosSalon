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
    public partial class FrmClienteBuscar : Form
    {
        DataTable ListaClientes { get; set; }
        Cliente MiClienteLocal { get; set; }
        public FrmClienteBuscar()
        {
            InitializeComponent();

            ListaClientes = new DataTable();
            MiClienteLocal = new Cliente();
        }

        private void CargarLista()
        {
            ListaClientes = new DataTable();
            string FiltroBusqueda = "";

            if (TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
                ListaClientes = MiClienteLocal.Listar(FiltroBusqueda);
            }
            ListaClientes = MiClienteLocal.Listar(FiltroBusqueda);


            DtVista.DataSource = ListaClientes;
            DtVista.ClearSelection();
        }


        private void FrmClienteBuscar_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int ID = Convert.ToInt32(Mifila.Cells["CCodigoCliente"].Value);
                string Nombre = Convert.ToString(Mifila.Cells["CNombre"].Value);
                string Apellidos = Convert.ToString(Mifila.Cells["CApellidos"].Value);

                Globales.MiAgregarCita.MiCitaLocal.MiCliente.CodigoCliente = ID;
                Globales.MiAgregarCita.MiCitaLocal.MiCliente.Nombre = Nombre;
                Globales.MiAgregarCita.MiCitaLocal.MiCliente.Apellidos = Apellidos;
                DialogResult = DialogResult.OK;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
