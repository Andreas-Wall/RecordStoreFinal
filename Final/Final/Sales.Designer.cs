namespace Final
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.crvOrders = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvOrders
            // 
            this.crvOrders.ActiveViewIndex = -1;
            this.crvOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvOrders.Location = new System.Drawing.Point(0, 0);
            this.crvOrders.Name = "crvOrders";
            this.crvOrders.ShowCloseButton = false;
            this.crvOrders.ShowExportButton = false;
            this.crvOrders.ShowGotoPageButton = false;
            this.crvOrders.ShowGroupTreeButton = false;
            this.crvOrders.ShowLogo = false;
            this.crvOrders.ShowParameterPanelButton = false;
            this.crvOrders.Size = new System.Drawing.Size(800, 450);
            this.crvOrders.TabIndex = 0;
            this.crvOrders.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.Sales_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvOrders;
    }
}