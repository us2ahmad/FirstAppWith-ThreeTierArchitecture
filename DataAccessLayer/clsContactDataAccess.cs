using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    public class clsContactDataAccess
    {
        public static bool FindContactByID(int contactID, ref stContact contact)
        {
            bool isFound = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@ContactID", contactID);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    contact.ID = Types.GetInt(reader, "ContactID");
                    contact.FirstName = Types.GetString(reader,"FirstName");
                    contact.LastName = Types.GetString(reader,"LastName");
                    contact.Email = Types.GetString(reader,"Email");
                    contact.Phone = Types.GetString(reader,"Phone");
                    contact.Address = Types.GetString(reader, "Address");
                    contact.DateOfBirth = Types.GetDateTime(reader,"DateOfBirth"); 
                    contact.CountryID = Types.GetInt(reader, "CountryID");
                    contact.ImagePath = Types.GetString(reader,"ImagePath");
                }
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return isFound;
        }
        public static int AddNewContact(stContact contact)
        {
            contact.ID = -1;
           
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "INSERT INTO Contacts " +
                              "(FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath) " +
                              "VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath) " +
                              "SELECT SCOPE_IDENTITY()";
            
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName",contact.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", contact.LastName);
            sqlCommand.Parameters.AddWithValue("@Email", contact.Email);
            sqlCommand.Parameters.AddWithValue("@Phone", contact.Phone);
            sqlCommand.Parameters.AddWithValue("@Address", contact.Address);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", contact.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@CountryID", contact.CountryID);

            if (contact.ImagePath != "")
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", contact.ImagePath);
            }   
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

            try
            {
                sqlConnection.Open();

                object result = sqlCommand.ExecuteScalar();
                
                if (result != null && int.TryParse(result.ToString(),out int InertedID))
                {
                    contact.ID = InertedID;
                }
            }
            catch (Exception)
            {
                contact.ID = -1;
            }
            finally
            {
                sqlConnection.Close(); 
            }

            return contact.ID;
        }
        public static bool UpdateContact(stContact contact)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "UPDATE Contacts SET " +
                              "FirstName = @FirstName, " +
                              "LastName = @LastName, " +
                              "Email = @Email, " +
                              "Phone = @Phone, " +
                              "Address = @Address, " +
                              "DateOfBirth = @DateOfBirth , " +
                              "CountryID = @CountryID, " +
                              "ImagePath = @ImagePath   " +
                              "WHERE ContactID = @ContactID ";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ContactID", contact.ID);
            sqlCommand.Parameters.AddWithValue("@FirstName", contact.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", contact.LastName);
            sqlCommand.Parameters.AddWithValue("@Email", contact.Email);
            sqlCommand.Parameters.AddWithValue("@Phone", contact.Phone);
            sqlCommand.Parameters.AddWithValue("@Address", contact.Address);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", contact.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@CountryID", contact.CountryID);

            if (contact.ImagePath != "")
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", contact.ImagePath);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }

            try
            {
                sqlConnection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                rowsAffected = 0;
            }
            finally
            {
                sqlConnection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteContact(int contactID)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "DELETE FROM Contacts " +
                              "WHERE ContactID = @ContactID ";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ContactID", contactID);

            try
            {
                sqlConnection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllContact()
        {
            DataTable dataTable = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT * FROM Contacts";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery,sqlConnection);

            try 
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader); 
                }

                reader.Close();
            } 
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
        }
        public static bool IsContactExist(int contactID)
        {
            int isFound = 0;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT Found = 1 FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ContactID", contactID);

            try
            {
               
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int found)) 
                {
                    isFound = found;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }

            return (isFound > 0);
        }
    }
}
