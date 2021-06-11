
namespace AdminitracionDeTorneosP.View
{
    partial class Reporte_Utilidades
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListUtilidades = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ListUtilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(220, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(488, 60);
            this.label4.TabIndex = 21;
            this.label4.Text = "Utilidades De Negocio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(537, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(4)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(277, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Fecha Inicio";
            // 
            // ListUtilidades
            // 
            this.ListUtilidades.AllowUserToAddRows = false;
            this.ListUtilidades.AllowUserToDeleteRows = false;
            this.ListUtilidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListUtilidades.BackgroundColor = System.Drawing.Color.Azure;
            this.ListUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListUtilidades.Location = new System.Drawing.Point(112, 340);
            this.ListUtilidades.Margin = new System.Windows.Forms.Padding(4);
            this.ListUtilidades.Name = "ListUtilidades";
            this.ListUtilidades.ReadOnly = true;
            this.ListUtilidades.RowHeadersVisible = false;
            this.ListUtilidades.RowHeadersWidth = 51;
            this.ListUtilidades.Size = new System.Drawing.Size(701, 155);
            this.ListUtilidades.TabIndex = 17;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(348, 566);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(215, 62);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.BackColor = System.Drawing.Color.Azure;
            this.txtFechaFinal.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtFechaFinal.Location = new System.Drawing.Point(477, 257);
            this.txtFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.Size = new System.Drawing.Size(243, 35);
            this.txtFechaFinal.TabIndex = 12;
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.BackColor = System.Drawing.Color.Azure;
            this.txtFechaInicio.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.txtFechaInicio.Location = new System.Drawing.Point(216, 257);
            this.txtFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(243, 35);
            this.txtFechaInicio.TabIndex = 11;
            // 
            // Reporte_Utilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(951, 694);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListUtilidades);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.txtFechaInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reporte_Utilidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte_Utilidades";
            ((System.ComponentModel.ISupportInitialize)(this.ListUtilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ListUtilidades;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.TextBox txtFechaInicio;
    }
}