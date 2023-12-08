namespace ReflejosSalon.Forms
{
    partial class FrmAgregarCita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtHoraFin = new System.Windows.Forms.DateTimePicker();
            this.DtHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.BtnBuscarProfesional = new System.Windows.Forms.Button();
            this.TxtProfesional = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CbEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbServicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtFecha
            // 
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFecha.Location = new System.Drawing.Point(90, 160);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(200, 26);
            this.DtFecha.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtHoraFin);
            this.groupBox1.Controls.Add(this.DtHoraInicio);
            this.groupBox1.Controls.Add(this.BtnBuscarProfesional);
            this.groupBox1.Controls.Add(this.TxtProfesional);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtCliente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnBuscarCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CbEstado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CbServicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 367);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Cita";
            // 
            // DtHoraFin
            // 
            this.DtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtHoraFin.Location = new System.Drawing.Point(351, 207);
            this.DtHoraFin.Name = "DtHoraFin";
            this.DtHoraFin.ShowUpDown = true;
            this.DtHoraFin.Size = new System.Drawing.Size(89, 26);
            this.DtHoraFin.TabIndex = 17;
            // 
            // DtHoraInicio
            // 
            this.DtHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtHoraInicio.Location = new System.Drawing.Point(106, 208);
            this.DtHoraInicio.Name = "DtHoraInicio";
            this.DtHoraInicio.ShowUpDown = true;
            this.DtHoraInicio.Size = new System.Drawing.Size(89, 26);
            this.DtHoraInicio.TabIndex = 16;
            // 
            // BtnBuscarProfesional
            // 
            this.BtnBuscarProfesional.Location = new System.Drawing.Point(351, 110);
            this.BtnBuscarProfesional.Name = "BtnBuscarProfesional";
            this.BtnBuscarProfesional.Size = new System.Drawing.Size(75, 26);
            this.BtnBuscarProfesional.TabIndex = 15;
            this.BtnBuscarProfesional.Text = "Buscar";
            this.BtnBuscarProfesional.UseVisualStyleBackColor = true;
            this.BtnBuscarProfesional.Click += new System.EventHandler(this.BtnBuscarProfesional_Click);
            // 
            // TxtProfesional
            // 
            this.TxtProfesional.Location = new System.Drawing.Point(106, 110);
            this.TxtProfesional.Name = "TxtProfesional";
            this.TxtProfesional.ReadOnly = true;
            this.TxtProfesional.Size = new System.Drawing.Size(239, 26);
            this.TxtProfesional.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Profesional";
            // 
            // TxtCliente
            // 
            this.TxtCliente.Location = new System.Drawing.Point(76, 54);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.ReadOnly = true;
            this.TxtCliente.Size = new System.Drawing.Size(269, 26);
            this.TxtCliente.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cliente";
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.Location = new System.Drawing.Point(351, 54);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(75, 26);
            this.BtnBuscarCliente.TabIndex = 10;
            this.BtnBuscarCliente.Text = "Buscar";
            this.BtnBuscarCliente.UseVisualStyleBackColor = true;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estado";
            // 
            // CbEstado
            // 
            this.CbEstado.FormattingEnabled = true;
            this.CbEstado.Location = new System.Drawing.Point(90, 322);
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.Size = new System.Drawing.Size(182, 28);
            this.CbEstado.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Servicio";
            // 
            // CbServicio
            // 
            this.CbServicio.FormattingEnabled = true;
            this.CbServicio.Location = new System.Drawing.Point(90, 257);
            this.CbServicio.Name = "CbServicio";
            this.CbServicio.Size = new System.Drawing.Size(182, 28);
            this.CbServicio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hora Finalización";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hora Inicio";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.Black;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAgregar.Location = new System.Drawing.Point(531, 407);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(92, 30);
            this.BtnAgregar.TabIndex = 17;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // FrmAgregarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(635, 449);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAgregarCita";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cita";
            this.Load += new System.EventHandler(this.FrmAgregarCita_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbServicio;
        private System.Windows.Forms.Button BtnBuscarProfesional;
        private System.Windows.Forms.TextBox TxtProfesional;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.DateTimePicker DtHoraInicio;
        private System.Windows.Forms.DateTimePicker DtHoraFin;
    }
}