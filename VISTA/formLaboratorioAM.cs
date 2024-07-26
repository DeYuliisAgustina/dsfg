using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formLaboratorioAM : Form
    {
        private Laboratorio laboratorio; // variable de tipo Sede para almacenar la sede que se va a modificar
        private bool modificar = false;

        public formLaboratorioAM()
        {
            InitializeComponent();
            laboratorio = new Laboratorio();
            ActualizarCb();
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public formLaboratorioAM(Laboratorio laboratorioModificar)
        {
            InitializeComponent();
            laboratorio = laboratorioModificar;
            modificar = true;
            ActualizarCb();
        }

        public void ActualizarCb()
        {
            foreach (Sede sede in ControladoraSede.Instancia.RecuperarSedes()) // se recorren las sedes para agregarlas al combobox de sedes para que el usuario pueda seleccionar una sede para el laboratorio que se va a modificar
            {
                cbSedes.Items.Add(sede.NombreSede.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formLaboratorioAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Laboratorio";

                txtNombreLaboratorio.Text = laboratorio.NombreLaboratorio.ToString();
                cbSedes.SelectedItem = laboratorio.Sede.NombreSede.ToString(); // se selecciona la sede del laboratorio que se va a modificar en el combobox de sedes
                numCapacidad.Value = laboratorio.CapacidadMaxima;

            }
            else
            {
                cbSedes.Items.Add("Seleccione una sede...");
                cbSedes.SelectedItem = "Seleccione una sede...";

                lblAgregaroModificar.Text = "Agregar Laboratorio";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea modificar el laboratorio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {


                        string NombreSede = cbSedes.Text; // se recupera el nombre de la sede seleccionada del combobox de sedes
                        if (ControladoraLaboratorio.Instancia.RecuperarLaboratorios().Any(l => l.Sede.NombreSede.ToLower() == NombreSede.ToLower() && l.NombreLaboratorio.ToLower() == txtNombreLaboratorio.Text.ToLower() && l.LaboratorioId != laboratorio.LaboratorioId))
                        {
                            MessageBox.Show("Ya existe un laboratorio con ese nombre en la sede seleccionada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        laboratorio.Sede = ControladoraSede.Instancia.RecuperarSedes().FirstOrDefault(s => s.NombreSede.ToLower() == NombreSede.ToLower()); // se recupera la sede seleccionada del combobox de sedes para asignarla al laboratorio que se va a modificar
                        laboratorio.CapacidadMaxima = (int)numCapacidad.Value;
                        laboratorio.NombreLaboratorio = txtNombreLaboratorio.Text;

                        var mensaje = ControladoraLaboratorio.Instancia.ModificarLaboratorio(laboratorio);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    string NombreSede = cbSedes.Text; // se recupera el nombre de la sede seleccionada del combobox de sedes
                    laboratorio.Sede = ControladoraSede.Instancia.RecuperarSedes().FirstOrDefault(s => s.NombreSede.ToLower() == NombreSede.ToLower()); // se recupera la sede seleccionada del combobox de sedes para asignarla al laboratorio que se va a modificar
                    laboratorio.CapacidadMaxima = (int)numCapacidad.Value;
                    laboratorio.NombreLaboratorio = txtNombreLaboratorio.Text;

                    var mensaje = ControladoraLaboratorio.Instancia.AgregarLaboratorio(laboratorio);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreLaboratorio.Text) || txtNombreLaboratorio.Text == "Ingrese un nombre...")
            {
                MessageBox.Show("Debe ingresar un nombre de laboratorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbSedes.SelectedItem == null || cbSedes.SelectedItem.ToString() == "Seleccione una sede...")
            {
                MessageBox.Show("Debe seleccionar una sede para agregar el laboratorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numCapacidad.Value == 0 || numCapacidad.Value < 0) //valido que la capacidad máxima de computadoras sea mayor a 0
            {
                MessageBox.Show("Debe ingresar un número de capacidad máxima mayor a 0 de computadoras para el laboratorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtNombreLaboratorio_Enter(object sender, EventArgs e)
        {
            if (txtNombreLaboratorio.Text == "Ingrese un nombre...")
            {
                txtNombreLaboratorio.Text = "";
                txtNombreLaboratorio.ForeColor = Color.Black;
            }
        }

        private void txtNombreLaboratorio_Leave(object sender, EventArgs e)
        {
            if (txtNombreLaboratorio.Text == "")
            {
                txtNombreLaboratorio.Text = "Ingrese un nombre...";
                txtNombreLaboratorio.ForeColor = Color.Silver;
            }
        }

        private void formLaboratorioAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNombreLaboratorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtNombreLaboratorio.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
