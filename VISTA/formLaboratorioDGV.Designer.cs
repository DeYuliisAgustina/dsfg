namespace VISTA
{
    partial class formLaboratorioDGV
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
            dgvLaboratorio = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscarLaboratorio = new TextBox();
            label1 = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorio).BeginInit();
            SuspendLayout();
            // 
            // dgvLaboratorio
            // 
            dgvLaboratorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratorio.Location = new Point(12, 124);
            dgvLaboratorio.Name = "dgvLaboratorio";
            dgvLaboratorio.RowTemplate.Height = 25;
            dgvLaboratorio.Size = new Size(749, 314);
            dgvLaboratorio.TabIndex = 0;
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
            btnModificar.Location = new Point(116, 89);
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
            btnEliminar.Location = new Point(223, 89);
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
            btnBuscar.Location = new Point(497, 88);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(83, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarLaboratorio
            // 
            txtBuscarLaboratorio.ForeColor = SystemColors.GrayText;
            txtBuscarLaboratorio.Location = new Point(586, 96);
            txtBuscarLaboratorio.Name = "txtBuscarLaboratorio";
            txtBuscarLaboratorio.Size = new Size(175, 23);
            txtBuscarLaboratorio.TabIndex = 5;
            txtBuscarLaboratorio.Text = "Por nombre o sede";
            txtBuscarLaboratorio.TextAlign = HorizontalAlignment.Center;
            txtBuscarLaboratorio.Enter += txtBuscarLaboratorio_Enter;
            txtBuscarLaboratorio.KeyPress += txtBuscarLaboratorio_KeyPress;
            txtBuscarLaboratorio.Leave += txtBuscarLaboratorio_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(252, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 29);
            label1.TabIndex = 7;
            label1.Text = "Gestionar Laboratorios";
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(748, 5);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // formLaboratorioDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 450);
            Controls.Add(btnCerrar);
            Controls.Add(label1);
            Controls.Add(txtBuscarLaboratorio);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvLaboratorio);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formLaboratorioDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formLaboratorioDGV";
            Load += formLaboratorioDGV_Load;
            MouseDown += formLaboratorioDGV_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLaboratorio;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscarLaboratorio;
        private Label label1;
        private Button btnCerrar;
    }
}