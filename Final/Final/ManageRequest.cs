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
    public partial class ManageRequest : Form{
        EmployeesDLL employeesDLL = new EmployeesDLL();
        DataTable scheduleTable = new DataTable();
        DataTable requestTable = new DataTable();
        int count;
        bool request = false;
        string RequestID, position, date, employeeID;
        //method used to reload the page
        public void reload(){
            request = false;
            scheduleTable.Clear();
            requestTable.Clear();
            dgvRequests.DataSource = null;
            dgvSchedule.DataSource = null;
            dgvRequests.Rows.Clear();
            dgvSchedule.Rows.Clear();
            employeesDLL.showRequest();
            employeesDLL.fillTable(requestTable);
            dgvRequests.DataSource = requestTable;
            employeesDLL.getSchedule(scheduleTable);
            dgvSchedule.DataSource = scheduleTable;
            count = employeesDLL.countRequest();
            if (count != 0) { request = true; }
            dgvRequests.Refresh();
            dgvSchedule.Refresh();}
        //enables the buttons
        public void enable(){
            btnAccept.Enabled = true;
            btnDelete.Enabled = true;
            btnReject.Enabled = true;}
        public ManageRequest(){InitializeComponent();}
        //closes the form
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //deletes the request from the database
        private void btnDelete_Click(object sender, EventArgs e) {
            RequestID = dgvRequests.Rows[dgvRequests.CurrentCell.RowIndex].Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this from the database?", "Remove Request", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { employeesDLL.deleteRequest(RequestID); }
            reload();}
        //reloads the page
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e){reload();}
        //sets the buts to active once a request has been selected
        private void dgvRequests_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e){
            if (request == true) { enable(); }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ManageRequestHelp.html");
        }

        //rejects the request made by the employee
        private void btnReject_Click(object sender, EventArgs e){
            RequestID = dgvRequests.Rows[dgvRequests.CurrentCell.RowIndex].Cells[0].Value.ToString();
            employeesDLL.rejectRequest(RequestID);
            reload();}
        //accepts the request made by the employee and removes it from the database, the request will be added tot he schedule
        private void btnAccept_Click(object sender, EventArgs e)
        {
            RequestID = dgvRequests.Rows[dgvRequests.CurrentCell.RowIndex].Cells[0].Value.ToString();
            employeeID = dgvRequests.Rows[dgvRequests.CurrentCell.RowIndex].Cells[1].Value.ToString();
            date = dgvRequests.Rows[dgvRequests.CurrentCell.RowIndex].Cells[3].Value.ToString();
            position = dgvRequests.Rows[dgvRequests.CurrentCell.RowIndex].Cells[4].Value.ToString();
            try{
                employeesDLL.insertSchedule(employeeID, position, date);
                employeesDLL.deleteRequest(RequestID);}
            catch{}
            reload();}
        //on load event for the page. Fills the data grid views with the schedule and any schedule requests. If there are no requests submitted then the form will be inactive
        private void ManageRequest_Load(object sender, EventArgs e)
        {
            employeesDLL.showRequest();
            employeesDLL.fillTable(requestTable);
            dgvRequests.DataSource = requestTable;
            employeesDLL.getSchedule(scheduleTable);
            dgvSchedule.DataSource = scheduleTable;
            count = employeesDLL.countRequest();
            if (count != 0) { request = true; }
        }
    }
}
