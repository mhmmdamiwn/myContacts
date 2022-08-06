using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class ContactRepository : IContactRepository
    {
        private string connection_string = "Data Source=.; Initial Catalog=MyContacts_DB; Integrated Security=true";
        public bool Delete(int ContactID)
        {
            SqlConnection Connection = new SqlConnection(connection_string);
            try
            {
                string query = "Delete From MyContact Where ContactID=@contactID";
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("contactID", ContactID);
                Connection.Open();
                Command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

        }

        public bool Insert(string Name, string Family, string Email, int Age, string Phonenumber)
        {
            SqlConnection Connection = new SqlConnection(connection_string);
            try {
                
                string query = "Insert Into MyContact (Name,Family,Age,Email,Phonenumber) values (@Name,@Family,@Age,@Email,@Phonenumber)";
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@Name", Name);
                Command.Parameters.AddWithValue("@Family", Family);
                Command.Parameters.AddWithValue("@Age", Age);
                Command.Parameters.AddWithValue("@Email", Email);
                Command.Parameters.AddWithValue("@Phonenumber", Phonenumber);
                Connection.Open();
                Command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
            
        }

        public DataTable Search(string alleh)
        {
            SqlConnection Connection = new SqlConnection(connection_string);
            string query = "Select * From MyContact Where Name like @alleh or Family like @alleh";
            SqlDataAdapter Adapter = new SqlDataAdapter(query, Connection);
            Adapter.SelectCommand.Parameters.AddWithValue("@alleh", "%" + alleh + "%");
            DataTable Data = new DataTable();
            Adapter.Fill(Data);
            return Data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MyContact";
            SqlConnection Connection = new SqlConnection(connection_string);
            SqlDataAdapter Adapter = new SqlDataAdapter(query, Connection);
            DataTable Data = new DataTable();
            Adapter.Fill(Data);
            return Data;
        }

        public DataTable SelectRow(int ContactID)
        {
            string query = "Select * From MyContact Where ContactID="+ContactID;
            SqlConnection Connection = new SqlConnection(connection_string);
            SqlDataAdapter Adapter = new SqlDataAdapter(query, Connection);
            DataTable Data = new DataTable();
            Adapter.Fill(Data);
            return Data;
        }

        public bool Update(int ContactID, string Name, string Family, string Email, int Age, string Phonenumber)
        {
            SqlConnection Connection = new SqlConnection(connection_string);
            try
            {

                string query = "Update MyContact Set Name=@Name,Family=@Family,Age=@Age,Email=@Email,Phonenumber=@Phonenumber Where ContactID="+ContactID;
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@Name", Name);
                Command.Parameters.AddWithValue("@Family", Family);
                Command.Parameters.AddWithValue("@Age", Age);
                Command.Parameters.AddWithValue("@Email", Email);
                Command.Parameters.AddWithValue("@Phonenumber", Phonenumber);
                Connection.Open();
                Command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
