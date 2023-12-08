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
    public partial class FrmGestionProfesional : Form
    {

        private Logica.Models.Profesional MiProfesionalLocal { get; set; }
        private DataTable ListaProfesionales { get; set; }
        public FrmGestionProfesional()
        {
            InitializeComponent();
            MiProfesionalLocal = new Profesional();
            ListaProfesionales = new DataTable();
        }

        private void DtVista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int Id = Convert.ToInt32(Mifila.Cells["CcodigoProfesional"].Value);

                MiProfesionalLocal = new Logica.Models.Profesional();

                MiProfesionalLocal.CodigoProfesional = Id;

                MiProfesionalLocal = MiProfesionalLocal.ConsultarPorIDRetornaProfesional();

                if (MiProfesionalLocal != null && MiProfesionalLocal.CodigoProfesional > 0)
                {
                    TxtNombre.Text = MiProfesionalLocal.Nombre;
                    TxtApellido.Text = MiProfesionalLocal.Apellido;
                    TxtCedula.Text =MiProfesionalLocal.Cedula;
                    TxtCorreo.Text = MiProfesionalLocal.Correo;
                    TxtTelefono.Text = MiProfesionalLocal.Telefono;

                    CbTipoProfesional.SelectedValue = MiProfesionalLocal.MiTipoProfesional.CodigoTipoProfesional;

                    ActivarEditarEliminar();
                }

            }
        }

        private void LimpiarForm()
        {
            TxtApellido.Text = "Apellido";
            TxtNombre.Text = "Nombre";
            TxtCedula.Text = "Cédula";
            TxtTelefono.Text = "Teléfono";
            TxtCorreo.Text = "Correo electrónico";
            CbTipoProfesional.SelectedIndex = -1;
        }

        private void ActivarAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void ActivarEditarEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
        }

        private bool ValidarDatosDigitados()
        {
            bool r = true;

            
               if (string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe de digitar un nombre para el trabajador", "Error de validación", MessageBoxButtons.OK);
                    TxtNombre.Focus();
                    return false;
                }
            if (string.IsNullOrEmpty(TxtCedula.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar una cédula para el trabajador", "Error de validación", MessageBoxButtons.OK);
                TxtCedula.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtApellido.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar un apellido para el trabajador", "Error de validación", MessageBoxButtons.OK);
                TxtApellido.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
                {
                    MessageBox.Show("Debe de digitar un correo para el trabajador", "Error de validación", MessageBoxButtons.OK);
                    TxtCorreo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
                {
                    MessageBox.Show("Debe de digitar un teléfono para el trabajador", "Error de validación", MessageBoxButtons.OK);
                    TxtTelefono.Focus();
                    return false;
                }

                if (CbTipoProfesional.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe de digitar un rol para el usuario", "Error de validación", MessageBoxButtons.OK);
                    CbTipoProfesional.Focus();
                    return false;
                }


            

            return r;

        }

        private void CargarListaDeProfesionales()
        {
            ListaProfesionales = new DataTable();
            string FiltroBusqueda = "";

            if (TxtBuscar.Text.Trim() != "Buscar" && TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
            }

            if (CbActivos.Checked)
            {

                ListaProfesionales = MiProfesionalLocal.ListarActivos(FiltroBusqueda);
            }
            else
            {
                ListaProfesionales = MiProfesionalLocal.ListarInactivos(FiltroBusqueda);
            }

            DtVista.DataSource = ListaProfesionales;
            DtVista.ClearSelection();
        }

        private void CargarListaTipoProfesionales()
        {
            Logica.Models.TipoProfesional MiTipoProfesional = new Logica.Models.TipoProfesional();
            DataTable dt = new DataTable();
            String x = "";
            dt = MiTipoProfesional.Listar(x);

            if (dt != null && dt.Rows.Count > 0)
            {
                CbTipoProfesional.ValueMember = "codigoTipoProfesional";
                CbTipoProfesional.DisplayMember = "Descripcion";
                CbTipoProfesional.DataSource = dt;
                CbTipoProfesional.SelectedIndex = -1;
            }
        }

        private void FrmGestionProfesional_Load(object sender, EventArgs e)
        {
            CargarListaDeProfesionales();
            CargarListaTipoProfesionales();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                bool EmailOK;
                bool CedulaOK;

                MiProfesionalLocal = new Logica.Models.Profesional();

                MiProfesionalLocal.Nombre = TxtNombre.Text.Trim();
                MiProfesionalLocal.Correo = TxtCorreo.Text.Trim();
                MiProfesionalLocal.Cedula = TxtCedula.Text.Trim();
                MiProfesionalLocal.Apellido = TxtApellido.Text.Trim();
                MiProfesionalLocal.Telefono = TxtTelefono.Text.Trim();
                MiProfesionalLocal.MiTipoProfesional.CodigoTipoProfesional = Convert.ToInt32(CbTipoProfesional.SelectedValue);

                EmailOK = MiProfesionalLocal.ConsultarPorEmail();
                CedulaOK = MiProfesionalLocal.ConsultarPorCedula();

                if (EmailOK == false && CedulaOK == false)
                {
                    string msg = string.Format("¿Está seguro que desea agregar al trabajador {0}?", MiProfesionalLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiProfesionalLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Trabajador guardado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();

                            CargarListaDeProfesionales();
                        }
                        else
                        {
                            MessageBox.Show("Trabajador no se pudo guardar correctamente!", ":(", MessageBoxButtons.OK);
                        }


                    }
                }
                else
                {

                    if (EmailOK)
                    {
                        MessageBox.Show("Ya existe un trabajador con el correo digitado", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }
                    if (CedulaOK)
                    {
                        MessageBox.Show("Ya existe un trabajador con la cédula digitada", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }

                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                MiProfesionalLocal.Nombre = TxtNombre.Text.Trim();
                MiProfesionalLocal.Correo = TxtCorreo.Text.Trim();
                MiProfesionalLocal.Cedula = TxtCedula.Text.Trim();
                MiProfesionalLocal.Apellido = TxtApellido.Text.Trim();
                MiProfesionalLocal.Telefono = TxtTelefono.Text.Trim();
                MiProfesionalLocal.MiTipoProfesional.CodigoTipoProfesional = Convert.ToInt32(CbTipoProfesional.SelectedValue);

                if (MiProfesionalLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar el trabajador?", "???",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiProfesionalLocal.Editar())
                        {
                            MessageBox.Show("El trAbajador ha sido modificado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            ActivarAgregar();
                            CargarListaDeProfesionales();
                        }
                    }

                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MiProfesionalLocal.CodigoProfesional > 0 && MiProfesionalLocal.ConsultarPorID())
            {
                if (CbActivos.Checked)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar al trabajador?", "???",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiProfesionalLocal.DesactivarProfesional())
                        {
                            MessageBox.Show("EL trabajador ha sido eliminado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            ActivarAgregar();
                            CargarListaDeProfesionales();
                        }
                    }
                }
                else
                {
                    if (MiProfesionalLocal.ActivarProfesional())
                    {
                        MessageBox.Show("El trbajador ha sido activado correctamente!", ":)", MessageBoxButtons.OK);

                        LimpiarForm();
                        ActivarAgregar();
                        CargarListaDeProfesionales();
                    }

                }

            }
        }

        private void CbActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaDeProfesionales();

            if (CbActivos.Checked)
            {
                BtnEliminar.Text = "Desactivar";
            }
            else
            {
                BtnEliminar.Text = "Activar" +
                    "";
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            DtVista.ClearSelection();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaDeProfesionales();
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

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresNumeros(e, true);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresNumeros(e, true);
        }
    }
}
