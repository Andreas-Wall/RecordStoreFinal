using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            OrdersReport ordersReport = new OrdersReport();
            ordersReport.SetDatabaseLogon("mawall", "1175037");
            ordersReport.Refresh();
            crvOrders.ReportSource = ordersReport;
        }
    }
}
