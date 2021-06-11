using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProductsDLL{
    public class ProductDLL{
        SqlConnection dataConnect;
        SqlCommand dataCommand;
        SqlDataAdapter dataAdapter;
        SqlDataReader DataReader;
        //creates a general connection to the database.
        public void connect(){
            try{
                dataConnect = new SqlConnection("");
                dataConnect.Open();
                dataCommand = new SqlCommand("select p.*, v.VariantPrice, v.VariantStock from Products p join variant v on p.ASIN = v.VariantID order by p.Band", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch{ MessageBox.Show("An error has occured connecting to the database."); }
            }
        //kills the connection to the database
        public void stopConnect(){
            dataConnect.Close();
            dataAdapter.Dispose();
            dataCommand.Dispose();}
        //method used to fill the passed in database
        public void fillTable(DataTable table){ dataAdapter.Fill(table); }
        //safely removes the product from the database
        public void deleteData(string id){
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("delete from cart where itemID =  '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataCommand = new SqlCommand("delete from variant where VariantID =  '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataCommand = new SqlCommand("delete from Products where ASIN =  '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();}
        //updates the products information with picture
        public void updateData(string id, string name, string band, string price, string release, string label, string runtime, byte[] picture, string vprice){
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("update Products set AlbumName = '" + name + "', Band = '" + band + "', Price = '" + price + "', ReleaseDate = '" + release + "', Label = '" + label + "', Runtime = '" + runtime + "', Picture = @picture where ASIN =  '" + id + "'", dataConnect);
            dataCommand.Parameters.AddWithValue("@picture", picture);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataCommand = new SqlCommand("update variant set VariantPrice = '" + vprice + "' where VariantID = '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();}
        //updates the product without picture
        public void updateDataWOPicture(string id, string name, string band, string price, string release, string label, string runtime, string vprice)
        {
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("update Products set AlbumName = '" + name + "', Band = '" + band + "', Price = '" + price + "', ReleaseDate = '" + release + "', Label = '" + label + "', Runtime = '" + runtime + "' where ASIN =  '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataCommand = new SqlCommand("update variant set VariantPrice = '" + vprice + "' where VariantID = '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();
        }
        //updates the products price
        public void updateStock(string id, string Stock, string vStock){
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("update Products set Stock = '" + Stock + "' where ASIN =  ('" + id + "')", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataCommand = new SqlCommand("update variant set VariantStock = '" + vStock + "' where VariantID = '" + id + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();}
        //inserts a new product into the database
        public void insert(string id, string name, string band, string price, string release, string label, string runtime, string stock, byte[] picture, string vprice, string vstock){
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("insert into Products values ('" + id + "','" + name + "','" + band + "','" + price + "','" + release + "','" + label + "','" + runtime + "','" + stock + "', @picture)", dataConnect);
            dataCommand.Parameters.AddWithValue("@picture", picture);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataCommand = new SqlCommand("insert into variant values ('" + id + "','" + vprice + "','" + vstock + "')", dataConnect);
            dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();}
        //adds an invoice of the most recent change of stock or added item
        public void addInvoice(string id, string name, string Stock, string price, string vStock, string vprice, string total){ 
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("insert into Invoice values ('" + id + "','" + name + "','" + Stock + "','" + price + "','" + vStock + "','" + vprice + "','" + total + "')", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();}
        public void deleteInvoice(){
            dataConnect = new SqlConnection("");
            dataConnect.Open();
            dataCommand = new SqlCommand("delete from Invoice", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            DataReader.Close();
            dataConnect.Close();}
        
    }
}
