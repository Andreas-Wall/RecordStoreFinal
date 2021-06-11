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
    public partial class ManagerLogin : Form{
        EmployeesDLL employees = new EmployeesDLL();
        string ID, Pass;
        public bool logged = false;
        public ManagerLogin(){InitializeComponent();}
        //closes login
        private void btnBack_Click(object sender, EventArgs e){ this.Close(); }
        //checks to see if the login is correct then passes it back to the main form to open the manager page
        private void btnLogin_Click(object sender, EventArgs e){
            ID = txtID.Text;
            Pass = txtPass.Text;
            if (employees.managerLogin(ID, Pass) == true){
                logged = true;
                this.Close();}
        }
    }
}
