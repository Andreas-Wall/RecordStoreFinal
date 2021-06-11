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
    public partial class ManageChanges : Form{
        EmployeesDLL employeesDLL = new EmployeesDLL();
        DataTable scheduleTable = new DataTable();
        DataTable changesTable = new DataTable();
        DataTable employeeTable = new DataTable();
        int count;
        bool change = false;
        string ChangeID, requestersID, requestedID, employeeID1, employeeID2;
        public ManageChanges(){InitializeComponent();}
        //method used to reload the page
        public void reload(){
            change = false;
            scheduleTable.Clear();
            changesTable.Clear();
            employeeTable.Clear();
            dgvChanges.DataSource = null;
            dgvSchedule.DataSource = null;
            dgvChanges.Rows.Clear();
            dgvSchedule.Rows.Clear();
            employeesDLL.showChanges();
            employeesDLL.fillTable(changesTable);
            dgvChanges.DataSource = changesTable;
            employeesDLL.getSchedule(scheduleTable);
            dgvSchedule.DataSource = scheduleTable;
            count = employeesDLL.countChanges();
            if (count != 0) { change = true; }
            dgvChanges.Refresh();
            dgvSchedule.Refresh();}

        //on load event for the page. Fills the data grid views with the schedule and any schedule change requests. If there are no changes submitted then the form will be inactive
        private void ManageChanges_Load(object sender, EventArgs e){
            employeesDLL.showChanges();
            employeesDLL.fillTable(changesTable);
            dgvChanges.DataSource = changesTable;
            employeesDLL.getSchedule(scheduleTable);
            dgvSchedule.DataSource = scheduleTable;
            count = employeesDLL.countChanges();
            if (count != 0){ change = true; }
        }
        //enables the buttons
        public void enable(){
            btnAccept.Enabled = true;
            btnDelete.Enabled = true;
            btnReject.Enabled = true;}

        private void btnDelete_Click(object sender, EventArgs e){
            ChangeID = dgvChanges.Rows[dgvChanges.CurrentCell.RowIndex].Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this from the database?", "Remove Request", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { employeesDLL.deleteChnage(ChangeID); }
            reload();}

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e){ reload(); }

        private void btnReject_Click(object sender, EventArgs e){
            ChangeID = dgvChanges.Rows[dgvChanges.CurrentCell.RowIndex].Cells[0].Value.ToString();
            employeesDLL.rejectChange(ChangeID);
            reload();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ManageChangeHelp.html");
        }


        //disables the buttons
        public void disable(){
            btnAccept.Enabled = false;
            btnDelete.Enabled = false;
            btnReject.Enabled = false; }
        //close the form
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //accepts the change request. switches the employeeIDs on the schedule and then deletes the request
        private void btnAccept_Click(object sender, EventArgs e){
            ChangeID = dgvChanges.Rows[dgvChanges.CurrentCell.RowIndex].Cells[0].Value.ToString();
            requestersID = dgvChanges.Rows[dgvChanges.CurrentCell.RowIndex].Cells[1].Value.ToString();
            requestedID = dgvChanges.Rows[dgvChanges.CurrentCell.RowIndex].Cells[2].Value.ToString();
            employeeID1 = dgvChanges.Rows[dgvChanges.CurrentCell.RowIndex].Cells[3].Value.ToString();
            employeesDLL.findEmployeeID(requestedID, employeeTable);
            employeeID2 = employeeTable.Rows[0]["EmployeeID"].ToString();

            employeesDLL.updateScheduleChange(employeeID1, requestedID);
            employeesDLL.updateScheduleChange(employeeID2, requestersID);
            employeesDLL.deleteChnage(ChangeID);
            reload();
        }
        //enables the uses of buttons once the datagrid has been clicked
        private void dgvChanges_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e){
            if(change == true){enable();}
        }
        
    }
}
