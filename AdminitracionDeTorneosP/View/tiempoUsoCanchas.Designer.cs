
namespace AdminitracionDeTorneosP.View
{
    partial class tiempoUsoCanchas
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
            this.buttonFecha = new System.Windows.Forms.RadioButton();
            this.radioNombreCancha = new System.Windows.Forms.RadioButton();
            this.radioNombreTorneo = new System.Windows.Forms.RadioButton();
            this.buscar = new System.Windows.Forms.Button();
            this.textFechaInicio = new System.Windows.Forms.TextBox();
            this.textFechaFin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFecha
            // 
            this.buttonFecha.AutoSize = true;
            this.buttonFecha.Location = new System.Drawing.Point(198, 181);
            this.buttonFecha.Name = "buttonFecha";
            this.buttonFecha.Size = new System.Drawing.Size(83, 32);
            this.buttonFecha.TabIndex = 0;
            this.buttonFecha.TabStop = true;
            this.buttonFecha.Text = "Fecha";
            this.buttonFecha.UseVisualStyleBackColor = true;
            this.buttonFecha.CheckedChanged += new System.EventHandler(this.buttonFecha_CheckedChanged);
            // 
            // radioNombreCancha
            // 
            this.radioNombreCancha.AutoSize = true;
            this.radioNombreCancha.Location = new System.Drawing.Point(198, 219);
            this.radioNombreCancha.Name = "radioNombreCancha";
            this.radioNombreCancha.Size = new System.Drawing.Size(174, 32);
            this.radioNombreCancha.TabIndex = 1;
            this.radioNombreCancha.TabStop = true;
            this.radioNombreCancha.Text = "Nombre Cancha";
            this.radioNombreCancha.UseVisualStyleBackColor = true;
            this.radioNombreCancha.CheckedChanged += new System.EventHandler(this.radioNombreCancha_CheckedChanged);
            // 
            // radioNombreTorneo
            // 
            this.radioNombreTorneo.AutoSize = true;
            this.radioNombreTorneo.Location = new System.Drawing.Point(199, 257);
            this.radioNombreTorneo.Name = "radioNombreTorneo";
            this.radioNombreTorneo.Size = new System.Drawing.Size(173, 32);
            this.radioNombreTorneo.TabIndex = 2;
            this.radioNombreTorneo.TabStop = true;
            this.radioNombreTorneo.Text = "Nombre Torneo";
            this.radioNombreTorneo.UseVisualStyleBackColor = true;
            this.radioNombreTorneo.CheckedChanged += new System.EventHandler(this.radioNombreTorneo_CheckedChanged);
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.buscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buscar.Location = new System.Drawing.Point(521, 257);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(199, 50);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Visible = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // textFechaInicio
            // 
            this.textFechaInicio.BackColor = System.Drawing.Color.Azure;
            this.textFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textFechaInicio.Location = new System.Drawing.Point(441, 209);
            this.textFechaInicio.Name = "textFechaInicio";
            this.textFechaInicio.Size = new System.Drawing.Size(150, 35);
            this.textFechaInicio.TabIndex = 4;
            // 
            // textFechaFin
            // 
            this.textFechaFin.BackColor = System.Drawing.Color.Azure;
            this.textFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textFechaFin.Location = new System.Drawing.Point(639, 209);
            this.textFechaFin.Name = "textFechaFin";
            this.textFechaFin.Size = new System.Drawing.Size(150, 35);
            this.textFechaFin.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha Final";
            // 
            // textNombre
            // 
            this.textNombre.BackColor = System.Drawing.Color.Azure;
            this.textNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textNombre.Location = new System.Drawing.Point(544, 209);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(150, 35);
            this.textNombre.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 28);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = ".....";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Azure;
            this.dataGridView1.Location = new System.Drawing.Point(123, 316);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(802, 210);
            this.dataGridView1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(136, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(749, 59);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tiempo en minutos de uso de canchas";
            // 
            // tiempoUsoCanchas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1043, 603);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFechaFin);
            this.Controls.Add(this.textFechaInicio);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.radioNombreTorneo);
            this.Controls.Add(this.radioNombreCancha);
            this.Controls.Add(this.buttonFecha);
            this.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "tiempoUsoCanchas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tiempoUsoCanchas";
            this.Load += new System.EventHandler(this.tiempoUsoCanchas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton buttonFecha;
        private System.Windows.Forms.RadioButton radioNombreCancha;
        private System.Windows.Forms.RadioButton radioNombreTorneo;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox textFechaInicio;
        private System.Windows.Forms.TextBox textFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
    }
}