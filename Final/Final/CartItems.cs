using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalCustomerDLL;

namespace Final{
    public partial class CartItems : UserControl{
        public int index = 0;
        public string ID;
        public bool alt = false;
        public bool cancel;
        public int amount;
        public int checkAmount;
        public int checkAltAmount;
        CustomerDLL customer = new CustomerDLL();
        public delegate void RemoveSiteEventHandler(Object sender, ContentArgs e);
        public event RemoveSiteEventHandler onRemoveSite;
        public CartItems(){InitializeComponent();}
        public class ContentArgs : EventArgs{
            public int index;
            public ContentArgs(int value) { index = value; }
        }
        private void btnRemove_Click(object sender, EventArgs e){
            checkAmount = int.Parse(lblAmountInfo.Text);
            RemoveFromCart remove = new RemoveFromCart();
            remove.checkAmount = checkAmount;
            remove.ShowDialog();
            cancel = remove.removeCancel;
            if(cancel == false){
                amount = int.Parse(remove.txtRemoveAmount.Text);
                customer.removeFromCart(ID, alt, amount);
                lblAmountInfo.Text = (int.Parse(lblAmountInfo.Text) - amount).ToString();
                if (lblAmountInfo.Text == 0.ToString() && lblAltAmountInfo.Text == 0.ToString()){
                    customer.deleteFromCart(ID);
                    onRemoveSite(this, new ContentArgs(index));}
            } else {cancel = false;}
        }
        private void btnAltRemove_Click(object sender, EventArgs e){
            alt = true;
            checkAltAmount = int.Parse(lblAltAmountInfo.Text);
            RemoveFromCart remove = new RemoveFromCart();
            remove.checkAmount = checkAltAmount;
            remove.ShowDialog();
            cancel = remove.removeCancel;
            if (cancel == false){
                amount = int.Parse(remove.txtRemoveAmount.Text);
                customer.removeFromCart(ID, alt, amount);
                lblAltAmountInfo.Text = (int.Parse(lblAltAmountInfo.Text) - amount).ToString();
                if (lblAmountInfo.Text == 0.ToString() && lblAltAmountInfo.Text == 0.ToString()){
                    onRemoveSite(this, new ContentArgs(index));
                    customer.deleteFromCart(ID); }
            } else {
                cancel = false;
                alt = false;}
        }
    }
}
