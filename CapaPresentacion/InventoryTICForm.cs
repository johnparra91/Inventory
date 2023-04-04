using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class InventoryTICForm : Form
    {
        public InventoryTICForm()
        {
            InitializeComponent();


       



            Mostrar_DISPOSITIVOSCREADOS();

        }




        private void BtnEliminarDispositivoTI_Click(object sender, EventArgs e)
         {


            if (dataGridViewDispositivos.SelectedRows.Count > 0) // verifica si hay al menos una fila seleccionada
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar el dispositivo?", "Confirmar eliminación",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string cod_pc = dataGridViewDispositivos.SelectedRows[0].Cells["COD_PC"].Value.ToString();


                    using (var db = new MyDbContextTI())
                    {
                        DISPOSITIVOS dispositivo = db.TIDATOS.Where(d => d.COD_PC == cod_pc).FirstOrDefault();
                        if (dispositivo != null)
                        {
                            db.TIDATOS.Remove(dispositivo);
                            db.SaveChanges();
                            MessageBox.Show("Dispositivo eliminado exitosamente");
                        }
                    }

                    Mostrar_DISPOSITIVOSCREADOS();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar", "Seleccionar fila",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        }


        public async Task Mostrar_DISPOSITIVOSCREADOS()
        {
           
            using (var db = new MyDbContextTI())
            {
                var datos = await db.Database.SqlQuery<DISPOSITIVOS>("sp_MostrarDispositivos").ToListAsync();
                dataGridViewDispositivos.DataSource = datos;
                dataGridViewDispositivos.DefaultCellStyle.BackColor = Color.LightBlue;
            }


        }





        public class MyDbContextTI : DbContext
        {
            public MyDbContextTI() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }

            public DbSet<DISPOSITIVOS> TIDATOS { get; set; }
        }


        public class DISPOSITIVOS
        {

            [Key]
            // public int ID_DIS { get; set; }

            // [Index(IsUnique = true)]
            public string COD_PC { get; set; }
            //public string COD_USUARIO { get; set; }
            //public string NOMBRE_USUARIO { get; set; }
            public string SERIAL { get; set; }
            public string AREA { get; set; }
            public string TIPO { get; set; }
            public string PROCESADOR { get; set; }
            public int RAM { get; set; }
            public string TIPO_DISCO { get; set; }
            public int CAPACIDAD_DISCO { get; set; }
            public string SISTEMA_OPERATIVO { get; set; }
            public string MODELO { get; set; }
            public string MAC_LAN { get; set; }
            public string MAC_WIFI { get; set; }
            public DateTime? FECHA_CREACION { get; set; }
            public DateTime? FECHA_ASIGNACION { get; set; }
            public DateTime? FECHA_DEVOLUCION { get; set; }

        }

        private void dataGridViewDispositivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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






        public void ObtenerDatosListaTemporal()
        {

            // Crear un nuevo formulario temporal
            Form formTemp = new Form();
            formTemp.Text = "Agregar nuevo dispositivo";
            // Personalizar el tamaño del formulario temporal
            formTemp.StartPosition = FormStartPosition.CenterParent;
            formTemp.Size = new Size(280, 500);
            


                                                            // Crear los TextBox correspondientes a cada propiedad de DatosTI
                                                            TextBox txtCodPc = new TextBox();
                                                            //TextBox txtCodUsuario = new TextBox();
                                                            //TextBox txtNombreUsuario = new TextBox();
                                                            TextBox txtSerial = new TextBox();
                                                            TextBox txtArea = new TextBox();
                                                            TextBox txtTipo = new TextBox();
                                                            TextBox txtProcesador = new TextBox();
                                                            TextBox txtRam = new TextBox();
                                                            TextBox txtTipoDisco = new TextBox();
                                                            TextBox txtCapacidadDisco = new TextBox();
                                                            TextBox txtSistemaOperativo = new TextBox();
                                                            TextBox txtModelo = new TextBox();
                                                            TextBox txtMacLan = new TextBox();
                                                            TextBox txtMacWifi = new TextBox();





            //// eventos de textbox para el focus se escriben usando keydown
            /////// y ademas se llama al evento focus del formulario temporal
            formTemp.Load += (sender, e) =>
            {
                txtCodPc.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtSerial.Focus();
                };           

                txtSerial.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtArea.Focus();
                };

                txtArea.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtTipo.Focus();
                };

                txtTipo.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtProcesador.Focus();
                };

                txtProcesador.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtRam.Focus();
                };

                txtRam.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtTipoDisco.Focus();
                };

                txtTipoDisco.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtCapacidadDisco.Focus();
                };

                txtCapacidadDisco.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtSistemaOperativo.Focus();
                };

                txtSistemaOperativo.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtModelo.Focus();
                };

                txtModelo.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtMacLan.Focus();
                };

                txtMacLan.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtMacWifi.Focus();
                };
            };






                                                            // Crear las etiquetas correspondientes para cada TextBox
                                                            Label lblCodPc = new Label();
                                                            //Label lblCodUsuario = new Label();
                                                            //Label lblNombreUsuario = new Label();
                                                            Label lblSerial = new Label();
                                                            Label lblArea = new Label();
                                                            Label lblTipo = new Label();
                                                            Label lblProcesador = new Label();
                                                            Label lblRam = new Label();
                                                            Label lblTipoDisco = new Label();
                                                            Label lblCapacidadDisco = new Label();
                                                            Label lblSistemaOperativo = new Label();
                                                            Label lblModelo = new Label();
                                                            Label lblMacLan = new Label();
                                                            Label lblMacWifi = new Label();

                                                            // Agregar los TextBox y las etiquetas al formulario
                                                            formTemp.Controls.Add(lblCodPc);
                                                            formTemp.Controls.Add(txtCodPc);
                                                            //formTemp.Controls.Add(lblCodUsuario);
                                                            //formTemp.Controls.Add(txtCodUsuario);
                                                            //formTemp.Controls.Add(lblNombreUsuario);
                                                            //formTemp.Controls.Add(txtNombreUsuario);
                                                            formTemp.Controls.Add(lblSerial);
                                                            formTemp.Controls.Add(txtSerial);
                                                            formTemp.Controls.Add(lblArea);
                                                            formTemp.Controls.Add(txtArea);
                                                            formTemp.Controls.Add(lblTipo);
                                                            formTemp.Controls.Add(txtTipo);
                                                            formTemp.Controls.Add(lblProcesador);
                                                            formTemp.Controls.Add(txtProcesador);
                                                            formTemp.Controls.Add(lblRam);
                                                            formTemp.Controls.Add(txtRam);
                                                            formTemp.Controls.Add(lblTipoDisco);
                                                            formTemp.Controls.Add(txtTipoDisco);
                                                            formTemp.Controls.Add(lblCapacidadDisco);
                                                            formTemp.Controls.Add(txtCapacidadDisco);
                                                            formTemp.Controls.Add(lblSistemaOperativo);
                                                            formTemp.Controls.Add(txtSistemaOperativo);
                                                            formTemp.Controls.Add(lblModelo);
                                                            formTemp.Controls.Add(txtModelo);
                                                            formTemp.Controls.Add(lblMacLan);
                                                            formTemp.Controls.Add(txtMacLan);
                                                            formTemp.Controls.Add(lblMacWifi);
                                                            formTemp.Controls.Add(txtMacWifi);

                                                            // Establecer el texto de las etiquetas
                                                            lblCodPc.Text = "Código PC:";
                                                            //lblCodUsuario.Text = "Código Usuario:";
                                                            //lblNombreUsuario.Text = "Nombre Usuario:";
                                                            lblSerial.Text = "Serial:";
                                                            lblArea.Text = "Área:";
                                                            lblTipo.Text = "Tipo:";
                                                            lblProcesador.Text = "Procesador:";
                                                            lblRam.Text = "RAM:";
                                                            lblTipoDisco.Text = "Tipo de disco:";
                                                            lblCapacidadDisco.Text = "Capacidad del disco:";
                                                            lblSistemaOperativo.Text = "Sistema Operativo:";
                                                            lblModelo.Text = "Modelo:";
                                                            lblMacLan.Text = "MAC LAN:";
                                                            lblMacWifi.Text = "MAC WIFI:";



                                                                        // Establecer la posición de las etiquetas y los cuadros de texto
                                                                        lblCodPc.SetBounds(10, 10, 100, 20);
                                                                        txtCodPc.SetBounds(lblCodPc.Right + 10, 10, 100, 20);

                                                                        //lblCodUsuario.SetBounds(10, 40, 100, 20);
                                                                        //txtCodUsuario.SetBounds(lblCodUsuario.Right + 10 , 40, 100, 20);

                                                                        //lblNombreUsuario.SetBounds(10, 70, 100, 20);
                                                                        //txtNombreUsuario.SetBounds(lblNombreUsuario.Right + 10, 70, 100, 20);

                                                                        lblSerial.SetBounds(10, 40, 100, 20);
                                                                        txtSerial.SetBounds(lblSerial.Right + 10, 40, 100, 20);

                                                                        lblArea.SetBounds(10, 70, 100, 20);
                                                                        txtArea.SetBounds(lblArea.Right + 10, 70, 100, 20);

                                                                        lblTipo.SetBounds(10, 100, 100, 20);
                                                                        txtTipo.SetBounds(lblTipo.Right + 10, 100, 100, 20);

                                                                        lblProcesador.SetBounds(10, 130, 100, 20);
                                                                        txtProcesador.SetBounds(lblProcesador.Right + 10, 130, 100, 20);

                                                                        lblRam.SetBounds(10, 160, 100, 20);
                                                                        txtRam.SetBounds(lblRam.Right + 10, 160, 100, 20);

                                                                        lblTipoDisco.SetBounds(10, 190, 100, 20);
                                                                        txtTipoDisco.SetBounds(lblTipoDisco.Right + 10, 190, 100, 20);

                                                                        lblCapacidadDisco.SetBounds(10, 220, 100, 20);
                                                                        txtCapacidadDisco.SetBounds(lblCapacidadDisco.Right + 10, 220, 100, 20);

                                                                        lblSistemaOperativo.SetBounds(10, 250, 100, 20);
                                                                        txtSistemaOperativo.SetBounds(lblSistemaOperativo.Right + 10, 250, 100, 20);

                                                                        lblModelo.SetBounds(10, 280, 100, 20);
                                                                        txtModelo.SetBounds(lblModelo.Right + 10, 280, 100, 20);

                                                                        lblMacLan.SetBounds(10, 310, 100, 20);
                                                                        txtMacLan.SetBounds(lblMacLan.Right + 10, 310, 100, 20);

                                                                        lblMacWifi.SetBounds(10, 340, 100, 20);
                                                                        txtMacWifi.SetBounds(lblMacWifi.Right + 10, 340, 100, 20);






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

              
                using (var db = new MyDbContextTI())
                {
                    DISPOSITIVOS dispositivo = new DISPOSITIVOS
                    {
                        COD_PC = txtCodPc.Text,
                        //COD_USUARIO = txtCodUsuario.Text,
                        //NOMBRE_USUARIO = txtNombreUsuario.Text,
                        SERIAL = txtSerial.Text,
                        AREA = txtArea.Text,
                        TIPO = txtTipo.Text,
                        PROCESADOR = txtProcesador.Text,
                        RAM = int.Parse(txtRam.Text),
                        TIPO_DISCO = txtTipoDisco.Text,
                        CAPACIDAD_DISCO = int.Parse(txtCapacidadDisco.Text),
                        SISTEMA_OPERATIVO = txtSistemaOperativo.Text,
                        MODELO = txtModelo.Text,
                        MAC_LAN = txtMacLan.Text,
                        MAC_WIFI = txtMacWifi.Text,
                        FECHA_CREACION = DateTime.Now
                    };

                    db.TIDATOS.Add(dispositivo);
                    db.SaveChanges();
                }




                // Mostrar el mensaje al usuario y preguntar si desea limpiar los controles
                var result = MessageBox.Show("Dispositivo registrado con éxito. ¿Desea limpiar los controles?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                await Mostrar_DISPOSITIVOSCREADOS();


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








      
        private void BtnGrabarDispositivoTI_Click(object sender, EventArgs e)
            {

            ObtenerDatosListaTemporal();
   
            }


        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDispositivos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            
            // Obtener la fila editada
            DataGridViewRow row = dataGridViewDispositivos.Rows[e.RowIndex];

            // Obtener el objeto DISPOSITIVOS de la fila editada
            DISPOSITIVOS dispositivo = (DISPOSITIVOS)row.DataBoundItem;

            // Actualizar los valores de las celdas modificadas
            dispositivo.COD_PC = row.Cells["COD_PC"].Value.ToString();
            //dispositivo.COD_USUARIO = row.Cells["COD_USUARIO"].Value.ToString();
            //dispositivo.NOMBRE_USUARIO = row.Cells["NOMBRE_USUARIO"].Value.ToString();
            dispositivo.SERIAL = row.Cells["SERIAL"].Value.ToString();
            dispositivo.AREA = row.Cells["AREA"].Value.ToString();
            dispositivo.TIPO = row.Cells["TIPO"].Value.ToString();
            dispositivo.PROCESADOR = row.Cells["PROCESADOR"].Value.ToString();
            dispositivo.RAM = int.Parse(row.Cells["RAM"].Value.ToString());
            dispositivo.TIPO_DISCO = row.Cells["TIPO_DISCO"].Value.ToString();
            dispositivo.CAPACIDAD_DISCO = int.Parse(row.Cells["CAPACIDAD_DISCO"].Value.ToString());
            dispositivo.SISTEMA_OPERATIVO = row.Cells["SISTEMA_OPERATIVO"].Value.ToString();
            dispositivo.MODELO = row.Cells["MODELO"].Value.ToString();
            dispositivo.MAC_LAN = row.Cells["MAC_LAN"].Value.ToString();
            dispositivo.MAC_WIFI = row.Cells["MAC_WIFI"].Value.ToString();

            // Guardar los cambios en la base de datos
            using (var db = new MyDbContextTI())
            {
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
            }




        }

        private void dataGridViewDispositivos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (e.ColumnIndex == 0) // la primera columna es el COD_PC
            {
                MessageBox.Show("No se puede modificar el código de dispositivo.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // cancela la edición
            }



        }


    }
}
