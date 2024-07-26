using Controladora;
using Entidades;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace VISTA
{
    public partial class formTecnicoAM : Form
    {
        private Tecnico tecnico; // variable de tipo Sede para almacenar la sede que se va a modificar
        private bool modificar = false;

        public formTecnicoAM()
        {
            InitializeComponent();
            tecnico = new Tecnico();
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public formTecnicoAM(Tecnico tecnicoModificar)
        {
            InitializeComponent();
            tecnico = tecnicoModificar;
            modificar = true;
        }

        private void formTecnicoAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Tecnico";

                txtNombreyApellido.Text = tecnico.NombreyApellido;
                txtDni.Text = tecnico.Dni.ToString();
                txtLegajo.Text = tecnico.Legajo.ToString();
            }
            else lblAgregaroModificar.Text = "Agregar Tecnico";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el Técnico?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (ControladoraTecnico.Instancia.RecuperarTecnicos().Any(t => t.NombreyApellido.ToLower() == txtNombreyApellido.Text.ToLower()) && tecnico.NombreyApellido.ToLower() != txtNombreyApellido.Text.ToLower()) // Si el nombre y apellido ya existe y no es el mismo que el que se está modificando entonces mostrar mensaje de error 
                        {
                            // Mostrar un mensaje de error indicando que ya existe otro tecnico con ese código
                            MessageBox.Show("Ya existe otro tecnico con el mismo nombre y apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ValidaDNI(txtDni.Text) == false || txtDni.Text.Length > 9)
                        {
                            MessageBox.Show("El DNI ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ControladoraTecnico.Instancia.RecuperarTecnicos().Any(t => t.Dni == Convert.ToInt32(txtDni.Text)) && tecnico.Dni != Convert.ToInt32(txtDni.Text))
                        {
                            // Mostrar un mensaje de error indicando que ya existe otro tecnico con ese código
                            MessageBox.Show("Ya existe otro tecnico con el mismo DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ControladoraTecnico.Instancia.RecuperarTecnicos().Any(t => t.Legajo == txtLegajo.Text.ToLower() && tecnico.Legajo != txtLegajo.Text.ToLower()))
                        {
                            // Mostrar un mensaje de error indicando que ya existe otro tecnico con ese código
                            MessageBox.Show("Ya existe otro tecnico con el mismo legajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        

                        tecnico.NombreyApellido = txtNombreyApellido.Text;
                        tecnico.Dni = Convert.ToInt32(txtDni.Text);
                        tecnico.Legajo = txtLegajo.Text;

                        var mensaje = ControladoraTecnico.Instancia.ModificarTecnico(tecnico);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else                     
                    {
                        this.Close();
                    }
                }
                else
                {

                    if (ControladoraTecnico.Instancia.RecuperarTecnicos().Any(t => t.NombreyApellido.ToLower() == txtNombreyApellido.Text.ToLower()))
                    {
                        // Mostrar un mensaje de error indicando que ya existe otro tecnico con ese código
                        MessageBox.Show("Ya existe otro tecnico con el mismo nombre y apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ControladoraTecnico.Instancia.RecuperarTecnicos().Any(t => t.Dni == Convert.ToInt32(txtDni.Text)))
                    {
                        // Mostrar un mensaje de error indicando que ya existe otro tecnico con ese código
                        MessageBox.Show("Ya existe otro tecnico con el mismo DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ControladoraTecnico.Instancia.RecuperarTecnicos().Any(t => t.Legajo == txtLegajo.Text.ToLower()))
                    {
                        // Mostrar un mensaje de error indicando que ya existe otro tecnico con ese código
                        MessageBox.Show("Ya existe otro tecnico con el mismo legajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tecnico.NombreyApellido = txtNombreyApellido.Text;
                    tecnico.Dni = Convert.ToInt32(txtDni.Text);

                    if (ValidaDNI(txtDni.Text) == false)
                    {
                        MessageBox.Show("El DNI ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tecnico.Legajo = txtLegajo.Text;


                    var mensaje = ControladoraTecnico.Instancia.AgregarTecnico(tecnico);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreyApellido.Text) || txtNombreyApellido.Text == "Ingrese un nombre y apellido")
            {
                MessageBox.Show("Ingrese el nombre y apellido del técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreyApellido.Focus(); 
                return false;
            }
            if (string.IsNullOrEmpty(txtDni.Text) || txtDni.Text == "Ingrese un DNI")
            {
                MessageBox.Show("Ingrese el DNI del técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLegajo.Text) || txtLegajo.Text == "Ingrese un legajo")
            {
                MessageBox.Show("Ingrese el legajo del técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLegajo.Focus();
                return false;
            }
            return true;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloNumeros(e).Handled)
            {
                MessageBox.Show("Solo se permiten números, no letras o caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloNumeros(e).Handled)
            {
                MessageBox.Show("Solo se permiten números, no letras o caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtNombreyApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtNombreyApellido.Text).Handled)
            {
                MessageBox.Show("Solo se permiten letras no números o caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        static public bool ValidaDNI(string dni)
        {

            if (Regex.Match(dni, @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$").Success == true)
            {
                //dni correcto
                return true;
            }
            else
            {
                //dni incorrecto
                return false;
            }
        }

        static public KeyPressEventArgs KeyPressSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) //solo numeros
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //solo backspace, space, delete, etc.
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar)) //espacio
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            return e;
        }

        static public KeyPressEventArgs KeyPressSoloLetras(KeyPressEventArgs e, string TEXTO)
        {
            if (Char.IsLetter(e.KeyChar))
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

        private void txtNombreyApellido_Enter(object sender, EventArgs e)
        {
            if (txtNombreyApellido.Text == "Ingrese un nombre y apellido")
            {
                txtNombreyApellido.Text = "";
                txtNombreyApellido.ForeColor = Color.Black;
            }
        }

        private void txtNombreyApellido_Leave(object sender, EventArgs e)
        {
            if (txtNombreyApellido.Text == "")
            {
                txtNombreyApellido.Text = "Ingrese un nombre y apellido";
                txtNombreyApellido.ForeColor = Color.Silver;
            }
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            if (txtDni.Text == "Ingrese un DNI")
            {
                txtDni.Text = "";
                txtDni.ForeColor = Color.Black;
            }
        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (txtDni.Text == "")
            {
                txtDni.Text = "Ingrese un DNI";
                txtDni.ForeColor = Color.Silver;
            }
        }

        private void txtLegajo_Enter(object sender, EventArgs e)
        {
            if (txtLegajo.Text == "Ingrese un legajo")
            {
                txtLegajo.Text = "";
                txtLegajo.ForeColor = Color.Black;
            }
        }

        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            if (txtLegajo.Text == "")
            {
                txtLegajo.Text = "Ingrese un legajo";
                txtLegajo.ForeColor = Color.Silver;
            }
        }

        private void formTecnicoAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
