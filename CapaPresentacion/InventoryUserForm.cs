using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaPresentacion.InventoryTICForm;

namespace CapaPresentacion
{
    public partial class InventoryUserForm : Form
    {
        public InventoryUserForm()
        {
            InitializeComponent();

            MostrarUsuariosInventory();



        }



        public class MyDbContextUsuarios : DbContext
        {
            public MyDbContextUsuarios() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }

            public DbSet<USUARIOS_PC> UsuariosDATOS { get; set; }
        }


        public class USUARIOS_PC
        {

            [Key]
          //  public int ID_USU { get; set; }
            public string COD_USUARIO { get; set; }
            public string NOMBRES { get; set; }
            public string APELLIDOS { get; set; }
            public string AREA { get; set; }
            public string EMAIL { get; set; }

      


        }




        public void ObtenerDatosListaTemporal()
        {


            // Crear un nuevo formulario temporal
            Form formTemp = new Form();
            formTemp.Text = "Agregar nuevo usuario";
            // Personalizar el tamaño del formulario temporal
            formTemp.StartPosition = FormStartPosition.CenterParent;
            formTemp.Size = new Size(280, 500);

            // Crear los TextBox correspondientes a cada propiedad de DatosTI
            TextBox txtCodUsuario = new TextBox();
            TextBox txtNombreUsuario = new TextBox();
            TextBox txtApellidoUsuario = new TextBox();
            TextBox txtArea = new TextBox();
            TextBox txtEmail = new TextBox();

            // Eventos de textbox para el focus se escriben usando keydown
            // Y además se llama al evento focus del formulario temporal
            formTemp.Load += (sender, e) =>
            {
                txtCodUsuario.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtNombreUsuario.Focus();
                };

                txtNombreUsuario.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtApellidoUsuario.Focus();
                };

                txtApellidoUsuario.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtArea.Focus();
                };
                txtArea.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtEmail.Focus();
                };
            };

            // Crear las etiquetas correspondientes para cada TextBox
            Label lblCodUsuario = new Label();
            Label lblNombreUsuario = new Label();
            Label lblApellidoUsuario = new Label();
            Label lblArea = new Label();
            Label lblEmail = new Label();

            // Agregar los TextBox y las etiquetas al formulario
            formTemp.Controls.Add(lblCodUsuario);
            formTemp.Controls.Add(txtCodUsuario);
            formTemp.Controls.Add(lblNombreUsuario);
            formTemp.Controls.Add(txtNombreUsuario);
            formTemp.Controls.Add(lblApellidoUsuario);
            formTemp.Controls.Add(txtApellidoUsuario);
            formTemp.Controls.Add(lblArea);
            formTemp.Controls.Add(txtArea);
            formTemp.Controls.Add(lblEmail);
            formTemp.Controls.Add(txtEmail);

            // Establecer el texto de las etiquetas
            lblCodUsuario.Text = "Código Usuario:";
            lblNombreUsuario.Text = "Nombre Usuario:";
            lblApellidoUsuario.Text = "Apellido:";
            lblArea.Text = "Área:";
            lblEmail.Text = "Email:";

            // Establecer la posición de las etiquetas y los cuadros de texto
            lblCodUsuario.SetBounds(10, 40, 100, 20);
            txtCodUsuario.SetBounds(lblCodUsuario.Right + 10, 40, 100, 20);

            lblNombreUsuario.SetBounds(10, 70, 100, 20);
            txtNombreUsuario.SetBounds(lblNombreUsuario.Right + 10, 70, 100, 20);

            lblApellidoUsuario.SetBounds(10, 100, 100, 20);
            txtApellidoUsuario.SetBounds(lblApellidoUsuario.Right + 10, 100, 100, 20);

            lblArea.SetBounds(10, 130, 100, 20);
            txtArea.SetBounds(lblArea.Right + 10, 130, 100, 20);

            lblEmail.SetBounds(10, 160, 100, 20);
            txtEmail.SetBounds(lblEmail.Right + 10, 160, 100, 20);





            // Crear un botón gUARDAR 
            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // Agregar el sbotón al formulario
            formTemp.Controls.Add(btnGuardar);

            // Establecer la posición 
            btnGuardar.SetBounds((formTemp.ClientSize.Width - btnGuardar.Width) / 2, 390, 80, 25);

            // Función que se ejecutará cuando se haga clic en el segundo botón
            async void btnGuardar_Click(object sender, EventArgs e)
            {


                using (var db = new MyDbContextUsuarios())
                {
                    USUARIOS_PC usuarios = new USUARIOS_PC
                    {
                        COD_USUARIO = txtCodUsuario.Text,
                        NOMBRES = txtNombreUsuario.Text,
                        APELLIDOS = txtApellidoUsuario.Text,
                        AREA = txtArea.Text,
                        EMAIL = txtEmail.Text
                    };

                    db.UsuariosDATOS.Add(usuarios);
                    db.SaveChanges();
                }





                // Mostrar el mensaje al usuario y preguntar si desea limpiar los controles
                var result = MessageBox.Show("Usuario registrado con éxito. ¿Desea limpiar los controles?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario selecciona "Sí", limpiar los controles del formulario temporal
                if (result == DialogResult.Yes)
                {
                    foreach (Control control in formTemp.Controls)
                    {
                        if (control is TextBox)
                        {
                            TextBox textBox = (TextBox)control;
                            textBox.Clear();
                        }
                    }
                }

                // Actualizar la lista de dispositivos
                MostrarUsuariosInventory();


            }








            // Crear un botón CANCELAR y establecer sus propiedades
            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.DialogResult = DialogResult.OK;

            // Agregar el botón al formulario
            formTemp.Controls.Add(btnCancelar);

            // Establecer la posición del botón
            btnCancelar.SetBounds((formTemp.ClientSize.Width - btnCancelar.Width) / 2, 420, 80, 25);




            ////////////// MOSTRAR EL FORMULARIO TEMPORAL
            formTemp.ShowDialog();

















        }







        public void MostrarUsuariosInventory() {


            using (var db = new MyDbContextUsuarios())
            {
                var ContextoUsuarios = db.Database.SqlQuery<USUARIOS_PC>("MostrarUsuarios").ToList();
                dataGridViewUsuariosInventory.DataSource = ContextoUsuarios;
                dataGridViewUsuariosInventory.DefaultCellStyle.BackColor = Color.LightBlue;
            }






        }

        private void dataGridViewUsuariosInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.LightCyan;
            }
            else
            {
                e.CellStyle.BackColor = Color.LightSteelBlue;
            }


        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGrabarDispositivoTI_Click(object sender, EventArgs e)
        {



            ObtenerDatosListaTemporal();



        }

        private void dataGridViewUsuariosInventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            // Obtener la fila editada
            DataGridViewRow row = dataGridViewUsuariosInventory.Rows[e.RowIndex];

            // Obtener el objeto USUARIOS de la fila editada
            USUARIOS_PC uSUARIOS_PC = (USUARIOS_PC)row.DataBoundItem;

            // Actualizar los valores de las celdas modificadas
            
            uSUARIOS_PC.COD_USUARIO = row.Cells["COD_USUARIO"].Value.ToString();
            uSUARIOS_PC.NOMBRES = row.Cells["NOMBRES"].Value.ToString();
            uSUARIOS_PC.APELLIDOS = row.Cells["APELLIDOS"].Value.ToString();
            uSUARIOS_PC.AREA = row.Cells["AREA"].Value.ToString();
            uSUARIOS_PC.EMAIL = row.Cells["EMAIL"].Value.ToString();
            
            // Guardar los cambios en la base de datos
            using (var db = new MyDbContextTI())
            {
                db.Entry(uSUARIOS_PC).State = EntityState.Modified;
                db.SaveChanges();
            }




        }

        private void BtnEliminarUSUARIO_PC_Click(object sender, EventArgs e)
        {



            if (dataGridViewUsuariosInventory.SelectedRows.Count > 0) // verifica si hay al menos una fila seleccionada
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar el usuario?", "Confirmar eliminación",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string cod_USUARIO = dataGridViewUsuariosInventory.SelectedRows[0].Cells["COD_USUARIO"].Value.ToString();


                    using (var db = new MyDbContextUsuarios())
                    {
                        USUARIOS_PC uSUARIOS_PC = db.UsuariosDATOS.Where(d => d.COD_USUARIO == cod_USUARIO).FirstOrDefault();
                        if (uSUARIOS_PC != null)
                        {
                            db.UsuariosDATOS.Remove(uSUARIOS_PC);
                            db.SaveChanges();
                            MessageBox.Show("Usuario eliminado exitosamente");
                        }
                    }

                    MostrarUsuariosInventory();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar", "Seleccionar fila",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }






        }
    }
}
