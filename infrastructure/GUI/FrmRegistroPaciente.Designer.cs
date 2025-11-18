namespace GestionClinica.infrastructure.GUI
{
    partial class FrmRegistroPaciente
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
            txtCedula = new TextBox();
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtTelefono = new TextBox();
            label3 = new Label();
            chkSeguro = new CheckBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(122, 266);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(100, 23);
            txtCedula.TabIndex = 0;
            txtCedula.Tag = "Cedula";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(260, 266);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 248);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Cedula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 248);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(382, 266);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(402, 248);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 5;
            label3.Text = "Telefono";
            // 
            // chkSeguro
            // 
            chkSeguro.AutoSize = true;
            chkSeguro.Location = new Point(548, 261);
            chkSeguro.Name = "chkSeguro";
            chkSeguro.Size = new Size(99, 19);
            chkSeguro.TabIndex = 6;
            chkSeguro.Text = "Tiene seguro?";
            chkSeguro.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(319, 327);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmRegistroPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(chkSeguro);
            Controls.Add(label3);
            Controls.Add(txtTelefono);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(txtCedula);
            Name = "FrmRegistroPaciente";
            Text = "FrmRegistroPaciente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCedula;
        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private TextBox txtTelefono;
        private Label label3;
        private CheckBox chkSeguro;
        private Button btnGuardar;
    }
}