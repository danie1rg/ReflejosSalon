namespace ReflejosSalon.Forms
{
    partial class FrmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeTipoPorfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbServicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnNuevaCita = new System.Windows.Forms.Button();
            this.BtnCitaDia = new System.Windows.Forms.Button();
            this.BtnSemana = new System.Windows.Forms.Button();
            this.DtTiempo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DtVista = new System.Windows.Forms.DataGridView();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCitaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHora_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHora_Fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNOMBRECLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CcodigoEstadoCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CcodigoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCodigoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CServicioDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtVista)).BeginInit();
            this.GBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // gestionesToolStripMenuItem
            // 
            this.gestionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeUsuarioToolStripMenuItem,
            this.gestiónDeClienteToolStripMenuItem,
            this.gestiónDeTipoPorfesionalToolStripMenuItem,
            this.gestiónDeProfesionalToolStripMenuItem,
            this.gestiónDeServicioToolStripMenuItem});
            this.gestionesToolStripMenuItem.Name = "gestionesToolStripMenuItem";
            resources.ApplyResources(this.gestionesToolStripMenuItem, "gestionesToolStripMenuItem");
            // 
            // gestiónDeUsuarioToolStripMenuItem
            // 
            this.gestiónDeUsuarioToolStripMenuItem.Name = "gestiónDeUsuarioToolStripMenuItem";
            resources.ApplyResources(this.gestiónDeUsuarioToolStripMenuItem, "gestiónDeUsuarioToolStripMenuItem");
            this.gestiónDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeUsuarioToolStripMenuItem_Click);
            // 
            // gestiónDeClienteToolStripMenuItem
            // 
            this.gestiónDeClienteToolStripMenuItem.Name = "gestiónDeClienteToolStripMenuItem";
            resources.ApplyResources(this.gestiónDeClienteToolStripMenuItem, "gestiónDeClienteToolStripMenuItem");
            this.gestiónDeClienteToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeClienteToolStripMenuItem_Click);
            // 
            // gestiónDeTipoPorfesionalToolStripMenuItem
            // 
            this.gestiónDeTipoPorfesionalToolStripMenuItem.Name = "gestiónDeTipoPorfesionalToolStripMenuItem";
            resources.ApplyResources(this.gestiónDeTipoPorfesionalToolStripMenuItem, "gestiónDeTipoPorfesionalToolStripMenuItem");
            this.gestiónDeTipoPorfesionalToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeTipoPorfesionalToolStripMenuItem_Click);
            // 
            // gestiónDeProfesionalToolStripMenuItem
            // 
            this.gestiónDeProfesionalToolStripMenuItem.Name = "gestiónDeProfesionalToolStripMenuItem";
            resources.ApplyResources(this.gestiónDeProfesionalToolStripMenuItem, "gestiónDeProfesionalToolStripMenuItem");
            this.gestiónDeProfesionalToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeProfesionalToolStripMenuItem_Click);
            // 
            // gestiónDeServicioToolStripMenuItem
            // 
            this.gestiónDeServicioToolStripMenuItem.Name = "gestiónDeServicioToolStripMenuItem";
            resources.ApplyResources(this.gestiónDeServicioToolStripMenuItem, "gestiónDeServicioToolStripMenuItem");
            this.gestiónDeServicioToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeServicioToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Teal;
            this.groupBox1.Controls.Add(this.CbServicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CbEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnLimpiar);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // CbServicio
            // 
            this.CbServicio.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.CbServicio, "CbServicio");
            this.CbServicio.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.CbServicio.FormattingEnabled = true;
            this.CbServicio.Name = "CbServicio";
            this.CbServicio.SelectedIndexChanged += new System.EventHandler(this.CbServicio_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CbEstado
            // 
            this.CbEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.CbEstado, "CbEstado");
            this.CbEstado.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.CbEstado.FormattingEnabled = true;
            this.CbEstado.Name = "CbEstado";
            this.CbEstado.SelectedIndexChanged += new System.EventHandler(this.CbEstado_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BtnLimpiar
            // 
            resources.ApplyResources(this.BtnLimpiar, "BtnLimpiar");
            this.BtnLimpiar.ForeColor = System.Drawing.Color.Transparent;
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            // 
            // BtnNuevaCita
            // 
            resources.ApplyResources(this.BtnNuevaCita, "BtnNuevaCita");
            this.BtnNuevaCita.ForeColor = System.Drawing.Color.Black;
            this.BtnNuevaCita.Name = "BtnNuevaCita";
            this.BtnNuevaCita.UseVisualStyleBackColor = true;
            this.BtnNuevaCita.Click += new System.EventHandler(this.BtnNuevaCita_Click);
            // 
            // BtnCitaDia
            // 
            this.BtnCitaDia.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.BtnCitaDia, "BtnCitaDia");
            this.BtnCitaDia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCitaDia.Name = "BtnCitaDia";
            this.BtnCitaDia.UseVisualStyleBackColor = false;
            this.BtnCitaDia.Click += new System.EventHandler(this.BtnCitaDia_Click);
            // 
            // BtnSemana
            // 
            this.BtnSemana.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.BtnSemana, "BtnSemana");
            this.BtnSemana.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BtnSemana.Name = "BtnSemana";
            this.BtnSemana.UseVisualStyleBackColor = false;
            this.BtnSemana.Click += new System.EventHandler(this.BtnSemana_Click);
            // 
            // DtTiempo
            // 
            this.DtTiempo.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.DtTiempo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.DtTiempo, "DtTiempo");
            this.DtTiempo.Name = "DtTiempo";
            this.DtTiempo.Value = new System.DateTime(2023, 11, 17, 0, 0, 0, 0);
            this.DtTiempo.ValueChanged += new System.EventHandler(this.DtTiempo_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // DtVista
            // 
            this.DtVista.AllowUserToAddRows = false;
            this.DtVista.AllowUserToDeleteRows = false;
            this.DtVista.AllowUserToOrderColumns = true;
            this.DtVista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtVista.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.DtVista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DtVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtVista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CFecha,
            this.CCitaID,
            this.CHora_Inicio,
            this.CHora_Fin,
            this.CCodigoCliente,
            this.CNOMBRECLIENTE,
            this.CcodigoEstadoCita,
            this.CcodigoProfesional,
            this.CNombreProfesional,
            this.CCodigoServicio,
            this.CDescripcion,
            this.CServicioDescripcion});
            this.DtVista.GridColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.DtVista, "DtVista");
            this.DtVista.MultiSelect = false;
            this.DtVista.Name = "DtVista";
            this.DtVista.ReadOnly = true;
            this.DtVista.RowHeadersVisible = false;
            this.DtVista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtVista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DtVista_DataBindingComplete);
            // 
            // CFecha
            // 
            this.CFecha.DataPropertyName = "Fecha";
            this.CFecha.FillWeight = 70.27919F;
            resources.ApplyResources(this.CFecha, "CFecha");
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            // 
            // CCitaID
            // 
            this.CCitaID.DataPropertyName = "CitaID";
            resources.ApplyResources(this.CCitaID, "CCitaID");
            this.CCitaID.Name = "CCitaID";
            this.CCitaID.ReadOnly = true;
            // 
            // CHora_Inicio
            // 
            this.CHora_Inicio.DataPropertyName = "Hora_Inicio";
            this.CHora_Inicio.FillWeight = 85.27919F;
            resources.ApplyResources(this.CHora_Inicio, "CHora_Inicio");
            this.CHora_Inicio.Name = "CHora_Inicio";
            this.CHora_Inicio.ReadOnly = true;
            // 
            // CHora_Fin
            // 
            this.CHora_Fin.DataPropertyName = "Hora_Fin";
            this.CHora_Fin.FillWeight = 85.27919F;
            resources.ApplyResources(this.CHora_Fin, "CHora_Fin");
            this.CHora_Fin.Name = "CHora_Fin";
            this.CHora_Fin.ReadOnly = true;
            // 
            // CCodigoCliente
            // 
            this.CCodigoCliente.DataPropertyName = "CodigoCliente";
            resources.ApplyResources(this.CCodigoCliente, "CCodigoCliente");
            this.CCodigoCliente.Name = "CCodigoCliente";
            this.CCodigoCliente.ReadOnly = true;
            // 
            // CNOMBRECLIENTE
            // 
            this.CNOMBRECLIENTE.DataPropertyName = "NOMBRECLIENTE";
            this.CNOMBRECLIENTE.FillWeight = 85.27919F;
            resources.ApplyResources(this.CNOMBRECLIENTE, "CNOMBRECLIENTE");
            this.CNOMBRECLIENTE.Name = "CNOMBRECLIENTE";
            this.CNOMBRECLIENTE.ReadOnly = true;
            // 
            // CcodigoEstadoCita
            // 
            this.CcodigoEstadoCita.DataPropertyName = "codigoEstadoCita";
            resources.ApplyResources(this.CcodigoEstadoCita, "CcodigoEstadoCita");
            this.CcodigoEstadoCita.Name = "CcodigoEstadoCita";
            this.CcodigoEstadoCita.ReadOnly = true;
            // 
            // CcodigoProfesional
            // 
            this.CcodigoProfesional.DataPropertyName = "codigoProfesional";
            resources.ApplyResources(this.CcodigoProfesional, "CcodigoProfesional");
            this.CcodigoProfesional.Name = "CcodigoProfesional";
            this.CcodigoProfesional.ReadOnly = true;
            // 
            // CNombreProfesional
            // 
            this.CNombreProfesional.DataPropertyName = "NOMBREPROFESIONAL";
            this.CNombreProfesional.FillWeight = 85.27919F;
            resources.ApplyResources(this.CNombreProfesional, "CNombreProfesional");
            this.CNombreProfesional.Name = "CNombreProfesional";
            this.CNombreProfesional.ReadOnly = true;
            // 
            // CCodigoServicio
            // 
            this.CCodigoServicio.DataPropertyName = "CodigoServicio";
            resources.ApplyResources(this.CCodigoServicio, "CCodigoServicio");
            this.CCodigoServicio.Name = "CCodigoServicio";
            this.CCodigoServicio.ReadOnly = true;
            // 
            // CDescripcion
            // 
            this.CDescripcion.DataPropertyName = "Descripcion";
            this.CDescripcion.FillWeight = 85.27919F;
            resources.ApplyResources(this.CDescripcion, "CDescripcion");
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.ReadOnly = true;
            // 
            // CServicioDescripcion
            // 
            this.CServicioDescripcion.DataPropertyName = "ServicioDescripcion";
            this.CServicioDescripcion.FillWeight = 85.27919F;
            resources.ApplyResources(this.CServicioDescripcion, "CServicioDescripcion");
            this.CServicioDescripcion.Name = "CServicioDescripcion";
            this.CServicioDescripcion.ReadOnly = true;
            // 
            // GBox2
            // 
            this.GBox2.Controls.Add(this.linkLabel1);
            this.GBox2.Controls.Add(this.BtnEditar);
            this.GBox2.Controls.Add(this.DtVista);
            resources.ApplyResources(this.GBox2, "GBox2");
            this.GBox2.Name = "GBox2";
            this.GBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.BtnEditar, "BtnEditar");
            this.BtnEditar.ForeColor = System.Drawing.Color.Teal;
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // FrmMDI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.GBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtTiempo);
            this.Controls.Add(this.BtnSemana);
            this.Controls.Add(this.BtnCitaDia);
            this.Controls.Add(this.BtnNuevaCita);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMDI";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtVista)).EndInit();
            this.GBox2.ResumeLayout(false);
            this.GBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeTipoPorfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeProfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeServicioToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.ComboBox CbServicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbEstado;
        private System.Windows.Forms.Button BtnNuevaCita;
        private System.Windows.Forms.Button BtnCitaDia;
        private System.Windows.Forms.Button BtnSemana;
        private System.Windows.Forms.DateTimePicker DtTiempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DtVista;
        private System.Windows.Forms.GroupBox GBox2;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCitaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHora_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHora_Fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNOMBRECLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CcodigoEstadoCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn CcodigoProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodigoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CServicioDescripcion;
    }
}