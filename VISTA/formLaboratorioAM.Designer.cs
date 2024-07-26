namespace VISTA
{
    partial class formLaboratorioAM
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
            btnCerrar = new Button();
            lblAgregaroModificar = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            numCapacidad = new NumericUpDown();
            txtNombreLaboratorio = new TextBox();
            cbSedes = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(70, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 29);
            label1.TabIndex = 8;
            label1.Text = "Gestionar Laboratorios";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(405, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 9;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(112, 41);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(182, 15);
            lblAgregaroModificar.TabIndex = 11;
            lblAgregaroModificar.Text = "Agregar o Modificar Laboratorios";
            lblAgregaroModificar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 89);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 12;
            label3.Text = "Nombre Laboratorio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 13;
            label4.Text = "Agregar a la Sede:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 195);
            label6.Name = "label6";
            label6.Size = new Size(147, 20);
            label6.TabIndex = 15;
            label6.Text = "Capacidad Máxima:";
            // 
            // numCapacidad
            // 
            numCapacidad.Location = new Point(198, 192);
            numCapacidad.Name = "numCapacidad";
            numCapacidad.Size = new Size(214, 23);
            numCapacidad.TabIndex = 16;
            // 
            // txtNombreLaboratorio
            // 
            txtNombreLaboratorio.ForeColor = SystemColors.GrayText;
            txtNombreLaboratorio.Location = new Point(198, 86);
            txtNombreLaboratorio.Name = "txtNombreLaboratorio";
            txtNombreLaboratorio.Size = new Size(214, 23);
            txtNombreLaboratorio.TabIndex = 17;
            txtNombreLaboratorio.Text = "Ingrese un nombre...";
            txtNombreLaboratorio.Enter += txtNombreLaboratorio_Enter;
            txtNombreLaboratorio.KeyPress += txtNombreLaboratorio_KeyPress;
            txtNombreLaboratorio.Leave += txtNombreLaboratorio_Leave;
            // 
            // cbSedes
            // 
            cbSedes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSedes.FormattingEnabled = true;
            cbSedes.Location = new Point(198, 135);
            cbSedes.Name = "cbSedes";
            cbSedes.Size = new Size(214, 23);
            cbSedes.TabIndex = 18;
            // 
            // btnAceptar
            // 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(112, 255);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 30);
            btnAceptar.TabIndex = 20;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(211, 255);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 30);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // formLaboratorioAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 299);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cbSedes);
            Controls.Add(txtNombreLaboratorio);
            Controls.Add(numCapacidad);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblAgregaroModificar);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formLaboratorioAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formLaboratorioAM";
            Load += formLaboratorioAM_Load;
            MouseDown += formLaboratorioAM_MouseDown;
            ((System.ComponentModel.ISupportInitialize)numCapacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrar;
        private Label lblAgregaroModificar;
        private Label label3;
        private Label label4;
        private Label label6;
        private NumericUpDown numCapacidad;
        private TextBox txtNombreLaboratorio;
        private ComboBox cbSedes;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}