
namespace AdminitracionDeTorneosP.View
{
    partial class Torneo2
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
            this.ListTorneos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDefeatPoints = new System.Windows.Forms.Label();
            this.txtPuntosDerrota = new System.Windows.Forms.TextBox();
            this.txtTienPoints = new System.Windows.Forms.Label();
            this.txtVictoryPoints = new System.Windows.Forms.Label();
            this.txtAgeMax = new System.Windows.Forms.Label();
            this.txtAgeMin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPuntosEmpate = new System.Windows.Forms.TextBox();
            this.txtPuntosVictoria = new System.Windows.Forms.TextBox();
            this.txtEdadMaxima = new System.Windows.Forms.TextBox();
            this.txtEdadMinima = new System.Windows.Forms.TextBox();
            this.txtMaxPlayer = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDateInicio = new System.Windows.Forms.TextBox();
            this.txtDateFIn = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListTorneos)).BeginInit();
            this.SuspendLayout();
            // 
            // ListTorneos
            // 
            this.ListTorneos.BackgroundColor = System.Drawing.Color.Azure;
            this.ListTorneos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListTorneos.GridColor = System.Drawing.Color.Azure;
            this.ListTorneos.Location = new System.Drawing.Point(82, 240);
            this.ListTorneos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListTorneos.Name = "ListTorneos";
            this.ListTorneos.RowHeadersVisible = false;
            this.ListTorneos.RowHeadersWidth = 51;
            this.ListTorneos.Size = new System.Drawing.Size(615, 147);
            this.ListTorneos.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(126, 397);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(161, 50);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(310, 397);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(161, 50);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Actualizar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(495, 397);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(161, 50);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(95, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 47);
            this.label6.TabIndex = 24;
            this.label6.Text = "Datos Torneo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(417, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(368, 47);
            this.label7.TabIndex = 25;
            this.label7.Text = "Requisitos de Torneo";
            // 
            // txtDefeatPoints
            // 
            this.txtDefeatPoints.AutoSize = true;
            this.txtDefeatPoints.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefeatPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.txtDefeatPoints.Location = new System.Drawing.Point(654, 164);
            this.txtDefeatPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDefeatPoints.Name = "txtDefeatPoints";
            this.txtDefeatPoints.Size = new System.Drawing.Size(115, 21);
            this.txtDefeatPoints.TabIndex = 38;
            this.txtDefeatPoints.Text = "Puntos Derrota";
            // 
            // txtPuntosDerrota
            // 
            this.txtPuntosDerrota.BackColor = System.Drawing.Color.Azure;
            this.txtPuntosDerrota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtPuntosDerrota.Location = new System.Drawing.Point(669, 190);
            this.txtPuntosDerrota.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPuntosDerrota.Name = "txtPuntosDerrota";
            this.txtPuntosDerrota.Size = new System.Drawing.Size(88, 29);
            this.txtPuntosDerrota.TabIndex = 37;
            // 
            // txtTienPoints
            // 
            this.txtTienPoints.AutoSize = true;
            this.txtTienPoints.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.txtTienPoints.Location = new System.Drawing.Point(520, 164);
            this.txtTienPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTienPoints.Name = "txtTienPoints";
            this.txtTienPoints.Size = new System.Drawing.Size(114, 21);
            this.txtTienPoints.TabIndex = 36;
            this.txtTienPoints.Text = "Puntos Empate";
            // 
            // txtVictoryPoints
            // 
            this.txtVictoryPoints.AutoSize = true;
            this.txtVictoryPoints.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVictoryPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.txtVictoryPoints.Location = new System.Drawing.Point(371, 164);
            this.txtVictoryPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtVictoryPoints.Name = "txtVictoryPoints";
            this.txtVictoryPoints.Size = new System.Drawing.Size(115, 21);
            this.txtVictoryPoints.TabIndex = 35;
            this.txtVictoryPoints.Text = "Puntos Victoria";
            // 
            // txtAgeMax
            // 
            this.txtAgeMax.AutoSize = true;
            this.txtAgeMax.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgeMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.txtAgeMax.Location = new System.Drawing.Point(654, 104);
            this.txtAgeMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAgeMax.Name = "txtAgeMax";
            this.txtAgeMax.Size = new System.Drawing.Size(103, 21);
            this.txtAgeMax.TabIndex = 34;
            this.txtAgeMax.Text = "Edad Maxima";
            // 
            // txtAgeMin
            // 
            this.txtAgeMin.AutoSize = true;
            this.txtAgeMin.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgeMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.txtAgeMin.Location = new System.Drawing.Point(533, 104);
            this.txtAgeMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAgeMin.Name = "txtAgeMin";
            this.txtAgeMin.Size = new System.Drawing.Size(101, 21);
            this.txtAgeMin.TabIndex = 33;
            this.txtAgeMin.Text = "Edad Minima";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(352, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 21);
            this.label5.TabIndex = 32;
            this.label5.Text = "Maximo de Jugadores";
            // 
            // txtPuntosEmpate
            // 
            this.txtPuntosEmpate.BackColor = System.Drawing.Color.Azure;
            this.txtPuntosEmpate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtPuntosEmpate.Location = new System.Drawing.Point(537, 190);
            this.txtPuntosEmpate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPuntosEmpate.Name = "txtPuntosEmpate";
            this.txtPuntosEmpate.Size = new System.Drawing.Size(85, 29);
            this.txtPuntosEmpate.TabIndex = 31;
            // 
            // txtPuntosVictoria
            // 
            this.txtPuntosVictoria.BackColor = System.Drawing.Color.Azure;
            this.txtPuntosVictoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtPuntosVictoria.Location = new System.Drawing.Point(393, 190);
            this.txtPuntosVictoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPuntosVictoria.Name = "txtPuntosVictoria";
            this.txtPuntosVictoria.Size = new System.Drawing.Size(89, 29);
            this.txtPuntosVictoria.TabIndex = 30;
            // 
            // txtEdadMaxima
            // 
            this.txtEdadMaxima.BackColor = System.Drawing.Color.Azure;
            this.txtEdadMaxima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtEdadMaxima.Location = new System.Drawing.Point(669, 130);
            this.txtEdadMaxima.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEdadMaxima.Name = "txtEdadMaxima";
            this.txtEdadMaxima.Size = new System.Drawing.Size(88, 29);
            this.txtEdadMaxima.TabIndex = 29;
            // 
            // txtEdadMinima
            // 
            this.txtEdadMinima.BackColor = System.Drawing.Color.Azure;
            this.txtEdadMinima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtEdadMinima.Location = new System.Drawing.Point(537, 130);
            this.txtEdadMinima.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEdadMinima.Name = "txtEdadMinima";
            this.txtEdadMinima.Size = new System.Drawing.Size(85, 29);
            this.txtEdadMinima.TabIndex = 28;
            // 
            // txtMaxPlayer
            // 
            this.txtMaxPlayer.BackColor = System.Drawing.Color.Azure;
            this.txtMaxPlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtMaxPlayer.Location = new System.Drawing.Point(393, 130);
            this.txtMaxPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaxPlayer.Name = "txtMaxPlayer";
            this.txtMaxPlayer.Size = new System.Drawing.Size(89, 29);
            this.txtMaxPlayer.TabIndex = 27;
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.Azure;
            this.txtCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtCosto.Location = new System.Drawing.Point(240, 190);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(86, 29);
            this.txtCosto.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label9.Location = new System.Drawing.Point(257, 164);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 21);
            this.label9.TabIndex = 50;
            this.label9.Text = "Costo";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Azure;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Futbol 5",
            "Futbol 7",
            "Futbol 11"});
            this.comboBox1.Location = new System.Drawing.Point(136, 190);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 29);
            this.comboBox1.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label8.Location = new System.Drawing.Point(132, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 21);
            this.label8.TabIndex = 47;
            this.label8.Text = "Tipo de juego";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Azure;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtName.Location = new System.Drawing.Point(30, 130);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(85, 29);
            this.txtName.TabIndex = 39;
            // 
            // txtDateInicio
            // 
            this.txtDateInicio.BackColor = System.Drawing.Color.Azure;
            this.txtDateInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtDateInicio.Location = new System.Drawing.Point(136, 130);
            this.txtDateInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDateInicio.Name = "txtDateInicio";
            this.txtDateInicio.Size = new System.Drawing.Size(87, 29);
            this.txtDateInicio.TabIndex = 40;
            // 
            // txtDateFIn
            // 
            this.txtDateFIn.BackColor = System.Drawing.Color.Azure;
            this.txtDateFIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtDateFIn.Location = new System.Drawing.Point(240, 130);
            this.txtDateFIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDateFIn.Name = "txtDateFIn";
            this.txtDateFIn.Size = new System.Drawing.Size(86, 29);
            this.txtDateFIn.TabIndex = 41;
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.Color.Azure;
            this.txtType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtType.Location = new System.Drawing.Point(30, 190);
            this.txtType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(85, 29);
            this.txtType.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(39, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 43;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(132, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 44;
            this.label2.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(236, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 45;
            this.label3.Text = "Fecha Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(55, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 21);
            this.label4.TabIndex = 46;
            this.label4.Text = "Tipo";
            // 
            // Torneo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1043, 603);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDateInicio);
            this.Controls.Add(this.txtDateFIn);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDefeatPoints);
            this.Controls.Add(this.txtPuntosDerrota);
            this.Controls.Add(this.txtTienPoints);
            this.Controls.Add(this.txtVictoryPoints);
            this.Controls.Add(this.txtAgeMax);
            this.Controls.Add(this.txtAgeMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPuntosEmpate);
            this.Controls.Add(this.txtPuntosVictoria);
            this.Controls.Add(this.txtEdadMaxima);
            this.Controls.Add(this.txtEdadMinima);
            this.Controls.Add(this.txtMaxPlayer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.ListTorneos);
            this.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Torneo2";
            this.Text = "Torneo";
            ((System.ComponentModel.ISupportInitialize)(this.ListTorneos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListTorneos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtDefeatPoints;
        private System.Windows.Forms.TextBox txtPuntosDerrota;
        private System.Windows.Forms.Label txtTienPoints;
        private System.Windows.Forms.Label txtVictoryPoints;
        private System.Windows.Forms.Label txtAgeMax;
        private System.Windows.Forms.Label txtAgeMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPuntosEmpate;
        private System.Windows.Forms.TextBox txtPuntosVictoria;
        private System.Windows.Forms.TextBox txtEdadMaxima;
        private System.Windows.Forms.TextBox txtEdadMinima;
        private System.Windows.Forms.TextBox txtMaxPlayer;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDateInicio;
        private System.Windows.Forms.TextBox txtDateFIn;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}