using Controladora;
using Entidades;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formSedeAM : Form
    {
        private Sede sede; // variable de tipo Sede para almacenar la sede que se va a modificar
        private bool modificar = false;

        public formSedeAM()
        {
            InitializeComponent();
            sede = new Sede();
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public formSedeAM(Sede sedeModificar)
        {
            InitializeComponent();
            sede = sedeModificar;
            modificar = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formSedeAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Sede";

                txtNombreSede.Text = sede.NombreSede.ToString();
                txtDireccionSede.Text = sede.DireccionSede.ToString();
            }
            else lblAgregaroModificar.Text = "Agregar Sede";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar la sede?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        sede.Universidad = ControladoraSede.Instancia.RecuperarUniversidad();
                        if (ControladoraSede.Instancia.RecuperarSedes().Any(s => s.UniversidadId == sede.UniversidadId && s.NombreSede.ToLower() == txtNombreSede.Text.ToLower() && s.SedeId != sede.SedeId)) //con s.SedeId != sede.SedeId comparo el SedeId del elemento s con el SedeId de la sede actual verificando que el elemento no sea la misma sede que se está modificando.
                        {
                            MessageBox.Show("Ya existe una sede con ese nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (ControladoraSede.Instancia.RecuperarSedes().Any(s => s.UniversidadId == sede.UniversidadId && s.DireccionSede.ToLower() == txtDireccionSede.Text.ToLower() && s.SedeId != sede.SedeId))
                        {
                            MessageBox.Show("Ya existe una sede con esa dirección.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        sede.NombreSede = txtNombreSede.Text;
                        sede.DireccionSede = txtDireccionSede.Text;

                        var mensaje = ControladoraSede.Instancia.ModificarSede(sede);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    sede.Universidad = ControladoraSede.Instancia.RecuperarUniversidad();
                    if (ControladoraSede.Instancia.RecuperarSedes().Any(s => s.NombreSede.ToLower() == txtNombreSede.Text.ToLower()))
                    {
                        MessageBox.Show("Ya existe una sede con ese nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ControladoraSede.Instancia.RecuperarSedes().Any(s => s.DireccionSede.ToLower() == txtDireccionSede.Text.ToLower()))
                    {
                        MessageBox.Show("Ya existe una sede con esa dirección.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sede.NombreSede = txtNombreSede.Text;
                    sede.DireccionSede = txtDireccionSede.Text;

                    var mensaje = ControladoraSede.Instancia.AgregarSede(sede);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreSede.Text) || txtNombreSede.Text == "Ingrese un nombre")
            {
                MessageBox.Show("Debe ingresar un nombre para la sede.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccionSede.Text) || txtDireccionSede.Text == "Ingrese una dirección")
            {
                MessageBox.Show("Debe ingresar una direccion de la sede.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtNombreSede_Enter(object sender, EventArgs e)
        {
            if (txtNombreSede.Text == "Ingrese un nombre")
            {
                txtNombreSede.Text = "";
                txtNombreSede.ForeColor = Color.Black;
            }
        }

        private void txtNombreSede_Leave(object sender, EventArgs e)
        {
            if (txtNombreSede.Text == "")
            {
                txtNombreSede.Text = "Ingrese un nombre";
                txtNombreSede.ForeColor = Color.Silver;
            }
        }

        private void txtDireccionSede_Enter(object sender, EventArgs e)
        {
            if (txtDireccionSede.Text == "Ingrese una dirección")
            {
                txtDireccionSede.Text = "";
                txtDireccionSede.ForeColor = Color.Black;
            }
        }

        private void txtDireccionSede_Leave(object sender, EventArgs e)
        {
            if (txtDireccionSede.Text == "")
            {
                txtDireccionSede.Text = "Ingrese una dirección";
                txtDireccionSede.ForeColor = Color.Silver;
            }
        }

        private void formSedeAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNombreSede_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtNombreSede.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras y números, no caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDireccionSede_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtDireccionSede.Text).Handled)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
