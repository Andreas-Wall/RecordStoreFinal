using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProductsDLL;

namespace Final{
    public partial class Invoices : Form{
        ProductDLL productDLL = new ProductDLL();
        public Invoices(){InitializeComponent();}

        private void Invoices_Load(object sender, EventArgs e){
            InvoiceReport invoiceReport = new InvoiceReport();
            invoiceReport.SetDatabaseLogon("mawall", "1175037");
            invoiceReport.Refresh();
            crvInvoice.ReportSource = invoiceReport;}

        private void Invoices_FormClosing(object sender, FormClosingEventArgs e){productDLL.deleteInvoice();}
    }
}
