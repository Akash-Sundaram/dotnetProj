using System;
using System.Data.SqlClient;
using System.Data;
namespace LibraryManagement.Models
{
    public class Repository
    {

         SqlConnection connection =new SqlConnection("Data Source=ZEUS\\SQLEXPRESS;Initial Catalog=LBM;Integrated Security=SSPI;TrustServerCertificate=True");

        private static List<User> allUsers=new List<User>();
        public static IEnumerable<User> AllUsers
        {
            get
            {
                return allUsers;
            }
        }
        public int create(User user)
        {   
            // loginDetails.Add(user);
            Console.WriteLine("enter database before insertion of table");
            string? name=user.Name;    
            string? userid=user.UserID;
            string? email=user.Email;
            string? password=user.Password;
                try{
                connection.Open();
                
                SqlCommand command1=new SqlCommand($"insert into UserDetails values('{password}','{name}','{userid}','{email}')",connection);
                command1.ExecuteNonQuery();
                Console.WriteLine("Inserted successfully");
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception);
                }
                
                connection.Close();
                return 0;
        }
        public bool LoginPage(Login allUsers)
        {   
            
            try{
                connection.Open();
                SqlCommand command=new SqlCommand($"select Email,Password from UserDetails",connection);
                SqlDataReader sdr1=command.ExecuteReader();
                while(sdr1.Read())
                {
                    if((Convert.ToString(sdr1["Email"])==allUsers.Email)&&(Convert.ToString(sdr1["Password"])==allUsers.Password))
                    {                        
                        return true;
                    }
            }
            }
            
            catch(SqlException sqlexception)
            {
                Console.WriteLine(sqlexception);
            }
            return false;
            
        } 
        public void Reservation(string? UseriD,string? Bookname,decimal Bookprice)
        {
            Console.WriteLine(UseriD);
            string? name="";
            string? user="";
            try{
                connection.Open();
                SqlCommand command=new SqlCommand($"select Name , UserID from UserDetails where Email='{UseriD}'",connection);
                SqlDataReader sdr1=command.ExecuteReader();
                
                while(sdr1.Read())
                {
                    user=Convert.ToString(sdr1["UserID"]);
                    Console.WriteLine(user);
                    name=Convert.ToString(sdr1["Name"]);
            }
            sdr1.Close();
            DateTime currentDate = DateTime.Now;
            DateTime returnDate = currentDate.AddDays(30);
            SqlCommand insertcommand=new SqlCommand($"insert into Dashboard values('{user}','{name}','{Bookname}','{Bookprice}','{UseriD}','{returnDate}')",connection);
                        insertcommand.ExecuteNonQuery();
                        connection.Close();
            Console.Write(user);
                    
            }
            
            catch(SqlException sqlexception)
            {
                Console.WriteLine(sqlexception);
            }
        } 
        public List<Userbook> ReserveMyBook(string? email)
        {
            List<Userbook> list=new List<Userbook>();
            try{
                connection.Open();
                SqlCommand command=new SqlCommand($"select *from Dashboard where Email='{email}'",connection);
                SqlDataReader sdr1=command.ExecuteReader();
                
                while(sdr1.Read())
                {
                    Console.WriteLine(sdr1["UserID"]);
                    Userbook book=new Userbook();
                    book.UserID=Convert.ToString(sdr1["UserID"]);
                    book.Name=Convert.ToString(sdr1["Name"]);
                    book.BookName=Convert.ToString(sdr1["BookName"]);
                    book.Bookprice=Convert.ToDecimal(sdr1["BookPrice"]);
                    list.Add(book);
                }
            }
            
            catch(SqlException sqlexception)
            {
                Console.WriteLine(sqlexception);
            }
            connection.Close();
            return list;
        }
        public List<Userbook> ReserveMyBookforAdmin()
        {
            List<Userbook> list=new List<Userbook>();
            try{
                connection.Open();
                SqlCommand command=new SqlCommand($"select *from Dashboard",connection);
                SqlDataReader sdr1=command.ExecuteReader();
                
                while(sdr1.Read())
                {
                    Console.WriteLine(sdr1["UserID"]);
                    Userbook book=new Userbook();
                    book.UserID=Convert.ToString(sdr1["UserID"]);
                    book.Name=Convert.ToString(sdr1["Name"]);
                    book.BookName=Convert.ToString(sdr1["BookName"]);
                    book.Bookprice=Convert.ToDecimal(sdr1["BookPrice"]);
                    list.Add(book);
                }
            }
            
            catch(SqlException sqlexception)
            {
                Console.WriteLine(sqlexception);
            }
            connection.Close();
            return list;
        }
        public DataTable getUserRecords(){
            DataTable dataTable=new DataTable();
            try{   
                SqlDataAdapter sqlDataAdapter=new SqlDataAdapter($"SELECT UserID,Name FROM UserDetails",connection);
                sqlDataAdapter.Fill(dataTable);    
            }
            catch(Exception exception){

            }
            return dataTable;
        }
        public void removeUser(string userid){
            Console.WriteLine(userid+"****************");
            DataTable dataTable=new DataTable();
            try{                
                using(SqlCommand command1=new SqlCommand($"DELETE FROM UserDetails WHERE UserID='{userid}'",connection)){
                    connection.Open();
                    command1.ExecuteNonQuery();
                    SqlCommand command2=new SqlCommand($"DELETE FROM Dashboard WHERE UserID='{userid}'",connection);
                    command2.ExecuteNonQuery();
                }
            }
            catch(Exception exception){

            }
        }
    }
}    