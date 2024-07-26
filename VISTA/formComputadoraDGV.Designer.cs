namespace VISTA
{
    partial class formComputadoraDGV
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
            dgvComputadora = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscarComputadora = new TextBox();
            label1 = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComputadora).BeginInit();
            SuspendLayout();
            // 
            // dgvComputadora
            // 
            dgvComputadora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComputadora.Location = new Point(12, 124);
            dgvComputadora.Name = "dgvComputadora";
            dgvComputadora.RowTemplate.Height = 25;
            dgvComputadora.Size = new Size(749, 314);
            dgvComputadora.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(13, 89);
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
            btnModificar.Location = new Point(117, 89);
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
            btnEliminar.Location = new Point(226, 89);
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
            btnBuscar.Location = new Point(487, 89);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(83, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarComputadora
            // 
            txtBuscarComputadora.ForeColor = SystemColors.GrayText;
            txtBuscarComputadora.Location = new Point(576, 94);
            txtBuscarComputadora.Name = "txtBuscarComputadora";
            txtBuscarComputadora.Size = new Size(185, 23);
            txtBuscarComputadora.TabIndex = 5;
            txtBuscarComputadora.Text = "Por código, sede o laboratorio";
            txtBuscarComputadora.TextAlign = HorizontalAlignment.Center;
            txtBuscarComputadora.Enter += txtBuscarComputadora_Enter;
            txtBuscarComputadora.KeyPress += txtBuscarComputadora_KeyPress;
            txtBuscarComputadora.Leave += txtBuscarComputadora_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(253, 9);
            label1.Name = "label1";
            label1.Size = new Size(251, 25);
            label1.TabIndex = 6;
            label1.Text = "Gestionar Computadoras";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(756, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formComputadoraDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 450);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            Controls.Add(txtBuscarComputadora);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvComputadora);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formComputadoraDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formComputadoraDGV";
            Load += formComputadoraDGV_Load;
            MouseDown += formComputadoraDGV_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvComputadora).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvComputadora;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscarComputadora;
        private Label label1;
        private Button btnCerrar;
    }
}