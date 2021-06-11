
namespace AdminitracionDeTorneosP.View
{
    partial class Reporte_Tabla_Visitante
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmxTorneo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListReporteVisita = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ListReporteVisita)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(359, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(334, 60);
            this.label5.TabIndex = 35;
            this.label5.Text = "Tabla Visitante";
            // 
            // cmxTorneo
            // 
            this.cmxTorneo.BackColor = System.Drawing.Color.Azure;
            this.cmxTorneo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmxTorneo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.cmxTorneo.FormattingEnabled = true;
            this.cmxTorneo.Location = new System.Drawing.Point(369, 154);
            this.cmxTorneo.Margin = new System.Windows.Forms.Padding(4);
            this.cmxTorneo.Name = "cmxTorneo";
            this.cmxTorneo.Size = new System.Drawing.Size(317, 33);
            this.cmxTorneo.TabIndex = 34;
            this.cmxTorneo.SelectedIndexChanged += new System.EventHandler(this.cmxTorneo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(483, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 28);
            this.label4.TabIndex = 33;
            this.label4.Text = "Torneo";
            // 
            // ListReporteVisita
            // 
            this.ListReporteVisita.AllowUserToAddRows = false;
            this.ListReporteVisita.AllowUserToDeleteRows = false;
            this.ListReporteVisita.BackgroundColor = System.Drawing.Color.Azure;
            this.ListReporteVisita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListReporteVisita.GridColor = System.Drawing.Color.Azure;
            this.ListReporteVisita.Location = new System.Drawing.Point(85, 305);
            this.ListReporteVisita.Margin = new System.Windows.Forms.Padding(4);
            this.ListReporteVisita.Name = "ListReporteVisita";
            this.ListReporteVisita.ReadOnly = true;
            this.ListReporteVisita.RowHeadersVisible = false;
            this.ListReporteVisita.RowHeadersWidth = 51;
            this.ListReporteVisita.Size = new System.Drawing.Size(875, 258);
            this.ListReporteVisita.TabIndex = 29;
            this.ListReporteVisita.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListReporteVisita_CellContentClick);
            // 
            // Reporte_Tabla_Visitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1132, 694);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmxTorneo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListReporteVisita);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reporte_Tabla_Visitante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte_Tabla_Visitante";
            this.Load += new System.EventHandler(this.Reporte_Tabla_Visitante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListReporteVisita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmxTorneo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ListReporteVisita;
    }
}