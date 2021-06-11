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
    public partial class ManageSchedules : Form{
        EmployeesDLL employeesDLL = new EmployeesDLL();
        DataTable table = new DataTable();
        bool ins = false;
        bool del = false;
        bool upd = false;
        string ChangeID;
        //enables the delete and update buttons
        public void enableEdit() {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;}
        //disables edit buttons and enables text fields
        public void disable(){
            btnBack.Enabled = false;
            btnBack.Visible = false;
            btnInsert.Enabled = false;
            btnInsert.Visible = false;
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;

            btnCancel.Enabled = true;
            btnCancel.Visible = true;
            btnSubmit.Enabled = true;
            btnSubmit.Visible = true;

            txtEmployeeID.Enabled = true;
            txtPosition.Enabled = true;
            dtpDate.Enabled = true;}
        //enables edit buttons and disables text fields
        public void enables(){
            btnBack.Enabled = true;
            btnBack.Visible = true;
            btnInsert.Enabled = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;

            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            btnSubmit.Enabled = false;
            btnSubmit.Visible = false;

            txtEmployeeID.Enabled = false;
            txtPosition.Enabled = false;
            dtpDate.Enabled = false;}
        //reloads the datagridview
        public void reload(){
            txtPosition.Clear();
            txtEmployeeID.Clear();
            table.Clear();
            dgvSchedule.DataSource = null;
            dgvSchedule.Rows.Clear();
            employeesDLL.viewSchedule(table);
            dgvSchedule.DataSource = table;
            dgvSchedule.Refresh();}
        public ManageSchedules(){InitializeComponent();}
        //closes the form
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //on load event for the page
        private void ManageSchedules_Load(object sender, EventArgs e){
            employeesDLL.viewSchedule(table);
            dgvSchedule.DataSource = table;}
        //inserts a new entry to the schedule table
        private void btnInsert_Click(object sender, EventArgs e){
            ins = true;
            disable();}
        //updates a entry in the schedule
        private void btnUpdate_Click(object sender, EventArgs e){
            upd = true;
            disable();}
        //deletes a entry in the schedule
        private void btnDelete_Click(object sender, EventArgs e){
            del = true;
            disable();}
        //depending on what edit button was clicked the submit button will submit the correct DML transaction to the database
        private void btnSubmit_Click(object sender, EventArgs e){
            if (ins == true) {
                employeesDLL.insertSchedule(txtEmployeeID.Text, txtPosition.Text, DateTime.Parse(dtpDate.Text).ToString("MM-dd-yyyy"));
                enables();
                reload();}
            else if (upd == true){
                ChangeID = dgvSchedule.Rows[dgvSchedule.CurrentCell.RowIndex].Cells[0].Value.ToString();
                employeesDLL.updateSchedule(txtEmployeeID.Text, txtPosition.Text, DateTime.Parse(dtpDate.Text).ToString("MM-dd-yyyy"), ChangeID);
                enables();
                reload(); }
            else if (del == true){
                ChangeID = dgvSchedule.Rows[dgvSchedule.CurrentCell.RowIndex].Cells[0].Value.ToString();
                employeesDLL.deleteScheduleEntry(ChangeID);
                enables();
                reload();}
            ins = false;
            upd = false;
            del = false;
            enables();
            reload();}
        //cancels edit
        private void btnCancel_Click(object sender, EventArgs e){
            ins = false;
            upd = false;
            del = false;
            enables();
            reload();}
        //finds what row has been selected on the datgrid view
        private void dgvSchedule_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e){enableEdit(); }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e){reload();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ManageSchedulesHelp.html");
        }
    }
}
