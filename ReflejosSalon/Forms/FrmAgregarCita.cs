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
    public partial class FrmAgregarCita : Form
    {
        public Cita MiCitaLocal { get; set; }

        public DataTable ListaEstados { get; set; }

        public DataTable ListaServicios { get; set; }

        public FrmAgregarCita()
        {
            InitializeComponent();
            MiCitaLocal = new Cita();
            ListaEstados = new DataTable();
            ListaServicios = new DataTable();

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

        private void FrmAgregarCita_Load(object sender, EventArgs e)
        {
            CargarListaEstados();
            CargarListaServicios();
            AgregarOEditar();
        }

        private void Limpiar() 
        {
            TxtCliente.Text = "";
            TxtProfesional.Text = string.Empty;
            
        }

        private void AgregarOEditar() 
        {
            if (MiCitaLocal.CitaID != 0)
            {
                BtnAgregar.Text = "Editar";
                MiCitaLocal = MiCitaLocal.ConsultarPorIDRetornaCita();

                TxtCliente.Text = MiCitaLocal.MiCliente.Nombre;
                TxtProfesional.Text = MiCitaLocal.MiProfesional.Nombre;
                DtFecha.Value = MiCitaLocal.Fecha;
                CbEstado.SelectedValue = MiCitaLocal.MiEstadoDeCita.CodigoEstadoCita;
                CbServicio.SelectedValue = MiCitaLocal.MiServicio.CodigoServicio;
                DtHoraInicio.Value = Convert.ToDateTime(MiCitaLocal.Hora_Inicio);
                DtHoraFin.Value = Convert.ToDateTime(MiCitaLocal.Hora_Fin);

            }
            
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            Form FormClienteBuscar = new FrmClienteBuscar();

            DialogResult respuesta = FormClienteBuscar.ShowDialog();

            if (respuesta == DialogResult.OK) 
            {
                TxtCliente.Text = MiCitaLocal.MiCliente.Nombre + " " + MiCitaLocal.MiCliente.Apellidos;

            }

        }

        private void BtnBuscarProfesional_Click(object sender, EventArgs e)
        {
            Form FormProfesionalBuscar = new FrmProfesionalBuscar();

            DialogResult respuesta = FormProfesionalBuscar.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                TxtProfesional.Text = MiCitaLocal.MiProfesional.Nombre + " " + MiCitaLocal.MiProfesional.Apellido;

            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados() && BtnAgregar.Text == "Agregar")
            {

                MiCitaLocal.MiServicio.CodigoServicio = Convert.ToInt32(CbServicio.SelectedValue);
                MiCitaLocal.Fecha = DtFecha.Value.Date;
                MiCitaLocal.Hora_Inicio = DtHoraInicio.Value.TimeOfDay.ToString();
                MiCitaLocal.Hora_Fin = DtHoraFin.Value.TimeOfDay.ToString();
                MiCitaLocal.MiUsuario.UserId = Globales.MiUsuarioGlobal.UserId;
                MiCitaLocal.MiEstadoDeCita.CodigoEstadoCita = Convert.ToInt32(CbEstado.SelectedValue);



                if (MiCitaLocal.Agregar())
                {
                    MessageBox.Show("Cita creada correctamente", ":)", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;
                    Limpiar();
                }
            } else 
            {
                MiCitaLocal.MiServicio.CodigoServicio = Convert.ToInt32(CbServicio.SelectedValue);
                MiCitaLocal.Fecha = DtFecha.Value.Date;
                MiCitaLocal.Hora_Inicio = DtHoraInicio.Value.TimeOfDay.ToString();
                MiCitaLocal.Hora_Fin = DtHoraFin.Value.TimeOfDay.ToString();
                MiCitaLocal.MiEstadoDeCita.CodigoEstadoCita = Convert.ToInt32(CbEstado.SelectedValue);

                if (MiCitaLocal.Editar()) 
                {
                    MessageBox.Show("Cita modificada correctamente", ":)", MessageBoxButtons.OK);
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            

        }

        private bool ValidarDatosDigitados()
        {
            bool r = true;


            if (string.IsNullOrEmpty(TxtCliente.Text.Trim()))
            {
                MessageBox.Show("Debe de seleccionar un cliente", "Error de validación", MessageBoxButtons.OK);
                TxtCliente.Focus();
                return false;
            }

            if (CbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un estado de cita", "Error de validación", MessageBoxButtons.OK);
                CbEstado.Focus();
                return false;
            }

            if (CbServicio.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un servicio para la cita", "Error de validación", MessageBoxButtons.OK);
                CbServicio.Focus();
                return false;
            }

            return r;

        }


    }
}
