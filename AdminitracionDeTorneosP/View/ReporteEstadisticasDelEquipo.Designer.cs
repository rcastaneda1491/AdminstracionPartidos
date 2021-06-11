
namespace AdminitracionDeTorneosP.View
{
    partial class ReporteEstadisticasDelEquipo
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTorneos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEquipos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(259, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Estadisticas Del Equipo";
            // 
            // cmbTorneos
            // 
            this.cmbTorneos.BackColor = System.Drawing.Color.Azure;
            this.cmbTorneos.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTorneos.FormattingEnabled = true;
            this.cmbTorneos.Location = new System.Drawing.Point(427, 94);
            this.cmbTorneos.Name = "cmbTorneos";
            this.cmbTorneos.Size = new System.Drawing.Size(183, 36);
            this.cmbTorneos.TabIndex = 42;
            this.cmbTorneos.SelectionChangeCommitted += new System.EventHandler(this.cmbTorneos_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(343, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 28);
            this.label2.TabIndex = 41;
            this.label2.Text = "Torneo:";
            // 
            // comboEquipos
            // 
            this.comboEquipos.BackColor = System.Drawing.Color.Azure;
            this.comboEquipos.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEquipos.FormattingEnabled = true;
            this.comboEquipos.Location = new System.Drawing.Point(427, 161);
            this.comboEquipos.Name = "comboEquipos";
            this.comboEquipos.Size = new System.Drawing.Size(183, 36);
            this.comboEquipos.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(343, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 28);
            this.label3.TabIndex = 44;
            this.label3.Text = "Equipo:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(427, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 50);
            this.button1.TabIndex = 45;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Azure;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(183, 353);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 35);
            this.textBox1.TabIndex = 46;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Azure;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(183, 441);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 35);
            this.textBox2.TabIndex = 47;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Azure;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(418, 441);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 35);
            this.textBox3.TabIndex = 49;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Azure;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(418, 353);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 35);
            this.textBox4.TabIndex = 48;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Azure;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(654, 441);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(183, 35);
            this.textBox5.TabIndex = 51;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Azure;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(654, 353);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(183, 35);
            this.textBox6.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(466, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 28);
            this.label4.TabIndex = 52;
            this.label4.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(178, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 28);
            this.label5.TabIndex = 53;
            this.label5.Text = "Posición Actual";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(178, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 28);
            this.label6.TabIndex = 54;
            this.label6.Text = "Partidos Jugados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(422, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 28);
            this.label7.TabIndex = 55;
            this.label7.Text = "Partidos Ganados";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label8.Location = new System.Drawing.Point(413, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 28);
            this.label8.TabIndex = 56;
            this.label8.Text = "Partidos Empatados";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label9.Location = new System.Drawing.Point(649, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 28);
            this.label9.TabIndex = 57;
            this.label9.Text = "Partidos Perdidos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label10.Location = new System.Drawing.Point(649, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 28);
            this.label10.TabIndex = 58;
            this.label10.Text = "Punteo Actual";
            // 
            // ReporteEstadisticasDelEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1007, 509);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboEquipos);
            this.Controls.Add(this.cmbTorneos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteEstadisticasDelEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteEstadisticasDelEquipo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTorneos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEquipos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}