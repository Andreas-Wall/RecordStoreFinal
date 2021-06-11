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
using System.IO;

namespace Final{
    public partial class manageItems : Form{
        ProductDLL ProductsDLL = new ProductDLL();
        DataTable table = new DataTable();
        CurrencyManager currencyManager;
        bool ins = false;
        bool del = false;
        bool upd = false;
        bool image = false;
        byte[] picture;
        //paint event to redraw the box
        private void gbxInformationReader_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics, Color.Black);}
        private void gbxProductInformation_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics, Color.Black);}
        private void gbxDatabaseManager_Paint(object sender, PaintEventArgs e){
            GroupBox gb = sender as GroupBox;
            DrawGroupBox(gb, e.Graphics, Color.Black);}
        //Redraws the group box that way it is actually visiable to the user
        private void DrawGroupBox(GroupBox gb, Graphics g, Color borderColor){
            if (gb != null){
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF size = g.MeasureString(gb.Text, gb.Font);
                Rectangle rect = new Rectangle(gb.ClientRectangle.X, gb.ClientRectangle.Y + (int)(size.Height / 2), gb.ClientRectangle.Width - 1, gb.ClientRectangle.Height - (int)(size.Height / 2) - 1);
                g.Clear(this.BackColor);
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + gb.Padding.Left, rect.Y));
                g.DrawLine(borderPen, new Point(rect.X + gb.Padding.Left + (int)(size.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));}
        }
        public manageItems(){InitializeComponent();}
        //clears the data from the text fields
        public void clearData(){
            txtASIN.DataBindings.Clear();
            txtAlbum.DataBindings.Clear();
            txtBand.DataBindings.Clear();
            txtLabel.DataBindings.Clear();
            txtLength.DataBindings.Clear();
            txtReleaseDate.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtAltPrice.DataBindings.Clear();
            txtStock.DataBindings.Clear();
            txtAltStock.DataBindings.Clear();
            pbxProduct.DataBindings.Clear();}
        //clears the text fields
        public void clear(){
            txtASIN.Clear();
            txtAlbum.Clear();
            txtBand.Clear();
            txtLabel.Clear();
            txtLength.Clear();
            txtReleaseDate.Clear();
            txtPrice.Clear();
            txtAltPrice.Clear();
            txtStock.Clear();
            txtAltStock.Clear();
            pbxProduct.Image = null;}
        //enables the edit buttons and disables the buttons used to look at products
        public void enable(){
            btnFirst.Visible = false;
            btnLast.Visible = false;
            btnNext.Visible = false;
            btnPrevious.Visible = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;

            btnEdit.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnImage.Visible = false;
            btnBack.Visible = false;
            btnStock.Visible = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnImage.Enabled = false;
            btnBack.Enabled = false;
            btnStock.Enabled = false;

            btnCancel.Visible = true;
            btnCancel.Enabled = true;
            btnSubmit.Visible = true;
            btnSubmit.Enabled = true;
            btnImage.Visible = true;
            btnImage.Enabled = true;}
        //enables the text fields
        public void enableText(){
            txtASIN.Enabled = true;
            txtAlbum.Enabled = true;
            txtBand.Enabled = true;
            txtLabel.Enabled = true;
            txtLength.Enabled = true;
            txtReleaseDate.Enabled = true;
            txtPrice.Enabled = true;
            txtAltPrice.Enabled = true;
            txtStock.Enabled = true;
            txtAltStock.Enabled = true;}
        //disables the edit buttons and reenables the buttons used to look at products
        public void disable(){
            btnFirst.Visible = true;
            btnLast.Visible = true;
            btnNext.Visible = true;
            btnPrevious.Visible = true;
            btnFirst.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;

            btnEdit.Visible = true;
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnImage.Visible = true;
            btnBack.Visible = true;
            btnStock.Visible = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnImage.Enabled = true;
            btnBack.Enabled = true;
            btnStock.Enabled = true;

            btnCancel.Visible = false;
            btnCancel.Enabled = false;
            btnSubmit.Visible = false;
            btnSubmit.Enabled = false;
            btnImage.Visible = false;
            btnImage.Enabled = false;}
        //disables the text fields
        public void disableText(){
            txtASIN.Enabled = false;
            txtAlbum.Enabled = false;
            txtBand.Enabled = false;
            txtLabel.Enabled = false;
            txtLength.Enabled = false;
            txtReleaseDate.Enabled = false;
            txtPrice.Enabled = false;
            txtAltPrice.Enabled = false;
            txtStock.Enabled = false;
            txtAltStock.Enabled = false;}
        //closes the program
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e){
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the Application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            Application.Exit();}
        //load function that loads the table and databinds the information to the textfields
        public void load(){
            ProductsDLL.connect();
            ProductsDLL.fillTable(table);

            txtASIN.DataBindings.Add("Text", table, "ASIN");
            txtAlbum.DataBindings.Add("Text", table, "AlbumName");
            txtBand.DataBindings.Add("Text", table, "Band");
            txtLabel.DataBindings.Add("Text", table, "Label");
            txtLength.DataBindings.Add("Text", table, "RunTime");
            txtReleaseDate.DataBindings.Add("Text", table, "ReleaseDate");
            txtPrice.DataBindings.Add("Text", table, "Price");
            txtAltPrice.DataBindings.Add("Text", table, "VariantPrice");
            txtStock.DataBindings.Add("Text", table, "Stock");
            txtAltStock.DataBindings.Add("Text", table, "VariantStock");
            pbxProduct.DataBindings.Add("Image", table, "Picture", true);
            ProductsDLL.stopConnect();
            
            currencyManager = (CurrencyManager)this.BindingContext[table];}
        //on load event
        private void manageItems_Load(object sender, EventArgs e){load();}
        //goes to the next product
        private void btnNext_Click(object sender, EventArgs e) {currencyManager.Position++;}
        //goes to the previous product  
        private void btnPrevious_Click(object sender, EventArgs e){ currencyManager.Position--;}
        //goes to the first product
        private void btnFirst_Click(object sender, EventArgs e){ currencyManager.Position = 0; }
        //goes to the last product
        private void btnLast_Click(object sender, EventArgs e){ currencyManager.Position = currencyManager.Count - 1; }
        //uploads the image to the database
        private void btnImage_Click(object sender, EventArgs e){
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog()){
                if (openFileDialog.ShowDialog() == DialogResult.OK) { filePath = openFileDialog.FileName; }
                picture = File.ReadAllBytes(filePath);}
            image = true;
        }
        //allows the user to edit the products
        private void btnEdit_Click(object sender, EventArgs e){
            enable();
            enableText();
            txtPrice.Enabled = false;
            txtAltPrice.Enabled = false;
            txtASIN.Enabled = false;
            upd = true;}
        //allows the user to edit the price of the product
        private void btnPrice_Click(object sender, EventArgs e){
            decimal total;
            AddStock addStock = new AddStock();
            addStock.oldStock = int.Parse(txtStock.Text);
            addStock.oldAltStock = int.Parse(txtAltStock.Text);
            addStock.ShowDialog();
            try{
                if (addStock.stockCancel == false){
                    int oldStock = addStock.oldStock;
                    int oldAltStock = addStock.oldAltStock;
                    int newStock = addStock.newStock;
                    int newAltStock = addStock.newAltStock;
                    txtStock.Text = oldStock.ToString();
                    txtAltStock.Text = oldAltStock.ToString();
                    ProductsDLL.updateStock(txtASIN.Text, txtStock.Text, txtAltStock.Text);
                    total = (addStock.newStock * decimal.Parse(txtPrice.Text)) + (addStock.newAltStock * decimal.Parse(txtAltPrice.Text));
                    if (addStock.invoice == true){
                        ProductsDLL.addInvoice(txtASIN.Text, txtAlbum.Text, newStock.ToString(), txtPrice.Text, newAltStock.ToString(), txtAltPrice.Text, total.ToString());
                        if (MessageBox.Show("Would you like to print an invoice for the stock change", "Invoice", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes){
                            Invoices invoices = new Invoices();
                            invoices.ShowDialog();}
                    }
                    disable();
                    table.Clear();
                    clear();
                    load();
                    currencyManager.Position = 0;}
            }catch { }
        }
        //allows the user to add products
        private void btnAdd_Click(object sender, EventArgs e){
            clear();
            enableText();
            txtASIN.Focus();
            enable();
            ins = true;}
        //lets the user delete products
        private void btnDelete_Click(object sender, EventArgs e){
            enable();
            btnImage.Visible = false;
            btnImage.Enabled = false;
            del = true;}
        //Goes thought the process of seeing what type of edit to the database is being made
        private void btnSubmit_Click(object sender, EventArgs e){
            //if insert is true the application will insert the new product into the database
            if (ins == true && image == true)
            {
                try
                {
                    ProductsDLL.insert(txtASIN.Text.ToString(), txtAlbum.Text.ToString(), txtBand.Text.ToString(), txtPrice.Text.ToString(), txtReleaseDate.Text.ToString(), txtLabel.Text.ToString(), txtLength.Text.ToString(), txtStock.Text.ToString(), picture, txtAltPrice.Text.ToString(), txtAltStock.Text.ToString());
                    MessageBox.Show("The Product has been added to the database");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error with Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal total;
                total = (decimal.Parse(txtStock.Text) * decimal.Parse(txtPrice.Text)) + (decimal.Parse(txtAltStock.Text) * decimal.Parse(txtAltPrice.Text));
                ProductsDLL.addInvoice(txtASIN.Text, txtAlbum.Text, txtStock.Text, txtPrice.Text, txtAltStock.Text, txtAltPrice.Text, total.ToString());
                if (MessageBox.Show("Would you like to print an invoice for the new purchase", "Invoice", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Invoices invoices = new Invoices();
                    invoices.ShowDialog();
                }
                disableText();
                clearData();
                clear();
                image = false;
                ins = false;
            }
            else if (ins == true && image == false)
            {
                //forces the user to insert a pcture
                MessageBox.Show("Please insert a Picture;");
                var filePath = string.Empty;
                while (image == false)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK) { filePath = openFileDialog.FileName; }
                        picture = File.ReadAllBytes(filePath);
                    }
                    image = true;
                }
            }
            //if update is true application will update the inforamtion of the product
            else if (upd == true){
                if (image == true){
                    try{
                    ProductsDLL.updateData(txtASIN.Text.ToString(), txtAlbum.Text.ToString(), txtBand.Text.ToString(), txtPrice.Text.ToString(), txtReleaseDate.Text.ToString(), txtLabel.Text.ToString(), txtLength.Text.ToString(), picture, txtAltPrice.Text.ToString());}
                    catch (Exception ex){
                    MessageBox.Show(ex.Message, "Error with Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;}
                }
                else {
                    try{
                        ProductsDLL.updateDataWOPicture(txtASIN.Text.ToString(), txtAlbum.Text.ToString(), txtBand.Text.ToString(), txtPrice.Text.ToString(), txtReleaseDate.Text.ToString(), txtLabel.Text.ToString(), txtLength.Text.ToString(), txtAltPrice.Text.ToString());}
                    catch (Exception ex){
                        MessageBox.Show(ex.Message, "Error with Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;}
                }
                disableText();
                clearData();
                clear();
                image = false;
                upd = false;
            }
            //if delete is true application will delete the product from the database in all places
            else if (del == true)
            {
                if (MessageBox.Show("Are you sure you want to delete this Product form the database?", "Delete Project", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try { ProductsDLL.deleteData(txtASIN.Text.ToString()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error with Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    clearData();
                }
                del = false;
            }

            disable();
            table.Clear();
            clear();
            load();
            currencyManager.Position = 0;}
        //if the user cancels the edit then the page will go back to normal
        private void btnCancel_Click(object sender, EventArgs e){
            ins = false;
            del = false;
            upd = false;
            table.Clear();
            clearData();
            clear();
            disable();
            disableText();
            load();
            currencyManager.Position = 0;}
        //shows the about dialog box
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e){
            AboutBox1 ab1 = new AboutBox1();
            ab1.ShowDialog();}
        //closes the page
        private void btnBack_Click(object sender, EventArgs e){this.Close();}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ManagaItemsHelp.html");
        }
    }
}
