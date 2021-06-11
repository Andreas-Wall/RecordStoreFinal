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
    public partial class RemoveFromCart : Form{
        public bool removeCancel;
        public int checkAmount;

        public RemoveFromCart(){InitializeComponent();}

        private void btnCancel_Click(object sender, EventArgs e){
            removeCancel = true;
            this.Close();}

        private void btnRemove_Click(object sender, EventArgs e){
            try{
                if (checkAmount == 0 || int.Parse(txtRemoveAmount.Text) > checkAmount){
                    MessageBox.Show("Please enter a valid amount");
                    txtRemoveAmount.Focus();}
                else{this.Close();}
            }catch{
                MessageBox.Show("Please enter a valid amount");
                txtRemoveAmount.Focus();}
        }
    }
}
