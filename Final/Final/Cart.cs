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
    public partial class Cart : Form{
        //varibles
        CustomerDLL customer = new CustomerDLL();
        DataTable table = new DataTable();
        const int margin = 3;
        public int Count;
        int currencyCounter = 0;
        public string[] name;
        public string[] ID;
        public int[] quantity;
        public int[] altQuantity;
        public decimal[] price;
        public decimal[] altPrice;
        int calculate;
        int amount;
        int order;

        public decimal total;
        public decimal tax;
        public Cart(){InitializeComponent();}
        //method used to load cart 
        public void loadCart(){
            CartItems[] listings = new CartItems[Count];
            CartItems lastListing;
            listings[currencyCounter] = new CartItems();
            pnlProducts.Controls.Add(listings[currencyCounter]);
            if (pnlProducts.Controls.Count < 2){
                listings[currencyCounter].Location = new Point(0, 0);}
            else{
                lastListing = (CartItems)pnlProducts.Controls[pnlProducts.Controls.Count - 2];
                listings[currencyCounter].Location = new Point(0, lastListing.Location.Y + lastListing.Height + margin);}
            listings[currencyCounter].onRemoveSite += new CartItems.RemoveSiteEventHandler(RemoveSite_Click);
            listings[currencyCounter].index = pnlProducts.Controls.Count - 1;
            listings[currencyCounter].Width = pnlProducts.Width;
            listings[currencyCounter].Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right));
            listings[currencyCounter].lblNameInfo.Text = name[currencyCounter].ToString();
            listings[currencyCounter].lblAmountInfo.Text = quantity[currencyCounter].ToString();
            listings[currencyCounter].lblAltAmountInfo.Text = altQuantity[currencyCounter].ToString();
            listings[currencyCounter].lblPriceInfo.Text = price[currencyCounter].ToString();
            listings[currencyCounter].lblAltPriceInfo.Text = altPrice[currencyCounter].ToString();
            listings[currencyCounter].ID = ID[currencyCounter];
            if (listings[currencyCounter].lblAltAmountInfo.Text == 0.ToString()){
                listings[currencyCounter].btnAltRemove.Visible = false;
                listings[currencyCounter].btnAltRemove.Enabled = false;}
            if (listings[currencyCounter].lblAmountInfo.Text == 0.ToString()){
                listings[currencyCounter].btnRemove.Visible = false;
                listings[currencyCounter].btnRemove.Enabled = false;}
        }
        private void RemoveSite_Click(Object sender, CartItems.ContentArgs e){
            CartItems content = (CartItems)sender;
            CartItems updateList;
            for (int i = e.index; i < pnlProducts.Controls.Count; i++){
                updateList = (CartItems)pnlProducts.Controls[i];
                updateList.Location = new Point(0, updateList.Location.Y - updateList.Height - margin);
                updateList.index = i - 1;}
            pnlProducts.Controls.RemoveAt(e.index);}

        public void calculateTotal(){
            total = 0;
            lblPrice.Text = "";
            lblTaxInfo.Text = "";
            for (calculate = 0; calculate < Count; calculate++){
                total += price[calculate] + altPrice[calculate];}
            tax = total * (decimal).0875;
            lblTaxInfo.Text = Math.Round(tax, 2).ToString();
            total = total + tax;
            lblPrice.Text = Math.Round(total, 2).ToString();}
        public void clear(){
            name = null;
            ID = null;
            quantity = null;
            altQuantity = null;
            price = null;
            altPrice = null;
        }
        public void load(){
            Count = customer.countCart();
            name = new string[Count];
            ID = new string[Count];
            quantity = new int[Count];
            altQuantity = new int[Count];
            price = new decimal[Count];
            altPrice = new decimal[Count];
            customer.viewCart();
            customer.fillTable(table);
            for (int i = 0; i < Count; i++){
                name[currencyCounter] = table.Rows[currencyCounter]["AlbumName"].ToString();
                ID[currencyCounter] = table.Rows[currencyCounter]["ItemID"].ToString();
                quantity[currencyCounter] = Int32.Parse(table.Rows[currencyCounter]["Amount"].ToString());
                price[currencyCounter] = decimal.Parse(table.Rows[currencyCounter]["NormalTotal"].ToString());
                altQuantity[currencyCounter] = Int32.Parse(table.Rows[currencyCounter]["altAmount"].ToString());
                altPrice[currencyCounter] = decimal.Parse(table.Rows[currencyCounter]["altTotal"].ToString());
                loadCart();
                currencyCounter++;}
            calculateTotal();
            currencyCounter = 0;
            customer.stopConnect();
            table.Clear();
            table.Dispose();
        }
        private void Cart_Load(object sender, EventArgs e){
            load();
            if(Count == 0){btnCheckOut.Enabled = false;}
        }
        private void btnBack_Click(object sender, EventArgs e){this.Close();}

        private void btnCheckOut_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to check out?", "Check Out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                try{
                    for (int i = 0; i < Count; i++){
                        amount = +quantity[i] + altQuantity[i];}
                    customer.makeOrder(lblTaxInfo.Text, lblPrice.Text, amount);
                    order = customer.countOrders();
                    for (int i = 0; i < Count; i++){
                        customer.fillOrder(order, name[i], quantity[i], price[i].ToString(), altQuantity[i], altPrice[i].ToString());}
                    CheckOutReceipt receipt = new CheckOutReceipt();
                    receipt.ShowDialog();
                    amount = 0;
                    this.Close();
                }catch { MessageBox.Show("An error has occured while processing your order."); }
            }
            amount = 0;
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the Application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { Application.Exit(); }}

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();}

        private void btnUpdate_Click(object sender, EventArgs e){
            pnlProducts.Controls.Clear();
            clear();
            load();
            calculateTotal();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CartHelp.html");
        }
    }
}
