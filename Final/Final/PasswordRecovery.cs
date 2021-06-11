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
    public partial class PasswordRecovery : Form{
        EmployeesDLL employees = new EmployeesDLL();
        string ID, Email;
        public PasswordRecovery() { InitializeComponent(); }
        //closes the form
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //will check to make sure that the userID and email is correct then change the password to a new random password and email to it the user.
        private void btnRecover_Click(object sender, EventArgs e){
            ID = txtUsername.Text;
            Email = txtEmail.Text;
            if (employees.forgotPassword(ID,Email) == true){
                MessageBox.Show("The email has been sent with your new password. Please edit your password once you have logged in.");
                this.Close();}
        }
    }
}
