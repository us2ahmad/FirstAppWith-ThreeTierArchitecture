using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsCountryDataAccess
    {
        public static bool FindCountryByID(int countryID, ref string countryName, ref string code, ref string phoneCode)
        {
            bool isFound = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@CountryID", countryID);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    countryName = Types.GetString(reader, "CountryName");
                    code = Types.GetString(reader, "Code");
                    phoneCode = Types.GetString(reader, "PhoneCode");
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
        public static bool FindCountryByName(ref int countryID, ref string countryName, ref string code, ref string phoneCode)
        {
            bool isFound = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.Parameters.AddWithValue("@CountryName", countryName);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    countryID = Types.GetInt(reader, "CountryID");
                    countryName = Types.GetString(reader, "CountryName");
                    code = Types.GetString(reader, "Code");
                    phoneCode = Types.GetString(reader, "PhoneCode");
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
        public static int AddNewCountry(string countryName, string code, string phoneCode)
        {

            int ID = -1;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "INSERT INTO Countries " +
                              "(CountryName,Code,PhoneCode)" +
                              "VALUES (@CountryName,@Code,@PhoneCode) " +
                              "SELECT SCOPE_IDENTITY()";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryName", countryName);

            if (code != "")
            {
                sqlCommand.Parameters.AddWithValue("@Code", code);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Code", DBNull.Value);
            }
            if (phoneCode != "")
            {
                sqlCommand.Parameters.AddWithValue("@PhoneCode", phoneCode);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@PhoneCode", DBNull.Value);
            }
            try
            {
                sqlConnection.Open();

                object result = sqlCommand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InertedID))
                {
                    ID = InertedID;
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

            return ID;
        }
        public static bool UpdateCountry(int countryID, string countryName, string code, string phoneCode)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "UPDATE Countries SET " +
                              "CountryName = @CountryName, " +
                              "Code = @Code, " +
                              "PhoneCode = @PhoneCode " +
                              "WHERE CountryID = @CountryID ";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryID", countryID);
            sqlCommand.Parameters.AddWithValue("@CountryName", countryName);

            if (code != "")
            {
                sqlCommand.Parameters.AddWithValue("@Code", code);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Code", DBNull.Value);
            }

            if (phoneCode != "")
            {
                sqlCommand.Parameters.AddWithValue("@PhoneCode", phoneCode);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@PhoneCode", DBNull.Value);
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
        public static bool DeleteCountry(int countryID)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "DELETE FROM Countries " +
                              "WHERE CountryID = @CountryID ";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CountryID", countryID);

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
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT * FROM Countries";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

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
        public static bool IsCountryExist(int countryID)
        {
            int isFound = 0;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT Found = 1 FROM Countries WHERE CountryID = @CountryID";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CountryID", countryID);

            try
            {

                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int found))
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
        public static bool IsCountryExist(string countryName)
        {
            int isFound = 0;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string sqlQuery = "SELECT Found = 1 FROM Countries WHERE CountryName = @CountryName";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CountryName", countryName);

            try
            {

                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int found))
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
