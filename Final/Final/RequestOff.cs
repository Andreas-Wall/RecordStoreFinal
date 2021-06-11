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
    public partial class RequestOff : Form{
        EmployeesDLL employees = new EmployeesDLL();
        DataTable table = new DataTable();
        public string ID;
        public RequestOff(){InitializeComponent();}
        //closes the page.
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //submits a request for a day off or to leave early
        private void btnSubmit_Click(object sender, EventArgs e){
            employees.RequestOff(ID, DateTime.Parse(dtpDate.Text).ToString("MM-dd-yyyy"), cbxRequest.Text.ToString(), txtReason.Text);
            DialogResult dialogResult = MessageBox.Show("Would you like to submit another request?", "Request", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes){
                cbxRequest.SelectedIndex = 0;
                txtReason.Text = "";}
            else{this.Close();}
        }
        //on load event of the page
        //fills the datagrid view if there any request by that user.
        private void RequestOff_Load(object sender, EventArgs e){
            employees.showEmployeeRequest(ID);
            employees.fillTable(table);
            dgvRequests.DataSource = table;}
        //reloads the request table to see if there any chnages tot eh request
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e){
            table.Clear();
            dgvRequests.DataSource = null;
            dgvRequests.Rows.Clear();
            employees.showEmployeeRequest(ID);
            employees.fillTable(table);
            dgvRequests.DataSource = table;
            dgvRequests.Refresh();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("RequestOffHelp.html");
        }
    }
}
