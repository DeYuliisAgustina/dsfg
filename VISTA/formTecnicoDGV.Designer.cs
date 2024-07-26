namespace VISTA
{
    partial class formTecnicoDGV
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
            dgvTecnico = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscarTecnico = new TextBox();
            label1 = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTecnico).BeginInit();
            SuspendLayout();
            // 
            // dgvTecnico
            // 
            dgvTecnico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTecnico.Location = new Point(12, 126);
            dgvTecnico.Name = "dgvTecnico";
            dgvTecnico.RowTemplate.Height = 25;
            dgvTecnico.Size = new Size(749, 314);
            dgvTecnico.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(12, 88);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(83, 30);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Location = new Point(110, 88);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 30);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(210, 88);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 30);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(476, 90);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(83, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarTecnico
            // 
            txtBuscarTecnico.ForeColor = SystemColors.GrayText;
            txtBuscarTecnico.Location = new Point(565, 95);
            txtBuscarTecnico.Name = "txtBuscarTecnico";
            txtBuscarTecnico.Size = new Size(196, 23);
            txtBuscarTecnico.TabIndex = 5;
            txtBuscarTecnico.Text = "Por nombre, DNI o legajo";
            txtBuscarTecnico.TextAlign = HorizontalAlignment.Center;
            txtBuscarTecnico.Enter += txtBuscarTecnico_Enter;
            txtBuscarTecnico.KeyPress += txtBuscarTecnico_KeyPress;
            txtBuscarTecnico.Leave += txtBuscarTecnico_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(241, 9);
            label1.Name = "label1";
            label1.Size = new Size(222, 29);
            label1.TabIndex = 6;
            label1.Text = "Gestionar Técnicos";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(748, 9);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formTecnicoDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 450);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            Controls.Add(txtBuscarTecnico);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTecnico);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formTecnicoDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formSoporteDGV";
            Load += formTecnicoDGV_Load;
            MouseDown += formTecnicoDGV_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvTecnico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTecnico;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscarTecnico;
        private Label label1;
        private Button btnCerrar;
    }
}