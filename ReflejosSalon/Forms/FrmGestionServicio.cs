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
    public partial class FrmGestionServicio : Form
    {

        private Logica.Models.Servicio MiServicioLocal { get; set; }

        private DataTable ListaServicios { get; set; }
        public FrmGestionServicio()
        {
            InitializeComponent();
            ListaServicios = new DataTable();
            MiServicioLocal = new Servicio();
        }

        private bool ValidarDatosDigitados()
        {
            bool r = true;


            if (string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar una descripción para el servicio", "Error de validación", MessageBoxButtons.OK);
                TxtDescripcion.Focus();
                return false;
            }

            return r;

        }

        private void LimpiarForm()
        {
            TxtDescripcion.Clear();
            TxtCod.Clear();
            ActivarAgregar();

        }

        private void ActivarAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
        }

        private void ActivarEditarEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
        }

        private void CargarLista()
        {
            ListaServicios = new DataTable();
            string FiltroBusqueda = "";

            if (TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
                ListaServicios = MiServicioLocal.Listar(FiltroBusqueda);
            }
            ListaServicios = MiServicioLocal.Listar(FiltroBusqueda);


            DtVista.DataSource = ListaServicios;
            DtVista.ClearSelection();

        }

        private void FrmGestionServicio_Load(object sender, EventArgs e)
        {
            CargarLista();
            ActivarAgregar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                bool DescripcionOK;

                MiServicioLocal = new Logica.Models.Servicio();

                MiServicioLocal.Descripcion = TxtDescripcion.Text.Trim();



                DescripcionOK = MiServicioLocal.ConsultarPorDescripcion();

                if (DescripcionOK == false)
                {
                    string msg = string.Format("¿Está seguro que desea agregar el servicio {0}?", MiServicioLocal.Descripcion);

                    DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiServicioLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("El servicio se guardo correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();

                            CargarLista();
                        }
                        else
                        {
                            MessageBox.Show("El servicio no se pudo guardar correctamente!", ":(", MessageBoxButtons.OK);
                        }


                    }
                }
                else
                {

                    if (DescripcionOK)
                    {
                        MessageBox.Show("Ya existe un servicio", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }



                }

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {

                MiServicioLocal.Descripcion = TxtDescripcion.Text.Trim();

                if (MiServicioLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar?", "????",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiServicioLocal.Editar())
                        {
                            MessageBox.Show("El servicio ha sido modificado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            ActivarAgregar();
                            CargarLista();
                        }
                    }

                }
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void DtVista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int ID = Convert.ToInt32(Mifila.Cells["CCodigoServicio"].Value);

                MiServicioLocal = new Logica.Models.Servicio();

                MiServicioLocal.CodigoServicio = ID;

                MiServicioLocal = MiServicioLocal.ConsultarPorIDRetornaServicio();

                if (MiServicioLocal != null && MiServicioLocal.CodigoServicio > 0)
                {
                    TxtDescripcion.Text = MiServicioLocal.Descripcion;
                    TxtCod.Text = Convert.ToString(MiServicioLocal.CodigoServicio);

                    ActivarEditarEliminar();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            DtVista.ClearSelection();
        }
    }
}
