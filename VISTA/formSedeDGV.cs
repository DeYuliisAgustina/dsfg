using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formSedeDGV : Form
    {

        public formSedeDGV()
        {
            InitializeComponent();
            ActualizarGrilla();
            dgvSede.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //con esto hago que las columnas se ajusten al contenido
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ActualizarGrilla()
        {
            dgvSede.DataSource = null;
            dgvSede.DataSource = ControladoraSede.Instancia.RecuperarSedes();
            dgvSede.Columns["Universidad"].Visible = false; //lo oculto para prolijidad
            dgvSede.Columns["Laboratorios"].Visible = false;

        }

        private void formSedeDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formSedeAM = new formSedeAM();
            formSedeAM.ShowDialog();
            ActualizarGrilla();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSede.Rows.Count > 0)
            {
                var sede = (Sede)dgvSede.CurrentRow.DataBoundItem;

                // Prompt the user to confirm the deletion
                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar esta sede?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var mensaje = ControladoraSede.Instancia.EliminarSede(sede);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una sede para eliminarla.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvSede.Rows.Count > 0)
            {
                var sedeSeleccionada = (Sede)dgvSede.CurrentRow.DataBoundItem;
                formSedeAM formSedeAM = new formSedeAM(sedeSeleccionada);
                formSedeAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una sede para modificarla.");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarSede.Text != "Por nombre o dirección")
            {
                var listaSedes = ControladoraSede.Instancia.RecuperarSedes();
                var sedeEncontrada = listaSedes.FirstOrDefault(c => c.NombreSede.ToLower().Contains(txtBuscarSede.Text.ToLower()) || c.DireccionSede.ToLower().Contains(txtBuscarSede.Text.ToLower()) || c.SedeId.ToString().Contains(txtBuscarSede.Text));
                if (sedeEncontrada != null)
                {
                    dgvSede.DataSource = null; //limpio la grilla
                    dgvSede.DataSource = new List<Sede> { sedeEncontrada }; //visualizo la sede encontrada en la grilla
                    dgvSede.Columns["Universidad"].Visible = false; //lo oculto para prolijidad
                    dgvSede.Columns["Laboratorios"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No se han encontrado los datos ingresados.");
                    ActualizarGrilla();
                }
            }
            else
            {

                MessageBox.Show("Ingrese un nombre o una dirección de sede para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarGrilla();
            }

        }

        private void txtBuscarSede_Enter(object sender, EventArgs e)
        {
            if (txtBuscarSede.Text == "Por nombre o dirección")
            {
                txtBuscarSede.Text = "";
                txtBuscarSede.ForeColor = Color.Black;
            }
        }

        private void txtBuscarSede_Leave(object sender, EventArgs e)
        {
            if (txtBuscarSede.Text == "")
            {
                txtBuscarSede.Text = "Por nombre o dirección";
                txtBuscarSede.ForeColor = Color.Silver;
            }
        }

        private void formSedeDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscarSede_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtBuscarSede.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public KeyPressEventArgs KeyPressSoloLetras(KeyPressEventArgs e, string TEXTO)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }
    }
}

