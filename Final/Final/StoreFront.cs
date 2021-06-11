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
using System.Collections;

namespace Final{
    public partial class StoreFront : Form{
        CustomerDLL customer = new CustomerDLL();
        DataTable table = new DataTable();
        public string album;
        const int margin = 3;
        int count;
        int currencyCounter = 0;
        public string[] name;
        public string[] band;
        public string[] label;
        public StoreFront(){InitializeComponent();}
        //loads the panel with user controls to show the products for sell
        public void loadPanel(){
            //creates user controls
            productListings[] listings = new productListings[count];
            productListings lastListing;
            //instantiates the user control
            listings[currencyCounter] = new productListings();
            pnlProducts.Controls.Add(listings[currencyCounter]);
            //places the control in the correct location depending on which one it is in the order
            if (pnlProducts.Controls.Count < 2){
                listings[currencyCounter].Location = new Point(0, 0);}
            else {
                lastListing = (productListings)pnlProducts.Controls[pnlProducts.Controls.Count - 2];
                listings[currencyCounter].Location = new Point(0, lastListing.Location.Y + lastListing.Height + margin);}
            listings[currencyCounter].Width = pnlProducts.Width;
            listings[currencyCounter].Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right));
            //makes the labels in the control equal to the correct value depending on which product it is suppose to show
            listings[currencyCounter].lblAlbumInfo.Text = name[currencyCounter].ToString();
            listings[currencyCounter].lblBandInfo.Text = band[currencyCounter].ToString();
            listings[currencyCounter].lblLabelInfo.Text = label[currencyCounter].ToString();}
        //loads the store page
        private void StoreFront_Load(object sender, EventArgs e){
            count = customer.countProducts();
            name = new string[count];
            band = new string[count];
            label = new string[count];
            customer.connect();
            customer.fillTable(table);
            for (int i = 0; i < count; i++) {
                name[currencyCounter] = table.Rows[currencyCounter]["AlbumName"].ToString();
                band[currencyCounter] = table.Rows[currencyCounter]["Band"].ToString();
                label[currencyCounter] = table.Rows[currencyCounter]["Label"].ToString();
                loadPanel();

                currencyCounter++;}
            customer.stopConnect();}
        //safely closes the application
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the Application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes){ Application.Exit();}}
        //shows the about dialog box
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();}
        //shows the cart to the user
        private void btnViewCart_Click(object sender, EventArgs e){
            Cart cart = new Cart();
            cart.ShowDialog();}
        //login for managers
        private void loginToolStripMenuItem_Click(object sender, EventArgs e){
            ManagerLogin login = new ManagerLogin();
            login.ShowDialog();
            if(login.logged == true){
                ManagerView manager = new ManagerView();
                this.Hide();
                manager.ShowDialog();
                this.Close();}
        }
        //login for employees
        private void employeeLoginToolStripMenuItem_Click(object sender, EventArgs e){
            EmployeeLogin login = new EmployeeLogin();
            login.ShowDialog();
            if (login.logged == true){
                EmployeeView employeeView = new EmployeeView();
                employeeView.id = login.txtID.Text;
                this.Hide();
                employeeView.ShowDialog();
                this.Close();}
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("StoreFrontHelp.html");
        }
    }
}
