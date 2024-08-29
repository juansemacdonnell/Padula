namespace SistemaKinesiologia.Pantallas
{
    partial class VerUltimasSesiones
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelSesiones = new Panel();
            panel8 = new Panel();
            btnVerDetalleSesion = new Guna.UI2.WinForms.Guna2Button();
            panel9 = new Panel();
            lblTituloPanelSesion = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dgvSesiones = new Guna.UI2.WinForms.Guna2DataGridView();
            idSesion = new DataGridViewTextBoxColumn();
            pacienteSesion = new DataGridViewTextBoxColumn();
            lesionSesion = new DataGridViewTextBoxColumn();
            numeroSesion = new DataGridViewTextBoxColumn();
            fechaSesion = new DataGridViewTextBoxColumn();
            kineSesion = new DataGridViewTextBoxColumn();
            btnVolverInicio = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            panel2 = new Panel();
            histogramaFrecuencias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cmbSelectorAnio = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCantidadPacientesCompletar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCantidadSesionesCompletar = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCantidadDeSesiones = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cmbSelectorMes = new Guna.UI2.WinForms.Guna2ComboBox();
            lblMes = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel3 = new Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelSesiones.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histogramaFrecuencias).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panelSesiones
            // 
            panelSesiones.BackColor = Color.FromArgb(64, 64, 64);
            panelSesiones.Controls.Add(panel8);
            panelSesiones.ImeMode = ImeMode.Disable;
            panelSesiones.Location = new Point(35, 55);
            panelSesiones.Name = "panelSesiones";
            panelSesiones.Size = new Size(651, 596);
            panelSesiones.TabIndex = 7;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(btnVerDetalleSesion);
            panel8.Controls.Add(panel9);
            panel8.Controls.Add(dgvSesiones);
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(645, 590);
            panel8.TabIndex = 0;
            // 
            // btnVerDetalleSesion
            // 
            btnVerDetalleSesion.BackColor = Color.FromArgb(220, 100, 100);
            btnVerDetalleSesion.BorderColor = Color.DimGray;
            btnVerDetalleSesion.BorderThickness = 2;
            btnVerDetalleSesion.Cursor = Cursors.Hand;
            btnVerDetalleSesion.CustomizableEdges = customizableEdges9;
            btnVerDetalleSesion.DisabledState.BorderColor = Color.DarkGray;
            btnVerDetalleSesion.DisabledState.CustomBorderColor = Color.DarkGray;
            btnVerDetalleSesion.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnVerDetalleSesion.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnVerDetalleSesion.FillColor = Color.FromArgb(164, 198, 57);
            btnVerDetalleSesion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerDetalleSesion.ForeColor = Color.White;
            btnVerDetalleSesion.Location = new Point(260, 526);
            btnVerDetalleSesion.Name = "btnVerDetalleSesion";
            btnVerDetalleSesion.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnVerDetalleSesion.Size = new Size(120, 45);
            btnVerDetalleSesion.TabIndex = 58;
            btnVerDetalleSesion.Text = "Ver detalle de sesión";
            btnVerDetalleSesion.Click += btnVerDetalleSesion_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(64, 64, 64);
            panel9.Controls.Add(lblTituloPanelSesion);
            panel9.Location = new Point(15, 12);
            panel9.Name = "panel9";
            panel9.Size = new Size(612, 48);
            panel9.TabIndex = 57;
            // 
            // lblTituloPanelSesion
            // 
            lblTituloPanelSesion.BackColor = Color.Transparent;
            lblTituloPanelSesion.Enabled = false;
            lblTituloPanelSesion.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloPanelSesion.ForeColor = Color.White;
            lblTituloPanelSesion.Location = new Point(167, 7);
            lblTituloPanelSesion.Name = "lblTituloPanelSesion";
            lblTituloPanelSesion.Size = new Size(277, 32);
            lblTituloPanelSesion.TabIndex = 0;
            lblTituloPanelSesion.Text = "Últimas sesiones registradas";
            // 
            // dgvSesiones
            // 
            dataGridViewCellStyle6.BackColor = Color.White;
            dgvSesiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvSesiones.BorderStyle = BorderStyle.FixedSingle;
            dgvSesiones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvSesiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvSesiones.ColumnHeadersHeight = 50;
            dgvSesiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSesiones.Columns.AddRange(new DataGridViewColumn[] { idSesion, pacienteSesion, lesionSesion, numeroSesion, fechaSesion, kineSesion });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvSesiones.DefaultCellStyle = dataGridViewCellStyle10;
            dgvSesiones.GridColor = Color.FromArgb(231, 229, 255);
            dgvSesiones.Location = new Point(15, 66);
            dgvSesiones.Name = "dgvSesiones";
            dgvSesiones.RowHeadersVisible = false;
            dgvSesiones.Size = new Size(612, 446);
            dgvSesiones.TabIndex = 0;
            dgvSesiones.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSesiones.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvSesiones.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvSesiones.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvSesiones.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvSesiones.ThemeStyle.BackColor = Color.White;
            dgvSesiones.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvSesiones.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvSesiones.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvSesiones.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvSesiones.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvSesiones.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSesiones.ThemeStyle.HeaderStyle.Height = 50;
            dgvSesiones.ThemeStyle.ReadOnly = false;
            dgvSesiones.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvSesiones.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSesiones.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSesiones.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvSesiones.ThemeStyle.RowsStyle.Height = 25;
            dgvSesiones.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvSesiones.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvSesiones.SelectionChanged += dgvSesiones_SelectionChanged;
            // 
            // idSesion
            // 
            idSesion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.ForeColor = Color.Black;
            idSesion.DefaultCellStyle = dataGridViewCellStyle8;
            idSesion.HeaderText = "ID";
            idSesion.Name = "idSesion";
            idSesion.ReadOnly = true;
            idSesion.Width = 25;
            // 
            // pacienteSesion
            // 
            pacienteSesion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            pacienteSesion.HeaderText = "Paciente";
            pacienteSesion.Name = "pacienteSesion";
            pacienteSesion.ReadOnly = true;
            pacienteSesion.Width = 170;
            // 
            // lesionSesion
            // 
            lesionSesion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            lesionSesion.FillWeight = 12.8205147F;
            lesionSesion.HeaderText = "Lesión";
            lesionSesion.Name = "lesionSesion";
            lesionSesion.ReadOnly = true;
            lesionSesion.Width = 130;
            // 
            // numeroSesion
            // 
            numeroSesion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            numeroSesion.FillWeight = 230.769226F;
            numeroSesion.HeaderText = "Número de sesión";
            numeroSesion.Name = "numeroSesion";
            numeroSesion.ReadOnly = true;
            numeroSesion.Width = 60;
            // 
            // fechaSesion
            // 
            fechaSesion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            fechaSesion.DefaultCellStyle = dataGridViewCellStyle9;
            fechaSesion.FillWeight = 56.41026F;
            fechaSesion.HeaderText = "Fecha";
            fechaSesion.Name = "fechaSesion";
            fechaSesion.ReadOnly = true;
            fechaSesion.Width = 80;
            // 
            // kineSesion
            // 
            kineSesion.HeaderText = "Kinesiólogo";
            kineSesion.Name = "kineSesion";
            kineSesion.ReadOnly = true;
            // 
            // btnVolverInicio
            // 
            btnVolverInicio.BackColor = Color.FromArgb(220, 100, 100);
            btnVolverInicio.BorderColor = Color.DimGray;
            btnVolverInicio.BorderThickness = 2;
            btnVolverInicio.Cursor = Cursors.Hand;
            btnVolverInicio.CustomizableEdges = customizableEdges11;
            btnVolverInicio.DisabledState.BorderColor = Color.DarkGray;
            btnVolverInicio.DisabledState.CustomBorderColor = Color.DarkGray;
            btnVolverInicio.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnVolverInicio.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnVolverInicio.FillColor = Color.FromArgb(220, 100, 100);
            btnVolverInicio.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolverInicio.ForeColor = Color.White;
            btnVolverInicio.Location = new Point(35, 12);
            btnVolverInicio.Name = "btnVolverInicio";
            btnVolverInicio.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnVolverInicio.Size = new Size(198, 28);
            btnVolverInicio.TabIndex = 8;
            btnVolverInicio.Text = "Volver a pantalla de inicio";
            btnVolverInicio.Click += btnVolverInicio_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(692, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(585, 596);
            panel1.TabIndex = 58;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(histogramaFrecuencias);
            panel2.Controls.Add(cmbSelectorAnio);
            panel2.Controls.Add(guna2HtmlLabel4);
            panel2.Controls.Add(lblCantidadPacientesCompletar);
            panel2.Controls.Add(lblCantidadSesionesCompletar);
            panel2.Controls.Add(guna2HtmlLabel3);
            panel2.Controls.Add(guna2HtmlLabel2);
            panel2.Controls.Add(lblCantidadDeSesiones);
            panel2.Controls.Add(cmbSelectorMes);
            panel2.Controls.Add(lblMes);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(577, 590);
            panel2.TabIndex = 1;
            // 
            // histogramaFrecuencias
            // 
            histogramaFrecuencias.BackColor = Color.Transparent;
            chartArea2.Name = "ChartArea1";
            histogramaFrecuencias.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            histogramaFrecuencias.Legends.Add(legend2);
            histogramaFrecuencias.Location = new Point(15, 284);
            histogramaFrecuencias.Margin = new Padding(4, 3, 4, 3);
            histogramaFrecuencias.Name = "histogramaFrecuencias";
            histogramaFrecuencias.Padding = new Padding(0, 0, 12, 0);
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Fo";
            histogramaFrecuencias.Series.Add(series2);
            histogramaFrecuencias.Size = new Size(545, 228);
            histogramaFrecuencias.TabIndex = 67;
            histogramaFrecuencias.Text = "Histograma de Frecuencias";
            // 
            // cmbSelectorAnio
            // 
            cmbSelectorAnio.BackColor = Color.White;
            cmbSelectorAnio.Cursor = Cursors.Hand;
            cmbSelectorAnio.CustomizableEdges = customizableEdges13;
            cmbSelectorAnio.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSelectorAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectorAnio.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbSelectorAnio.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbSelectorAnio.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSelectorAnio.ForeColor = Color.FromArgb(68, 88, 112);
            cmbSelectorAnio.ItemHeight = 30;
            cmbSelectorAnio.Location = new Point(407, 89);
            cmbSelectorAnio.Name = "cmbSelectorAnio";
            cmbSelectorAnio.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cmbSelectorAnio.Size = new Size(111, 36);
            cmbSelectorAnio.TabIndex = 66;
            cmbSelectorAnio.SelectedIndexChanged += cmbSelectorAnio_SelectedIndexChanged;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = Color.FromArgb(64, 64, 64);
            guna2HtmlLabel4.Location = new Point(359, 91);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(42, 27);
            guna2HtmlLabel4.TabIndex = 65;
            guna2HtmlLabel4.Text = "año:";
            // 
            // lblCantidadPacientesCompletar
            // 
            lblCantidadPacientesCompletar.BackColor = Color.Transparent;
            lblCantidadPacientesCompletar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadPacientesCompletar.ForeColor = Color.FromArgb(64, 64, 64);
            lblCantidadPacientesCompletar.Location = new Point(330, 187);
            lblCantidadPacientesCompletar.Name = "lblCantidadPacientesCompletar";
            lblCantidadPacientesCompletar.Size = new Size(93, 27);
            lblCantidadPacientesCompletar.TabIndex = 64;
            lblCantidadPacientesCompletar.Text = "completar";
            // 
            // lblCantidadSesionesCompletar
            // 
            lblCantidadSesionesCompletar.BackColor = Color.Transparent;
            lblCantidadSesionesCompletar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadSesionesCompletar.ForeColor = Color.FromArgb(64, 64, 64);
            lblCantidadSesionesCompletar.Location = new Point(319, 139);
            lblCantidadSesionesCompletar.Name = "lblCantidadSesionesCompletar";
            lblCantidadSesionesCompletar.Size = new Size(93, 27);
            lblCantidadSesionesCompletar.TabIndex = 63;
            lblCantidadSesionesCompletar.Text = "completar";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.FromArgb(64, 64, 64);
            guna2HtmlLabel3.Location = new Point(15, 235);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(386, 27);
            guna2HtmlLabel3.TabIndex = 62;
            guna2HtmlLabel3.Text = " - Gráfico de cantidad de sesiones en el año:";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(64, 64, 64);
            guna2HtmlLabel2.Location = new Point(15, 187);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(309, 27);
            guna2HtmlLabel2.TabIndex = 61;
            guna2HtmlLabel2.Text = " - Cantidad de pacientes atendidos: ";
            // 
            // lblCantidadDeSesiones
            // 
            lblCantidadDeSesiones.BackColor = Color.Transparent;
            lblCantidadDeSesiones.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadDeSesiones.ForeColor = Color.FromArgb(64, 64, 64);
            lblCantidadDeSesiones.Location = new Point(15, 139);
            lblCantidadDeSesiones.Name = "lblCantidadDeSesiones";
            lblCantidadDeSesiones.Size = new Size(298, 27);
            lblCantidadDeSesiones.TabIndex = 60;
            lblCantidadDeSesiones.Text = " - Cantidad de sesiones realizadas: ";
            // 
            // cmbSelectorMes
            // 
            cmbSelectorMes.BackColor = Color.White;
            cmbSelectorMes.Cursor = Cursors.Hand;
            cmbSelectorMes.CustomizableEdges = customizableEdges15;
            cmbSelectorMes.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSelectorMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectorMes.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbSelectorMes.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbSelectorMes.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSelectorMes.ForeColor = Color.FromArgb(68, 88, 112);
            cmbSelectorMes.ItemHeight = 30;
            cmbSelectorMes.Location = new Point(168, 89);
            cmbSelectorMes.Name = "cmbSelectorMes";
            cmbSelectorMes.ShadowDecoration.CustomizableEdges = customizableEdges16;
            cmbSelectorMes.Size = new Size(164, 36);
            cmbSelectorMes.TabIndex = 59;
            cmbSelectorMes.SelectedIndexChanged += cmbSelectorMes_SelectedIndexChanged;
            // 
            // lblMes
            // 
            lblMes.BackColor = Color.Transparent;
            lblMes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMes.ForeColor = Color.FromArgb(64, 64, 64);
            lblMes.Location = new Point(15, 91);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(147, 27);
            lblMes.TabIndex = 58;
            lblMes.Text = "Selector de mes:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Controls.Add(guna2HtmlLabel1);
            panel3.Location = new Point(15, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(545, 48);
            panel3.TabIndex = 57;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Enabled = false;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(134, 7);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(276, 32);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Información del último mes";
            // 
            // VerUltimasSesiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1318, 696);
            Controls.Add(panel1);
            Controls.Add(btnVolverInicio);
            Controls.Add(panelSesiones);
            Name = "VerUltimasSesiones";
            Text = "Información";
            panelSesiones.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)histogramaFrecuencias).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSesiones;
        private Panel panel8;
        private Guna.UI2.WinForms.Guna2Button btnVerDetalleSesion;
        private Panel panel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTituloPanelSesion;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSesiones;
        private Guna.UI2.WinForms.Guna2Button btnVolverInicio;
        private DataGridViewTextBoxColumn idSesion;
        private DataGridViewTextBoxColumn pacienteSesion;
        private DataGridViewTextBoxColumn lesionSesion;
        private DataGridViewTextBoxColumn numeroSesion;
        private DataGridViewTextBoxColumn fechaSesion;
        private DataGridViewTextBoxColumn kineSesion;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMes;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCantidadDeSesiones;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSelectorMes;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCantidadPacientesCompletar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCantidadSesionesCompletar;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSelectorAnio;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramaFrecuencias;
    }
}