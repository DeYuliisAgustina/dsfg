using System.Runtime.InteropServices;

namespace VISTA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Metodos para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")] //importo las librerias necesarias para mover la ventana
        private extern static void ReleaseCapture(); //metodo para mover la ventana
        [DllImport("User32.DLL", EntryPoint = "SendMessage")] //importo las librerias necesarias para mover la ventana
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam); 

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLaboratorioMenu_Click(object sender, EventArgs e)
        {
            Form formLaboratorioDGV = new formLaboratorioDGV();
            formLaboratorioDGV.ShowDialog();
        }

        private void btnComputadoraMenu_Click(object sender, EventArgs e)
        {
            Form formComputadoraDGV = new formComputadoraDGV();
            formComputadoraDGV.ShowDialog();
        }

        private void btnSedeMenu_Click(object sender, EventArgs e)
        {
            Form formSedeDGV = new formSedeDGV();
            formSedeDGV.ShowDialog();
        }

        private void btnTicketMenu_Click(object sender, EventArgs e)
        {
            Form formHistorialDGV = new formTicketDGV();
            formHistorialDGV.ShowDialog();
        }

        private void btnTecnicosMenu_Click(object sender, EventArgs e)
        {
            Form formTecnicoDGV = new formTecnicoDGV();
            formTecnicoDGV.ShowDialog();
        }

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            //Metodos para mover la ventana
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //0x112 es el mensaje para mover la ventana
        }
    }
}
