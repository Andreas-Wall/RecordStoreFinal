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
    public partial class AddStock : Form{
        public int newStock;
        public int oldStock;
        public int newAltStock;
        public int oldAltStock;
        public bool stockCancel = false;
        public bool invoice = false;
        public AddStock(){InitializeComponent();}
        //cancles the edit of the stock
        private void btnCancel_Click(object sender, EventArgs e){
            stockCancel = true;
            this.Close();}

        private void btnEdit_Click(object sender, EventArgs e){
            try{
                newStock = int.Parse(txtStock.Text);
                newAltStock = int.Parse(txtAltStock.Text);
                if (newStock == 0 && newAltStock == 0){
                    MessageBox.Show("Please enter a valid amount");
                    txtStock.Focus();}
                else{
                    if (newStock < 0 || newAltStock < 0){
                        oldStock = oldStock + newStock;
                        oldAltStock = oldAltStock + newAltStock;
                        if (oldStock < 0 || oldAltStock < 0){
                            MessageBox.Show("Please enter a valid amount");
                            txtStock.Focus();}
                        else{
                            invoice = false;
                            this.Close(); }
                    } else {
                        invoice = true;
                        oldStock = oldStock + newStock;
                        oldAltStock = oldAltStock + newAltStock;
                        this.Close(); }
                }
            }
            catch{
                MessageBox.Show("Please enter a valid amount");
                txtStock.Focus();}
        }
    }
}
