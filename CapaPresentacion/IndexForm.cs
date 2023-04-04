using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void cuadraturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var secondaryForm = new Form1();
            secondaryForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
            secondaryForm.Show();


        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {



            // Cierra el formulario Index
            this.Close();

            // Crea una nueva instancia del formulario de autenticación y lo muestra
            LoginForm formLogin = new LoginForm();
            formLogin.Show();


        }

        private void inventarioTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AbrirInventoryTIForm = new InventoryTICForm();
            AbrirInventoryTIForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
            AbrirInventoryTIForm.Show();




        }
    }
}
