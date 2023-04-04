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
using System.Net;
using System.Net.Mail;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.IO;

namespace CapaPresentacion
{
    public partial class InventoryAssignmentForm : Form
    {
        public InventoryAssignmentForm()
        {
            InitializeComponent();

            //MostrarAsignaciones();
            LLENARCOMBOPC();
            LLENARCOMBOUSUARIOS();
            MostrarAsignaciones();

        }
        //contexto

        public class MyDbContextAsignarPC : DbContext
        {
            public MyDbContextAsignarPC() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }

          
            public DbSet<DISPAUSU> ASIGNARUsuariosDATOS { get; set; }
        }

        [Table("DISPAUSU")]
        public class DISPAUSU
        {

            [Key]
            public int ID_DISPAUSU{ get; set; }
            public string COD_PC { get; set; }
            public string COD_USUARIO { get; set; }
            public int NUM_ACTA { get; set; }
            public int ENVIADO { get; set; }
            public int ASIGNADO { get; set; }

            public DateTime? FECHA_ASIGNACION { get; set; }



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




        public void MostrarAsignaciones()
        {
            using (var connection = new SqlConnection("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;"))
            {
                connection.Open();

                using (var command = new SqlCommand("SP_MOSTRAR_ASIGNACION_PC", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewAsignaciones.DataSource = dataTable;
                    }
                }
            }


            //using (var db = new MyDbContextUsuarios())
            //{
            //    var ContextoUsuarios = db.Database.SqlQuery<DISPAUSU>("SP_MOSTRAR_ASIGNACION_PC").ToList();
            //    dataGridViewAsignaciones.DataSource = ContextoUsuarios;
            //    dataGridViewAsignaciones.DefaultCellStyle.BackColor = Color.LightBlue;
            //}

        }




        public void LLENARCOMBOPC()
        {

            using (var db = new MyDbContextTI())
            {
                var dispositivos = db.TIDATOS.Select(d => d.COD_PC).ToList();

                comboBox1.DataSource = dispositivos;
            }



        }



        public void LLENARCOMBOUSUARIOS()
        {

            using (var db = new MyDbContextUsuarios())
            {
                var usuarios = db.UsuariosDATOS.ToList();
                var nombres_codigos = usuarios.Select(d => d.COD_USUARIO + " " + d.NOMBRES).ToList();
                comboBox2.DataSource = nombres_codigos;
                comboBox2.DisplayMember = "nombres_codigos";
                // comboBox2.ValueMember = "COD_USUARIO";
            }

        }




        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void dataGridViewAsignaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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




        public void GenerarPDF() {

            // Obtener los datos de la consulta y almacenarlos en una lista de objetos
            List<DISPAUSU> datos = new List<DISPAUSU>();
            using (var db = new MyDbContextAsignarPC())
            {
                datos = db.ASIGNARUsuariosDATOS.ToList();
            }




            // Crear el documento PDF y la página
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            // Obtener el objeto XGraphics para dibujar en la página
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Crear la fuente y el formato para el texto
            XFont fontTitulo = new XFont("Arial", 20, XFontStyle.Bold);
            XFont fontNormal = new XFont("Arial", 12, XFontStyle.Regular);
            XStringFormat formatTitulo = new XStringFormat();
            formatTitulo.Alignment = XStringAlignment.Center;
            XStringFormat formatNormal = new XStringFormat();
            formatNormal.Alignment = XStringAlignment.Near;


            //Crear logo
            // Crea un objeto XImage a partir del archivo de imagen del logo
            XImage logo = XImage.FromFile(@"D:\CODE\Tools\CapaPresentacion\IMG\LogoActa.png");

            // Dibuja el logo en la página
            gfx.DrawImage(logo, 50, 50, 100, 100);


            // Agregar el título de la acta
            string titulo = "ACTA DE ENTREGA DE EQUIPOS";
            gfx.DrawString(titulo, fontTitulo, XBrushes.Black,
                new XRect(50, 150, page.Width - 100, fontTitulo.Height), formatTitulo);




            // Agregar la información del equipo entregado
            string TextoInicial = "En la siguiente acta se listan los equipos que se entregaran con fecha de " + DateTime.Today.ToString("dd/MM/yyyy") + ",";
            string TextoSegundo = "el usuario se hace responsable del estado de estos y además se compromete";
            string TextoTercero = "a mantener el área de trabajo limpia para no afectar el funcionamiento de los equipos.";

            string EquipoEntregado = "Computador Lenovo ThinkPad T470s";
            string NumeroSerie = "123456789";
            string RAM = "02/04/2023";
            string TipoDisco = "Juan Pérez";
            string Marca = "Juan Pérez";
            string Estado = "Juan Pérez";

            gfx.DrawString(TextoInicial, fontNormal, XBrushes.Black,
                new XRect(50, 200, page.Width - 100, fontNormal.Height), formatNormal);

            gfx.DrawString(TextoSegundo, fontNormal, XBrushes.Black,
                new XRect(50, 220, page.Width - 100, fontNormal.Height), formatNormal);

            gfx.DrawString(TextoTercero, fontNormal, XBrushes.Black,
                new XRect(50, 240, page.Width - 100, fontNormal.Height), formatNormal);



            // Agregar la información del equipo entregado
            gfx.DrawString("Equipo entregado: " + EquipoEntregado, fontNormal, XBrushes.Black,
                new XRect(50, 300, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("Número de serie: " + NumeroSerie, fontNormal, XBrushes.Black,
                new XRect(50, 320, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("RAM (GB): " + RAM, fontNormal, XBrushes.Black,
                new XRect(50, 340, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("Tipo Disco: " + TipoDisco, fontNormal, XBrushes.Black,
                new XRect(50, 360, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("Marca: " + Marca, fontNormal, XBrushes.Black,
                new XRect(50, 380, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("Estado: " + Estado, fontNormal, XBrushes.Black,
                new XRect(50, 400, page.Width - 100, fontNormal.Height), formatNormal);



            // Agregar la información del receptor del equipo
            string receptor = "Ana Gómez";
            string identificacion = "1234567890";
            string departamento = "Recursos Humanos";
            gfx.DrawString("Receptor del equipo: " + receptor, fontNormal, XBrushes.Black,
                new XRect(50, 440, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("Identificación: " + identificacion, fontNormal, XBrushes.Black,
                new XRect(50, 460, page.Width - 100, fontNormal.Height), formatNormal);
            gfx.DrawString("Departamento: " + departamento, fontNormal, XBrushes.Black,
                new XRect(50, 480, page.Width - 100, fontNormal.Height), formatNormal);



            // Agregar la sección de firmas
            XRect firmaResponsableRect = new XRect(50, 710, page.Width / 2 - 25, 80);
            gfx.DrawString("Firma del responsable de entrega:", fontNormal, XBrushes.Black,
            new XRect(firmaResponsableRect.Left, firmaResponsableRect.Top - fontNormal.Height, firmaResponsableRect.Width, fontNormal.Height), formatNormal);

            XRect firmaAREA = new XRect(50, 740, page.Width / 2 - 25, 100);
            gfx.DrawString("AREA:", fontNormal, XBrushes.Black,
            new XRect(firmaAREA.Left, firmaAREA.Top - fontNormal.Height, firmaAREA.Width, fontNormal.Height), formatNormal);


            XRect firmaReceptorRect = new XRect(page.Width / 2 + 25, 710, page.Width - 50, 80);
            gfx.DrawString("Firma del receptor del equipo:", fontNormal, XBrushes.Black,
            new XRect(firmaReceptorRect.Left, firmaReceptorRect.Top - fontNormal.Height, firmaReceptorRect.Width, fontNormal.Height), formatNormal);

            XRect firmaAREARECEPTOR = new XRect(325, 740, page.Width / 2 + 25, 100);
            gfx.DrawString("AREA:", fontNormal, XBrushes.Black,
            new XRect(firmaAREARECEPTOR.Left, firmaAREARECEPTOR.Top - fontNormal.Height, firmaAREARECEPTOR.Width, fontNormal.Height), formatNormal);



            // Pedir al usuario que seleccione una ubicación para guardar el PDF
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento como";
            saveFileDialog1.ShowDialog();

            // Si se selecciona una ubicación y se hace clic en "Guardar", guardar el PDF allí
            if (saveFileDialog1.FileName != "")
            {
                // Guardar el PDF
                document.Save(saveFileDialog1.FileName);

                // Leer el archivo PDF y convertirlo a un arreglo de bytes
                byte[] pdfBytes;
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    pdfBytes = new byte[fs.Length];
                    fs.Read(pdfBytes, 0, (int)fs.Length);
                }

                // Insertar los datos en la base de datos
                string connectionString = "Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User ID=sa;Password=Passw0rd..;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string codPc = dataGridViewAsignaciones.Rows[0].Cells[0].Value.ToString();
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE DISPAUSU SET ARCHIVO_PDF = @PDFData WHERE COD_PC = @CodPc", connection);
                    SqlParameter pdfDataParam = new SqlParameter("@PDFData", SqlDbType.VarBinary, -1);
                    pdfDataParam.Value = pdfBytes;
                    command.Parameters.Add(pdfDataParam);
                    command.Parameters.AddWithValue("@CodPc", codPc);
                    command.ExecuteNonQuery();

                }

                // Abrir el PDF en el visor de PDF predeterminado en el sistema
                Process.Start(saveFileDialog1.FileName);

                // Liberar los recursos
                document.Close();
            }





        }





        public void EnviarCorreo()
        {
            try
            {
                // Configurar el cliente SMTP
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("INFO@GIDDINGSFRUIT.COM", "Cera.2021");

                // Configurar el correo electrónico
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("INFO@GIDDINGSFRUIT.COM");
                mail.To.Add("JOHN.PARRA@GIDDINGSFRUIT.COM");
                mail.Subject = "Asunto del correo electrónico";
                mail.Body = "Cuerpo del correo electrónico";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;


                // Mostrar el diálogo de archivo para que el usuario pueda seleccionar el archivo PDF
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Adjuntar el archivo PDF seleccionado
                    string pdfPath = openFileDialog.FileName;
                    Attachment pdfAttachment = new Attachment(pdfPath);
                    mail.Attachments.Add(pdfAttachment);

                    // Enviar correo electrónico
                    client.Send(mail);
                    MessageBox.Show("Correo electronico enviado correctamente.");
                    Console.WriteLine("Correo electrónico enviado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
            }
        }


        private void Btn_Enviar_Click(object sender, EventArgs e)
        {
          
            EnviarCorreo();
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new MyDbContextAsignarPC())
                {
                    // Obtener el código de usuario seleccionado en el ComboBox
                    string usuarioSeleccionado = comboBox2.SelectedItem.ToString();
                    string[] partes = usuarioSeleccionado.Split(' '); // Dividir el texto en partes separadas por espacios en blanco
                    string cod_usuario = partes[0]; // El código de usuario sería la primera parte del texto resultante

                    // Obtener la PC seleccionada en el ComboBox
                    string pcSeleccionado = comboBox1.SelectedItem.ToString();

                    // Crear un nuevo registro en la tabla DISPAUSU
                    var nuevoRegistro = new DISPAUSU
                    {
                        COD_PC = pcSeleccionado,
                        COD_USUARIO = cod_usuario, // Usar el código de usuario obtenido anteriormente
                        NUM_ACTA = 1,
                        ENVIADO = 1,
                        ASIGNADO = 1,
                        FECHA_ASIGNACION = DateTime.Now
                    };

                    // Agregar el nuevo registro al contexto y guardar los cambios en la base de datos
                    context.ASIGNARUsuariosDATOS.Add(nuevoRegistro);
                    context.SaveChanges();

                    MostrarAsignaciones();

                    MessageBox.Show("Registro guardado exitosamente."); // Mostrar mensaje de éxito
                }


            }
            catch (DbUpdateException ex)
            {
               
                    MessageBox.Show("Ocurrió un error al guardar el registro: " + ex.Message);
            }






            }








        private void BtnPDF_Click(object sender, EventArgs e)
        {


            GenerarPDF();


        }

        private void BtnDevolucion_Click(object sender, EventArgs e)
        {

            //// Obtener el código de PC de la fila seleccionada
            //string codPc = dataGridViewAsignaciones.SelectedRows[0].Cells["COD_PC"].Value.ToString();

            //// Consultar la base de datos para obtener los bytes del archivo PDF
            //string connectionString = "Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User ID=sa;Password=Passw0rd..;";
            //string query = "SELECT ARCHIVO_PDF FROM DISPAUSU WHERE COD_PC = @CodPc";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@CodPc", codPc);
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                byte[] pdfBytes = (byte[])reader["ARCHIVO_PDF"];
            //                // Guardar el archivo PDF en un archivo temporal
            //                string tempFilePath = Path.GetTempFileName();
            //                File.WriteAllBytes(tempFilePath, pdfBytes);
            //                // Abrir el archivo PDF en Microsoft Edge
            //                Process.Start("microsoft-edge:" + tempFilePath);
            //            }
            //        }
            //    }
            }



        }
    }


