namespace VISTA
{
    partial class formComputadoraAM
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
            btnCerrar = new Button();
            label1 = new Label();
            lblAgregaroModificar = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtCodigoComputadora = new TextBox();
            cbLaboratorio = new ComboBox();
            cbEstado = new ComboBox();
            cbCondicion = new ComboBox();
            txtDescripcion = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            cbSede = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(473, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(108, 9);
            label1.Name = "label1";
            label1.Size = new Size(251, 25);
            label1.TabIndex = 7;
            label1.Text = "Gestionar Computadoras";
            // 
            // lblAgregaroModificar
            // 
            lblAgregaroModificar.AutoSize = true;
            lblAgregaroModificar.Location = new Point(131, 39);
            lblAgregaroModificar.Name = "lblAgregaroModificar";
            lblAgregaroModificar.Size = new Size(195, 15);
            lblAgregaroModificar.TabIndex = 8;
            lblAgregaroModificar.Text = "Agregar o Modificar Computadoras";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(31, 91);
            label3.Name = "label3";
            label3.Size = new Size(164, 20);
            label3.TabIndex = 9;
            label3.Text = "Código Computadora:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(31, 177);
            label5.Name = "label5";
            label5.Size = new Size(168, 20);
            label5.TabIndex = 11;
            label5.Text = "Agregar a Laboratorio:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(31, 231);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 12;
            label6.Text = "Estado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(31, 278);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 13;
            label7.Text = "Condición:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(31, 329);
            label8.Name = "label8";
            label8.Size = new Size(96, 20);
            label8.TabIndex = 14;
            label8.Text = "Descripción:";
            // 
            // txtCodigoComputadora
            // 
            txtCodigoComputadora.ForeColor = SystemColors.GrayText;
            txtCodigoComputadora.Location = new Point(209, 88);
            txtCodigoComputadora.Name = "txtCodigoComputadora";
            txtCodigoComputadora.Size = new Size(220, 23);
            txtCodigoComputadora.TabIndex = 15;
            txtCodigoComputadora.Text = "Ingrese el código de la computadora";
            txtCodigoComputadora.Enter += txtCodigoComputadora_Enter;
            txtCodigoComputadora.KeyPress += txtCodigoComputadora_KeyPress;
            txtCodigoComputadora.Leave += txtCodigoComputadora_Leave;
            // 
            // cbLaboratorio
            // 
            cbLaboratorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLaboratorio.FormattingEnabled = true;
            cbLaboratorio.Location = new Point(209, 174);
            cbLaboratorio.Name = "cbLaboratorio";
            cbLaboratorio.Size = new Size(220, 23);
            cbLaboratorio.TabIndex = 17;
            // 
            // cbEstado
            // 
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(209, 228);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(220, 23);
            cbEstado.TabIndex = 18;
            // 
            // cbCondicion
            // 
            cbCondicion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicion.FormattingEnabled = true;
            cbCondicion.Location = new Point(209, 275);
            cbCondicion.Name = "cbCondicion";
            cbCondicion.Size = new Size(220, 23);
            cbCondicion.TabIndex = 19;
            // 
            // txtDescripcion
            // 
            txtDescripcion.ForeColor = SystemColors.GrayText;
            txtDescripcion.Location = new Point(209, 330);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(220, 78);
            txtDescripcion.TabIndex = 20;
            txtDescripcion.Text = "Ingrese una descripción de la computadora...";
            txtDescripcion.Enter += txtDescripcion_Enter;
            txtDescripcion.Leave += txtDescripcion_Leave;
            // 
            // btnAceptar
            // 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Location = new Point(127, 444);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(83, 30);
            btnAceptar.TabIndex = 21;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(272, 444);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 30);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbSede
            // 
            cbSede.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSede.FormattingEnabled = true;
            cbSede.Location = new Point(209, 131);
            cbSede.Name = "cbSede";
            cbSede.Size = new Size(220, 23);
            cbSede.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(31, 134);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 24;
            label2.Text = "Agregar a la Sede:";
            // 
            // formComputadoraAM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 479);
            Controls.Add(label2);
            Controls.Add(cbSede);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            Controls.Add(cbCondicion);
            Controls.Add(cbEstado);
            Controls.Add(cbLaboratorio);
            Controls.Add(txtCodigoComputadora);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(lblAgregaroModificar);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formComputadoraAM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formComputadoraAM";
            Load += formComputadoraAM_Load;
            MouseDown += formComputadoraAM_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Label label1;
        private Label lblAgregaroModificar;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtCodigoComputadora;
        private ComboBox cbLaboratorio;
        private ComboBox cbEstado;
        private ComboBox cbCondicion;
        private TextBox txtDescripcion;
        private Button btnAceptar;
        private Button btnCancelar;
        private ComboBox cbSede;
        private Label label2;
    }
}