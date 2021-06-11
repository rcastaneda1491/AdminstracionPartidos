
namespace AdminitracionDeTorneosP.View
{
    partial class CRUD_REGISTRO_AMONESTACION
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
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.LIstAmonestaciones = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbJugador = new System.Windows.Forms.ComboBox();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.cmbEquipos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LIstAmonestaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTiempo
            // 
            this.txtTiempo.BackColor = System.Drawing.Color.Azure;
            this.txtTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtTiempo.Location = new System.Drawing.Point(400, 178);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(183, 26);
            this.txtTiempo.TabIndex = 2;
            // 
            // LIstAmonestaciones
            // 
            this.LIstAmonestaciones.AllowUserToAddRows = false;
            this.LIstAmonestaciones.AllowUserToDeleteRows = false;
            this.LIstAmonestaciones.BackgroundColor = System.Drawing.Color.Azure;
            this.LIstAmonestaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LIstAmonestaciones.GridColor = System.Drawing.Color.Azure;
            this.LIstAmonestaciones.Location = new System.Drawing.Point(93, 227);
            this.LIstAmonestaciones.Name = "LIstAmonestaciones";
            this.LIstAmonestaciones.ReadOnly = true;
            this.LIstAmonestaciones.RowHeadersVisible = false;
            this.LIstAmonestaciones.RowHeadersWidth = 51;
            this.LIstAmonestaciones.Size = new System.Drawing.Size(605, 138);
            this.LIstAmonestaciones.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(94, 388);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(161, 50);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(308, 388);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(161, 50);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Actualizar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(520, 388);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 50);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(457, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Jugador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(250, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tarjeta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(454, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tiempo";
            // 
            // cmbJugador
            // 
            this.cmbJugador.BackColor = System.Drawing.Color.Azure;
            this.cmbJugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJugador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmbJugador.FormattingEnabled = true;
            this.cmbJugador.Location = new System.Drawing.Point(400, 105);
            this.cmbJugador.Name = "cmbJugador";
            this.cmbJugador.Size = new System.Drawing.Size(183, 28);
            this.cmbJugador.TabIndex = 10;
            this.cmbJugador.SelectedIndexChanged += new System.EventHandler(this.cmbJugador_SelectedIndexChanged);
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.BackColor = System.Drawing.Color.Azure;
            this.cmbTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(188, 176);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(183, 28);
            this.cmbTarjeta.TabIndex = 11;
            this.cmbTarjeta.SelectedIndexChanged += new System.EventHandler(this.cmbTarjeta_SelectedIndexChanged);
            // 
            // cmbEquipos
            // 
            this.cmbEquipos.BackColor = System.Drawing.Color.Azure;
            this.cmbEquipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEquipos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmbEquipos.FormattingEnabled = true;
            this.cmbEquipos.Location = new System.Drawing.Point(188, 105);
            this.cmbEquipos.Name = "cmbEquipos";
            this.cmbEquipos.Size = new System.Drawing.Size(183, 28);
            this.cmbEquipos.TabIndex = 13;
            this.cmbEquipos.SelectedIndexChanged += new System.EventHandler(this.cmbEquipos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(244, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Equipos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(180, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(458, 47);
            this.label5.TabIndex = 14;
            this.label5.Text = "Registro De Amonestacion";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(632, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 34);
            this.button1.TabIndex = 15;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CRUD_REGISTRO_AMONESTACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(782, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEquipos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTarjeta);
            this.Controls.Add(this.cmbJugador);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.LIstAmonestaciones);
            this.Controls.Add(this.txtTiempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CRUD_REGISTRO_AMONESTACION";
            this.Text = "CRUD_REGISTRO_AMONESTACION";
            ((System.ComponentModel.ISupportInitialize)(this.LIstAmonestaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.DataGridView LIstAmonestaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbJugador;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.ComboBox cmbEquipos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}