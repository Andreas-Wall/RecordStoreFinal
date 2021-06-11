namespace Final
{
    partial class ManagerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.txtSpecial = new System.Windows.Forms.TextBox();
            this.gbxSpecial = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gbxReports = new System.Windows.Forms.GroupBox();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.gbxSchedules = new System.Windows.Forms.GroupBox();
            this.btnManageSchedules = new System.Windows.Forms.Button();
            this.btnManageRequest = new System.Windows.Forms.Button();
            this.btnManageChanges = new System.Windows.Forms.Button();
            this.lblSchedules = new System.Windows.Forms.Label();
            this.gbxInventory = new System.Windows.Forms.GroupBox();
            this.btnManageInventory = new System.Windows.Forms.Button();
            this.lblInventory = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbxSpecial.SuspendLayout();
            this.gbxReports.SuspendLayout();
            this.gbxSchedules.SuspendLayout();
            this.gbxInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.logOutToolStripMenuItem.Text = "&LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem1.Text = "&Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.BackColor = System.Drawing.Color.Thistle;
            this.lblSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpecial.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecial.Location = new System.Drawing.Point(43, 31);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(307, 32);
            this.lblSpecial.TabIndex = 35;
            this.lblSpecial.Text = "Special of the Week!";
            // 
            // txtSpecial
            // 
            this.txtSpecial.Enabled = false;
            this.txtSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecial.Location = new System.Drawing.Point(43, 86);
            this.txtSpecial.Multiline = true;
            this.txtSpecial.Name = "txtSpecial";
            this.txtSpecial.Size = new System.Drawing.Size(307, 129);
            this.txtSpecial.TabIndex = 36;
            // 
            // gbxSpecial
            // 
            this.gbxSpecial.Controls.Add(this.btnUpdate);
            this.gbxSpecial.Controls.Add(this.btnCancel);
            this.gbxSpecial.Controls.Add(this.btnEdit);
            this.gbxSpecial.Controls.Add(this.lblSpecial);
            this.gbxSpecial.Controls.Add(this.txtSpecial);
            this.gbxSpecial.Location = new System.Drawing.Point(476, 41);
            this.gbxSpecial.Name = "gbxSpecial";
            this.gbxSpecial.Size = new System.Drawing.Size(392, 323);
            this.gbxSpecial.TabIndex = 39;
            this.gbxSpecial.TabStop = false;
            this.gbxSpecial.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxSpecial_Paint);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Thistle;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(6, 230);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 52);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Thistle;
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(271, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 52);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Thistle;
            this.btnEdit.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(138, 230);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(115, 52);
            this.btnEdit.TabIndex = 37;
            this.btnEdit.Text = "Change &Special";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gbxReports
            // 
            this.gbxReports.Controls.Add(this.btnInventory);
            this.gbxReports.Controls.Add(this.btnSchedules);
            this.gbxReports.Controls.Add(this.btnSales);
            this.gbxReports.Controls.Add(this.lblReports);
            this.gbxReports.Location = new System.Drawing.Point(476, 379);
            this.gbxReports.Name = "gbxReports";
            this.gbxReports.Size = new System.Drawing.Size(392, 181);
            this.gbxReports.TabIndex = 40;
            this.gbxReports.TabStop = false;
            this.gbxReports.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxReports_Paint);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.Thistle;
            this.btnInventory.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(271, 106);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(115, 52);
            this.btnInventory.TabIndex = 42;
            this.btnInventory.Text = "Current &Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.BackColor = System.Drawing.Color.Thistle;
            this.btnSchedules.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedules.Location = new System.Drawing.Point(138, 106);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(115, 52);
            this.btnSchedules.TabIndex = 41;
            this.btnSchedules.Text = "Employee\'s &Schedules";
            this.btnSchedules.UseVisualStyleBackColor = false;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.Thistle;
            this.btnSales.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(6, 106);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(115, 52);
            this.btnSales.TabIndex = 40;
            this.btnSales.Text = "&Total Sales";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.BackColor = System.Drawing.Color.Thistle;
            this.lblReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReports.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.Location = new System.Drawing.Point(52, 27);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(279, 32);
            this.lblReports.TabIndex = 40;
            this.lblReports.Text = "Printable Reports";
            // 
            // gbxSchedules
            // 
            this.gbxSchedules.Controls.Add(this.btnManageSchedules);
            this.gbxSchedules.Controls.Add(this.btnManageRequest);
            this.gbxSchedules.Controls.Add(this.btnManageChanges);
            this.gbxSchedules.Controls.Add(this.lblSchedules);
            this.gbxSchedules.Location = new System.Drawing.Point(12, 41);
            this.gbxSchedules.Name = "gbxSchedules";
            this.gbxSchedules.Size = new System.Drawing.Size(364, 257);
            this.gbxSchedules.TabIndex = 41;
            this.gbxSchedules.TabStop = false;
            this.gbxSchedules.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxSchedules_Paint);
            // 
            // btnManageSchedules
            // 
            this.btnManageSchedules.BackColor = System.Drawing.Color.Thistle;
            this.btnManageSchedules.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageSchedules.Location = new System.Drawing.Point(123, 180);
            this.btnManageSchedules.Name = "btnManageSchedules";
            this.btnManageSchedules.Size = new System.Drawing.Size(115, 52);
            this.btnManageSchedules.TabIndex = 46;
            this.btnManageSchedules.Text = "Manage Sc&hedules";
            this.btnManageSchedules.UseVisualStyleBackColor = false;
            this.btnManageSchedules.Click += new System.EventHandler(this.btnManageSchedules_Click);
            // 
            // btnManageRequest
            // 
            this.btnManageRequest.BackColor = System.Drawing.Color.Thistle;
            this.btnManageRequest.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRequest.Location = new System.Drawing.Point(207, 104);
            this.btnManageRequest.Name = "btnManageRequest";
            this.btnManageRequest.Size = new System.Drawing.Size(115, 52);
            this.btnManageRequest.TabIndex = 45;
            this.btnManageRequest.Text = "Manage &Request";
            this.btnManageRequest.UseVisualStyleBackColor = false;
            this.btnManageRequest.Click += new System.EventHandler(this.btnManageRequest_Click);
            // 
            // btnManageChanges
            // 
            this.btnManageChanges.BackColor = System.Drawing.Color.Thistle;
            this.btnManageChanges.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageChanges.Location = new System.Drawing.Point(45, 104);
            this.btnManageChanges.Name = "btnManageChanges";
            this.btnManageChanges.Size = new System.Drawing.Size(115, 52);
            this.btnManageChanges.TabIndex = 44;
            this.btnManageChanges.Text = "&Manage Changes";
            this.btnManageChanges.UseVisualStyleBackColor = false;
            this.btnManageChanges.Click += new System.EventHandler(this.btnManageChanges_Click);
            // 
            // lblSchedules
            // 
            this.lblSchedules.AutoSize = true;
            this.lblSchedules.BackColor = System.Drawing.Color.Thistle;
            this.lblSchedules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSchedules.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedules.Location = new System.Drawing.Point(45, 31);
            this.lblSchedules.Name = "lblSchedules";
            this.lblSchedules.Size = new System.Drawing.Size(277, 32);
            this.lblSchedules.TabIndex = 43;
            this.lblSchedules.Text = "Manage Scheduels";
            // 
            // gbxInventory
            // 
            this.gbxInventory.Controls.Add(this.btnManageInventory);
            this.gbxInventory.Controls.Add(this.lblInventory);
            this.gbxInventory.Location = new System.Drawing.Point(12, 349);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(364, 188);
            this.gbxInventory.TabIndex = 44;
            this.gbxInventory.TabStop = false;
            this.gbxInventory.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxInventory_Paint);
            // 
            // btnManageInventory
            // 
            this.btnManageInventory.BackColor = System.Drawing.Color.Thistle;
            this.btnManageInventory.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageInventory.Location = new System.Drawing.Point(123, 111);
            this.btnManageInventory.Name = "btnManageInventory";
            this.btnManageInventory.Size = new System.Drawing.Size(115, 52);
            this.btnManageInventory.TabIndex = 40;
            this.btnManageInventory.Text = "In&ventory";
            this.btnManageInventory.UseVisualStyleBackColor = false;
            this.btnManageInventory.Click += new System.EventHandler(this.btnManageInventory_Click);
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.BackColor = System.Drawing.Color.Thistle;
            this.lblInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInventory.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(45, 30);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(274, 32);
            this.lblInventory.TabIndex = 43;
            this.lblInventory.Text = "Manage Inventory";
            // 
            // ManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(880, 572);
            this.Controls.Add(this.gbxInventory);
            this.Controls.Add(this.gbxSchedules);
            this.Controls.Add(this.gbxReports);
            this.Controls.Add(this.gbxSpecial);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManagerView";
            this.Text = "ManagerView";
            this.Load += new System.EventHandler(this.ManagerView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbxSpecial.ResumeLayout(false);
            this.gbxSpecial.PerformLayout();
            this.gbxReports.ResumeLayout(false);
            this.gbxReports.PerformLayout();
            this.gbxSchedules.ResumeLayout(false);
            this.gbxSchedules.PerformLayout();
            this.gbxInventory.ResumeLayout(false);
            this.gbxInventory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.TextBox txtSpecial;
        private System.Windows.Forms.GroupBox gbxSpecial;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox gbxReports;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.GroupBox gbxSchedules;
        private System.Windows.Forms.Label lblSchedules;
        private System.Windows.Forms.GroupBox gbxInventory;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Button btnManageInventory;
        private System.Windows.Forms.Button btnManageChanges;
        private System.Windows.Forms.Button btnManageRequest;
        private System.Windows.Forms.Button btnManageSchedules;
    }
}