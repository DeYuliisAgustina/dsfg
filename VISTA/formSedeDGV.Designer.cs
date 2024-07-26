namespace VISTA
{
    partial class formSedeDGV
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
            dgvSede = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscarSede = new TextBox();
            label1 = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSede).BeginInit();
            SuspendLayout();
            // 
            // dgvSede
            // 
            dgvSede.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSede.Location = new Point(12, 124);
            dgvSede.Name = "dgvSede";
            dgvSede.RowTemplate.Height = 25;
            dgvSede.Size = new Size(749, 314);
            dgvSede.TabIndex = 0;
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
            btnModificar.Location = new Point(116, 88);
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
            btnEliminar.Location = new Point(227, 88);
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
            btnBuscar.Location = new Point(497, 90);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(83, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarSede
            // 
            txtBuscarSede.ForeColor = SystemColors.GrayText;
            txtBuscarSede.Location = new Point(586, 95);
            txtBuscarSede.Name = "txtBuscarSede";
            txtBuscarSede.Size = new Size(175, 23);
            txtBuscarSede.TabIndex = 5;
            txtBuscarSede.Text = "Por nombre o dirección";
            txtBuscarSede.TextAlign = HorizontalAlignment.Center;
            txtBuscarSede.Enter += txtBuscarSede_Enter;
            txtBuscarSede.KeyPress += txtBuscarSede_KeyPress;
            txtBuscarSede.Leave += txtBuscarSede_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(272, 9);
            label1.Name = "label1";
            label1.Size = new Size(193, 29);
            label1.TabIndex = 6;
            label1.Text = "Gestionar Sedes";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(749, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formSedeDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 450);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            Controls.Add(txtBuscarSede);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvSede);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formSedeDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formSedeDGV";
            Load += formSedeDGV_Load;
            MouseDown += formSedeDGV_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvSede).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSede;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscarSede;
        private Label label1;
        private Button btnCerrar;
    }
}