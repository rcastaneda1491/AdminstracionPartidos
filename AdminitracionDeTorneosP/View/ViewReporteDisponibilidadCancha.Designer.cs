
namespace AdminitracionDeTorneosP.View
{
    partial class ViewReporteDisponibilidadCancha
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
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.listDisponibilidad = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxCanchas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listDisponibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.BackColor = System.Drawing.Color.Azure;
            this.txtFechaFinal.Location = new System.Drawing.Point(553, 120);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.Size = new System.Drawing.Size(118, 20);
            this.txtFechaFinal.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(567, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 79;
            this.label1.Text = "Fecha Final";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(346, 372);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 49);
            this.btnBuscar.TabIndex = 78;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // listDisponibilidad
            // 
            this.listDisponibilidad.BackgroundColor = System.Drawing.Color.Azure;
            this.listDisponibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDisponibilidad.Location = new System.Drawing.Point(54, 167);
            this.listDisponibilidad.Name = "listDisponibilidad";
            this.listDisponibilidad.Size = new System.Drawing.Size(682, 185);
            this.listDisponibilidad.TabIndex = 77;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label9.Location = new System.Drawing.Point(190, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 47);
            this.label9.TabIndex = 76;
            this.label9.Text = "Disponibilidad de Cancha";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.BackColor = System.Drawing.Color.Azure;
            this.txtFechaInicio.Location = new System.Drawing.Point(349, 120);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(118, 20);
            this.txtFechaInicio.TabIndex = 75;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(363, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 74;
            this.label7.Text = "Fecha Inicio";
            // 
            // cbxCanchas
            // 
            this.cbxCanchas.BackColor = System.Drawing.Color.Azure;
            this.cbxCanchas.FormattingEnabled = true;
            this.cbxCanchas.Location = new System.Drawing.Point(134, 120);
            this.cbxCanchas.Name = "cbxCanchas";
            this.cbxCanchas.Size = new System.Drawing.Size(121, 21);
            this.cbxCanchas.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(160, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 82;
            this.label2.Text = "Cancha";
            // 
            // ViewReporteDisponibilidadCancha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCanchas);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.listDisponibilidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.label7);
            this.Name = "ViewReporteDisponibilidadCancha";
            this.Text = "ViewReporteDisponibilidadCancha";
            ((System.ComponentModel.ISupportInitialize)(this.listDisponibilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView listDisponibilidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxCanchas;
        private System.Windows.Forms.Label label2;
    }
}