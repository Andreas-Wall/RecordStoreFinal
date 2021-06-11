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
    public partial class BuyAlbum : Form{
        CustomerDLL customer = new CustomerDLL();
        DataTable table = new DataTable();
        public string album;
        bool altPurchase;
        public BuyAlbum(){ InitializeComponent(); }
        public void clear(){
            lblIDInfo.Text = "";
            lblAlbumInfo.Text = "";
            lblBandInfo.Text = "";
            lblLabelInfo.Text = "";
            lblLengthInfo.Text = "";
            lblReleaseDateInfo.Text = "";
            lblPriceInfo.Text = "";
            lblaltPriceInfo.Text = "";
            lblStockInfo.Text = "";
            lblaltStockInfo.Text = "";
            pbxProduct.Image = null;}
        public void clearData(){
            lblIDInfo.DataBindings.Clear();
            lblAlbumInfo.DataBindings.Clear();
            lblBandInfo.DataBindings.Clear();
            lblLabelInfo.DataBindings.Clear();
            lblLengthInfo.DataBindings.Clear();
            lblReleaseDateInfo.DataBindings.Clear();
            lblPriceInfo.DataBindings.Clear();
            lblaltPriceInfo.DataBindings.Clear();
            lblStockInfo.DataBindings.Clear();
            lblaltStockInfo.DataBindings.Clear();
            pbxProduct.DataBindings.Clear();}
        public void load(){
            altPurchase = false;
            customer.albumSearch(album);
            customer.fillTable(table);
            
            lblIDInfo.DataBindings.Add("Text", table, "ASIN");
            lblAlbumInfo.DataBindings.Add("Text", table, "AlbumName");
            lblBandInfo.DataBindings.Add("Text", table, "Band");
            lblLabelInfo.DataBindings.Add("Text", table, "Label");
            lblLengthInfo.DataBindings.Add("Text", table, "RunTime");
            lblReleaseDateInfo.DataBindings.Add("Text", table, "ReleaseDate");
            lblPriceInfo.DataBindings.Add("Text", table, "Price");
            lblaltPriceInfo.DataBindings.Add("Text", table, "VariantPrice");
            lblStockInfo.DataBindings.Add("Text", table, "Stock");
            lblaltStockInfo.DataBindings.Add("Text", table, "VariantStock");
            pbxProduct.DataBindings.Add("Image", table, "Picture", true);
            customer.stopConnect();}
        private void BuyAlbum_Load(object sender, EventArgs e){
            load();
            if (lblStockInfo.Text == 0.ToString()){
                lblStockInfo.Text = "Out Of Stock";
                btnBuyAlbum.Enabled = false;}
            if (lblaltStockInfo.Text == 0.ToString()) {
                lblaltStockInfo.Text = "Out Of Stock";
                btnBuyAltAlbum.Enabled = false;}
        }
        private void btnBack_Click(object sender, EventArgs e){this.Close();}
        private void btnBuyAlbum_Click(object sender, EventArgs e){
            string item = lblIDInfo.Text;
            try { customer.addCart(item, altPurchase); }
            catch {
                table.Clear();
                clearData();
                clear();}
            table.Clear();
            clearData();
            clear();
            load();
            if (lblStockInfo.Text == 0.ToString()){
                lblStockInfo.Text = "Out Of Stock";
                btnBuyAlbum.Enabled = false;}
            if (lblaltStockInfo.Text == 0.ToString()) {
                lblaltStockInfo.Text = "Out Of Stock";
                btnBuyAltAlbum.Enabled = false;}
        }
        private void btnBuyAltAlbum_Click(object sender, EventArgs e){
            string item = lblIDInfo.Text;
            altPurchase = true;
            try { customer.addCart(item, altPurchase); }
            catch{
                table.Clear();
                clearData();
                clear();}
            table.Clear();
            clearData();
            clear();
            load();
            if (lblStockInfo.Text == 0.ToString()){
                lblStockInfo.Text = "Out Of Stock";
                btnBuyAlbum.Enabled = false;}
            if (lblaltStockInfo.Text == 0.ToString()){
                lblaltStockInfo.Text = "Out Of Stock";
                btnBuyAltAlbum.Enabled = false;}
        }
        private void btnGlow_Click(object sender, EventArgs e){
            Glow glow = new Glow();
            glow.ShowDialog();}
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the Application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { Application.Exit(); }}
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("BuyAlbumHelp.html");
        }
    }
}
