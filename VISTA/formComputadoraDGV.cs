using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formComputadoraDGV : Form
    {
        public formComputadoraDGV()
        {
            InitializeComponent();
            ActualizarGrilla();
            dgvComputadora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //con esto hago que las columnas se ajusten al contenido
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ActualizarGrilla()
        {
            dgvComputadora.DataSource = null;
            dgvComputadora.DataSource = ControladoraLaboratorio.Instancia.RecuperarLaboratorios();
            dgvComputadora.DataSource = ControladoraComputadora.Instancia.RecuperarComputadoras();
            dgvComputadora.Columns["Tickets"].Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formComputadoraAM = new formComputadoraAM();
            formComputadoraAM.ShowDialog();
            ActualizarGrilla();
        }

        private void formComputadoraDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComputadora.Rows.Count > 0)
            {
                var computadoraSeleccionada = (Computadora)dgvComputadora.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar la computadora?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraComputadora.Instancia.EliminarComputadora(computadoraSeleccionada);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una computadora para eliminarla");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvComputadora.Rows.Count > 0)
            {
                var computadoraSeleccionada = (Computadora)dgvComputadora.CurrentRow.DataBoundItem;
                formComputadoraAM formComputadoraAM = new formComputadoraAM(computadoraSeleccionada);
                formComputadoraAM.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una computadora para modificarla");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarComputadora.Text != "Por código, sede o laboratorio")
            {
                var listaComputadora = ControladoraComputadora.Instancia.RecuperarComputadoras();
                var computadorasEncontradas = listaComputadora.Where(c => c.CodigoComputadora.ToLower().Contains(txtBuscarComputadora.Text.ToLower()) || c.Laboratorio.NombreLaboratorio.ToLower().Contains(txtBuscarComputadora.Text.ToLower()) || c.NombreSede.ToLower().Contains(txtBuscarComputadora.Text.ToLower())).ToList();

                if (computadorasEncontradas.Count > 0)
                {
                    dgvComputadora.DataSource = null;
                    dgvComputadora.DataSource = computadorasEncontradas;
                    dgvComputadora.Columns["Tickets"].Visible = false;

                }
                else
                {
                    MessageBox.Show("No se han encontrado los datos ingresados.");
                    ActualizarGrilla();
                    dgvComputadora.Columns["Tickets"].Visible = false;

                }
            }
            else
            {
                MessageBox.Show("Ingrese un código de computadora,nombre de sede o laboratorio para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarGrilla();
                dgvComputadora.Columns["Tickets"].Visible = false;

            }
        }

        private void txtBuscarComputadora_Enter(object sender, EventArgs e)
        {
            if (txtBuscarComputadora.Text == "Por código, sede o laboratorio")
            {
                txtBuscarComputadora.Text = "";
                txtBuscarComputadora.ForeColor = Color.Black;
            }
        }

        private void txtBuscarComputadora_Leave(object sender, EventArgs e)
        {
            if (txtBuscarComputadora.Text == "")
            {
                txtBuscarComputadora.Text = "Por código, sede o laboratorio";
                txtBuscarComputadora.ForeColor = Color.Silver;
            }
        }

        private void formComputadoraDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscarComputadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtBuscarComputadora.Text).Handled)
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
