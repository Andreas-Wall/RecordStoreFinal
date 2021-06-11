namespace Final
{
    partial class ChangeShedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeShedule));
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvChanges = new System.Windows.Forms.DataGridView();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblYourScheduleID = new System.Windows.Forms.Label();
            this.lblTheirScheduleID = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtPersonal = new System.Windows.Forms.TextBox();
            this.txtTheirs = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanges)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Thistle;
            this.btnBack.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(663, 468);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 53);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvChanges
            // 
            this.dgvChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChanges.Location = new System.Drawing.Point(91, 73);
            this.dgvChanges.Name = "dgvChanges";
            this.dgvChanges.Size = new System.Drawing.Size(597, 120);
            this.dgvChanges.TabIndex = 34;
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.BackColor = System.Drawing.Color.Thistle;
            this.lblSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSchedule.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedule.Location = new System.Drawing.Point(286, 35);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(207, 26);
            this.lblSchedule.TabIndex = 36;
            this.lblSchedule.Text = "Current Requests";
            // 
            // lblYourScheduleID
            // 
            this.lblYourScheduleID.AutoSize = true;
            this.lblYourScheduleID.BackColor = System.Drawing.Color.Thistle;
            this.lblYourScheduleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYourScheduleID.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourScheduleID.Location = new System.Drawing.Point(91, 229);
            this.lblYourScheduleID.Name = "lblYourScheduleID";
            this.lblYourScheduleID.Size = new System.Drawing.Size(154, 20);
            this.lblYourScheduleID.TabIndex = 37;
            this.lblYourScheduleID.Text = "Your Schedule ID:";
            // 
            // lblTheirScheduleID
            // 
            this.lblTheirScheduleID.AutoSize = true;
            this.lblTheirScheduleID.BackColor = System.Drawing.Color.Thistle;
            this.lblTheirScheduleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTheirScheduleID.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheirScheduleID.Location = new System.Drawing.Point(91, 277);
            this.lblTheirScheduleID.Name = "lblTheirScheduleID";
            this.lblTheirScheduleID.Size = new System.Drawing.Size(158, 20);
            this.lblTheirScheduleID.TabIndex = 38;
            this.lblTheirScheduleID.Text = "Their Schedule ID:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.BackColor = System.Drawing.Color.Thistle;
            this.lblReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReason.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(91, 322);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(75, 20);
            this.lblReason.TabIndex = 39;
            this.lblReason.Text = "Reason:";
            // 
            // txtPersonal
            // 
            this.txtPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonal.Location = new System.Drawing.Point(276, 224);
            this.txtPersonal.Name = "txtPersonal";
            this.txtPersonal.Size = new System.Drawing.Size(100, 26);
            this.txtPersonal.TabIndex = 40;
            // 
            // txtTheirs
            // 
            this.txtTheirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheirs.Location = new System.Drawing.Point(276, 272);
            this.txtTheirs.Name = "txtTheirs";
            this.txtTheirs.Size = new System.Drawing.Size(100, 26);
            this.txtTheirs.TabIndex = 41;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(276, 317);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(305, 79);
            this.txtReason.TabIndex = 42;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Thistle;
            this.btnSubmit.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(276, 420);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(125, 53);
            this.btnSubmit.TabIndex = 43;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 44;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // ChangeShedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtTheirs);
            this.Controls.Add(this.txtPersonal);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblTheirScheduleID);
            this.Controls.Add(this.lblYourScheduleID);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.dgvChanges);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeShedule";
            this.Text = "ChangeSchedule";
            this.Load += new System.EventHandler(this.ChangeShedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanges)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvChanges;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblYourScheduleID;
        private System.Windows.Forms.Label lblTheirScheduleID;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtPersonal;
        private System.Windows.Forms.TextBox txtTheirs;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}