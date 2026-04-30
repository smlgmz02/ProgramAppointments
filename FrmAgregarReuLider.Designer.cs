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
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_reuniones
            // 
            this.datagrid_reuniones.BackgroundColor = System.Drawing.Color.White;
            this.datagrid_reuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_reuniones.Location = new System.Drawing.Point(447, 85);
            this.datagrid_reuniones.Name = "datagrid_reuniones";
            this.datagrid_reuniones.Size = new System.Drawing.Size(410, 213);
            this.datagrid_reuniones.TabIndex = 0;
            this.datagrid_reuniones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_reuniones_CellContentClick_1);
            this.datagrid_reuniones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_reuniones_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reuniones agendadas para este dia";
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(30, 100);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(137, 20);
            this.txtMes.TabIndex = 2;
            // 
            // txtDia
            // 
            this.txtDia.Location = new System.Drawing.Point(30, 166);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(137, 20);
            this.txtDia.TabIndex = 3;
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(30, 233);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(137, 20);
            this.txtHoraInicio.TabIndex = 4;
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(220, 233);
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(137, 20);
            this.txtHoraFinal.TabIndex = 5;
            // 
            // combo_investigadores
            // 
            this.combo_investigadores.FormattingEnabled = true;
            this.combo_investigadores.Location = new System.Drawing.Point(30, 301);
            this.combo_investigadores.Name = "combo_investigadores";
            this.combo_investigadores.Size = new System.Drawing.Size(327, 21);
            this.combo_investigadores.TabIndex = 6;
            // 
            // btn_agg_inv
            // 
            this.btn_agg_inv.BackColor = System.Drawing.Color.White;
            this.btn_agg_inv.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agg_inv.Location = new System.Drawing.Point(30, 350);
            this.btn_agg_inv.Name = "btn_agg_inv";
            this.btn_agg_inv.Size = new System.Drawing.Size(327, 31);
            this.btn_agg_inv.TabIndex = 7;
            this.btn_agg_inv.Text = "Agregar Investigador";
            this.btn_agg_inv.UseVisualStyleBackColor = false;
            this.btn_agg_inv.Click += new System.EventHandler(this.btn_agg_inv_Click);
            // 
            // btn_agendar_reu
            // 
            this.btn_agendar_reu.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_agendar_reu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agendar_reu.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agendar_reu.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_agendar_reu.Location = new System.Drawing.Point(585, 323);
            this.btn_agendar_reu.Name = "btn_agendar_reu";
            this.btn_agendar_reu.Size = new System.Drawing.Size(150, 42);
            this.btn_agendar_reu.TabIndex = 8;
            this.btn_agendar_reu.Text = "Agendar Reunion";
            this.btn_agendar_reu.UseVisualStyleBackColor = false;
            this.btn_agendar_reu.Click += new System.EventHandler(this.btn_agendar_reu_Click);
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.BackColor = System.Drawing.Color.Transparent;
            this.lblDia.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.Location = new System.Drawing.Point(30, 146);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(29, 17);
            this.lblDia.TabIndex = 9;
            this.lblDia.Text = "Dia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hora inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hora Final";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProgramAppointments.Properties.Resources.Captura_de_pantalla_2026_04_24_124234;
            this.pictureBox1.Location = new System.Drawing.Point(863, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // txtnombrereu
            // 
            this.txtnombrereu.Location = new System.Drawing.Point(220, 100);
            this.txtnombrereu.Name = "txtnombrereu";
            this.txtnombrereu.Size = new System.Drawing.Size(137, 20);
            this.txtnombrereu.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nombre de la reunion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(222, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Motivo";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtmotivoreu
            // 
            this.txtmotivoreu.Location = new System.Drawing.Point(220, 166);
            this.txtmotivoreu.Name = "txtmotivoreu";
            this.txtmotivoreu.Size = new System.Drawing.Size(137, 20);
            this.txtmotivoreu.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::ProgramAppointments.Properties.Resources.flecha_izquierda;
            this.button2.Location = new System.Drawing.Point(33, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 33);
            this.button2.TabIndex = 19;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Investigador";
            // 
            // FrmAgregarReuLider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(918, 442);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtmotivoreu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnombrereu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.btn_agendar_reu);
            this.Controls.Add(this.btn_agg_inv);
            this.Controls.Add(this.combo_investigadores);
            this.Controls.Add(this.txtHoraFinal);
            this.Controls.Add(this.txtHoraInicio);
            this.Controls.Add(this.txtDia);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagrid_reuniones);
            this.Name = "FrmAgregarReuLider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarReuLider";
            this.Load += new System.EventHandler(this.FrmAgregarReuLider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid_reuniones;
        private System.Windows.Forms.Label label1;
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
    }
}