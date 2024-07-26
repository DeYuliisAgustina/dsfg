using Controladora;
using Entidades;
using System.Runtime.InteropServices;
using static Entidades.Computadora; //se importan enums de Computadora para acceder a ellos directamente en el código sin tener que escribir Computadora.EstadoComputadora o Computadora.CondicionComputadora. 

namespace VISTA
{
    public partial class formComputadoraAM : Form
    {
        private Computadora computadora; // variable de tipo Sede para almacenar la sede que se va a modificar
        private bool modificar = false;

        public formComputadoraAM()
        {
            InitializeComponent();
            computadora = new Computadora();
            ActualizarCb();
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public formComputadoraAM(Computadora computadoraModificar)
        {
            InitializeComponent();
            computadora = computadoraModificar;
            modificar = true;
            ActualizarCb();
        }

        private void ActualizarCb()
        {
            foreach (Sede sede in ControladoraSede.Instancia.RecuperarSedes()) //se recorren las sedes y se agregan al cmb
            {
                cbSede.Items.Add(sede.NombreSede.ToString()); //se agrega el nombre de la sede al cmb
            }
            cbSede.SelectedIndexChanged += (s, e) =>  //con este evento al seleccionar una sede actualizo el cmb de laboratorios
            {
                cbLaboratorio.Items.Clear();  //se limpia el cmb de laboratorios para que no se acumulen los laboratorios de las sedes anteriores
                foreach (Laboratorio laboratorio in ControladoraLaboratorio.Instancia.RecuperarLaboratorios().Where(l => l.Sede.NombreSede == cbSede.SelectedItem.ToString())) //se recorren los laboratorios y se agregan al cmb
                {
                    cbLaboratorio.Items.Add(laboratorio.NombreLaboratorio.ToString());
                }
            };
            foreach (EstadoComputadora estado in Enum.GetValues(typeof(EstadoComputadora))) //se recorren los valores del enum de EstadoComputadora y se agregan al combobox de estados
            {
                cbEstado.Items.Add(estado.ToString());
            }
            foreach (CondicionComputadora condicion in Enum.GetValues(typeof(CondicionComputadora)))
            {
                cbCondicion.Items.Add(condicion.ToString());
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

        private void formComputadoraAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Computadora";

                txtCodigoComputadora.Text = computadora.CodigoComputadora.ToString();
                txtDescripcion.Text = computadora.DescripcionComputadora.ToString();
                cbSede.SelectedItem = computadora.Laboratorio.Sede.NombreSede.ToString();
                cbLaboratorio.SelectedItem = computadora.Laboratorio.ToString();
                cbEstado.SelectedItem = computadora.estado.ToString();
                cbCondicion.SelectedItem = computadora.condicion.ToString();

            }
            else
            {
                cbSede.Items.Add("Seleccione una sede...");
                cbSede.SelectedItem = "Seleccione una sede...";
                cbLaboratorio.Items.Add("Seleccione un laboratorio...");
                cbLaboratorio.SelectedItem = "Seleccione un laboratorio...";
                cbEstado.Items.Add("Seleccione un estado...");
                cbEstado.SelectedItem = "Seleccione un estado...";
                cbCondicion.Items.Add("Seleccione una condición...");
                cbCondicion.SelectedItem = "Seleccione una condición...";

                lblAgregaroModificar.Text = "Agregar Computadora";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar la computadora?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (ControladoraComputadora.Instancia.RecuperarComputadoras().Any(c => c.CodigoComputadora.ToLower() == txtCodigoComputadora.Text.ToLower() && c.LaboratorioId == computadora.LaboratorioId && c.ComputadoraId != computadora.ComputadoraId))
                        {
                            MessageBox.Show("Ya existe una computadora con ese código en el laboratorio seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        computadora.NombreSede = cbSede.Text; // se recupera el nombre de la sede seleccionada del combobox de sedes
                        computadora.Laboratorio = ControladoraLaboratorio.Instancia.RecuperarLaboratorios().FirstOrDefault(l => l.NombreLaboratorio == cbLaboratorio.Text); //se recupera el laboratorio seleccionado del combobox de laboratorios
                        computadora.LaboratorioId = computadora.Laboratorio.LaboratorioId; //se asigna el id del laboratorio seleccionado a la
                        computadora.NombreSede = computadora.Laboratorio.Sede.NombreSede; //se asigna el nombre de la sede del laboratorio seleccionado a la

                        computadora.CodigoComputadora = txtCodigoComputadora.Text;
                        computadora.DescripcionComputadora = txtDescripcion.Text;

                        string estado = cbEstado.Text; //se recupera el estado seleccionado del combobox de estados
                        string condicion = cbCondicion.Text;
                        computadora.estado = (EstadoComputadora)Enum.Parse(typeof(EstadoComputadora), estado); //se convierte el string a enum el type of es para obtener el tipo de dato de la variable
                        computadora.condicion = (CondicionComputadora)Enum.Parse(typeof(CondicionComputadora), condicion);

                        var mensaje = ControladoraComputadora.Instancia.ModificarComputadora(computadora);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {

                    computadora.NombreSede = cbSede.Text; // se recupera el nombre de la sede seleccionada del combobox de sedes
                    computadora.Laboratorio = ControladoraLaboratorio.Instancia.RecuperarLaboratorios().FirstOrDefault(l => l.NombreLaboratorio == cbLaboratorio.Text); //se recupera el laboratorio seleccionado del combobox de laboratorios
                    computadora.LaboratorioId = computadora.Laboratorio.LaboratorioId; //se asigna el id del laboratorio seleccionado a la
                    computadora.NombreSede = computadora.Laboratorio.Sede.NombreSede; //se asigna el nombre de la sede del laboratorio seleccionado a la


                    computadora.CodigoComputadora = txtCodigoComputadora.Text;
                    computadora.DescripcionComputadora = txtDescripcion.Text;

                    string estado = cbEstado.Text;
                    string condicion = cbCondicion.Text;
                    computadora.estado = (EstadoComputadora)Enum.Parse(typeof(EstadoComputadora), estado);
                    computadora.condicion = (CondicionComputadora)Enum.Parse(typeof(CondicionComputadora), condicion); //computadora.condicion hace referencia al enum de la clase computadora

                    var mensaje = ControladoraComputadora.Instancia.AgregarComputadora(computadora);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtCodigoComputadora.Text) || txtCodigoComputadora.Text == "Ingrese el código de la computadora")
            {
                MessageBox.Show("El campo Código de Computadora no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbSede.SelectedItem == null || cbSede.SelectedItem.ToString() == "Seleccione una sede...")
            {
                MessageBox.Show("El campo Sede no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbLaboratorio.SelectedItem == null || cbLaboratorio.SelectedItem.ToString() == "Seleccione un laboratorio...")
            {
                MessageBox.Show("El campo Laboratorio no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbEstado.SelectedItem == null || cbEstado.SelectedItem.ToString() == "Seleccione un estado...")
            {
                MessageBox.Show("El campo Estado no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbCondicion.SelectedItem == null || cbCondicion.SelectedItem.ToString() == "Seleccione una condición...")
            {
                MessageBox.Show("El campo Condición no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text) || txtDescripcion.Text == "Ingrese una descripción de la computadora...")
            {
                MessageBox.Show("El campo Descripción no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtCodigoComputadora_Enter(object sender, EventArgs e)
        {
            if (txtCodigoComputadora.Text == "Ingrese el código de la computadora")
            {
                txtCodigoComputadora.Text = "";
                txtCodigoComputadora.ForeColor = Color.Black;
            }
        }

        private void txtCodigoComputadora_Leave(object sender, EventArgs e)
        {
            if (txtCodigoComputadora.Text == "")
            {
                txtCodigoComputadora.Text = "Ingrese el código de la computadora";
                txtCodigoComputadora.ForeColor = Color.Silver;
            }
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Ingrese una descripción de la computadora...")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.Black;
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Ingrese una descripción de la computadora...";
                txtDescripcion.ForeColor = Color.Silver;
            }
        }

        private void formComputadoraAM_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtCodigoComputadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtCodigoComputadora.Text).Handled)
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = true;
        }
    }
}
