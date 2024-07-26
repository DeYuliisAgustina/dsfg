namespace VISTA
{
    partial class formSedeAM
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
            label1 = new Label();
            lblAgregaroModificar = new Label();
            btnCerrar = new Button();
            label3 = new Label();
            label4 = new Label();
            txtNombreSede = new TextBox();
            txtDireccionSede = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(88, 9);
            label1.Name = "label1";
            label1.Size = new Size(172, 25);
            label1.TabIndex = 0;
            label1.Text = "Gestionar Sedes";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(99, 44);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(146, 15);
            lblAgregaroModificar.TabIndex = 1;
            lblAgregaroModificar.Text = "Agregar o Modificar Sedes";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(347, 5);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 96);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 4;
            label3.Text = "Nombre Sede:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(10, 150);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 5;
            label4.Text = "Dirección Sede:";
            // 
            // txtNombreSede
            // 
            txtNombreSede.BackColor = SystemColors.Window;
            txtNombreSede.ForeColor = SystemColors.GrayText;
            txtNombreSede.Location = new Point(185, 93);
            txtNombreSede.Name = "txtNombreSede";
            txtNombreSede.Size = new Size(179, 23);
            txtNombreSede.TabIndex = 7;
            txtNombreSede.Text = "Ingrese un nombre";
            txtNombreSede.Enter += txtNombreSede_Enter;
            txtNombreSede.KeyPress += txtNombreSede_KeyPress;
            txtNombreSede.Leave += txtNombreSede_Leave;
            // 
            // txtDireccionSede
            // 
            txtDireccionSede.ForeColor = SystemColors.GrayText;
            txtDireccionSede.Location = new Point(185, 147);
            txtDireccionSede.Name = "txtDireccionSede";
            txtDireccionSede.Size = new Size(179, 23);
            txtDireccionSede.TabIndex = 8;
            txtDireccionSede.Text = "Ingrese una dirección";
            txtDireccionSede.Enter += txtDireccionSede_Enter;
            txtDireccionSede.KeyPress += txtDireccionSede_KeyPress;
            txtDireccionSede.Leave += txtDireccionSede_Leave;
            // 
            // btnAceptar
            // 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(88, 207);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 30);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(185, 207);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 30);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // formSedeAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 254);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDireccionSede);
            Controls.Add(txtNombreSede);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCerrar);
            Controls.Add(lblAgregaroModificar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formSedeAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formSedeAM";
            Load += formSedeAM_Load;
            MouseDown += formSedeAM_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblAgregaroModificar;
        private Button btnCerrar;
        private Label label3;
        private Label label4;
        private TextBox txtNombreSede;
        private TextBox txtDireccionSede;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}