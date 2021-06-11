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
    public partial class EmployeeLogin : Form{
        EmployeesDLL employees = new EmployeesDLL();
        string ID, Pass;
        public bool logged = false;
        //closes login
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        //checks to see if the login is correct then passes it back to the main form to open the employee page
        private void btnLogin_Click(object sender, EventArgs e){
            ID = txtID.Text;
            Pass = txtPass.Text;
            if (employees.employeeLogin(ID, Pass) == true){
                logged = true;
                this.Close();}
        }
        //opens password recovery
        private void btnForgot_Click(object sender, EventArgs e){
            PasswordRecovery passwordRecovery = new PasswordRecovery();
            passwordRecovery.ShowDialog();}
        

        public EmployeeLogin(){InitializeComponent();}

    }
}
