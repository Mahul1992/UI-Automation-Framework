using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public static class DataHelperExtensions
    {
        //Open the DB Connection

        public static SqlConnection DBConnect(this SqlConnection sqlConnection, String connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch(Exception e)
            {
                LogHelpers.Write("Error:: "+e.Message);
            }
            return null;
        }

        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                LogHelpers.Write("Error:: " + e.Message);
            }
        }
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;
            try
            {
                if (sqlConnection == null || sqlConnection!= null && sqlConnection.State==ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                {
                    sqlConnection.Open();

                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataset = new DataSet();
                dataAdapter.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            }
            catch(Exception e)
            {
                dataset = null;   
                sqlConnection.Close();
                LogHelpers.Write("Error:: " + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }
        }
    }
}
