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
    public partial class FrmLoginIn : Form
    {
        public FrmLoginIn()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtCorreo.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPas.Text.Trim()))
            {
                string usuario = TxtCorreo.Text.Trim();
                string contrasennia = TxtPas.Text.Trim();

                Globales.MiUsuarioGlobal = Globales.MiUsuarioGlobal.ValidarUsuario(usuario, contrasennia);

                if (Globales.MiUsuarioGlobal.UserId > 0)
                {

                    Globales.MiFormPrincipal.Show();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrectas...", "Error de validación", MessageBoxButtons.OK);

                    TxtPas.Focus();
                    TxtPas.SelectAll();

                }

            }
            else
            {
                MessageBox.Show("Faltan datos requeridos!", "Error de validación", MessageBoxButtons.OK);
            }


        }

        private void FrmLoginIn_Load(object sender, EventArgs e)
        {

        }
    }
}
