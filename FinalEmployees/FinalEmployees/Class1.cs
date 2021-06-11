using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Mail;

namespace FinalEmployees{
    public class EmployeesDLL{
        SqlConnection dataConnect;
        SqlCommand dataCommand;
        SqlDataAdapter dataAdapter;
        SqlDataReader DataReader;
        SmtpClient Smtp_Server;
        MailMessage e_mail;
        //login process for the manager
        public bool managerLogin(string ID, string Pass){
            string locked = "True";
            dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
            dataConnect.Open();
            dataCommand = new SqlCommand("select ManagerID, Locked from Manager where ManagerID = '" + ID + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            try {
                if (DataReader.Read())
                {
                    //first checks to see if the user name is in the database
                    if (ID == DataReader[0].ToString())
                    {
                        //then checks to see if the account is locked
                        if (DataReader[1].ToString() == locked)
                        {
                            MessageBox.Show("Your account has been locked out. Please contact the Database Admin immediately!", "ACCOUNT LOCKED");
                            return false;
                        }
                        //if not it will then check to make sure the password matches the username in the database
                        else
                        {
                            DataReader.Close();
                            dataCommand = new SqlCommand("select ManagerID, Password from Manager where ManagerID = '" + ID + "' and Password = '" + Pass + "'", dataConnect);
                            DataReader = dataCommand.ExecuteReader();
                        }
                        if (DataReader.Read())
                        {
                            //is so the manager will be logged in and the attempt count will be set back to 0
                            if (ID == DataReader[0].ToString() && Pass == DataReader[1].ToString())
                            {
                                MessageBox.Show("Welcome back");
                                DataReader.Close();
                                dataCommand = new SqlCommand("update Manager set attemptCount = 0 where ManagerID = '" + ID + "'", dataConnect);
                                DataReader = dataCommand.ExecuteReader();
                                return true;
                            }
                        }
                        //if not the attempt count will be incremented and notify the user that password was incorrect
                        else
                        {
                            MessageBox.Show("Incorrect Password. Please try again.");
                            DataReader.Close();
                            dataCommand = new SqlCommand(" begin declare @attempts int; update Manager set attemptCount = attemptCount + 1 where ManagerID = '" + ID + "'; select @attempts = (attemptCount)from Manager where ManagerID = '" + ID + "'; select @attempts; if @attempts = 3 begin update Manager set Locked = 1 where ManagerID = '" + ID + "'; end end", dataConnect);
                            DataReader = dataCommand.ExecuteReader();
                            DataReader.Close();
                        }
                    }
                } else { MessageBox.Show("Incorrect username. Please try again."); }
            } catch  { MessageBox.Show("An error has occured during your login. If this continoues please notify the Database Admin immediately."); }
            return false;}
        //login process for employees
        public bool employeeLogin(string ID, string Pass){
            string locked = "True";
            dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
            dataConnect.Open();
            dataCommand = new SqlCommand("select EmployeeID, Locked from Employee where EmployeeID = '" + ID + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            try{
                if (DataReader.Read()){
                    //first checks to see if the user name is in the database
                    if (ID == DataReader[0].ToString()) {
                        //then checks to see if the account is locked
                        if (DataReader[1].ToString() == locked){
                            MessageBox.Show("Your account has been locked out. Please use the password recovery to regain entry.", "ACCOUNT LOCKED");
                            return false;}
                        //if not it will then check to make sure the password matches the username in the database
                        else{
                            DataReader.Close();
                            dataCommand = new SqlCommand("select EmployeeID, Password from Employee where EmployeeID = '" + ID + "' and Password = '" + Pass + "'", dataConnect);
                            DataReader = dataCommand.ExecuteReader();}
                        if (DataReader.Read()){
                            //is so the manager will be logged in and the attempt count will be set back to 0
                            if (ID == DataReader[0].ToString() && Pass == DataReader[1].ToString()){
                                MessageBox.Show("Welcome back");
                                DataReader.Close();
                                dataCommand = new SqlCommand("update Employee set attemptCount = 0 where EmployeeID = '" + ID + "'", dataConnect);
                                DataReader = dataCommand.ExecuteReader();
                                return true;}}
                        //if not the attempt count will be incremented and notify the user that password was incorrect
                        else{
                            MessageBox.Show("Incorrect Password. Please try again.");
                            DataReader.Close();
                            dataCommand = new SqlCommand(" begin declare @attempts int; update Employee set attemptCount = attemptCount + 1 where EmployeeID = '" + ID + "'; select @attempts = (attemptCount)from Employee where EmployeeID = '" + ID + "'; select @attempts; if @attempts = 3 begin update Employee set Locked = 1 where EmployeeID = '" + ID + "'; end end", dataConnect);
                            DataReader = dataCommand.ExecuteReader();
                            DataReader.Close();}
                    }
                }else { MessageBox.Show("Incorrect username. Please try again."); }
            }catch { MessageBox.Show("An error has occured during your login. If this continoues please notify the Database Admin immediately."); }
            return false;}
        //method to send password to user email if the user has forgot it or if the account has been locked out.
        public bool forgotPassword(string ID, string Email){
            Random ran = new Random();
            int newPass = ran.Next(12345, 99999);
            dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
            dataConnect.Open();
            dataCommand = new SqlCommand("select EmployeeID from Employee where EmployeeID = '" + ID + "'", dataConnect);
            DataReader = dataCommand.ExecuteReader();
            try{
                if (DataReader.Read()){
                    if (ID == DataReader[0].ToString()){
                        DataReader.Close();
                        dataCommand = new SqlCommand("select EmployeeID, Email from Employee where EmployeeID = '" + ID + "' and Email = '" + Email + "'", dataConnect);
                        DataReader = dataCommand.ExecuteReader();
                        if (DataReader.Read()){
                            if (ID == DataReader[0].ToString() && Email == DataReader[1].ToString()){
                                DataReader.Close();
                                dataCommand = new SqlCommand("update Employee set locked = 0 where EmployeeID = '" + ID + "'", dataConnect);
                                DataReader = dataCommand.ExecuteReader();
                                DataReader.Close();
                                dataCommand = new SqlCommand("update Employee set attemptCount = 2 where EmployeeID = '" + ID + "'", dataConnect);
                                DataReader = dataCommand.ExecuteReader();
                                DataReader.Close();
                                dataCommand = new SqlCommand("Update Employee set Password = 'R" + newPass + "' where EmployeeID = '" + ID + "' and  Email = '" + Email + "'", dataConnect);
                                DataReader = dataCommand.ExecuteReader();
                                //Sends an email of the reset password
                                Smtp_Server = new SmtpClient();
                                Smtp_Server.UseDefaultCredentials = false;
                                Smtp_Server.Credentials = new System.Net.NetworkCredential("m.Andreas.wall@gmail.com", "Trueeverybody3");
                                Smtp_Server.Port = 587;
                                Smtp_Server.EnableSsl = true;
                                Smtp_Server.Host = "smtp.gmail.com";
                                e_mail = new MailMessage();
                                e_mail.From = new MailAddress("m.Andreas.wall@gmail.com");
                                e_mail.To.Add(Email);
                                e_mail.Subject = "Account Password Reset";
                                e_mail.Body = "Hello, your password has been changed to R" + newPass + ".";

                                Smtp_Server.Send(e_mail);
                                return true;}
                        }   else{ MessageBox.Show("Incorrect Email. Please enter the correct email.");
                        return false;}
                    }
                } else { MessageBox.Show("Incorrect username. Please try again."); }
            } catch { MessageBox.Show("An error has occured during your attempt to reset you password. If this continoues please notify the Database Admin immediately."); }
            return false;}

        //fills the table
        public void fillTable(DataTable table) { dataAdapter.Fill(table); }
        //get special of the week
        public void getSpecial(){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select * from DealofWeek", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //updates the special of the week
        public void updateSpecial(string deal){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("update DealofWeek set Deal = '" + deal + "'", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //Loads the schedule table
        public void getSchedule(DataTable table){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                SqlCommand dataCommand = new SqlCommand("select s.ScheduleEntryID, (e.FirstName + ' ' + e.LastName) as 'Name', s.Position, s.Shift from Schedules s join Employee e on e.EmployeeID = s.EmployeeID", dataConnect);
                dataAdapter.Dispose();
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;
                dataAdapter.Fill(table);}
            catch { MessageBox.Show("Connection to the database has been lost"); }}
        //Loads employee's information
        public void EmployeeInfo(string ID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select EmployeeID, Password, FirstName, LastName, Phone, Email, Salary from Employee where EmployeeID = '" + ID + "'", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //edits the inforamtion of the employee
        public void editInformation(string ID, string Password, string FirstName, string LastName, string Phone, string Email){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("update Employee set Password = '" + Password + "', FirstName = '" + FirstName + "', LastName = '" + LastName + "', Phone = '" + Phone + "', Email = '" + Email + "' where EmployeeID = '" + ID + "'", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch(Exception ex) { MessageBox.Show("An error has occured during your update." + "\n" + ex.Message); }
        }
        //Submit request off
        public void RequestOff(string ID, string Shift, string Request, string Reason){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("insert into RequestOff values ('" + ID + "','" + Shift + "','" + Request + "','" + Reason + "', 'awaiting confirmation')", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch (Exception ex) { MessageBox.Show("An error has occured during your attemp to request time off." + "\n" + ex.Message); }
        }
        //shows request made by specific employee
        public void showEmployeeRequest(string ID){
            try {
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select r.RequestID, r.EmployeeID, (e.FirstName + ' ' + e.LastName) as 'Name', r.Shift, r.Request, r.Reason, r.Status from RequestOff r join Employee e on e.EmployeeID = r.EmployeeID  where r.EmployeeID = '" + ID + "'", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;
            }
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //Submit request change
        public void RequestChange(string PersonalID, string DesiredID, string ID, string Reason){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("insert into ScheduleChanges values (" + PersonalID + "," + DesiredID + ",'" + ID + "','Change','" + Reason + "', 'awaiting confirmation')", dataConnect);
                DataReader = dataCommand.ExecuteReader();
            } catch { MessageBox.Show("An error has occored while trying to submit your request." + "\n" + " Please make sure that all information is correct."); }
        }
        //shows changes requested by specific employee
        public void showEmployeeChange(string ID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select c.ChangeID, c.PersonalScheduleID, c.RequestedScheduleID, c.EmployeeID, (e.FirstName + ' ' + e.LastName) as 'Name', c.Request, c.Reason, c.Status from ScheduleChanges c join Employee e on e.EmployeeID = c.EmployeeID  where c.EmployeeID = '" + ID + "'", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;
            } catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //shows the manager all requested schedule changes
        public void showChanges(){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select c.ChangeID, c.PersonalScheduleID, c.RequestedScheduleID, c.EmployeeID, (e.FirstName + ' ' + e.LastName) as 'Name', c.Request, c.Reason, c.Status from ScheduleChanges c join Employee e on e.EmployeeID = c.EmployeeID ", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //shows the manager all schedule requests
        public void showRequest(){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select r.RequestID, r.EmployeeID, (e.FirstName + ' ' + e.LastName) as 'Name', r.Shift, r.Request, r.Reason, r.Status from RequestOff r join Employee e on e.EmployeeID = r.EmployeeID", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //counts the number of schedule changes requests made
        public int countChanges(){
            int count;
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select COUNT(*) from ScheduleChanges", dataConnect);}
            catch { MessageBox.Show("Connection to the database has been lost"); }
            count = (int)dataCommand.ExecuteScalar();
            return count;}
        //counts the number of schedule requests made
        public int countRequest(){
            int count;
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select COUNT(*) from RequestOff", dataConnect);
            }
            catch { MessageBox.Show("Connection to the database has been lost"); }
            count = (int)dataCommand.ExecuteScalar();
            return count;}
        //deletes the requested change
        public void deleteChnage(string ID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("delete from ScheduleChanges where ChangeID = '" + ID + "'", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //deletes the request
        public void deleteRequest(string ID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("delete from RequestOff where RequestID = '" + ID + "'", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();
            }catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //rejects the change
        public void rejectChange(string ID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("update ScheduleChanges set Status = 'Rejected' where ChangeID = '" + ID + "'", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //rejects the request
        public void rejectRequest(string ID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("update RequestOff set Status = 'Rejected' where RequestID = '" + ID + "'", dataConnect);
                SqlDataReader DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //finds employeesID
        public void findEmployeeID(string ID, DataTable table){
            try {
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("select EmployeeID from Schedules where ScheduleEntryID = '" + ID + "'", dataConnect);
                dataAdapter.Dispose();
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;
                dataAdapter.Fill(table);}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }
        //insert new entry into the schedule table
        public void insertSchedule(string ID, string postion, string shift){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("insert into Schedules values ('" + ID + "','" + postion + "','" + shift + "')", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("An error has occored while trying to submit your request." + "\n" + " Please make sure that all information is correct."); }
        }
        //updates the schedule entry selected
        public void updateSchedule(string employeeID, string postion, string shift, string scheduleID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("update Schedules set EmployeeID = '" + employeeID + "', Position = '" + postion + "', Shift = '" + shift + "' where ScheduleEntryID = '" + scheduleID + "'", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("An error has occored while trying to submit your request." + "\n" + " Please make sure that all information is correct."); }
        }
        //deletes the schedule entry selected
        public void deleteScheduleEntry(string scheduleID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("delete from Schedules where ScheduleEntryID = '" + scheduleID + "'", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("An error has occored while trying to submit your request." + "\n" + " Please make sure that all information is correct."); }
        }
        //updates the schedule based on a schedule change request
        public void updateScheduleChange(string employeeID, string scheduleID){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                dataCommand = new SqlCommand("update Schedules set employeeID = '" + employeeID + "' where ScheduleEntryID = '" + scheduleID + "'", dataConnect);
                DataReader = dataCommand.ExecuteReader();}
            catch { MessageBox.Show("An error has occored while trying to submit your request." + "\n" + " Please make sure that all information is correct."); }
        }
        //Loads the schedule table
        public void viewSchedule(DataTable table){
            try{
                dataConnect = new SqlConnection("Server = cstnt.tstc.edu; Database = wallM_Final; User Id = mawall; password = 1175037");
                dataConnect.Open();
                SqlCommand dataCommand = new SqlCommand("select s.ScheduleEntryID, s.EmployeeID, (e.FirstName + ' ' + e.LastName) as 'Name', s.Position, s.Shift from Schedules s join Employee e on e.EmployeeID = s.EmployeeID", dataConnect);
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = dataCommand;
                dataAdapter.Fill(table);}
            catch { MessageBox.Show("Connection to the database has been lost"); }
        }

        //kills connection
        public void stopConnect(){
            dataConnect.Close();
            dataAdapter.Dispose();
            dataCommand.Dispose(); }
    }
}
