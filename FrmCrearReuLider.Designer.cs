namespace ProgramAppointments
{
    partial class FrmCrearReuLider
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
            this.calendar_picker = new System.Windows.Forms.MonthCalendar();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_seleccionar_dia = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // calendar_picker
            // 
            this.calendar_picker.Location = new System.Drawing.Point(72, 144);
            this.calendar_picker.Name = "calendar_picker";
            this.calendar_picker.TabIndex = 1;
            this.calendar_picker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.Location = new System.Drawing.Point(67, 34);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(303, 28);
            this.lbl_welcome.TabIndex = 2;
            this.lbl_welcome.Text = "HOLA LUCHO, BIENVENIDO";
            this.lbl_welcome.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elige un dia por favor";
            // 
            // btn_seleccionar_dia
            // 
            this.btn_seleccionar_dia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_seleccionar_dia.Location = new System.Drawing.Point(368, 355);
            this.btn_seleccionar_dia.Name = "btn_seleccionar_dia";
            this.btn_seleccionar_dia.Size = new System.Drawing.Size(133, 46);
            this.btn_seleccionar_dia.TabIndex = 4;
            this.btn_seleccionar_dia.Text = "Seleccionar dia";
            this.btn_seleccionar_dia.UseVisualStyleBackColor = false;
            this.btn_seleccionar_dia.Click += new System.EventHandler(this.btn_seleccionar_dia_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProgramAppointments.Properties.Resources.Captura_de_pantalla_2026_04_24_124234;
            this.pictureBox1.Location = new System.Drawing.Point(747, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::ProgramAppointments.Properties.Resources.flecha_izquierda;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 6;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCrearReuLider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProgramAppointments.Properties.Resources.MEETLYFONDO;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_seleccionar_dia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_welcome);
            this.Controls.Add(this.calendar_picker);
            this.Name = "FrmCrearReuLider";
            this.Text = "FrmCrearReuLider";
            this.Load += new System.EventHandler(this.FrmCrearReuLider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar_picker;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_seleccionar_dia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}