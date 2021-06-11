
namespace AdminitracionDeTorneosP.View
{
    partial class ViewAlquilerCancha
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
            this.cbArbitraje = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaApartada = new System.Windows.Forms.TextBox();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.txtHoraFinal = new System.Windows.Forms.TextBox();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.cbxCancha = new System.Windows.Forms.ComboBox();
            this.txtPrecioCancha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxArbitro = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listAlquilerCancha = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listAlquilerCancha)).BeginInit();
            this.SuspendLayout();
            // 
            // cbArbitraje
            // 
            this.cbArbitraje.AutoSize = true;
            this.cbArbitraje.Location = new System.Drawing.Point(389, 165);
            this.cbArbitraje.Name = "cbArbitraje";
            this.cbArbitraje.Size = new System.Drawing.Size(119, 17);
            this.cbArbitraje.TabIndex = 37;
            this.cbArbitraje.Text = "Servicio de arbitraje";
            this.cbArbitraje.UseVisualStyleBackColor = true;
            this.cbArbitraje.CheckedChanged += new System.EventHandler(this.cbArbitraje_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(29, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 21);
            this.label7.TabIndex = 41;
            this.label7.Text = "Fecha Apartada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(225, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 42;
            this.label2.Text = "Hora Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(408, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 43;
            this.label3.Text = "Hora Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(570, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 44;
            this.label4.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(58, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 45;
            this.label5.Text = "Cancha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(171, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 21);
            this.label1.TabIndex = 46;
            this.label1.Text = "Precio de cancha por hora";
            // 
            // txtFechaApartada
            // 
            this.txtFechaApartada.Location = new System.Drawing.Point(28, 105);
            this.txtFechaApartada.Name = "txtFechaApartada";
            this.txtFechaApartada.Size = new System.Drawing.Size(118, 20);
            this.txtFechaApartada.TabIndex = 47;
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(211, 105);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(118, 20);
            this.txtHoraInicio.TabIndex = 48;
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(390, 107);
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(118, 20);
            this.txtHoraFinal.TabIndex = 49;
            // 
            // cbxCliente
            // 
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(543, 104);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(118, 21);
            this.cbxCliente.TabIndex = 50;
            this.cbxCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCliente_SelectedIndexChanged);
            // 
            // cbxCancha
            // 
            this.cbxCancha.FormattingEnabled = true;
            this.cbxCancha.Location = new System.Drawing.Point(30, 165);
            this.cbxCancha.Name = "cbxCancha";
            this.cbxCancha.Size = new System.Drawing.Size(118, 21);
            this.cbxCancha.TabIndex = 51;
            this.cbxCancha.SelectedIndexChanged += new System.EventHandler(this.cbxCancha_SelectedIndexChanged);
            // 
            // txtPrecioCancha
            // 
            this.txtPrecioCancha.Location = new System.Drawing.Point(214, 166);
            this.txtPrecioCancha.Name = "txtPrecioCancha";
            this.txtPrecioCancha.Size = new System.Drawing.Size(118, 20);
            this.txtPrecioCancha.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(571, 133);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 53;
            this.label6.Text = "Arbitro";
            this.label6.Visible = false;
            // 
            // cbxArbitro
            // 
            this.cbxArbitro.FormattingEnabled = true;
            this.cbxArbitro.Location = new System.Drawing.Point(543, 161);
            this.cbxArbitro.Name = "cbxArbitro";
            this.cbxArbitro.Size = new System.Drawing.Size(118, 21);
            this.cbxArbitro.TabIndex = 54;
            this.cbxArbitro.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label9.Location = new System.Drawing.Point(212, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(280, 47);
            this.label9.TabIndex = 57;
            this.label9.Text = "Alquiler Cancha";
            // 
            // listAlquilerCancha
            // 
            this.listAlquilerCancha.BackgroundColor = System.Drawing.SystemColors.Window;
            this.listAlquilerCancha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listAlquilerCancha.Location = new System.Drawing.Point(211, 205);
            this.listAlquilerCancha.Name = "listAlquilerCancha";
            this.listAlquilerCancha.Size = new System.Drawing.Size(450, 150);
            this.listAlquilerCancha.TabIndex = 58;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(33, 287);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(117, 68);
            this.btnEliminar.TabIndex = 61;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(33, 205);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 66);
            this.btnGuardar.TabIndex = 59;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ViewAlquilerCancha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(782, 490);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.listAlquilerCancha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxArbitro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrecioCancha);
            this.Controls.Add(this.cbxCancha);
            this.Controls.Add(this.cbxCliente);
            this.Controls.Add(this.txtHoraFinal);
            this.Controls.Add(this.txtHoraInicio);
            this.Controls.Add(this.txtFechaApartada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbArbitraje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewAlquilerCancha";
            this.Text = "Alquiler Cancha";
            ((System.ComponentModel.ISupportInitialize)(this.listAlquilerCancha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbArbitraje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaApartada;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.TextBox txtHoraFinal;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.ComboBox cbxCancha;
        private System.Windows.Forms.TextBox txtPrecioCancha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxArbitro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView listAlquilerCancha;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
    }
}