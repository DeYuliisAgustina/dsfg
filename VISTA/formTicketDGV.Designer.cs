namespace VISTA
{
    partial class formTicketDGV
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
            dgvTicket = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            txtBuscarTicket = new TextBox();
            btnCerrar = new Button();
            label1 = new Label();
            btnImprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).BeginInit();
            SuspendLayout();
            // 
            // dgvTicket
            // 
            dgvTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTicket.Location = new Point(12, 124);
            dgvTicket.Name = "dgvTicket";
            dgvTicket.RowTemplate.Height = 25;
            dgvTicket.Size = new Size(749, 314);
            dgvTicket.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Location = new Point(12, 91);
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
            btnModificar.Location = new Point(102, 91);
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
            btnEliminar.Location = new Point(195, 91);
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
            btnBuscar.Location = new Point(422, 91);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(83, 30);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarTicket
            // 
            txtBuscarTicket.ForeColor = SystemColors.GrayText;
            txtBuscarTicket.Location = new Point(511, 96);
            txtBuscarTicket.Name = "txtBuscarTicket";
            txtBuscarTicket.Size = new Size(250, 23);
            txtBuscarTicket.TabIndex = 5;
            txtBuscarTicket.Text = "Por código de pc, técnico, sede o laboratorio";
            txtBuscarTicket.TextAlign = HorizontalAlignment.Center;
            txtBuscarTicket.Enter += txtBuscarTicket_Enter;
            txtBuscarTicket.KeyPress += txtBuscarTicket_KeyPress;
            txtBuscarTicket.Leave += txtBuscarTicket_Leave;
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(755, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(24, 24);
            btnCerrar.TabIndex = 6;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(278, 9);
            label1.Name = "label1";
            label1.Size = new Size(185, 29);
            label1.TabIndex = 8;
            label1.Text = "Historial Tickets";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = SystemColors.ActiveCaption;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnImprimir.Location = new Point(12, 9);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(178, 30);
            btnImprimir.TabIndex = 9;
            btnImprimir.Text = "Terminar e Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // formTicketDGV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 450);
            Controls.Add(btnImprimir);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            Controls.Add(txtBuscarTicket);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTicket);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formTicketDGV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formHistorialDGV";
            Load += formHistorialDGV_Load;
            MouseDown += formTicketDGV_MouseDown;
            ((System.ComponentModel.ISupportInitialize)dgvTicket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTicket;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnBuscar;
        private TextBox txtBuscarTicket;
        private Button btnCerrar;
        private Label label1;
        private Button btnImprimir;
    }
}