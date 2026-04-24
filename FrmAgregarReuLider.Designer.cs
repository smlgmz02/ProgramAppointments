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
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_reuniones
            // 
            this.datagrid_reuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_reuniones.Location = new System.Drawing.Point(462, 91);
            this.datagrid_reuniones.Name = "datagrid_reuniones";
            this.datagrid_reuniones.Size = new System.Drawing.Size(335, 213);
            this.datagrid_reuniones.TabIndex = 0;
            this.datagrid_reuniones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_reuniones_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(458, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reuniones agendadas para este dia";
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(57, 96);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(137, 20);
            this.txtMes.TabIndex = 2;
            this.txtMes.TextChanged += new System.EventHandler(this.txtMes_TextChanged);
            // 
            // txtDia
            // 
            this.txtDia.Location = new System.Drawing.Point(57, 162);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(137, 20);
            this.txtDia.TabIndex = 3;
            this.txtDia.TextChanged += new System.EventHandler(this.txtDia_TextChanged);
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(57, 229);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(137, 20);
            this.txtHoraInicio.TabIndex = 4;
            this.txtHoraInicio.TextChanged += new System.EventHandler(this.txtHoraInicio_TextChanged);
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(57, 305);
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(137, 20);
            this.txtHoraFinal.TabIndex = 5;
            this.txtHoraFinal.TextChanged += new System.EventHandler(this.txtHoraFinal_TextChanged);
            // 
            // combo_investigadores
            // 
            this.combo_investigadores.FormattingEnabled = true;
            this.combo_investigadores.Location = new System.Drawing.Point(462, 329);
            this.combo_investigadores.Name = "combo_investigadores";
            this.combo_investigadores.Size = new System.Drawing.Size(220, 21);
            this.combo_investigadores.TabIndex = 6;
            this.combo_investigadores.SelectedIndexChanged += new System.EventHandler(this.combo_investigadores_SelectedIndexChanged);
            // 
            // btn_agg_inv
            // 
            this.btn_agg_inv.Location = new System.Drawing.Point(462, 384);
            this.btn_agg_inv.Name = "btn_agg_inv";
            this.btn_agg_inv.Size = new System.Drawing.Size(129, 23);
            this.btn_agg_inv.TabIndex = 7;
            this.btn_agg_inv.Text = "Agregar investigador";
            this.btn_agg_inv.UseVisualStyleBackColor = true;
            this.btn_agg_inv.Click += new System.EventHandler(this.btn_agg_inv_Click);
            // 
            // btn_agendar_reu
            // 
            this.btn_agendar_reu.Location = new System.Drawing.Point(260, 440);
            this.btn_agendar_reu.Name = "btn_agendar_reu";
            this.btn_agendar_reu.Size = new System.Drawing.Size(124, 53);
            this.btn_agendar_reu.TabIndex = 8;
            this.btn_agendar_reu.Text = "Agendar Reunion";
            this.btn_agendar_reu.UseVisualStyleBackColor = true;
            this.btn_agendar_reu.Click += new System.EventHandler(this.btn_agendar_reu_Click);
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(54, 135);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(23, 13);
            this.lblDia.TabIndex = 9;
            this.lblDia.Text = "Dia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hora inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hora Final";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProgramAppointments.Properties.Resources.Captura_de_pantalla_2026_04_24_124234;
            this.pictureBox1.Location = new System.Drawing.Point(859, 495);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAgregarReuLider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(918, 554);
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
    }
}