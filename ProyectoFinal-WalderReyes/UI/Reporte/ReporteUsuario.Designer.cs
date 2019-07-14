namespace ProyectoFinal_WalderReyes.UI.Reporte
{
    partial class ReporteUsuario
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
            this.Reporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.UsuarioReporte = new ProyectoFinal_WalderReyes.UsuarioReporte();
            this.SuspendLayout();
            // 
            // Reporte
            // 
            this.Reporte.ActiveViewIndex = 0;
            this.Reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Reporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.Reporte.Location = new System.Drawing.Point(0, 0);
            this.Reporte.Name = "Reporte";
            this.Reporte.ReportSource = this.UsuarioReporte;
            this.Reporte.Size = new System.Drawing.Size(800, 450);
            this.Reporte.TabIndex = 5;
            // 
            // UsuarioReporte
            // 
            this.UsuarioReporte.InitReport += new System.EventHandler(this.UsuarioReporte_InitReport);
            // 
            // ReporteUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reporte);
            this.Name = "ReporteUsuario";
            this.Text = "ReporteUsuario";
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Reporte;
        private ProyectoFinal_WalderReyes.UsuarioReporte UsuarioReporte;
    }
}