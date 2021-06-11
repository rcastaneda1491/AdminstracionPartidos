
namespace AdminitracionDeTorneosP.View
{
    partial class CRUD_CAMBIOS
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
            this.lista_cambios_data_grid = new System.Windows.Forms.DataGridView();
            this.cmb_jugadores_entran = new System.Windows.Forms.ComboBox();
            this.cmb_jugadores_salen = new System.Windows.Forms.ComboBox();
            this.txt_tiempo_entra = new System.Windows.Forms.TextBox();
            this.txt_sale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_id_juego = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_id_local = new System.Windows.Forms.TextBox();
            this.txt_id_visita = new System.Windows.Forms.TextBox();
            this.txt_dpi_entra = new System.Windows.Forms.TextBox();
            this.txt_dpi_sale = new System.Windows.Forms.TextBox();
            this.txt_id_equipo_entra = new System.Windows.Forms.TextBox();
            this.txt_id_equipo_sale = new System.Windows.Forms.TextBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_equuipos_encuentros = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_hora_inicio = new System.Windows.Forms.TextBox();
            this.txt_hora_final = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lista_cambios_data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_cambios_data_grid
            // 
            this.lista_cambios_data_grid.AllowUserToAddRows = false;
            this.lista_cambios_data_grid.AllowUserToDeleteRows = false;
            this.lista_cambios_data_grid.BackgroundColor = System.Drawing.Color.Azure;
            this.lista_cambios_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista_cambios_data_grid.GridColor = System.Drawing.Color.Azure;
            this.lista_cambios_data_grid.Location = new System.Drawing.Point(69, 399);
            this.lista_cambios_data_grid.Name = "lista_cambios_data_grid";
            this.lista_cambios_data_grid.ReadOnly = true;
            this.lista_cambios_data_grid.RowHeadersVisible = false;
            this.lista_cambios_data_grid.RowHeadersWidth = 51;
            this.lista_cambios_data_grid.RowTemplate.Height = 24;
            this.lista_cambios_data_grid.Size = new System.Drawing.Size(885, 130);
            this.lista_cambios_data_grid.TabIndex = 0;
            this.lista_cambios_data_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lista_cambios_data_grid_CellContentClick);
            // 
            // cmb_jugadores_entran
            // 
            this.cmb_jugadores_entran.BackColor = System.Drawing.Color.Azure;
            this.cmb_jugadores_entran.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_jugadores_entran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmb_jugadores_entran.FormattingEnabled = true;
            this.cmb_jugadores_entran.Location = new System.Drawing.Point(507, 171);
            this.cmb_jugadores_entran.Name = "cmb_jugadores_entran";
            this.cmb_jugadores_entran.Size = new System.Drawing.Size(183, 36);
            this.cmb_jugadores_entran.TabIndex = 1;
            this.cmb_jugadores_entran.Text = "Elige una opcion";
            this.cmb_jugadores_entran.SelectedIndexChanged += new System.EventHandler(this.cmb_jugadores_entran_SelectedIndexChanged);
            this.cmb_jugadores_entran.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_jugadores_entran_Validating);
            // 
            // cmb_jugadores_salen
            // 
            this.cmb_jugadores_salen.BackColor = System.Drawing.Color.Azure;
            this.cmb_jugadores_salen.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_jugadores_salen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmb_jugadores_salen.FormattingEnabled = true;
            this.cmb_jugadores_salen.Location = new System.Drawing.Point(877, 171);
            this.cmb_jugadores_salen.Name = "cmb_jugadores_salen";
            this.cmb_jugadores_salen.Size = new System.Drawing.Size(183, 36);
            this.cmb_jugadores_salen.TabIndex = 2;
            this.cmb_jugadores_salen.Text = "Elige una opcion";
            this.cmb_jugadores_salen.SelectedIndexChanged += new System.EventHandler(this.cmb_jugadores_salen_SelectedIndexChanged);
            this.cmb_jugadores_salen.Validating += new System.ComponentModel.CancelEventHandler(this.cmb_jugadores_salen_Validating);
            // 
            // txt_tiempo_entra
            // 
            this.txt_tiempo_entra.BackColor = System.Drawing.Color.Azure;
            this.txt_tiempo_entra.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tiempo_entra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_tiempo_entra.Location = new System.Drawing.Point(288, 325);
            this.txt_tiempo_entra.Name = "txt_tiempo_entra";
            this.txt_tiempo_entra.Size = new System.Drawing.Size(183, 35);
            this.txt_tiempo_entra.TabIndex = 3;
            this.txt_tiempo_entra.TextChanged += new System.EventHandler(this.txt_tiempo_entra_TextChanged);
            this.txt_tiempo_entra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tiempo_entra_KeyPress);
            this.txt_tiempo_entra.Validating += new System.ComponentModel.CancelEventHandler(this.txt_tiempo_entra_Validating);
            // 
            // txt_sale
            // 
            this.txt_sale.BackColor = System.Drawing.Color.Azure;
            this.txt_sale.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_sale.Location = new System.Drawing.Point(654, 325);
            this.txt_sale.Name = "txt_sale";
            this.txt_sale.Size = new System.Drawing.Size(183, 35);
            this.txt_sale.TabIndex = 4;
            this.txt_sale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_sale_KeyPress);
            this.txt_sale.Validating += new System.ComponentModel.CancelEventHandler(this.txt_sale_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(339, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Jugador Ingresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(729, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jugador Sale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(96, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tiempo ingreso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(493, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tiempo Salida";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(17, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "ID_juego";
            // 
            // txt_id_juego
            // 
            this.txt_id_juego.BackColor = System.Drawing.Color.Azure;
            this.txt_id_juego.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id_juego.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_id_juego.Location = new System.Drawing.Point(127, 12);
            this.txt_id_juego.Name = "txt_id_juego";
            this.txt_id_juego.Size = new System.Drawing.Size(183, 35);
            this.txt_id_juego.TabIndex = 10;
            this.txt_id_juego.TextChanged += new System.EventHandler(this.txt_id_juego_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(308, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(453, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "VS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label8.Location = new System.Drawing.Point(553, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 32);
            this.label8.TabIndex = 13;
            this.label8.Text = "label8";
            // 
            // txt_id_local
            // 
            this.txt_id_local.Location = new System.Drawing.Point(795, 112);
            this.txt_id_local.Name = "txt_id_local";
            this.txt_id_local.Size = new System.Drawing.Size(121, 22);
            this.txt_id_local.TabIndex = 14;
            this.txt_id_local.TextChanged += new System.EventHandler(this.txt_id_local_TextChanged);
            // 
            // txt_id_visita
            // 
            this.txt_id_visita.Location = new System.Drawing.Point(795, 62);
            this.txt_id_visita.Name = "txt_id_visita";
            this.txt_id_visita.Size = new System.Drawing.Size(121, 22);
            this.txt_id_visita.TabIndex = 15;
            this.txt_id_visita.TextChanged += new System.EventHandler(this.txt_id_visita_TextChanged);
            // 
            // txt_dpi_entra
            // 
            this.txt_dpi_entra.BackColor = System.Drawing.Color.Azure;
            this.txt_dpi_entra.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dpi_entra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_dpi_entra.Location = new System.Drawing.Point(288, 259);
            this.txt_dpi_entra.Name = "txt_dpi_entra";
            this.txt_dpi_entra.Size = new System.Drawing.Size(183, 35);
            this.txt_dpi_entra.TabIndex = 16;
            this.txt_dpi_entra.TextChanged += new System.EventHandler(this.txt_dpi_entra_TextChanged);
            // 
            // txt_dpi_sale
            // 
            this.txt_dpi_sale.BackColor = System.Drawing.Color.Azure;
            this.txt_dpi_sale.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dpi_sale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_dpi_sale.Location = new System.Drawing.Point(654, 259);
            this.txt_dpi_sale.Name = "txt_dpi_sale";
            this.txt_dpi_sale.Size = new System.Drawing.Size(183, 35);
            this.txt_dpi_sale.TabIndex = 17;
            this.txt_dpi_sale.TextChanged += new System.EventHandler(this.txt_dpi_sale_TextChanged);
            // 
            // txt_id_equipo_entra
            // 
            this.txt_id_equipo_entra.Location = new System.Drawing.Point(922, 112);
            this.txt_id_equipo_entra.Name = "txt_id_equipo_entra";
            this.txt_id_equipo_entra.Size = new System.Drawing.Size(121, 22);
            this.txt_id_equipo_entra.TabIndex = 18;
            this.txt_id_equipo_entra.TextChanged += new System.EventHandler(this.txt_id_equipo_entra_TextChanged);
            // 
            // txt_id_equipo_sale
            // 
            this.txt_id_equipo_sale.Location = new System.Drawing.Point(922, 84);
            this.txt_id_equipo_sale.Name = "txt_id_equipo_sale";
            this.txt_id_equipo_sale.Size = new System.Drawing.Size(121, 22);
            this.txt_id_equipo_sale.TabIndex = 19;
            this.txt_id_equipo_sale.TextChanged += new System.EventHandler(this.txt_id_equipo_sale_TextChanged);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Guardar.Location = new System.Drawing.Point(366, 544);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(161, 50);
            this.btn_Guardar.TabIndex = 22;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_actualizar.FlatAppearance.BorderSize = 0;
            this.btn_actualizar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_actualizar.Location = new System.Drawing.Point(153, 544);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(161, 50);
            this.btn_actualizar.TabIndex = 23;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(567, 544);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 50);
            this.button1.TabIndex = 24;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label11.Location = new System.Drawing.Point(334, -1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(293, 59);
            this.label11.TabIndex = 27;
            this.label11.Text = "Sustituciones";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(995, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 38);
            this.button5.TabIndex = 41;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label12.Location = new System.Drawing.Point(5, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 28);
            this.label12.TabIndex = 42;
            this.label12.Text = "Equipo";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // cmb_equuipos_encuentros
            // 
            this.cmb_equuipos_encuentros.BackColor = System.Drawing.Color.Azure;
            this.cmb_equuipos_encuentros.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_equuipos_encuentros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmb_equuipos_encuentros.FormattingEnabled = true;
            this.cmb_equuipos_encuentros.Location = new System.Drawing.Point(127, 171);
            this.cmb_equuipos_encuentros.Name = "cmb_equuipos_encuentros";
            this.cmb_equuipos_encuentros.Size = new System.Drawing.Size(183, 36);
            this.cmb_equuipos_encuentros.TabIndex = 43;
            this.cmb_equuipos_encuentros.Text = "Seleccione una opcion";
            this.cmb_equuipos_encuentros.SelectedIndexChanged += new System.EventHandler(this.cmb_equuipos_encuentros_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 44;
            // 
            // txt_hora_inicio
            // 
            this.txt_hora_inicio.BackColor = System.Drawing.Color.Azure;
            this.txt_hora_inicio.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hora_inicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_hora_inicio.Location = new System.Drawing.Point(127, 137);
            this.txt_hora_inicio.Name = "txt_hora_inicio";
            this.txt_hora_inicio.Size = new System.Drawing.Size(183, 28);
            this.txt_hora_inicio.TabIndex = 45;
            // 
            // txt_hora_final
            // 
            this.txt_hora_final.BackColor = System.Drawing.Color.Azure;
            this.txt_hora_final.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hora_final.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txt_hora_final.Location = new System.Drawing.Point(507, 131);
            this.txt_hora_final.Name = "txt_hora_final";
            this.txt_hora_final.Size = new System.Drawing.Size(183, 28);
            this.txt_hora_final.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label13.Location = new System.Drawing.Point(96, 259);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 28);
            this.label13.TabIndex = 47;
            this.label13.Text = "Dpi jugador entra";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label9.Location = new System.Drawing.Point(493, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 28);
            this.label9.TabIndex = 48;
            this.label9.Text = "Dpi jugador sale";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label10.Location = new System.Drawing.Point(5, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 28);
            this.label10.TabIndex = 49;
            this.label10.Text = "Hora inicio: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label14.Location = new System.Drawing.Point(339, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 28);
            this.label14.TabIndex = 50;
            this.label14.Text = "Hora final: ";
            // 
            // CRUD_CAMBIOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1081, 599);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_hora_final);
            this.Controls.Add(this.txt_hora_inicio);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmb_equuipos_encuentros);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.txt_id_equipo_sale);
            this.Controls.Add(this.txt_id_equipo_entra);
            this.Controls.Add(this.txt_dpi_sale);
            this.Controls.Add(this.txt_dpi_entra);
            this.Controls.Add(this.txt_id_visita);
            this.Controls.Add(this.txt_id_local);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_id_juego);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sale);
            this.Controls.Add(this.txt_tiempo_entra);
            this.Controls.Add(this.cmb_jugadores_salen);
            this.Controls.Add(this.cmb_jugadores_entran);
            this.Controls.Add(this.lista_cambios_data_grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CRUD_CAMBIOS";
            this.Text = "CRUD_CAMBIOS";
            this.Load += new System.EventHandler(this.CRUD_CAMBIOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista_cambios_data_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lista_cambios_data_grid;
        private System.Windows.Forms.ComboBox cmb_jugadores_entran;
        private System.Windows.Forms.ComboBox cmb_jugadores_salen;
        private System.Windows.Forms.TextBox txt_tiempo_entra;
        private System.Windows.Forms.TextBox txt_sale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_id_juego;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_id_local;
        private System.Windows.Forms.TextBox txt_id_visita;
        private System.Windows.Forms.TextBox txt_dpi_entra;
        private System.Windows.Forms.TextBox txt_dpi_sale;
        private System.Windows.Forms.TextBox txt_id_equipo_entra;
        private System.Windows.Forms.TextBox txt_id_equipo_sale;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_equuipos_encuentros;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_hora_inicio;
        private System.Windows.Forms.TextBox txt_hora_final;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
    }
}