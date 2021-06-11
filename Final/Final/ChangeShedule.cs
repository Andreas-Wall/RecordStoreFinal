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
    public partial class ChangeShedule : Form{
        EmployeesDLL employeesDLL = new EmployeesDLL();
        DataTable table = new DataTable();
        public string ID;
        public ChangeShedule(){InitializeComponent();}
        //closes the page
        private void btnBack_Click(object sender, EventArgs e) {this.Close();}
        //on load event for the page. shows all request made by the user
        private void ChangeShedule_Load(object sender, EventArgs e){
            employeesDLL.showEmployeeChange(ID);
            employeesDLL.fillTable(table);
            dgvChanges.DataSource = table;}
        //submits the schedule change request to the manager
        private void btnSubmit_Click(object sender, EventArgs e){
            employeesDLL.RequestChange(txtPersonal.Text, txtTheirs.Text, ID, txtReason.Text);
            DialogResult dialogResult = MessageBox.Show("Would you like to submit another request?", "Request", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes){
                txtPersonal.Text = "";
                txtTheirs.Text = "";
                txtReason.Text = "";
                txtPersonal.Focus();}
            else { this.Close(); }
        }
        //Reloads the datagridview for the user to see if the request has been approved or not
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e){
            table.Clear();
            dgvChanges.DataSource = null;
            dgvChanges.Rows.Clear();
            employeesDLL.showEmployeeChange(ID);
            employeesDLL.fillTable(table);
            dgvChanges.DataSource = table;
            dgvChanges.Refresh();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ChangeScheduleHelp.html");
        }
    }
}
