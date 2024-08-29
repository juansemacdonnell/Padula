namespace SistemaKinesiologia.Pantallas
{
    partial class PantallaConfirmacion
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaConfirmacion));
            panel1 = new Panel();
            btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            lblPregunta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnConfirmar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(lblPregunta);
            panel1.Location = new Point(34, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 145);
            panel1.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(220, 100, 100);
            btnConfirmar.BorderColor = Color.DimGray;
            btnConfirmar.BorderThickness = 2;
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.CustomizableEdges = customizableEdges1;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.FillColor = Color.FromArgb(164, 198, 57);
            btnConfirmar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(178, 87);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnConfirmar.Size = new Size(133, 34);
            btnConfirmar.TabIndex = 36;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(220, 100, 100);
            btnCancelar.BorderColor = Color.DimGray;
            btnCancelar.BorderThickness = 2;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.CustomizableEdges = customizableEdges3;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelar.FillColor = Color.FromArgb(220, 100, 100);
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(39, 87);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancelar.Size = new Size(133, 34);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblPregunta
            // 
            lblPregunta.BackColor = Color.Transparent;
            lblPregunta.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPregunta.Location = new Point(32, 25);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(292, 27);
            lblPregunta.TabIndex = 0;
            lblPregunta.Text = "¿Confirmar registro de paciente?";
            // 
            // PantallaConfirmacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(428, 208);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PantallaConfirmacion";
            Text = "¡ AVISO !";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPregunta;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
    }
}