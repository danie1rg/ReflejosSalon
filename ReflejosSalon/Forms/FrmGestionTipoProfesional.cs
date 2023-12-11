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
    public partial class FrmGestionTipoProfesional : Form
    {

        private Logica.Models.TipoProfesional MiTipoProfesionalLocal { get; set; }

        private DataTable ListaTipoProfesionales { get; set; }
        public FrmGestionTipoProfesional()
        {
            InitializeComponent();
            ListaTipoProfesionales = new DataTable();
            MiTipoProfesionalLocal = new TipoProfesional();
        }

        private bool ValidarDatosDigitados()
        {
            bool r = true;


            if (string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Debe de digitar una descripción para el tipo de profesional", "Error de validación", MessageBoxButtons.OK);
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
            ListaTipoProfesionales = new DataTable();
            string FiltroBusqueda = "";

            if (TxtBuscar.Text.Count() >= 3)
            {
                FiltroBusqueda = TxtBuscar.Text.Trim();
                ListaTipoProfesionales = MiTipoProfesionalLocal.Listar(FiltroBusqueda);
            }
            ListaTipoProfesionales = MiTipoProfesionalLocal.Listar(FiltroBusqueda);


            DtVista.DataSource = ListaTipoProfesionales;
            DtVista.ClearSelection();

        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                bool DescripcionOK;

                MiTipoProfesionalLocal = new Logica.Models.TipoProfesional();

                MiTipoProfesionalLocal.Descripcion = TxtDescripcion.Text.Trim();



                DescripcionOK = MiTipoProfesionalLocal.ConsultarPorDescripcion();

                if (DescripcionOK == false)
                {
                    string msg = string.Format("¿Está seguro que desea agregar el tipo profesional {0}?", MiTipoProfesionalLocal.Descripcion);

                    DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        bool ok = MiTipoProfesionalLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("El tipo de profesional se guardo correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();

                            CargarLista();
                        }
                        else
                        {
                            MessageBox.Show("El tipo de profesional no se pudo guardar correctamente!", ":(", MessageBoxButtons.OK);
                        }


                    }
                }
                else
                {

                    if (DescripcionOK)
                    {
                        MessageBox.Show("Ya existe un tipo de profesional", "Error de validación", MessageBoxButtons.OK);
                        return;
                    }



                }

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {

                MiTipoProfesionalLocal.Descripcion = TxtDescripcion.Text.Trim();

                if (MiTipoProfesionalLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar ","????",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiTipoProfesionalLocal.Editar())
                        {
                            MessageBox.Show("El tipo de profesional ha sido modificado correctamente!", ":)", MessageBoxButtons.OK);

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

                int ID = Convert.ToInt32(Mifila.Cells["CCodigoTipoProfesional"].Value);

                MiTipoProfesionalLocal = new Logica.Models.TipoProfesional();

                MiTipoProfesionalLocal.CodigoTipoProfesional = ID;

                MiTipoProfesionalLocal= MiTipoProfesionalLocal.ConsultarPorIDRetornaTipoProfesional();

                if (MiTipoProfesionalLocal != null && MiTipoProfesionalLocal.CodigoTipoProfesional > 0)
                {
                    TxtDescripcion.Text = MiTipoProfesionalLocal.Descripcion;
                    TxtCod.Text = Convert.ToString(MiTipoProfesionalLocal.CodigoTipoProfesional);
                    
                    ActivarEditarEliminar();
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            DtVista.ClearSelection();
        }

        private void FrmGestionTipoProfesional_Load(object sender, EventArgs e)
        {
            CargarLista();
            ActivarAgregar();
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.CaracteresTexto(e, true);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista();
        }
    }
}
