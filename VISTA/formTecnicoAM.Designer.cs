namespace VISTA
{
    partial class formTecnicoAM
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
            label5 = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtNombreyApellido = new TextBox();
            txtDni = new TextBox();
            txtLegajo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(97, 9);
            label1.Name = "label1";
            label1.Size = new Size(222, 29);
            label1.TabIndex = 0;
            label1.Text = "Gestionar Técnicos";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(129, 38);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(161, 15);
            lblAgregaroModificar.TabIndex = 1;
            lblAgregaroModificar.Text = "Agregar o modificar Técnicos";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(390, 4);
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
            label3.Location = new Point(40, 91);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 4;
            label3.Text = "Nombre y Apellido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(40, 142);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 5;
            label4.Text = "DNI:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(40, 191);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 6;
            label5.Text = "Legajo:";
            // 
            // btnAceptar
            // 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(97, 238);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 30);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(207, 238);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 30);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNombreyApellido
            // 
            txtNombreyApellido.ForeColor = SystemColors.GrayText;
            txtNombreyApellido.Location = new Point(186, 91);
            txtNombreyApellido.Name = "txtNombreyApellido";
            txtNombreyApellido.Size = new Size(198, 23);
            txtNombreyApellido.TabIndex = 9;
            txtNombreyApellido.Text = "Ingrese un nombre y apellido";
            txtNombreyApellido.Enter += txtNombreyApellido_Enter;
            txtNombreyApellido.KeyPress += txtNombreyApellido_KeyPress;
            txtNombreyApellido.Leave += txtNombreyApellido_Leave;
            // 
            // txtDni
            // 
            txtDni.ForeColor = SystemColors.GrayText;
            txtDni.Location = new Point(186, 139);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(198, 23);
            txtDni.TabIndex = 10;
            txtDni.Text = "Ingrese un DNI";
            txtDni.Enter += txtDni_Enter;
            txtDni.KeyPress += txtDni_KeyPress;
            txtDni.Leave += txtDni_Leave;
            // 
            // txtLegajo
            // 
            txtLegajo.ForeColor = SystemColors.GrayText;
            txtLegajo.Location = new Point(186, 188);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(198, 23);
            txtLegajo.TabIndex = 11;
            txtLegajo.Text = "Ingrese un legajo";
            txtLegajo.Enter += txtLegajo_Enter;
            txtLegajo.KeyPress += txtLegajo_KeyPress;
            txtLegajo.Leave += txtLegajo_Leave;
            // 
            // formTecnicoAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 290);
            Controls.Add(txtLegajo);
            Controls.Add(txtDni);
            Controls.Add(txtNombreyApellido);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCerrar);
            Controls.Add(lblAgregaroModificar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formTecnicoAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formSoporteAM";
            Load += formTecnicoAM_Load;
            MouseDown += formTecnicoAM_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblAgregaroModificar;
        private Button btnCerrar;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtNombreyApellido;
        private TextBox txtDni;
        private TextBox txtLegajo;
    }
}