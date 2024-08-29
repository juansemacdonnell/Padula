namespace SistemaKinesiologia
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelPrincipal = new Panel();
            btnUltimasSesiones = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblFecha = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblHora = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnBuscarPaciente = new Guna.UI2.WinForms.Guna2Button();
            btnRegistarPaciente = new Guna.UI2.WinForms.Guna2Button();
            cmbBoxKine = new Guna.UI2.WinForms.Guna2ComboBox();
            lblKinesiologo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnCargarPlanGenerico = new Guna.UI2.WinForms.Guna2Button();
            panelPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = SystemColors.Control;
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(btnCargarPlanGenerico);
            panelPrincipal.Controls.Add(btnUltimasSesiones);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Controls.Add(lblFecha);
            panelPrincipal.Controls.Add(lblHora);
            panelPrincipal.Controls.Add(btnBuscarPaciente);
            panelPrincipal.Controls.Add(btnRegistarPaciente);
            panelPrincipal.Location = new Point(241, 140);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(900, 450);
            panelPrincipal.TabIndex = 0;
            // 
            // btnUltimasSesiones
            // 
            btnUltimasSesiones.BorderColor = Color.DimGray;
            btnUltimasSesiones.BorderThickness = 2;
            btnUltimasSesiones.Cursor = Cursors.Hand;
            btnUltimasSesiones.CustomizableEdges = customizableEdges3;
            btnUltimasSesiones.DisabledState.BorderColor = Color.DarkGray;
            btnUltimasSesiones.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUltimasSesiones.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUltimasSesiones.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUltimasSesiones.FillColor = Color.Teal;
            btnUltimasSesiones.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUltimasSesiones.ForeColor = Color.White;
            btnUltimasSesiones.Location = new Point(202, 367);
            btnUltimasSesiones.Name = "btnUltimasSesiones";
            btnUltimasSesiones.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnUltimasSesiones.Size = new Size(240, 60);
            btnUltimasSesiones.TabIndex = 5;
            btnUltimasSesiones.Text = "VER ULTIMAS SESIONES ";
            btnUltimasSesiones.Click += btnUltimasSesiones_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Enabled = false;
            lblTitulo.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.DimGray;
            lblTitulo.Location = new Point(285, 160);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(354, 88);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "KineSystem";
            // 
            // lblFecha
            // 
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Enabled = false;
            lblFecha.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.DimGray;
            lblFecha.Location = new Point(322, 25);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(257, 34);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Domingo, 26 de mayo";
            // 
            // lblHora
            // 
            lblHora.BackColor = Color.Transparent;
            lblHora.Enabled = false;
            lblHora.Font = new Font("Segoe UI", 51.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHora.ForeColor = Color.DimGray;
            lblHora.Location = new Point(384, 42);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(129, 94);
            lblHora.TabIndex = 3;
            lblHora.Text = "1:41";
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.BorderColor = Color.DimGray;
            btnBuscarPaciente.BorderThickness = 2;
            btnBuscarPaciente.Cursor = Cursors.Hand;
            btnBuscarPaciente.CustomizableEdges = customizableEdges5;
            btnBuscarPaciente.DisabledState.BorderColor = Color.DarkGray;
            btnBuscarPaciente.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBuscarPaciente.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBuscarPaciente.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBuscarPaciente.FillColor = Color.Teal;
            btnBuscarPaciente.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscarPaciente.ForeColor = Color.White;
            btnBuscarPaciente.Location = new Point(458, 295);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBuscarPaciente.Size = new Size(240, 60);
            btnBuscarPaciente.TabIndex = 1;
            btnBuscarPaciente.Text = "BUSCAR PACIENTE";
            btnBuscarPaciente.Click += btnBuscarPaciente_Click;
            // 
            // btnRegistarPaciente
            // 
            btnRegistarPaciente.BorderColor = Color.DimGray;
            btnRegistarPaciente.BorderThickness = 2;
            btnRegistarPaciente.Cursor = Cursors.Hand;
            btnRegistarPaciente.CustomizableEdges = customizableEdges7;
            btnRegistarPaciente.DisabledState.BorderColor = Color.DarkGray;
            btnRegistarPaciente.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegistarPaciente.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegistarPaciente.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegistarPaciente.FillColor = Color.Teal;
            btnRegistarPaciente.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistarPaciente.ForeColor = Color.White;
            btnRegistarPaciente.Location = new Point(202, 295);
            btnRegistarPaciente.Name = "btnRegistarPaciente";
            btnRegistarPaciente.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRegistarPaciente.Size = new Size(240, 60);
            btnRegistarPaciente.TabIndex = 0;
            btnRegistarPaciente.Text = "REGISTRAR PACIENTE";
            btnRegistarPaciente.Click += btnRegistarPaciente_Click;
            // 
            // cmbBoxKine
            // 
            cmbBoxKine.BackColor = Color.White;
            cmbBoxKine.Cursor = Cursors.Hand;
            cmbBoxKine.CustomizableEdges = customizableEdges9;
            cmbBoxKine.DrawMode = DrawMode.OwnerDrawFixed;
            cmbBoxKine.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxKine.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbBoxKine.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbBoxKine.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxKine.ForeColor = Color.FromArgb(68, 88, 112);
            cmbBoxKine.ItemHeight = 30;
            cmbBoxKine.Location = new Point(1147, 35);
            cmbBoxKine.Name = "cmbBoxKine";
            cmbBoxKine.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmbBoxKine.Size = new Size(190, 36);
            cmbBoxKine.TabIndex = 13;
            // 
            // lblKinesiologo
            // 
            lblKinesiologo.BackColor = Color.Transparent;
            lblKinesiologo.Enabled = false;
            lblKinesiologo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblKinesiologo.ForeColor = Color.DimGray;
            lblKinesiologo.Location = new Point(881, 33);
            lblKinesiologo.Name = "lblKinesiologo";
            lblKinesiologo.Size = new Size(260, 34);
            lblKinesiologo.TabIndex = 12;
            lblKinesiologo.Text = "Kinesiólogo en sesión:";
            // 
            // btnCargarPlanGenerico
            // 
            btnCargarPlanGenerico.BorderColor = Color.DimGray;
            btnCargarPlanGenerico.BorderThickness = 2;
            btnCargarPlanGenerico.Cursor = Cursors.Hand;
            btnCargarPlanGenerico.CustomizableEdges = customizableEdges1;
            btnCargarPlanGenerico.DisabledState.BorderColor = Color.DarkGray;
            btnCargarPlanGenerico.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCargarPlanGenerico.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCargarPlanGenerico.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCargarPlanGenerico.FillColor = Color.Teal;
            btnCargarPlanGenerico.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargarPlanGenerico.ForeColor = Color.White;
            btnCargarPlanGenerico.Location = new Point(458, 367);
            btnCargarPlanGenerico.Name = "btnCargarPlanGenerico";
            btnCargarPlanGenerico.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCargarPlanGenerico.Size = new Size(240, 60);
            btnCargarPlanGenerico.TabIndex = 6;
            btnCargarPlanGenerico.Text = "CARGAR PLAN DE ENTRENAMIENTO GENERICO ";
            btnCargarPlanGenerico.Click += btnCargarPlanGenerico_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1370, 624);
            Controls.Add(cmbBoxKine);
            Controls.Add(lblKinesiologo);
            Controls.Add(panelPrincipal);
            Name = "Inicio";
            Text = "Inicio";
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelPrincipal;
        private Guna.UI2.WinForms.Guna2Button btnRegistarPaciente;
        private Guna.UI2.WinForms.Guna2Button btnBuscarPaciente;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHora;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFecha;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBoxKine;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKinesiologo;
        private Guna.UI2.WinForms.Guna2Button btnUltimasSesiones;
        private Guna.UI2.WinForms.Guna2Button btnCargarPlanGenerico;
    }
}
