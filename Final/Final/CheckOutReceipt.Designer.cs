namespace Final
{
    partial class CheckOutReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOutReceipt));
            this.crvCheckout = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCheckout
            // 
            this.crvCheckout.ActiveViewIndex = -1;
            this.crvCheckout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCheckout.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCheckout.Location = new System.Drawing.Point(0, 0);
            this.crvCheckout.Name = "crvCheckout";
            this.crvCheckout.ShowCloseButton = false;
            this.crvCheckout.ShowExportButton = false;
            this.crvCheckout.ShowGotoPageButton = false;
            this.crvCheckout.ShowGroupTreeButton = false;
            this.crvCheckout.ShowLogo = false;
            this.crvCheckout.ShowParameterPanelButton = false;
            this.crvCheckout.ShowTextSearchButton = false;
            this.crvCheckout.Size = new System.Drawing.Size(800, 450);
            this.crvCheckout.TabIndex = 0;
            this.crvCheckout.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CheckOutReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvCheckout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckOutReceipt";
            this.Text = "CheckOutReceipt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckOutReceipt_FormClosing);
            this.Load += new System.EventHandler(this.CheckOutReceipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCheckout;
    }
}