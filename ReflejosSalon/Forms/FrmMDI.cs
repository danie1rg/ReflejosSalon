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
    public partial class FrmMDI : Form
    {
        public Cita MiCitaLocal { get; set; }

        public DataTable ListaEstados { get; set; }

        public DataTable ListaServicios { get; set; }

        DataTable ListaCitas { get; set; }
        public FrmMDI()
        {
            InitializeComponent();
            MiCitaLocal = new Cita();
            ListaEstados = new DataTable();
            ListaServicios = new DataTable();
            ListaCitas = new DataTable();
        }

        private void CargarListaEstados()
        {
            Logica.Models.EstadoDeCita MiEstado = new Logica.Models.EstadoDeCita();
            DataTable dt = new DataTable();
            dt = MiEstado.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                CbEstado.ValueMember = "ID";
                CbEstado.DisplayMember = "Descripcion";
                CbEstado.DataSource = dt;
                CbEstado.SelectedIndex = -1;
            }
        }

        private void CargarListaServicios()
        {
            Logica.Models.Servicio MiServicio = new Logica.Models.Servicio();
            DataTable dt = new DataTable();
            dt = MiServicio.Listar("");

            if (dt != null && dt.Rows.Count > 0)
            {
                CbServicio.ValueMember = "CodigoServicio";
                CbServicio.DisplayMember = "Descripcion";
                CbServicio.DataSource = dt;
                CbServicio.SelectedIndex = -1;
            }
        }

        private void gestiónDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiGestionUsaurio.Visible)
            {
                Globales.MiGestionUsaurio = new FrmGestionUsuario();

                Globales.MiGestionUsaurio.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void gestiónDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiGestionCliente.Visible)
            {
                Globales.MiGestionCliente = new FrmGestionCliente();

                Globales.MiGestionCliente.Show();
            }

        }

        private void gestiónDeTipoPorfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiGestionTipoProfesional.Visible)
            {
                Globales.MiGestionTipoProfesional = new FrmGestionTipoProfesional();

                Globales.MiGestionTipoProfesional.Show();
            }
        }

        private void gestiónDeProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiGestionProfesional.Visible)
            {
                Globales.MiGestionProfesional = new FrmGestionProfesional();

                Globales.MiGestionProfesional.Show();
            }
        }

        private void gestiónDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globales.MiGestionServicio.Visible)
            {
                Globales.MiGestionServicio = new FrmGestionServicio();

                Globales.MiGestionServicio.Show();
            }
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            CargarListaEstados();
            CargarListaServicios();
            CargarListaPorDia();

            switch(Globales.MiUsuarioGlobal.MiUsuarioRol.UserRolID)
            {
                case 1:
                    break;
                case 2:
                    gestiónDeUsuarioToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void BtnNuevaCita_Click(object sender, EventArgs e)
        {
            if (!Globales.MiAgregarCita.Visible)
            {
                Globales.MiAgregarCita = new FrmAgregarCita();

                Globales.MiAgregarCita.Show();
            }
        }

        private void CargarListaPorEstados()
        {
            ListaCitas = new DataTable();

            int x = Convert.ToInt32(CbEstado.SelectedValue);

            ListaCitas = MiCitaLocal.ListarPorEstado(x);

            DtVista.DataSource = ListaCitas;
            string y = Convert.ToString(CbEstado.Text);
            GBox2.Text = "Vista por " + y;

        }

        private void CargarListaPorFecha()
        {
            ListaCitas = new DataTable();

            DateTime x = DtTiempo.Value.Date;

            ListaCitas = MiCitaLocal.ListarPorFecha(x);

            DtVista.DataSource = ListaCitas;
            GBox2.Text = "Vista por " + x.DayOfWeek;
            DtVista.ClearSelection();

        }

        private void CargarListaPorServicios()
        {
            
            
            ListaCitas = new DataTable();

            int x = Convert.ToInt32(CbServicio.SelectedValue);

            ListaCitas = MiCitaLocal.ListarPorServicio(x);

            DtVista.DataSource = ListaCitas;
            string y = Convert.ToString(CbServicio.Text);
            GBox2.Text = "Vista por " + y;
            DtVista.ClearSelection();
        }
        private void CargarListaPorDia()
        {
            GBox2.Text = "Vista por día";
            ListaCitas = new DataTable();

            ListaCitas = MiCitaLocal.ListarPorDia();

            DtVista.DataSource = ListaCitas;
            DtVista.ClearSelection();

        }
        private void CargarListaPorSemana()
        {
            GBox2.Text = "Vista por semana";
            ListaCitas = new DataTable();

            ListaCitas = MiCitaLocal.ListarPorSemana();

            DtVista.DataSource = ListaCitas;
            DtVista.ClearSelection();

        }


        private void CbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListaPorEstados();
        }

        private void CbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarListaPorServicios();
        }

        private void BtnCitaDia_Click(object sender, EventArgs e)
        {
            CargarListaPorDia();
        }

        private void BtnSemana_Click(object sender, EventArgs e)
        {
            CargarListaPorSemana();
        }

        private void DtTiempo_ValueChanged(object sender, EventArgs e)
        {
            CargarListaPorFecha();
        }

        private void DtVista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtVista.ClearSelection();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int ClienteID = Convert.ToInt32(Mifila.Cells["CCitaID"].Value);

               
                if (!Globales.MiAgregarCita.Visible)
                {
                    Globales.MiAgregarCita = new FrmAgregarCita();
                    Globales.MiAgregarCita.MiCitaLocal.CitaID = ClienteID;
                   
                    
                    DialogResult resp = Globales.MiAgregarCita.ShowDialog();

                    if (resp == DialogResult.OK) 
                    {
                        CargarListaPorDia();
                    }


                }


            }
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
