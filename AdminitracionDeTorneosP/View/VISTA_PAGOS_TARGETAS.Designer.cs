
namespace AdminitracionDeTorneosP.View
{
    partial class VISTA_PAGOS_TARGETAS
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
            this.lista_amonstaciones_datagrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_id_juego = new System.Windows.Forms.TextBox();
            this.txt_dpi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_id_targeta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.cmb_pagada = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_tiempo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lista_amonstaciones_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_amonstaciones_datagrid
            // 
            this.lista_amonstaciones_datagrid.AllowUserToAddRows = false;
            this.lista_amonstaciones_datagrid.AllowUserToDeleteRows = false;
            this.lista_amonstaciones_datagrid.BackgroundColor = System.Drawing.Color.Azure;
            this.lista_amonstaciones_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista_amonstaciones_datagrid.GridColor = System.Drawing.Color.Azure;
            this.lista_amonstaciones_datagrid.Location = new System.Drawing.Point(49, 287);
            this.lista_amonstaciones_datagrid.Name = "lista_amonstaciones_datagrid";
            this.lista_amonstaciones_datagrid.ReadOnly = true;
            this.lista_amonstaciones_datagrid.RowHeadersVisible = false;
            this.lista_amonstaciones_datagrid.RowHeadersWidth = 51;
            this.lista_amonstaciones_datagrid.RowTemplate.Height = 24;
            this.lista_amonstaciones_datagrid.Size = new System.Drawing.Size(904, 150);
            this.lista_amonstaciones_datagrid.TabIndex = 0;
            this.lista_amonstaciones_datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(241, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(523, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_id_juego
            // 
            this.txt_id_juego.BackColor = System.Drawing.Color.Azure;
            this.txt_id_juego.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id_juego.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_id_juego.Location = new System.Drawing.Point(121, 130);
            this.txt_id_juego.Name = "txt_id_juego";
            this.txt_id_juego.Size = new System.Drawing.Size(183, 35);
            this.txt_id_juego.TabIndex = 3;
            // 
            // txt_dpi
            // 
            this.txt_dpi.BackColor = System.Drawing.Color.Azure;
            this.txt_dpi.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dpi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_dpi.Location = new System.Drawing.Point(450, 130);
            this.txt_dpi.Name = "txt_dpi";
            this.txt_dpi.Size = new System.Drawing.Size(183, 35);
            this.txt_dpi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(330, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Control de pagos de tarjetas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id juego";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(332, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dpi jugador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(655, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID targeta";
            // 
            // txt_id_targeta
            // 
            this.txt_id_targeta.BackColor = System.Drawing.Color.Azure;
            this.txt_id_targeta.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id_targeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_id_targeta.Location = new System.Drawing.Point(770, 124);
            this.txt_id_targeta.Name = "txt_id_targeta";
            this.txt_id_targeta.Size = new System.Drawing.Size(183, 35);
            this.txt_id_targeta.TabIndex = 8;
            this.txt_id_targeta.TextChanged += new System.EventHandler(this.txt_id_targeta_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(332, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Pagada";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(655, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha pago";
            // 
            // txt_fecha
            // 
            this.txt_fecha.BackColor = System.Drawing.Color.Azure;
            this.txt_fecha.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_fecha.Location = new System.Drawing.Point(770, 229);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(183, 35);
            this.txt_fecha.TabIndex = 12;
            this.txt_fecha.Validating += new System.ComponentModel.CancelEventHandler(this.txt_fecha_Validating);
            // 
            // cmb_pagada
            // 
            this.cmb_pagada.BackColor = System.Drawing.Color.Azure;
            this.cmb_pagada.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pagada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmb_pagada.FormattingEnabled = true;
            this.cmb_pagada.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmb_pagada.Location = new System.Drawing.Point(440, 218);
            this.cmb_pagada.Name = "cmb_pagada";
            this.cmb_pagada.Size = new System.Drawing.Size(183, 36);
            this.cmb_pagada.TabIndex = 14;
            this.cmb_pagada.Text = "Seleccione una opcion";
            this.cmb_pagada.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_pagada_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(806, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "DD/MM/AA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label8.Location = new System.Drawing.Point(7, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tiempo";
            // 
            // txt_tiempo
            // 
            this.txt_tiempo.BackColor = System.Drawing.Color.Azure;
            this.txt_tiempo.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_tiempo.Location = new System.Drawing.Point(121, 223);
            this.txt_tiempo.Name = "txt_tiempo";
            this.txt_tiempo.Size = new System.Drawing.Size(183, 35);
            this.txt_tiempo.TabIndex = 17;
            // 
            // VISTA_PAGOS_TARGETAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1025, 556);
            this.Controls.Add(this.txt_tiempo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_pagada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_fecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_id_targeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_dpi);
            this.Controls.Add(this.txt_id_juego);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lista_amonstaciones_datagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VISTA_PAGOS_TARGETAS";
            this.Text = "VISTA_PAGOS_TARGETAS";
            ((System.ComponentModel.ISupportInitialize)(this.lista_amonstaciones_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lista_amonstaciones_datagrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_id_juego;
        private System.Windows.Forms.TextBox txt_dpi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_id_targeta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.ComboBox cmb_pagada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tiempo;
    }
}