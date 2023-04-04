namespace CapaPresentacion
{
    partial class InventoryAssignmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnDevolucion = new System.Windows.Forms.Button();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.dataGridViewAsignaciones = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.LblCod_Usuario = new System.Windows.Forms.Label();
            this.LblCodUsuario = new System.Windows.Forms.Label();
            this.Btn_Enviar = new System.Windows.Forms.Button();
            this.BtnPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDevolucion
            // 
            this.BtnDevolucion.Location = new System.Drawing.Point(72, 50);
            this.BtnDevolucion.Name = "BtnDevolucion";
            this.BtnDevolucion.Size = new System.Drawing.Size(98, 39);
            this.BtnDevolucion.TabIndex = 14;
            this.BtnDevolucion.Text = "Devolucion";
            this.BtnDevolucion.UseVisualStyleBackColor = true;
            this.BtnDevolucion.Click += new System.EventHandler(this.BtnDevolucion_Click);
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Location = new System.Drawing.Point(12, 50);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(54, 39);
            this.BtnAsignar.TabIndex = 13;
            this.BtnAsignar.Text = "Asignar";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // dataGridViewAsignaciones
            // 
            this.dataGridViewAsignaciones.AllowUserToAddRows = false;
            this.dataGridViewAsignaciones.AllowUserToOrderColumns = true;
            this.dataGridViewAsignaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAsignaciones.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsignaciones.Location = new System.Drawing.Point(0, 154);
            this.dataGridViewAsignaciones.Name = "dataGridViewAsignaciones";
            this.dataGridViewAsignaciones.Size = new System.Drawing.Size(1236, 332);
            this.dataGridViewAsignaciones.TabIndex = 12;
            this.dataGridViewAsignaciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAsignaciones_CellFormatting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1236, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(176, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(303, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(305, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // LblCod_Usuario
            // 
            this.LblCod_Usuario.AutoSize = true;
            this.LblCod_Usuario.Location = new System.Drawing.Point(176, 50);
            this.LblCod_Usuario.Name = "LblCod_Usuario";
            this.LblCod_Usuario.Size = new System.Drawing.Size(24, 13);
            this.LblCod_Usuario.TabIndex = 18;
            this.LblCod_Usuario.Text = "PC:";
            // 
            // LblCodUsuario
            // 
            this.LblCodUsuario.AutoSize = true;
            this.LblCodUsuario.Location = new System.Drawing.Point(303, 52);
            this.LblCodUsuario.Name = "LblCodUsuario";
            this.LblCodUsuario.Size = new System.Drawing.Size(46, 13);
            this.LblCodUsuario.TabIndex = 19;
            this.LblCodUsuario.Text = "Usuario:";
            // 
            // Btn_Enviar
            // 
            this.Btn_Enviar.Location = new System.Drawing.Point(684, 52);
            this.Btn_Enviar.Name = "Btn_Enviar";
            this.Btn_Enviar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Enviar.TabIndex = 20;
            this.Btn_Enviar.Text = "ENVIAR";
            this.Btn_Enviar.UseVisualStyleBackColor = true;
            this.Btn_Enviar.Click += new System.EventHandler(this.Btn_Enviar_Click);
            // 
            // BtnPDF
            // 
            this.BtnPDF.Location = new System.Drawing.Point(684, 101);
            this.BtnPDF.Name = "BtnPDF";
            this.BtnPDF.Size = new System.Drawing.Size(75, 23);
            this.BtnPDF.TabIndex = 21;
            this.BtnPDF.Text = "PDF";
            this.BtnPDF.UseVisualStyleBackColor = true;
            this.BtnPDF.Click += new System.EventHandler(this.BtnPDF_Click);
            // 
            // InventoryAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1236, 492);
            this.Controls.Add(this.BtnPDF);
            this.Controls.Add(this.Btn_Enviar);
            this.Controls.Add(this.LblCodUsuario);
            this.Controls.Add(this.LblCod_Usuario);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnDevolucion);
            this.Controls.Add(this.BtnAsignar);
            this.Controls.Add(this.dataGridViewAsignaciones);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InventoryAssignmentForm";
            this.Text = "InventoryAssignmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDevolucion;
        private System.Windows.Forms.Button BtnAsignar;
        private System.Windows.Forms.DataGridView dataGridViewAsignaciones;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label LblCod_Usuario;
        private System.Windows.Forms.Label LblCodUsuario;
        private System.Windows.Forms.Button Btn_Enviar;
        private System.Windows.Forms.Button BtnPDF;
    }
}