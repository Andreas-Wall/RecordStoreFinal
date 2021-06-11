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
    public partial class EmployeeView : Form{
        EmployeesDLL employees = new EmployeesDLL();
        DataTable table = new DataTable();
        DataTable scheduleTable = new DataTable();
        string MessageDeal;
        public string id;
        public EmployeeView(){InitializeComponent();}
        //Shows About Dialog Box
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();}
        //Logs the user out
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes){
                StoreFront store = new StoreFront();
                this.Hide();
                store.ShowDialog();
                this.Close();}
        }
        //Closes the Application
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the Application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { Application.Exit(); }}
        //loads the schedule onto the page
        public void loadSchedule(){
            table.Clear();
            employees.getSchedule(scheduleTable);
            dgvSchedules.DataSource = scheduleTable;}
        //on load event for the page
        private void EmployeeView_Load(object sender, EventArgs e){
            employees.getSpecial();
            employees.fillTable(table);
            MessageDeal = table.Rows[0]["Deal"].ToString();
            MessageBox.Show(MessageDeal);
            loadSchedule();}
        //opens the infomation editor
        private void btnInfo_Click(object sender, EventArgs e){
            EmployeeInformation employeeInformation = new EmployeeInformation();
            employeeInformation.ID = id;
            employeeInformation.ShowDialog();}
        //reloads the schedule for the users
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e){
            scheduleTable.Clear();
            dgvSchedules.DataSource = null;
            dgvSchedules.Rows.Clear();
            employees.getSchedule(scheduleTable);
            dgvSchedules.DataSource = scheduleTable;
            dgvSchedules.Refresh();}
        //opens the page to request a day off.
        private void btnOff_Click(object sender, EventArgs e){
            RequestOff requestOff = new RequestOff();
            requestOff.ID = id;
            requestOff.ShowDialog();}

        private void btnChange_Click(object sender, EventArgs e){
            ChangeShedule changeShedule = new ChangeShedule();
            changeShedule.ID = id;
            changeShedule.ShowDialog();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EmployeeViewHelp.html");
        }
    }
}
