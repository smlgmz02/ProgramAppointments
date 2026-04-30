namespace ProgramAppointments
{
    partial class consultarReuLider
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.datagrid_reuniones = new System.Windows.Forms.DataGridView();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.calendar_picker = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ProgramAppointments.Properties.Resources.flecha_izquierda;
            this.button1.Location = new System.Drawing.Point(25, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 36);
            this.button1.TabIndex = 11;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Variable Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.Location = new System.Drawing.Point(73, 25);
            this.lbl_welcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(277, 36);
            this.lbl_welcome.TabIndex = 8;
            this.lbl_welcome.Text = "Consultar Reuniones";
            // 
            // datagrid_reuniones
            // 
            this.datagrid_reuniones.BackgroundColor = System.Drawing.Color.White;
            this.datagrid_reuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_reuniones.Location = new System.Drawing.Point(593, 119);
            this.datagrid_reuniones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datagrid_reuniones.Name = "datagrid_reuniones";
            this.datagrid_reuniones.RowHeadersWidth = 51;
            this.datagrid_reuniones.Size = new System.Drawing.Size(587, 298);
            this.datagrid_reuniones.TabIndex = 12;
            this.datagrid_reuniones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_reuniones_CellContentClick);
            // 
            // btn_editar
            // 
            this.btn_editar.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_editar.Location = new System.Drawing.Point(593, 430);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(285, 57);
            this.btn_editar.TabIndex = 13;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = false;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.Thistle;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.Color.Crimson;
            this.btn_eliminar.Location = new System.Drawing.Point(895, 430);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(285, 57);
            this.btn_eliminar.TabIndex = 14;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(133, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Elige un dia por favor";
            // 
            // calendar_picker
            // 
            this.calendar_picker.Location = new System.Drawing.Point(91, 158);
            this.calendar_picker.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.calendar_picker.Name = "calendar_picker";
            this.calendar_picker.TabIndex = 7;
            this.calendar_picker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_picker_DateChanged);
            // 
            // consultarReuLider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.ClientSize = new System.Drawing.Size(1212, 670);
            this.ControlBox = false;
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.datagrid_reuniones);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_welcome);
            this.Controls.Add(this.calendar_picker);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "consultarReuLider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEETLY - CONSULTAR REUNIONES";
            this.Load += new System.EventHandler(this.consultarReuLider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_reuniones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.DataGridView datagrid_reuniones;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar calendar_picker;
    }
}