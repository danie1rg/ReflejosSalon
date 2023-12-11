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
    public partial class FrmGestionCliente : Form
    {
        private Logica.Models.Cliente MiClienteLocal { get; set; }

        private DataTable ListaClientes { get; set; }
        public FrmGestionCliente()
        {
            InitializeComponent();
            ListaClientes = new DataTable();
            MiClienteLocal = new Cliente();
        }

        private void FrmGestionCliente_Load(object sender, EventArgs e)
        {
            CargarLista();
            ActivarAgregar();
        }

        private void CargarLista()
        {
            ListaClientes = new DataTable();
            string FiltroBusqueda = "";

            if (TxtBuscar.Text.Trim() != "Buscar" && TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
                ListaClientes = MiClienteLocal.Listar(FiltroBusqueda);
            }
            ListaClientes = MiClienteLocal.Listar(FiltroBusqueda);


            DtVista.DataSource = ListaClientes;
            DtVista.ClearSelection();
        }

        private bool ValidarDatosDigitados()
        {
            bool r = true;


            if (string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar un nombre para el cliente", "Error de validación", MessageBoxButtons.OK);
                TxtNombre.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtApellidos.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar un apellido para el cliente", "Error de validación", MessageBoxButtons.OK);
                TxtApellidos.Focus();
                return false;
            }

            
            if (string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar un télefono para el cliente", "Error de validación", MessageBoxButtons.OK);
                TxtTelefono.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar un correo para el cliente", "Error de validación", MessageBoxButtons.OK);
                TxtCorreo.Focus();
                return false;
            }

            

            return r;

        }

        private void LimpiarForm()
        {
            TxtNombre.Clear();
            TxtCorreo.Clear();
            TxtTelefono.Clear();
            TxtApellidos.Clear();
            DtVista.ClearSelection();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                bool EmailOK;


                MiClienteLocal = new Logica.Models.Cliente();

                MiClienteLocal.Nombre = TxtNombre.Text.Trim();
                MiClienteLocal.Correo = TxtCorreo.Text.Trim();
                MiClienteLocal.Apellidos = TxtApellidos.Text.Trim();
                MiClienteLocal.Telefono = TxtTelefono.Text.Trim();


                EmailOK = MiClienteLocal.ConsultarPorEmail();
   
                if (EmailOK == false)
                {
                    string msg = string.Format("¿Está seguro que desea agregar al cliente {0}?", MiClienteLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiClienteLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("El cliente se guardo correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();

                            CargarLista();
                        }
                        else
                        {
                            MessageBox.Show("El cliente no se pudo guardar correctamente!", ":(", MessageBoxButtons.OK);
                        }


                    }
                }
                else
                {

                    if (EmailOK)
                    {
                        MessageBox.Show("Ya existe un cliente con el correo digitado", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }

                   

                }

            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista();
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
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {


                MiClienteLocal.Nombre = TxtNombre.Text.Trim();
                MiClienteLocal.Correo = TxtCorreo.Text.Trim();
                MiClienteLocal.Apellidos = TxtApellidos.Text.Trim();
                MiClienteLocal.Telefono = TxtTelefono.Text.Trim();

                if (MiClienteLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar este cliente?", "???",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiClienteLocal.Editar())
                        {
                            MessageBox.Show("El cliente ha sido modificado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            ActivarAgregar();
                            CargarLista();
                        }
                    }

                }
            }
        }

        private void DtVista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int ID = Convert.ToInt32(Mifila.Cells["CCodigoCliente"].Value);

                MiClienteLocal = new Logica.Models.Cliente();

                MiClienteLocal.CodigoCliente = ID;

                MiClienteLocal = MiClienteLocal.ConsultarPorIDRetornaCliente();

                if (MiClienteLocal != null && MiClienteLocal.CodigoCliente > 0)
                {
                    TxtNombre.Text = MiClienteLocal.Nombre;
                    TxtApellidos.Text = MiClienteLocal.Apellidos;
                    TxtCorreo.Text = MiClienteLocal.Correo;
                    TxtTelefono.Text = MiClienteLocal.Telefono;


                    ActivarEditarEliminar();
                }

            }
        }

        private void DtVista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtVista.ClearSelection();
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void TxtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
            {
                if (!Validation.ValidarEmail(TxtCorreo.Text.Trim()))
                {
                    MessageBox.Show("El formato del correo es incorrecto", "Error de validación", MessageBoxButtons.OK);
                    TxtCorreo.Focus();
                }
            }
        }
    }
}
