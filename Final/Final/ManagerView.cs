using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalEmployees;

namespace Final{
    public partial class ManagerView : Form{
        EmployeesDLL employees = new EmployeesDLL();
        DataTable table = new DataTable();
        public ManagerView(){InitializeComponent();}
        //paint event to redraw the box
        private void gbxSpecial_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics,  Color.Black);}
        private void gbxReports_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics, Color.Black);}
        private void gbxSchedules_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics, Color.Black);}
        private void gbxInventory_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics, Color.Black);}
        //Redraws the group box that way it is actually visiable to the user
        private void DrawGroupBox(GroupBox gb, Graphics g, Color borderColor){
            if (gb != null){
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF size = g.MeasureString(gb.Text, gb.Font);
                Rectangle rect = new Rectangle(gb.ClientRectangle.X, gb.ClientRectangle.Y + (int)(size.Height / 2), gb.ClientRectangle.Width - 1, gb.ClientRectangle.Height - (int)(size.Height / 2) - 1);
                g.Clear(this.BackColor);
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + gb.Padding.Left, rect.Y));
                g.DrawLine(borderPen, new Point(rect.X + gb.Padding.Left + (int)(size.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));}
        }
        //method used of on load event or when changes have been made to the page
        public void load(){
            employees.getSpecial();
            employees.fillTable(table);
            txtSpecial.DataBindings.Add("Text", table, "Deal");
        }
        //loads the page
        private void ManagerView_Load(object sender, EventArgs e){
            load();}
        //logs the manager out of the system and redirects them to the store page;
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes){
                StoreFront store = new StoreFront();
                this.Hide();
                store.ShowDialog();
                this.Close();}
        }
        //allows the manager to edit the special of the week
        private void btnEdit_Click(object sender, EventArgs e){
            txtSpecial.Enabled = true;
            btnEdit.Enabled = false;
            btnEdit.Visible = false;
            btnUpdate.Enabled = true;
            btnUpdate.Visible = true;
            btnCancel.Enabled = true;
            btnCancel.Visible = true;}
        //cancels the edit
        private void btnCancel_Click(object sender, EventArgs e){
            txtSpecial.Enabled = false;
            btnEdit.Enabled = true;
            btnEdit.Visible = true;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;}
        //allows the manager to update the special of the week
        private void btnUpdate_Click(object sender, EventArgs e){
            if (txtSpecial.Text != ""){
                employees.updateSpecial(txtSpecial.Text);
                txtSpecial.Enabled = false;
                btnEdit.Enabled = true;
                btnEdit.Visible = true;
                btnUpdate.Enabled = false;
                btnUpdate.Visible = false;
                btnCancel.Enabled = false;
                btnCancel.Visible = false;
                txtSpecial.Focus();
                txtSpecial.DataBindings.Clear();
                table.Clear();
                load();}
            else{
                MessageBox.Show("Please enter a Special");
                txtSpecial.Focus();
                txtSpecial.DataBindings.Clear();
                table.Clear();
                load();}
        }
        //brings up inventory report
        private void btnInventory_Click(object sender, EventArgs e){
            Inventory inventory = new Inventory();
            inventory.ShowDialog();}
        //brings up page to manage inventory
        private void btnManageInventory_Click(object sender, EventArgs e){
            manageItems items = new manageItems();
            items.ShowDialog();}
        //brings up sales report
        private void btnSales_Click(object sender, EventArgs e){
            Sales sales = new Sales();
            sales.ShowDialog();}
        //Shows About Dialog Box
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();}
        //closes the application
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the Application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { Application.Exit(); }}
        //shows a printable report of the current schedule
        private void btnSchedules_Click(object sender, EventArgs e){
            Schedules schedules = new Schedules();
            schedules.ShowDialog();}

        private void btnManageRequest_Click(object sender, EventArgs e){
            ManageRequest manageRequest = new ManageRequest();
            manageRequest.ShowDialog();}

        private void btnManageChanges_Click(object sender, EventArgs e){
            ManageChanges manageChanges = new ManageChanges();
            manageChanges.ShowDialog();}

        private void btnManageSchedules_Click(object sender, EventArgs e){
            ManageSchedules manageSchedules = new ManageSchedules();
            manageSchedules.ShowDialog();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ManagerViewHelp.html");
        }
    }
}
