using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalCustomerDLL;

namespace Final{
    public partial class CheckOutReceipt : Form{
        CustomerDLL customer = new CustomerDLL();
        public CheckOutReceipt(){InitializeComponent();}

        private void CheckOutReceipt_Load(object sender, EventArgs e){
            CheckOutReport checkOut = new CheckOutReport();
            checkOut.SetDatabaseLogon("mawall", "1175037");
            checkOut.Refresh();
            crvCheckout.ReportSource = checkOut;}

        private void CheckOutReceipt_FormClosing(object sender, FormClosingEventArgs e){customer.deleteCart();}
    }
}
