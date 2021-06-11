
namespace AdminitracionDeTorneosP.View
{
    partial class CRUD_EQUIPO
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.textNombreEquipo = new System.Windows.Forms.TextBox();
            this.textRepresentante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboNombreEntrenador = new System.Windows.Forms.ComboBox();
            this.comboApellidoEntrenador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Azure;
            this.dataGridView1.Location = new System.Drawing.Point(129, 306);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(802, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(22)))), ((int)(((byte)(26)))));
            this.buttonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEliminar.Location = new System.Drawing.Point(726, 533);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(161, 50);
            this.buttonEliminar.TabIndex = 19;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.buttonAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAgregar.FlatAppearance.BorderSize = 0;
            this.buttonAgregar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAgregar.Location = new System.Drawing.Point(454, 533);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(161, 50);
            this.buttonAgregar.TabIndex = 0;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.buttonSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSeleccionar.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeleccionar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSeleccionar.Location = new System.Drawing.Point(169, 533);
            this.buttonSeleccionar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(161, 50);
            this.buttonSeleccionar.TabIndex = 9;
            this.buttonSeleccionar.Text = "Actualizar";
            this.buttonSeleccionar.UseVisualStyleBackColor = false;
            this.buttonSeleccionar.Click += new System.EventHandler(this.button2_Click);
            // 
            // textNombreEquipo
            // 
            this.textNombreEquipo.BackColor = System.Drawing.Color.Azure;
            this.textNombreEquipo.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textNombreEquipo.Location = new System.Drawing.Point(314, 144);
            this.textNombreEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.textNombreEquipo.Name = "textNombreEquipo";
            this.textNombreEquipo.Size = new System.Drawing.Size(183, 35);
            this.textNombreEquipo.TabIndex = 1;
            this.textNombreEquipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textNombreEquipo.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // textRepresentante
            // 
            this.textRepresentante.BackColor = System.Drawing.Color.Azure;
            this.textRepresentante.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRepresentante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textRepresentante.Location = new System.Drawing.Point(606, 144);
            this.textRepresentante.Margin = new System.Windows.Forms.Padding(4);
            this.textRepresentante.Name = "textRepresentante";
            this.textRepresentante.Size = new System.Drawing.Size(183, 35);
            this.textRepresentante.TabIndex = 3;
            this.textRepresentante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            this.textRepresentante.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre Del Equipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Representante";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 199);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre Entrenador";
            // 
            // comboNombreEntrenador
            // 
            this.comboNombreEntrenador.BackColor = System.Drawing.Color.Azure;
            this.comboNombreEntrenador.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNombreEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.comboNombreEntrenador.FormattingEnabled = true;
            this.comboNombreEntrenador.Location = new System.Drawing.Point(314, 230);
            this.comboNombreEntrenador.Name = "comboNombreEntrenador";
            this.comboNombreEntrenador.Size = new System.Drawing.Size(183, 36);
            this.comboNombreEntrenador.TabIndex = 29;
            this.comboNombreEntrenador.SelectedIndexChanged += new System.EventHandler(this.comboNombreEntrenador_SelectedIndexChanged);
            // 
            // comboApellidoEntrenador
            // 
            this.comboApellidoEntrenador.BackColor = System.Drawing.Color.Azure;
            this.comboApellidoEntrenador.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboApellidoEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.comboApellidoEntrenador.FormattingEnabled = true;
            this.comboApellidoEntrenador.Location = new System.Drawing.Point(606, 230);
            this.comboApellidoEntrenador.Name = "comboApellidoEntrenador";
            this.comboApellidoEntrenador.Size = new System.Drawing.Size(183, 36);
            this.comboApellidoEntrenador.TabIndex = 30;
            this.comboApellidoEntrenador.SelectedIndexChanged += new System.EventHandler(this.comboApellidoEntrenador_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(601, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 28);
            this.label2.TabIndex = 31;
            this.label2.Text = "Apellido Entrenador";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(345, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(418, 59);
            this.label6.TabIndex = 33;
            this.label6.Text = "Inscripción Equipos";
            // 
            // CRUD_EQUIPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1043, 603);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboApellidoEntrenador);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.comboNombreEntrenador);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textRepresentante);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNombreEquipo);
            this.Controls.Add(this.buttonAgregar);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CRUD_EQUIPO";
            this.RightToLeftLayout = true;
            this.Text = "Agregar Equipo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.TextBox textNombreEquipo;
        private System.Windows.Forms.TextBox textRepresentante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboNombreEntrenador;
        private System.Windows.Forms.ComboBox comboApellidoEntrenador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}