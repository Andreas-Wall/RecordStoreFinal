namespace Final
{
    partial class Schedules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedules));
            this.crvSchedules = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvSchedules
            // 
            this.crvSchedules.ActiveViewIndex = -1;
            this.crvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSchedules.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvSchedules.Location = new System.Drawing.Point(0, 0);
            this.crvSchedules.Name = "crvSchedules";
            this.crvSchedules.ShowCloseButton = false;
            this.crvSchedules.ShowExportButton = false;
            this.crvSchedules.ShowGotoPageButton = false;
            this.crvSchedules.ShowGroupTreeButton = false;
            this.crvSchedules.ShowLogo = false;
            this.crvSchedules.ShowParameterPanelButton = false;
            this.crvSchedules.Size = new System.Drawing.Size(800, 450);
            this.crvSchedules.TabIndex = 0;
            this.crvSchedules.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Schedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvSchedules);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Schedules";
            this.Text = "Schedules";
            this.Load += new System.EventHandler(this.Schedules_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSchedules;
    }
}