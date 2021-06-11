namespace Final
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.crvInventory = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvInventory
            // 
            this.crvInventory.ActiveViewIndex = -1;
            this.crvInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInventory.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvInventory.Location = new System.Drawing.Point(0, 0);
            this.crvInventory.Name = "crvInventory";
            this.crvInventory.ShowCloseButton = false;
            this.crvInventory.ShowGotoPageButton = false;
            this.crvInventory.ShowGroupTreeButton = false;
            this.crvInventory.ShowLogo = false;
            this.crvInventory.ShowParameterPanelButton = false;
            this.crvInventory.ShowRefreshButton = false;
            this.crvInventory.ShowTextSearchButton = false;
            this.crvInventory.Size = new System.Drawing.Size(800, 450);
            this.crvInventory.TabIndex = 0;
            this.crvInventory.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvInventory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInventory;
    }
}