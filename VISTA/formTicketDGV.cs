using Controladora;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class formTicketDGV : Form
    {
        public formTicketDGV()
        {
            InitializeComponent();
            ActualizarGrilla();
            dgvTicket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //con esto hago que las columnas se ajusten al contenido
        }

        //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void ActualizarGrilla()
        {
            dgvTicket.DataSource = null;
            dgvTicket.DataSource = ControladoraSede.Instancia.RecuperarSedes();
            dgvTicket.DataSource = ControladoraComputadora.Instancia.RecuperarComputadoras();
            dgvTicket.DataSource = ControladoraLaboratorio.Instancia.RecuperarLaboratorios();
            dgvTicket.DataSource = ControladoraTecnico.Instancia.RecuperarTecnicos();
            dgvTicket.DataSource = ControladoraTicket.Instancia.RecuperarTicket();
            dgvTicket.Columns["Laboratorios"].Visible = false;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formHistorialDGV_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formTicketAM = new formTicketAM();
            formTicketAM.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTicket.Rows.Count > 0)
            {
                var ticketSelecionado = (Ticket)dgvTicket.CurrentRow.DataBoundItem;

                // Preguntar al usuario si está seguro de eliminar el ticket
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar el ticket?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    var respuesta = ControladoraTicket.Instancia.EliminarTicket(ticketSelecionado);
                    MessageBox.Show(respuesta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para eliminarlo.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTicket.Rows.Count > 0)
            {
                var ticketSeleccionado = (Ticket)dgvTicket.CurrentRow.DataBoundItem;
                formTicketAM formTicketAM = new formTicketAM(ticketSeleccionado);
                formTicketAM.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para modificarlo.");
            }
            ActualizarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarTicket.Text != "Por código de pc, técnico, sede o laboratorio")
            {
                var listaTicket = ControladoraTicket.Instancia.RecuperarTicket();
                var ticketEncontrado = listaTicket.Where(t => t.Computadora.CodigoComputadora.ToLower().Contains(txtBuscarTicket.Text.ToLower()) || t.TicketId.ToString().Contains(txtBuscarTicket.Text.ToLower()) || t.estado.ToString().ToLower().Contains(txtBuscarTicket.Text.ToLower()) || t.FechaCreacion.ToString().ToLower().Contains(txtBuscarTicket.Text.ToLower()) || t.tipo.ToString().ToLower().Contains(txtBuscarTicket.Text.ToLower()) || t.Tecnico.NombreyApellido.ToLower().Contains(txtBuscarTicket.Text.ToLower()) || t.NombreSede.ToLower().Contains(txtBuscarTicket.Text.ToLower()) || t.Computadora.Laboratorio.NombreLaboratorio.ToLower().Contains(txtBuscarTicket.Text.ToLower()));

                if (ticketEncontrado.Count() > 0)
                {
                    dgvTicket.DataSource = null;
                    dgvTicket.DataSource = ticketEncontrado.ToList();
                    dgvTicket.Columns["Laboratorios"].Visible = false;

                }
                else
                {
                    MessageBox.Show("No se han encontrado tickets.");
                    ActualizarGrilla();
                    dgvTicket.Columns["Laboratorios"].Visible = false;

                }
            }
            else
            {
                MessageBox.Show("Ingrese un codigo de computadora, técnico, sede o laboratorio para buscar el ticket.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActualizarGrilla();
                dgvTicket.Columns["Laboratorios"].Visible = false;

            }
        }

        private void txtBuscarTicket_Enter(object sender, EventArgs e)
        {
            if (txtBuscarTicket.Text == "Por código de pc, técnico, sede o laboratorio")
            {
                txtBuscarTicket.Text = "";
                txtBuscarTicket.ForeColor = Color.Black;
            }
        }

        private void txtBuscarTicket_Leave(object sender, EventArgs e)
        {
            if (txtBuscarTicket.Text == "")
            {
                txtBuscarTicket.Text = "Por código de pc, técnico, sede o laboratorio";
                txtBuscarTicket.ForeColor = Color.Silver;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Verificar si hay tickets creados
            if (ControladoraTicket.Instancia.RecuperarTicket().Count == 0) //si no hay tickets creados, muestro un mensaje de advertencia 
            {
                MessageBox.Show("No hay tickets creados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog(); //creo un objeto de tipo SaveFileDialog para guardar el pdf 
            guardar.FileName = "Historial de Tickets" + ("") + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf"; //nombro el archivo pdf que se va a guardar
            string paginahtml_texto = Properties.Resources.plantilla.ToString(); //cargo la plantilla html en una variable string para luego reemplazar los valores de los tickets en el pdf que se va a crear con itextsharp
            if (guardar.ShowDialog() == DialogResult.OK) //si se selecciona un archivo para guardar el pdf
            {
                try
                {
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create, FileAccess.Write, FileShare.None)) //Esto significa que el archivo se creará si no existe o se sobrescribirá si ya existe.
                    {
                        using (Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25)) //creo el documento pdf con itextsharp y le doy un tamaño de hoja A4
                        {
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream); //creo el documento pdf con itextsharp y lo guardo en la ruta que se seleccionó

                            pdfDoc.Open(); //abro el documento pdf

                            pdfDoc.Add(new Phrase(" "));

                            var listaTicket = ControladoraTicket.Instancia.RecuperarTicket(); //recupero los tickets de la base de datos

                            foreach (var ticket in listaTicket) //recorro la lista de tickets para mostrarlos en el pdf que se va a crear con itextsharp 
                            {
                                string paginahtml_ticket = paginahtml_texto; //cargo la plantilla html en una variable string para luego reemplazar los valores de los tickets en el pdf que se va a crear con itextsharp

                                paginahtml_ticket = paginahtml_ticket.Replace("@TecnicoId", ticket.TecnicoId.ToString()); //reemplazo los valores de los tickets en la plantilla html
                                paginahtml_ticket = paginahtml_ticket.Replace("@TicketId", ticket.TicketId.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@ComputadoraId", ticket.ComputadoraId.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@Computadora", ticket.Computadora.CodigoComputadora.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@Ubicacion", ticket.Ubicacion.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@NombreSede", ticket.NombreSede.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@FechaCreacion", ticket.FechaCreacion.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@DescripcionTicket", ticket.DescripcionTicket.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@Tecnico", ticket.Tecnico.NombreyApellido.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@categoria", ticket.categoria.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@urgencia", ticket.urgencia.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@estado", ticket.estado.ToString());
                                paginahtml_ticket = paginahtml_ticket.Replace("@tipo", ticket.tipo.ToString());

                                //mostrar los tecnicos en el pdf y la cantidad de tickets que tiene asignados a cada uno de ellos
                                var listaTecnicos = ControladoraTecnico.Instancia.RecuperarTecnicos();
                                foreach (var tecnico in listaTecnicos)
                                {
                                    if (tecnico.TecnicoId == ticket.TecnicoId)
                                    {
                                        paginahtml_ticket = paginahtml_ticket.Replace("@Tecnico", tecnico.NombreyApellido.ToString());
                                        paginahtml_ticket = paginahtml_ticket.Replace("@CantidadTickets", tecnico.Tickets.Count.ToString()); //lo que hago con count es contar la cantidad de tickets que tiene asignados a cada tecnico y mostrarlo en el pdf
                                    }
                                }

                                using (StringReader sr = new StringReader(paginahtml_ticket)) //convierto el string en un archivo html  
                                {
                                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr); //parseo el archivo html a pdf con itextsharp
                                }
                            }

                            pdfDoc.Close(); //cierro el documento pdf

                            MessageBox.Show("Archivo PDF creado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el archivo PDF, debe cerrar el pdf abierto.: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void formTicketDGV_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscarTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressSoloLetras(e, txtBuscarTicket.Text).Handled)
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
