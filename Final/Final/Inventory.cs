using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final{
    public partial class Inventory : Form{
        public Inventory(){InitializeComponent();}

        private void Inventory_Load(object sender, EventArgs e){
            InventoryReport inventory = new InventoryReport();
            inventory.SetDatabaseLogon("mawall", "1175037");
            inventory.Refresh();
            crvInventory.ReportSource = inventory;}
    }
}
