namespace Final
{
    partial class Invoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoices));
            this.crvInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvInvoice
            // 
            this.crvInvoice.ActiveViewIndex = -1;
            this.crvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvInvoice.Location = new System.Drawing.Point(0, 0);
            this.crvInvoice.Name = "crvInvoice";
            this.crvInvoice.ShowCloseButton = false;
            this.crvInvoice.ShowExportButton = false;
            this.crvInvoice.ShowGotoPageButton = false;
            this.crvInvoice.ShowGroupTreeButton = false;
            this.crvInvoice.ShowLogo = false;
            this.crvInvoice.ShowParameterPanelButton = false;
            this.crvInvoice.Size = new System.Drawing.Size(800, 450);
            this.crvInvoice.TabIndex = 0;
            this.crvInvoice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Invoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvInvoice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Invoices";
            this.Text = "Invoices";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Invoices_FormClosing);
            this.Load += new System.EventHandler(this.Invoices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInvoice;
    }
}