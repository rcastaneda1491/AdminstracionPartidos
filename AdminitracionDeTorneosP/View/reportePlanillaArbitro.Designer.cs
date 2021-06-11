
namespace AdminitracionDeTorneosP.View
{
    partial class reportePlanillaArbitro
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
            this.textFechaInicio = new System.Windows.Forms.TextBox();
            this.textFechaFinal = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Azure;
            this.dataGridView1.Location = new System.Drawing.Point(119, 337);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(802, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // textFechaInicio
            // 
            this.textFechaInicio.BackColor = System.Drawing.Color.Azure;
            this.textFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textFechaInicio.Location = new System.Drawing.Point(293, 176);
            this.textFechaInicio.Name = "textFechaInicio";
            this.textFechaInicio.Size = new System.Drawing.Size(183, 35);
            this.textFechaInicio.TabIndex = 1;
            // 
            // textFechaFinal
            // 
            this.textFechaFinal.BackColor = System.Drawing.Color.Azure;
            this.textFechaFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.textFechaFinal.Location = new System.Drawing.Point(586, 176);
            this.textFechaFinal.Name = "textFechaFinal";
            this.textFechaFinal.Size = new System.Drawing.Size(183, 35);
            this.textFechaFinal.TabIndex = 2;
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(102)))));
            this.buscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buscar.Location = new System.Drawing.Point(446, 259);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(161, 50);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "buscar";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(283, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(493, 59);
            this.label3.TabIndex = 30;
            this.label3.Text = "Reporte pagos a arbitros";
            // 
            // reportePlanillaArbitro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1061, 650);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.textFechaFinal);
            this.Controls.Add(this.textFechaInicio);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "reportePlanillaArbitro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reportePlanillaArbitro";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textFechaInicio;
        private System.Windows.Forms.TextBox textFechaFinal;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}