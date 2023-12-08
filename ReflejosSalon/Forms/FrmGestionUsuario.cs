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
    public partial class FrmGestionUsuario : Form
    {
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }
        private DataTable ListaUsuarios { get; set; }
        public FrmGestionUsuario()
        {
            InitializeComponent();
            MiUsuarioLocal = new Logica.Models.Usuario();
            ListaUsuarios = new DataTable();
        }
        private void LimpiarForm() 
        {
            TxtPass.Text = "Contraseña";
            TxtNombre.Text = "Nombre";
            TxtTelefono.Text = "Teléfono";
            TxtCorreo.Text = "Correo electrónico";
            CbUsuarioRol.SelectedIndex = -1;
        }

        private void TxtNombre_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text == "Nombre") 
            {
                TxtNombre.Text = "";
            }
            
        }

        private void TxtTelefono_Click(object sender, EventArgs e)
        {
            if (TxtTelefono.Text == "Teléfono")
            {
                TxtTelefono.Text = "";
            }
            
        }

        private void TxtCorreo_Click(object sender, EventArgs e)
        {
            
            if (TxtCorreo.Text == "Correo electrónico")
            {
                TxtCorreo.Text = "";
            }
        }

        private void TxtPass_Click(object sender, EventArgs e)
        {
            if (TxtPass.Text == "Contraseña")
            {
                TxtPass.Text = "";
            }
            
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {

            LimpiarForm();
            DtVista.ClearSelection();
        }

        private bool ValidarDatosDigitados(bool OmitirPassword = false)
        {
            bool r = false;

            if (!string.IsNullOrEmpty(TxtNombre.Text.Trim()) && !string.IsNullOrEmpty(TxtCorreo.Text.Trim()) &&
                CbUsuarioRol.SelectedIndex > -1 && !string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                if (OmitirPassword)
                {
                    r = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(TxtPass.Text.Trim()))
                    {
                        r = true;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(TxtPass.Text.Trim()))
                        {
                            MessageBox.Show("Debe de digitar una contraseña para el usuario", "Error de validación", MessageBoxButtons.OK);
                            TxtPass.Focus();
                            return false;
                        }
                    }
                }

            }
            else
            {
                if (string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe de digitar un nombre para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
                {
                    MessageBox.Show("Debe de digitar un correo para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtCorreo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
                {
                    MessageBox.Show("Debe de digitar un teléfono para el usuario", "Error de validación", MessageBoxButtons.OK);
                    TxtTelefono.Focus();
                    return false;
                }

                if (CbUsuarioRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe de digitar un rol para el usuario", "Error de validación", MessageBoxButtons.OK);
                    CbUsuarioRol.Focus();
                    return false;
                }


            }

            return r;

        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                bool EmailOK;

                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
                MiUsuarioLocal.Correo = TxtCorreo.Text.Trim();
                MiUsuarioLocal.Password = TxtPass.Text.Trim();
                MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
                MiUsuarioLocal.MiUsuarioRol.UserRolID = Convert.ToInt32(CbUsuarioRol.SelectedValue);

                EmailOK = MiUsuarioLocal.ConsultarPorEmail();

                if (EmailOK == false)
                {
                    string msg = string.Format("¿Está seguro que desea agregar al usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiUsuarioLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Usuario guardado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();

                            CargarListaDeUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Usuario no se pudo guardar correctamente!", ":(", MessageBoxButtons.OK);
                        }


                    }
                }
                else
                {

                    if (EmailOK)
                    {
                        MessageBox.Show("Ya existe un usuario con el correo digitado", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }

                }
            }
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

        private void CargarListaDeUsuarios()
        {
            ListaUsuarios = new DataTable();
            string FiltroBusqueda = "";
            DtVista.ClearSelection();

            if (TxtBuscar.Text.Trim() != "Buscar" && TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
            }

            if (CbActivos.Checked)
            {

                ListaUsuarios = MiUsuarioLocal.ListarActivos(FiltroBusqueda);
            }
            else
            {
                ListaUsuarios = MiUsuarioLocal.ListarInactivos(FiltroBusqueda);
            }

            DtVista.DataSource = ListaUsuarios;

        }


        private void CargarListaRoles()
        {
            Logica.Models.UsuarioRol MiRol = new Logica.Models.UsuarioRol();
            DataTable dt = new DataTable();
            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                CbUsuarioRol.ValueMember = "ID";
                CbUsuarioRol.DisplayMember = "Descripcion";
                CbUsuarioRol.DataSource = dt;
                CbUsuarioRol.SelectedIndex = -1;
            }
        }

        private void FrmGestionUsuario_Load_1(object sender, EventArgs e)
        {
            ActivarAgregar();
            CargarListaRoles();
            CargarListaDeUsuarios();
            DtVista.ClearSelection();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados(true))
            {
                MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
                MiUsuarioLocal.Correo = TxtCorreo.Text.Trim();
                MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
                MiUsuarioLocal.Password = TxtPass.Text.Trim();
                MiUsuarioLocal.MiUsuarioRol.UserRolID = Convert.ToInt32(CbUsuarioRol.SelectedValue);

                if (MiUsuarioLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar el usuario?", "???",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Editar())
                        {
                            MessageBox.Show("El usuario ha sido modificado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            ActivarAgregar();
                            CargarListaDeUsuarios();
                        }
                    }

                }
            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            if (MiUsuarioLocal.UserId > 0 && MiUsuarioLocal.ConsultarPorID())
            {
                if (CbActivos.Checked)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar al usuario?", "???",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.DesactivarUsuario())
                        {
                            MessageBox.Show("Usuario ha sido eliminado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            ActivarAgregar();
                            CargarListaDeUsuarios();
                        }
                    }
                }
                else
                {
                    if (MiUsuarioLocal.ActivarUsuario())
                    {
                        MessageBox.Show("Usuario ha sido activado correctamente!", ":)", MessageBoxButtons.OK);

                        LimpiarForm();
                        ActivarAgregar();
                        CargarListaDeUsuarios();
                    }

                }

            }


        }

        private void CbActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaDeUsuarios();

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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaDeUsuarios();
        }

        private void DtVista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtVista.SelectedRows.Count == 1)
            {
                DataGridViewRow Mifila = DtVista.SelectedRows[0];

                int IdUsuario = Convert.ToInt32(Mifila.Cells["CUserID"].Value);

                MiUsuarioLocal = new Logica.Models.Usuario();

                MiUsuarioLocal.UserId = IdUsuario;

                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorIDRetornaUsuario();

                if (MiUsuarioLocal != null && MiUsuarioLocal.UserId > 0)
                {
                    TxtNombre.Text = MiUsuarioLocal.Nombre;
                    TxtCorreo.Text = MiUsuarioLocal.Correo;
                    TxtTelefono.Text = MiUsuarioLocal.Telefono;

                    CbUsuarioRol.SelectedValue = MiUsuarioLocal.MiUsuarioRol.UserRolID;

                    ActivarEditarEliminar();
                }

            }
        }

        private void TxtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            if (TxtBuscar.Text == "Buscar")
            {
                TxtBuscar.Text = "";
            }
            
           
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (TxtBuscar.Text == "")
            {
                TxtBuscar.Text = "Buscar";
            }
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (TxtNombre.Text == "")
            {
                TxtNombre.Text = "Nombre";
            }
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            if (TxtTelefono.Text == "")
            {
                TxtTelefono.Text = "Teléfono";
            }
        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {
            if (TxtCorreo.Text == "")
            {
                TxtCorreo.Text = "Correo";
            }
            if (!string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
            {
                if (!Validation.ValidarEmail(TxtCorreo.Text.Trim()))
                {
                    MessageBox.Show("El formato del correo es incorrecto", "Error de validación", MessageBoxButtons.OK);
                    TxtCorreo.Focus();
                }
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            
            if (TxtPass.Text == "")
            {
                TxtPass.Text = "Contraseña";
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresNumeros(e,true); 
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void DtVista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DtVista.ClearSelection();
        }
    }
}
