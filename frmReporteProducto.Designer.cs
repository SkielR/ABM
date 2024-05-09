namespace ABM1w1
{
    partial class frmReporteProducto
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptproducto1 = new ABM1w1.rptproducto();
            this.btnImpimirTodo = new System.Windows.Forms.Button();
            this.btnImpimirAlgo = new System.Windows.Forms.Button();
            this.txtImprimirFiltro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(776, 345);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnImpimirTodo
            // 
            this.btnImpimirTodo.Location = new System.Drawing.Point(12, 395);
            this.btnImpimirTodo.Name = "btnImpimirTodo";
            this.btnImpimirTodo.Size = new System.Drawing.Size(75, 23);
            this.btnImpimirTodo.TabIndex = 1;
            this.btnImpimirTodo.Text = "ImprimirTodo";
            this.btnImpimirTodo.UseVisualStyleBackColor = true;
            this.btnImpimirTodo.Click += new System.EventHandler(this.btnImpimirTodo_Click);
            // 
            // btnImpimirAlgo
            // 
            this.btnImpimirAlgo.Location = new System.Drawing.Point(689, 392);
            this.btnImpimirAlgo.Name = "btnImpimirAlgo";
            this.btnImpimirAlgo.Size = new System.Drawing.Size(99, 23);
            this.btnImpimirAlgo.TabIndex = 2;
            this.btnImpimirAlgo.Text = "Imprimir Con filtro";
            this.btnImpimirAlgo.UseVisualStyleBackColor = true;
            this.btnImpimirAlgo.Click += new System.EventHandler(this.btnImpimirAlgo_Click);
            // 
            // txtImprimirFiltro
            // 
            this.txtImprimirFiltro.Location = new System.Drawing.Point(554, 395);
            this.txtImprimirFiltro.Name = "txtImprimirFiltro";
            this.txtImprimirFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtImprimirFiltro.TabIndex = 4;
            // 
            // frmReporteProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtImprimirFiltro);
            this.Controls.Add(this.btnImpimirAlgo);
            this.Controls.Add(this.btnImpimirTodo);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmReporteProducto";
            this.Text = "frmReporteProducto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private rptproducto rptproducto1;
        private System.Windows.Forms.Button btnImpimirTodo;
        private System.Windows.Forms.Button btnImpimirAlgo;
        private System.Windows.Forms.TextBox txtImprimirFiltro;
    }
}