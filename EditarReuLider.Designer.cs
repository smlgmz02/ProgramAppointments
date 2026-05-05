namespace ProgramAppointments
{
    partial class EditarReuLider
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtmotivoreu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnombrereu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoraFinal = new System.Windows.Forms.TextBox();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.combobox_investig_disponibles = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnDesvincular = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_guardar_edicion = new Guna.UI2.WinForms.Guna2Button();
            this.combobox_investig_vinculados = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnVincular = new Guna.UI2.WinForms.Guna2Button();
            this.calendar_fecha = new System.Windows.Forms.MonthCalendar();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(304, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Investigadores Vinculados";
            // 
            // txtmotivoreu
            // 
            this.txtmotivoreu.Location = new System.Drawing.Point(515, 69);
            this.txtmotivoreu.Name = "txtmotivoreu";
            this.txtmotivoreu.Size = new System.Drawing.Size(154, 23);
            this.txtmotivoreu.TabIndex = 34;
            this.txtmotivoreu.TextChanged += new System.EventHandler(this.txtmotivoreu_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(514, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Motivo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(308, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Nombre de la reunión";
            // 
            // txtnombrereu
            // 
            this.txtnombrereu.Location = new System.Drawing.Point(310, 69);
            this.txtnombrereu.Name = "txtnombrereu";
            this.txtnombrereu.Size = new System.Drawing.Size(137, 23);
            this.txtnombrereu.TabIndex = 31;
            this.txtnombrereu.TextChanged += new System.EventHandler(this.txtnombrereu_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(513, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Hora Finalización";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(308, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Hora Inicio";
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(515, 117);
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(154, 23);
            this.txtHoraFinal.TabIndex = 24;
            this.txtHoraFinal.TextChanged += new System.EventHandler(this.txtHoraFinal_TextChanged);
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(309, 119);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(137, 23);
            this.txtHoraInicio.TabIndex = 23;
            this.txtHoraInicio.TextChanged += new System.EventHandler(this.txtHoraInicio_TextChanged);
            // 
            // combobox_investig_disponibles
            // 
            this.combobox_investig_disponibles.BackColor = System.Drawing.Color.Transparent;
            this.combobox_investig_disponibles.BorderColor = System.Drawing.Color.Gray;
            this.combobox_investig_disponibles.BorderRadius = 5;
            this.combobox_investig_disponibles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_investig_disponibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_investig_disponibles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_investig_disponibles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_investig_disponibles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.combobox_investig_disponibles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.combobox_investig_disponibles.ItemHeight = 30;
            this.combobox_investig_disponibles.Location = new System.Drawing.Point(515, 184);
            this.combobox_investig_disponibles.Name = "combobox_investig_disponibles";
            this.combobox_investig_disponibles.Size = new System.Drawing.Size(154, 36);
            this.combobox_investig_disponibles.TabIndex = 36;
            this.combobox_investig_disponibles.SelectedIndexChanged += new System.EventHandler(this.combobox_investig_disponibles_SelectedIndexChanged);
            // 
            // btnDesvincular
            // 
            this.btnDesvincular.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnDesvincular.BorderRadius = 5;
            this.btnDesvincular.BorderThickness = 1;
            this.btnDesvincular.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDesvincular.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDesvincular.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDesvincular.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDesvincular.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDesvincular.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(129)))), ((int)(((byte)(214)))));
            this.btnDesvincular.Font = new System.Drawing.Font("Segoe UI Variable Text", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDesvincular.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDesvincular.Location = new System.Drawing.Point(302, 226);
            this.btnDesvincular.Name = "btnDesvincular";
            this.btnDesvincular.Size = new System.Drawing.Size(145, 45);
            this.btnDesvincular.TabIndex = 37;
            this.btnDesvincular.Text = "DESVINCULAR";
            this.btnDesvincular.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(512, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Investigadores Disponibles";
            // 
            // btn_guardar_edicion
            // 
            this.btn_guardar_edicion.Animated = true;
            this.btn_guardar_edicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(129)))), ((int)(((byte)(214)))));
            this.btn_guardar_edicion.BorderRadius = 5;
            this.btn_guardar_edicion.BorderThickness = 1;
            this.btn_guardar_edicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_guardar_edicion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_guardar_edicion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_guardar_edicion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_guardar_edicion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_guardar_edicion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(129)))), ((int)(((byte)(214)))));
            this.btn_guardar_edicion.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.btn_guardar_edicion.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_guardar_edicion.Location = new System.Drawing.Point(24, 226);
            this.btn_guardar_edicion.Name = "btn_guardar_edicion";
            this.btn_guardar_edicion.Size = new System.Drawing.Size(218, 45);
            this.btn_guardar_edicion.TabIndex = 39;
            this.btn_guardar_edicion.Text = "GUARDAR CAMBIOS";
            this.btn_guardar_edicion.Click += new System.EventHandler(this.btn_guardar_edicion_Click);
            // 
            // combobox_investig_vinculados
            // 
            this.combobox_investig_vinculados.BackColor = System.Drawing.Color.Transparent;
            this.combobox_investig_vinculados.BorderColor = System.Drawing.Color.Gray;
            this.combobox_investig_vinculados.BorderRadius = 5;
            this.combobox_investig_vinculados.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_investig_vinculados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_investig_vinculados.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_investig_vinculados.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_investig_vinculados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.combobox_investig_vinculados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.combobox_investig_vinculados.ItemHeight = 30;
            this.combobox_investig_vinculados.Location = new System.Drawing.Point(305, 185);
            this.combobox_investig_vinculados.Name = "combobox_investig_vinculados";
            this.combobox_investig_vinculados.Size = new System.Drawing.Size(143, 36);
            this.combobox_investig_vinculados.TabIndex = 40;
            this.combobox_investig_vinculados.SelectedIndexChanged += new System.EventHandler(this.combobox_investig_vinculados_SelectedIndexChanged);
            // 
            // btnVincular
            // 
            this.btnVincular.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnVincular.BorderRadius = 5;
            this.btnVincular.BorderThickness = 1;
            this.btnVincular.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVincular.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVincular.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVincular.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVincular.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(129)))), ((int)(((byte)(214)))));
            this.btnVincular.Font = new System.Drawing.Font("Segoe UI Variable Text", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnVincular.ForeColor = System.Drawing.SystemColors.Window;
            this.btnVincular.Location = new System.Drawing.Point(515, 226);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(153, 45);
            this.btnVincular.TabIndex = 41;
            this.btnVincular.Text = "VINCULAR";
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // calendar_fecha
            // 
            this.calendar_fecha.Location = new System.Drawing.Point(24, 46);
            this.calendar_fecha.Name = "calendar_fecha";
            this.calendar_fecha.TabIndex = 42;
            this.calendar_fecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_fecha_DateChanged);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.guna2Button1);
            this.guna2GroupBox1.Controls.Add(this.calendar_fecha);
            this.guna2GroupBox1.Controls.Add(this.btn_guardar_edicion);
            this.guna2GroupBox1.Controls.Add(this.btnVincular);
            this.guna2GroupBox1.Controls.Add(this.combobox_investig_vinculados);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.btnDesvincular);
            this.guna2GroupBox1.Controls.Add(this.combobox_investig_disponibles);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.txtmotivoreu);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.txtnombrereu);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.txtHoraFinal);
            this.guna2GroupBox1.Controls.Add(this.txtHoraInicio);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(-2, -2);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(690, 292);
            this.guna2GroupBox1.TabIndex = 43;
            this.guna2GroupBox1.Text = "                                                                                 " +
    "                                                                                " +
    "                  PROGRAMACIÓN";
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button1.Image = global::ProgramAppointments.Properties.Resources.flecha_izquierda64px;
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(24, 7);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(109, 22);
            this.guna2Button1.TabIndex = 43;
            this.guna2Button1.Text = "Regresar";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // EditarReuLider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnDesvincular;
            this.ClientSize = new System.Drawing.Size(684, 287);
            this.ControlBox = false;
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "EditarReuLider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEETLY - EDITAR REUNIÓN";
            this.Load += new System.EventHandler(this.EditarReuLider_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtmotivoreu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnombrereu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoraFinal;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_investig_disponibles;
        private Guna.UI2.WinForms.Guna2Button btnDesvincular;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_guardar_edicion;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_investig_vinculados;
        private Guna.UI2.WinForms.Guna2Button btnVincular;
        private System.Windows.Forms.MonthCalendar calendar_fecha;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}