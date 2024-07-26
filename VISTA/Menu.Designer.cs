namespace VISTA
{
    partial class Menu
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
            label2 = new Label();
            btnSedeMenu = new Button();
            btnLaboratorioMenu = new Button();
            btnComputadoraMenu = new Button();
            btnTicketMenu = new Button();
            btnTecnicosMenu = new Button();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(350, 2);
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
            label1.Location = new Point(142, 8);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 2;
            label1.Text = "Menu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(96, 33);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 3;
            label2.Text = "Sistema Gestión";
            // 
            // btnSedeMenu
            // 
            btnSedeMenu.FlatStyle = FlatStyle.Flat;
            btnSedeMenu.Location = new Point(133, 84);
            btnSedeMenu.Name = "btnSedeMenu";
            btnSedeMenu.Size = new Size(97, 63);
            btnSedeMenu.TabIndex = 4;
            btnSedeMenu.Text = "Gestionar Sedes";
            btnSedeMenu.UseVisualStyleBackColor = true;
            btnSedeMenu.Click += btnSedeMenu_Click;
            // 
            // btnLaboratorioMenu
            // 
            btnLaboratorioMenu.FlatStyle = FlatStyle.Flat;
            btnLaboratorioMenu.Location = new Point(133, 167);
            btnLaboratorioMenu.Name = "btnLaboratorioMenu";
            btnLaboratorioMenu.Size = new Size(97, 63);
            btnLaboratorioMenu.TabIndex = 5;
            btnLaboratorioMenu.Text = "Gestionar Laboratorios";
            btnLaboratorioMenu.UseVisualStyleBackColor = true;
            btnLaboratorioMenu.Click += btnLaboratorioMenu_Click;
            // 
            // btnComputadoraMenu
            // 
            btnComputadoraMenu.FlatStyle = FlatStyle.Flat;
            btnComputadoraMenu.Location = new Point(133, 248);
            btnComputadoraMenu.Name = "btnComputadoraMenu";
            btnComputadoraMenu.Size = new Size(97, 63);
            btnComputadoraMenu.TabIndex = 6;
            btnComputadoraMenu.Text = "Gestionar Computadoras";
            btnComputadoraMenu.UseVisualStyleBackColor = true;
            btnComputadoraMenu.Click += btnComputadoraMenu_Click;
            // 
            // btnTicketMenu
            // 
            btnTicketMenu.FlatStyle = FlatStyle.Flat;
            btnTicketMenu.Location = new Point(133, 405);
            btnTicketMenu.Name = "btnTicketMenu";
            btnTicketMenu.Size = new Size(97, 63);
            btnTicketMenu.TabIndex = 7;
            btnTicketMenu.Text = "Gestionar Tickets";
            btnTicketMenu.UseVisualStyleBackColor = true;
            btnTicketMenu.Click += btnTicketMenu_Click;
            // 
            // btnTecnicosMenu
            // 
            btnTecnicosMenu.FlatStyle = FlatStyle.Flat;
            btnTecnicosMenu.Location = new Point(133, 326);
            btnTecnicosMenu.Name = "btnTecnicosMenu";
            btnTecnicosMenu.Size = new Size(97, 63);
            btnTecnicosMenu.TabIndex = 8;
            btnTecnicosMenu.Text = "Gestionar Técnicos";
            btnTecnicosMenu.UseVisualStyleBackColor = true;
            btnTecnicosMenu.Click += btnTecnicosMenu_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 495);
            Controls.Add(btnTecnicosMenu);
            Controls.Add(btnTicketMenu);
            Controls.Add(btnComputadoraMenu);
            Controls.Add(btnLaboratorioMenu);
            Controls.Add(btnSedeMenu);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += Menu_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Label label1;
        private Label label2;
        private Button btnSedeMenu;
        private Button btnLaboratorioMenu;
        private Button btnComputadoraMenu;
        private Button btnTicketMenu;
        private Button btnTecnicosMenu;
    }
}