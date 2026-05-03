namespace ProgramAppointments
{
    partial class FrmAgregarReuLider
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
            this.datagrid_reuniones = new System.Windows.Forms.DataGridView();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.txtHoraFinal = new System.Windows.Forms.TextBox();
            this.combo_investigadores = new System.Windows.Forms.ComboBox();
            this.btn_agg_inv = new System.Windows.Forms.Button();
            this.btn_agendar_reu = new System.Windows.Forms.Button();
            this.lblDia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtnombrereu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmotivoreu = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid_reuniones
            // 
            this.datagrid_reuniones.BackgroundColor = System.Drawing.Color.White;
            this.datagrid_reuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_reuniones.Location = new System.Drawing.Point(26, 71);
            this.datagrid_reuniones.Margin = new System.Windows.Forms.Padding(4);
            this.datagrid_reuniones.Name = "datagrid_reuniones";
            this.datagrid_reuniones.RowHeadersWidth = 51;
            this.datagrid_reuniones.Size = new System.Drawing.Size(547, 262);
            this.datagrid_reuniones.TabIndex = 0;
            this.datagrid_reuniones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_reuniones_CellContentClick_1);
            this.datagrid_reuniones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_reuniones_CellDoubleClick);
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(25, 77);
            this.txtMes.Margin = new System.Windows.Forms.Padding(4);
            this.txtMes.Multiline = true;
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(220, 42);
            this.txtMes.TabIndex = 2;
            // 
            // txtDia
            // 
            this.txtDia.Location = new System.Drawing.Point(284, 77);
            this.txtDia.Margin = new System.Windows.Forms.Padding(4);
            this.txtDia.Multiline = true;
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(217, 42);
            this.txtDia.TabIndex = 3;
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(26, 152);
            this.txtHoraInicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoraInicio.Multiline = true;
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(219, 41);
            this.txtHoraInicio.TabIndex = 4;
            this.txtHoraInicio.TextChanged += new System.EventHandler(this.txtHoraInicio_TextChanged_1);
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(284, 152);
            this.txtHoraFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoraFinal.Multiline = true;
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(217, 41);
            this.txtHoraFinal.TabIndex = 5;
            // 
            // combo_investigadores
            // 
            this.combo_investigadores.FormattingEnabled = true;
            this.combo_investigadores.Location = new System.Drawing.Point(23, 397);
            this.combo_investigadores.Margin = new System.Windows.Forms.Padding(4);
            this.combo_investigadores.Name = "combo_investigadores";
            this.combo_investigadores.Size = new System.Drawing.Size(290, 28);
            this.combo_investigadores.TabIndex = 6;
            // 
            // btn_agg_inv
            // 
            this.btn_agg_inv.BackColor = System.Drawing.Color.White;
            this.btn_agg_inv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_agg_inv.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agg_inv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_agg_inv.Location = new System.Drawing.Point(321, 396);
            this.btn_agg_inv.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agg_inv.Name = "btn_agg_inv";
            this.btn_agg_inv.Size = new System.Drawing.Size(180, 29);
            this.btn_agg_inv.TabIndex = 7;
            this.btn_agg_inv.Text = "AGREGAR";
            this.btn_agg_inv.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_agg_inv.UseVisualStyleBackColor = false;
            this.btn_agg_inv.Click += new System.EventHandler(this.btn_agg_inv_Click);
            // 
            // btn_agendar_reu
            // 
            this.btn_agendar_reu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(129)))), ((int)(((byte)(214)))));
            this.btn_agendar_reu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agendar_reu.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agendar_reu.ForeColor = System.Drawing.Color.White;
            this.btn_agendar_reu.Location = new System.Drawing.Point(23, 440);
            this.btn_agendar_reu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agendar_reu.Name = "btn_agendar_reu";
            this.btn_agendar_reu.Size = new System.Drawing.Size(478, 52);
            this.btn_agendar_reu.TabIndex = 8;
            this.btn_agendar_reu.Text = "AGENDAR REUNIÓN";
            this.btn_agendar_reu.UseVisualStyleBackColor = false;
            this.btn_agendar_reu.Click += new System.EventHandler(this.btn_agendar_reu_Click);
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.BackColor = System.Drawing.Color.Transparent;
            this.lblDia.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.Location = new System.Drawing.Point(280, 51);
            this.lblDia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(33, 19);
            this.lblDia.TabIndex = 9;
            this.lblDia.Text = "DÍA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "MES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "HORA INICIO";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "HORA FINAL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProgramAppointments.Properties.Resources.Captura_de_pantalla_2026_04_24_124234;
            this.pictureBox1.Location = new System.Drawing.Point(1119, 508);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // txtnombrereu
            // 
            this.txtnombrereu.Location = new System.Drawing.Point(23, 226);
            this.txtnombrereu.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombrereu.Multiline = true;
            this.txtnombrereu.Name = "txtnombrereu";
            this.txtnombrereu.Size = new System.Drawing.Size(478, 37);
            this.txtnombrereu.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "NOMBRE DE LA REUNIÓN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 271);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "MOTIVO";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtmotivoreu
            // 
            this.txtmotivoreu.Location = new System.Drawing.Point(23, 294);
            this.txtmotivoreu.Margin = new System.Windows.Forms.Padding(4);
            this.txtmotivoreu.Multiline = true;
            this.txtmotivoreu.Name = "txtmotivoreu";
            this.txtmotivoreu.Size = new System.Drawing.Size(478, 74);
            this.txtmotivoreu.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::ProgramAppointments.Properties.Resources.flecha_izquierda;
            this.button2.Location = new System.Drawing.Point(16, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 41);
            this.button2.TabIndex = 19;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 374);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 19);
            this.label7.TabIndex = 20;
            this.label7.Text = "INVESTIGADOR";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.btn_agendar_reu);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.btn_agg_inv);
            this.guna2GroupBox1.Controls.Add(this.combo_investigadores);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.txtnombrereu);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.txtmotivoreu);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.lblDia);
            this.guna2GroupBox1.Controls.Add(this.txtHoraFinal);
            this.guna2GroupBox1.Controls.Add(this.txtHoraInicio);
            this.guna2GroupBox1.Controls.Add(this.txtDia);
            this.guna2GroupBox1.Controls.Add(this.txtMes);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(15, 54);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(532, 512);
            this.guna2GroupBox1.TabIndex = 21;
            this.guna2GroupBox1.Text = "DETALLES DE LA REUNIÓN";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.datagrid_reuniones);
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(567, 55);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(609, 446);
            this.guna2GroupBox2.TabIndex = 22;
            this.guna2GroupBox2.Text = "REUNIONES AGENDADAS PARA ESTE DIA";
            // 
            // FrmAgregarReuLider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1195, 578);
            this.ControlBox = false;
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAgregarReuLider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEETLY - AGREGAR REUNIÓN";
            this.Load += new System.EventHandler(this.FrmAgregarReuLider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid_reuniones;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.TextBox txtHoraFinal;
        private System.Windows.Forms.ComboBox combo_investigadores;
        private System.Windows.Forms.Button btn_agg_inv;
        private System.Windows.Forms.Button btn_agendar_reu;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtnombrereu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmotivoreu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
    }
}