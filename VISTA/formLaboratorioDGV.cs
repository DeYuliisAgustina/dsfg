using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formLaboratorioDGV : Form
    {
        public formLaboratorioDGV()
        {
            InitializeComponent();
            dgvLaboratorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //con esto hago que las columnas se ajusten al contenido
            ActualizarGrilla();

        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ActualizarGrilla()
        {
            dgvLaboratorio.DataSource = null;
            dgvLaboratorio.DataSource = ControladoraSede.Instancia.RecuperarSedes();
            dgvLaboratorio.DataSource = ControladoraLaboratorio.Instancia.RecuperarLaboratorios();
            dgvLaboratorio.Columns["Computadoras"].Visible = false;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formLaboratorioDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formLaboratorioAM = new formLaboratorioAM();
            formLaboratorioAM.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLaboratorio.Rows.Count > 0)
            {
                var laboratorioSeleccionado = (Laboratorio)dgvLaboratorio.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el laboratorio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var mensaje = ControladoraLaboratorio.Instancia.EliminarLaboratorio(laboratorioSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un laboratorio para eliminarlo.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvLaboratorio.Rows.Count > 0)
            {
                var laboratorioSeleccionado = (Laboratorio)dgvLaboratorio.CurrentRow.DataBoundItem;
                formLaboratorioAM formLaboratorioAM = new formLaboratorioAM(laboratorioSeleccionado);
                formLaboratorioAM.ShowDialog();
                ActualizarGrilla();

            }
            else
            {
                MessageBox.Show("Seleccione un laboratorio para modificarlo.");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarLaboratorio.Text != "Por nombre o sede")
            {
                var listaLaboratorio = ControladoraLaboratorio.Instancia.RecuperarLaboratorios();
                var listaSede = ControladoraSede.Instancia.RecuperarSedes();

                var laboratorioEncontrado = listaLaboratorio.FirstOrDefault(l => l.NombreLaboratorio.ToLower().Contains(txtBuscarLaboratorio.Text.ToLower()));
                var sedeEncontrada = listaSede.FirstOrDefault(s => s.NombreSede.ToLower().Contains(txtBuscarLaboratorio.Text.ToLower()));

                if (laboratorioEncontrado != null) //si se encuentra el laboratorio
                {
                    dgvLaboratorio.DataSource = null; //limpio la grilla
                    dgvLaboratorio.DataSource = new List<Laboratorio> { laboratorioEncontrado }; //agrego el laboratorio encontrado a la grilla
                    dgvLaboratorio.Columns["Computadoras"].Visible = false;

                }
                else if (sedeEncontrada != null) //si se encuentra la sede
                {
                    dgvLaboratorio.DataSource = null;
                    dgvLaboratorio.DataSource = listaLaboratorio.Where(l => l.SedeId == sedeEncontrada.SedeId).ToList(); //lo mismo que con laboratorio
                    dgvLaboratorio.Columns["Computadoras"].Visible = false;

                }
                else
                {
                    MessageBox.Show("No se han encontrado los datos ingresados.");
                    ActualizarGrilla();
                    dgvLaboratorio.Columns["Computadoras"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de laboratorio o sede para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarGrilla();
                dgvLaboratorio.Columns["Computadoras"].Visible = false;
            }
        }

        private void txtBuscarLaboratorio_Enter(object sender, EventArgs e)
        {
            if (txtBuscarLaboratorio.Text == "Por nombre o sede")
            {
                txtBuscarLaboratorio.Text = "";
                txtBuscarLaboratorio.ForeColor = Color.Black;
            }
        }

        private void txtBuscarLaboratorio_Leave(object sender, EventArgs e)
        {
            if (txtBuscarLaboratorio.Text == "")
            {
                txtBuscarLaboratorio.Text = "Por nombre o sede";
                txtBuscarLaboratorio.ForeColor = Color.DimGray;
            }
        }

        private void formLaboratorioDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscarLaboratorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtBuscarLaboratorio.Text).Handled)
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
