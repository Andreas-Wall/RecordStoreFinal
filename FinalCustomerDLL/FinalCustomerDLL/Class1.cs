using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalCustomerDLL{
    public class CustomerDLL{
        SqlConnection dataConnect;
        SqlCommand dataCommand;
        SqlDataAdapter dataAdapter;

        //pulls up entire store listing of products
        public void connect(){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select AlbumName, Band, Label from Products order by Band, AlbumName", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //kills connection
        public void stopConnect(){
            dataConnect.Close();
            dataAdapter.Dispose();
            dataCommand.Dispose();}
        //fills the table
        public void fillTable(DataTable table) { dataAdapter.Fill(table); }
        //pulls up selected album
        public void albumSearch(string name){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select p.*, v.VariantPrice, v.VariantStock from Products p join variant v on p.ASIN = v.VariantID where AlbumName = '" + name + "' order by p.Band ", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //view cart
        public void viewCart(){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select p.AlbumName, c.ItemID, c.Amount,(c.Amount * p.Price) as 'NormalTotal', c.altAmount, (c.altAmount * v.VariantPrice) as 'AltTotal' from Cart c join Products p on c.ItemID = p.ASIN join variant v on c.ItemID = v.VariantID", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //Add to cart
        public void addCart(string Item, bool alt){
            try {
                bool inCart = false;
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select ItemID from Cart where ItemID = '" + Item + "'", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();
                //checks to see if there is already an entry for the item being added
                try{
                    if (DataReader.Read()){
                        if (Item == DataReader[0].ToString()){ inCart = true; }
                    }
                    DataReader.Close();}
                catch (Exception ex) { MessageBox.Show("That Item is no longer listed" + ex.Message); }
                DataReader.Close();
                //a series of if statements to either make a new entry into the cart table or to add onto an already existing entry
                //will also check to see if it is a normal product or a variant
                try{
                    if (inCart == true && alt == false){
                        dataCommand = new SqlCommand("update cart set Amount = Amount + 1 where ItemID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        DataReader.Close();
                        dataCommand = new SqlCommand("update products set Stock = Stock - 1 where ASIN = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        MessageBox.Show("The album has been added to your cart"); }
                    else if (inCart == true && alt == true){
                        dataCommand = new SqlCommand("update cart set altAmount = altAmount + 1 where ItemID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        DataReader.Close();
                        dataCommand = new SqlCommand("update variant set VariantStock = VariantStock - 1 where VariantID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        MessageBox.Show("The album has been added to your cart");}
                    else if (inCart == false && alt == false) {
                        dataCommand = new SqlCommand("insert into cart values ('" + Item + "',1,0)", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        DataReader.Close();
                        dataCommand = new SqlCommand("update products set Stock = Stock - 1 where ASIN = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        MessageBox.Show("The album has been added to your cart");}
                    else if (inCart == false && alt == true){
                        dataCommand = new SqlCommand("insert into cart values ('" + Item + "', 0,1)", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        DataReader.Close();
                        dataCommand = new SqlCommand("update variant set VariantStock = VariantStock - 1 where VariantID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        MessageBox.Show("The album has been added to your cart");}
                }catch (Exception ex) { MessageBox.Show("That Item is no longer listed. " + ex.Message); }
            }catch { MessageBox.Show("Connection to the database has been lost"); }}
        //deletes cart after purchese
        public void deleteCart() {
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("delete from Cart", dataConnect);
                dataCommand.ExecuteReader();}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //counts the amount of products in the database
        public int countProducts(){
            int count;
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select COUNT(*) from Products", dataConnect);}
            catch { MessageBox.Show("Connection to the database has been lost"); }
            count = (int)dataCommand.ExecuteScalar();
            return count;}
        //counts the number of items in the cart
        public int countCart() {
            int count;
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select COUNT(*) from Cart", dataConnect);}
            catch { MessageBox.Show("Connection to the database has been lost"); }
            count = (int)dataCommand.ExecuteScalar();
            return count;}
        //safely removes the item from the cart and adds it back to the inventory
        public void removeFromCart(string Item, bool alt, int amount) {
            try {
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                SqlDataReader DataReader;
                try {
                    if (alt == false) {
                        dataCommand = new SqlCommand("update cart set Amount = Amount - " + amount + " where ItemID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        DataReader.Close();
                        dataCommand = new SqlCommand("update products set Stock = Stock + " + amount + " where ASIN = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        MessageBox.Show("The album has been removed from your cart"); }
                    else if (alt == true) {
                        dataCommand = new SqlCommand("update cart set altAmount = altAmount - " + amount + " where ItemID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        DataReader.Close();
                        dataCommand = new SqlCommand("update variant set VariantStock = VariantStock + " + amount + " where VariantID = '" + Item + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        MessageBox.Show("The album has been removed from your cart"); } }
                catch (Exception ex) { MessageBox.Show("That Item is no longer listed. " + ex.Message); }
            }catch { MessageBox.Show("Connection to the database has been lost"); }}
        //deletes an entry from the cart if the product count is 0 in the cart
        public void deleteFromCart(string id){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("delete from Cart where ItemID = '" + id + "'", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //creates the order documentation
        public void makeOrder(string tax, string price, int amount){
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("insert into Orders values ('" + tax + "','" + price +"'," + amount + ")", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();}
        //counts the amount of orders to find the most recently made order to fill it with the order details
        public int countOrders(){
            int count;
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select COUNT(*) from Orders", dataConnect);
            }catch { MessageBox.Show("Connection to the database has been lost"); }
            count = (int)dataCommand.ExecuteScalar();
            return count;}
        //fill the orderdetails with the information from the cart
        public void fillOrder(int orderID, string name, int amount, string price, int altAmount, string altPrice){
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("insert into OrderDetails values (" + orderID + ",'" + name + "'," + amount + "," + price + "," + altAmount + "," + altPrice + ")", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();}
    }
}
