using Controladora;
using Entidades;
using System.Runtime.InteropServices;
using static Entidades.Ticket;


namespace VISTA
{
    public partial class formTicketAM : Form
    {
        private Ticket ticket; // variable de tipo Ticket para almacenar el ticket que se va a modificar
        private bool modificar = false;

        public formTicketAM()
        {
            InitializeComponent();
            ticket = new Ticket();
            Actualizarcb();
        }

        //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public formTicketAM(Ticket ticketModificar)
        {
            InitializeComponent();
            ticket = ticketModificar;
            modificar = true;
            Actualizarcb();
        }

        public void Actualizarcb()
        {
            foreach (Sede sede in ControladoraSede.Instancia.RecuperarSedes()) //se recorren las sedes y se agregan al cmb
            {
                cbSede.Items.Add(sede.NombreSede.ToString());
            }
            cbSede.SelectedIndexChanged += (s, e) =>  //se agrega un evento al cmb para que al seleccionar una sede se actualice el cmb de laboratorios
            {
                cbLaboratorio.Items.Clear();  //se limpia el cmb de laboratorios
                foreach (Laboratorio laboratorio in ControladoraLaboratorio.Instancia.RecuperarLaboratorios().Where(l => l.Sede.NombreSede == cbSede.SelectedItem.ToString())) //se recorren los laboratorios y se agregan al cmb
                {
                    cbLaboratorio.Items.Add(laboratorio.NombreLaboratorio.ToString());
                }
            };
            cbLaboratorio.SelectedIndexChanged += (s, e) =>  //se agrega un evento al cmb para que al seleccionar un laboratorio se actualice el cmb de computadoras
            {
                cbCodigoPc.Items.Clear();  //se limpia el cmb de computadoras
                foreach (Computadora computadora in ControladoraComputadora.Instancia.RecuperarComputadoras().Where(c => c.Laboratorio.NombreLaboratorio == cbLaboratorio.SelectedItem.ToString())) //se recorren las computadoras y se agregan al cmb
                {
                    cbCodigoPc.Items.Add(computadora.CodigoComputadora.ToString());
                }
            };
            foreach (Tipo tipo in Enum.GetValues(typeof(Tipo))) //se recorren los valores del enum de Categoria y se agregan al combobox de categorias
            {
                cbTipoTicket.Items.Add(tipo.ToString());
            }
            foreach (Categoria categoria in Enum.GetValues(typeof(Categoria))) //se recorren los valores del enum de Categoria y se agregan al combobox de categorias
            {
                cbCategoria.Items.Add(categoria.ToString());
            }
            foreach (Estado estado in Enum.GetValues(typeof(Estado))) //se recorren los valores del enum de Urgencia y se agregan al combobox de urgencia
            {
                cbEstado.Items.Add(estado.ToString());
            }
            foreach (Urgencia urgencia in Enum.GetValues(typeof(Urgencia))) //se recorren los valores del enum de Urgencia y se agregan al combobox de urgencia
            {
                cbUrgencia.Items.Add(urgencia.ToString());
            }
            foreach (Tecnico tecnico in ControladoraTecnico.Instancia.RecuperarTecnicos()) //se recorren los laboratorios y se agregan al cmb
            {
                cbTecnico.Items.Add(tecnico.NombreyApellido.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formTicketAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Computadora";

                dtpFechaInicio.Value = ticket.FechaCreacion;
                txtDescripcion.Text = ticket.DescripcionTicket;

                cbSede.SelectedItem = ticket.NombreSede.ToString();
                cbLaboratorio.SelectedItem = ticket.Computadora.Laboratorio.NombreLaboratorio.ToString();
                cbCodigoPc.SelectedItem = ticket.Computadora.CodigoComputadora.ToString();
                cbTipoTicket.SelectedItem = ticket.tipo.ToString();
                cbCategoria.SelectedItem = ticket.categoria.ToString();
                cbEstado.SelectedItem = ticket.estado.ToString();
                cbUrgencia.SelectedItem = ticket.urgencia.ToString();
                cbTecnico.SelectedItem = ticket.Tecnico.NombreyApellido.ToString();
            }
            else
            {
                cbSede.Items.Add("Seleccione una sede...");
                cbSede.SelectedItem = "Seleccione una sede...";
                cbLaboratorio.Items.Add("Seleccione un laboratorio...");
                cbLaboratorio.SelectedItem = "Seleccione un laboratorio...";
                cbCodigoPc.Items.Add("Seleccione una computadora...");
                cbCodigoPc.SelectedItem = "Seleccione una computadora...";
                cbTipoTicket.Items.Add("Seleccione un tipo de ticket...");
                cbTipoTicket.SelectedItem = "Seleccione un tipo de ticket...";
                cbCategoria.Items.Add("Seleccione una categoría...");
                cbCategoria.SelectedItem = "Seleccione una categoría...";
                cbEstado.Items.Add("Seleccione un estado...");
                cbEstado.SelectedItem = "Seleccione un estado...";
                cbUrgencia.Items.Add("Seleccione una urgencia...");
                cbUrgencia.SelectedItem = "Seleccione una urgencia...";
                cbTecnico.Items.Add("Seleccione un técnico...");
                cbTecnico.SelectedItem = "Seleccione un técnico...";

                lblAgregaroModificar.Text = "Agregar Ticket";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea modificar el ticket?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Obtener el código de computadora seleccionado
                        string codigoComputadora = cbCodigoPc.SelectedItem.ToString();

                        // Verificar si existe otro ticket con el mismo código de computadora
                        if (ControladoraTicket.Instancia.RecuperarTicket().Any(t => t.Computadora.CodigoComputadora == codigoComputadora && t != ticket))
                        {
                            MessageBox.Show("Ya existe otro ticket con el mismo código de computadora." + ticket.Computadora.CodigoComputadora, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ticket.NombreSede = cbSede.SelectedItem.ToString();
                        ticket.Ubicacion = cbLaboratorio.SelectedItem.ToString();
                        ticket.Computadora = ControladoraComputadora.Instancia.RecuperarComputadoras().FirstOrDefault(c => c.CodigoComputadora == cbCodigoPc.SelectedItem.ToString() && c.Laboratorio.NombreLaboratorio == cbLaboratorio.SelectedItem.ToString());
                        ticket.Tecnico = ControladoraTecnico.Instancia.RecuperarTecnicos().FirstOrDefault(t => t.NombreyApellido == cbTecnico.SelectedItem.ToString());

                        ticket.DescripcionTicket = txtDescripcion.Text;
                        ticket.FechaCreacion = dtpFechaInicio.Value;
                        ticket.tipo = (Tipo)Enum.Parse(typeof(Tipo), cbTipoTicket.SelectedItem.ToString());
                        ticket.categoria = (Categoria)Enum.Parse(typeof(Categoria), cbCategoria.SelectedItem.ToString());
                        ticket.estado = (Estado)Enum.Parse(typeof(Estado), cbEstado.SelectedItem.ToString());
                        ticket.urgencia = (Urgencia)Enum.Parse(typeof(Urgencia), cbUrgencia.SelectedItem.ToString());


                        var mensaje = ControladoraTicket.Instancia.ModificarTicket(ticket);
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    ticket.NombreSede = cbSede.SelectedItem.ToString();
                    ticket.Ubicacion = cbLaboratorio.SelectedItem.ToString();
                    ticket.Computadora = ControladoraComputadora.Instancia.RecuperarComputadoras().FirstOrDefault(c => c.CodigoComputadora == cbCodigoPc.SelectedItem.ToString() && c.Laboratorio.NombreLaboratorio == cbLaboratorio.SelectedItem.ToString());
                    ticket.Tecnico = ControladoraTecnico.Instancia.RecuperarTecnicos().FirstOrDefault(t => t.NombreyApellido == cbTecnico.SelectedItem.ToString());

                    ticket.DescripcionTicket = txtDescripcion.Text;
                    ticket.FechaCreacion = dtpFechaInicio.Value;
                    ticket.tipo = (Tipo)Enum.Parse(typeof(Tipo), cbTipoTicket.SelectedItem.ToString());
                    ticket.categoria = (Categoria)Enum.Parse(typeof(Categoria), cbCategoria.SelectedItem.ToString());
                    ticket.estado = (Estado)Enum.Parse(typeof(Estado), cbEstado.SelectedItem.ToString());
                    ticket.urgencia = (Urgencia)Enum.Parse(typeof(Urgencia), cbUrgencia.SelectedItem.ToString());



                    var mensaje = ControladoraTicket.Instancia.AgregarTicket(ticket);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (dtpFechaInicio.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbSede.SelectedItem == null || cbSede.SelectedItem.ToString() == "Seleccione una sede...")
            {
                MessageBox.Show("El campo sede no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbLaboratorio.SelectedItem == null || cbLaboratorio.SelectedItem.ToString() == "Seleccione un laboratorio...")
            {
                MessageBox.Show("El campo laboratorio no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbCodigoPc.SelectedItem == null || cbCodigoPc.SelectedItem.ToString() == "Seleccione una computadora...")
            {
                MessageBox.Show("El campo código de computadora no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbTipoTicket.SelectedItem == null || cbTipoTicket.SelectedItem.ToString() == "Seleccione un tipo de ticket...")
            {
                MessageBox.Show("El campo tipo ticket no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbCategoria.SelectedItem == null || cbCategoria.SelectedItem.ToString() == "Seleccione una categoría...")
            {
                MessageBox.Show("El campo categoría no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbEstado.SelectedItem == null || cbEstado.SelectedItem.ToString() == "Seleccione un estado...")
            {
                MessageBox.Show("El campo estado no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbUrgencia.SelectedItem == null || cbUrgencia.SelectedItem.ToString() == "Seleccione una urgencia...")
            {
                MessageBox.Show("El campo urgencia no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbTecnico.SelectedItem == null || cbTecnico.SelectedItem.ToString() == "Seleccione un técnico...")
            {
                MessageBox.Show("El campo asignado no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text) || txtDescripcion.Text == "Ingrese una descripción del ticket...")
            {
                MessageBox.Show("El campo descripción no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Ingrese una descripción del ticket...")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.Black;
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Ingrese una descripción del ticket...";
                txtDescripcion.ForeColor = Color.Silver;
            }
        }

        private void formTicketAM_MouseDown(object sender, MouseEventArgs e)
        {
            //Metodos para mover la ventana
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
