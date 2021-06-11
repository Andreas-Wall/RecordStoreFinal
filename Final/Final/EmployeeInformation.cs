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
using System.Text.RegularExpressions;

namespace Final{
    public partial class EmployeeInformation : Form{
        EmployeesDLL employeesDLL = new EmployeesDLL();
        DataTable table = new DataTable();
        public string ID;
        //clears the text fields
        public void clear() {
            txtEmail.Clear();
            txtEmployeeID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtSalary.Clear();}
        //clears the text fields databindings
        public void clearData(){
            txtEmail.DataBindings.Clear();
            txtEmployeeID.DataBindings.Clear();
            txtFirstName.DataBindings.Clear();
            txtLastName.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtSalary.DataBindings.Clear();}
        //check to make sure the email entered is valid
        public static bool checkEmail(string email, params string[] entry){
            foreach (string address in entry){
                if (email.Contains(address)) { return true; }}
            return false;}
        //check to make sure the phone number entered is correct
        public static bool checkPhone(string number) {
            return Regex.Match(number, @"^([0-9][0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9])$").Success;}
        //enables the editing of the text fields while also disabling the other buttons
        public void enable(){
            txtEmail.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtPassword.Enabled = true;
            txtPhone.Enabled = true;

            btnBack.Enabled = false;
            btnBack.Visible = false;
            btnEdit.Enabled = false;
            btnEdit.Visible = false;
            btnCancel.Enabled = true;
            btnCancel.Visible = true;
            btnSubmit.Enabled = true;
            btnSubmit.Visible = true;}
        //disables the editing of the text fields while also enabling the other buttons
        public void disable(){
            txtEmail.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtPassword.Enabled = false;
            txtPhone.Enabled = false;

            btnBack.Enabled = true;
            btnBack.Visible = true;
            btnEdit.Enabled = true;
            btnEdit.Visible = true;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            btnSubmit.Enabled = false;
            btnSubmit.Visible = false;}
        public void load(){
            employeesDLL.EmployeeInfo(ID);
            employeesDLL.fillTable(table);
            txtEmployeeID.DataBindings.Add("Text", table, "EmployeeID");
            txtFirstName.DataBindings.Add("Text", table, "FirstName");
            txtLastName.DataBindings.Add("Text", table, "LastName");
            txtPhone.DataBindings.Add("Text", table, "Phone");
            txtEmail.DataBindings.Add("Text", table, "Email");
            txtPassword.DataBindings.Add("Text", table, "Password");
            txtSalary.DataBindings.Add("Text", table, "Salary");
            employeesDLL.stopConnect();}
        public EmployeeInformation(){InitializeComponent();}
        //closes the page
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //starts the editting process of the information
        private void btnEdit_Click(object sender, EventArgs e){ enable(); }
        //starts the process to see if the information submitted is valid before making the edit
        private void btnSubmit_Click(object sender, EventArgs e){
            if (txtEmail.Text != null && txtFirstName.Text != null && txtLastName.Text != null && txtPassword.Text != null && txtPhone.Text != null){
                if (checkPhone(txtPhone.Text) == true){
                    //Email regular expression;
                    Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match m = reg.Match(txtEmail.Text);
                    if (m.Success){
                        if (checkEmail(txtEmail.Text, "@gmail.com", "@yahoo.com", "@outlook.com") == true){
                            //check to make sure the password is in the right format
                            bool num = txtPassword.Text.Any(char.IsDigit);
                            bool upper = txtPassword.Text.Any(char.IsUpper);
                            if (num == true && upper == true){
                                employeesDLL.editInformation(txtEmployeeID.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text);
                                table.Clear();
                                clearData();
                                clear();
                                disable();
                                load();
                            }else {
                                MessageBox.Show("Please enter a valid Password");
                                txtPassword.Focus();}
                        }else { MessageBox.Show("Please enter a valid Email Address");
                            txtEmail.Focus();}
                    }else{ MessageBox.Show("Please enter a valid Email Address");
                        txtEmail.Focus();}
                }else { MessageBox.Show("Please enter a valid Phone Number");
                    txtPhone.Focus();}
            }else { MessageBox.Show("Please make sure no text field is empty"); }
        }
        //on load event for the page
        private void EmployeeInformation_Load(object sender, EventArgs e){load();}
        //cancels the edit of information
        private void btnCancel_Click(object sender, EventArgs e){
            table.Clear();
            clearData();
            clear();
            disable();
            load();}
    }
}
