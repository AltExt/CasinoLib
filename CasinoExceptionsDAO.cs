using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CasinoLib
{
	public class CasinoExceptionsDAO
	{
		private string ConnectionString { get; set; }

		public CasinoExceptionsDAO() 
		{
			ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlackJackBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
		}

		public void LogExceptionToDB(Exception ex)
		{
			string queryString =	"INSERT INTO ExceptionTable" +
									"(ExceptionType, ExceptionMessage, TimeStamp)" +
									"VALUES" +
									"(@ExceptionType, @ExceptionMessage, @TimeStamp)";

			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);

				command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
				command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
				command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

				command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
				command.Parameters["@ExceptionMessage"].Value = ex.Message;
				command.Parameters["@TimeStamp"].Value = DateTime.Now;

				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void AdminCall()
		{
			List<ExceptionEntity> Exceptions = ReadExceptions();

			Console.WriteLine("List contains " + Exceptions.Count.ToString());

			for (int i = 0; i < Exceptions.Count; i++)
			{
				Exceptions[i].PrintToConsole();
			}
		}

		private List<ExceptionEntity> ReadExceptions()
		{
			Console.WriteLine("ReadExceptions() Called");

			string queryString = @"SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM ExceptionTable";
			List<ExceptionEntity> output = new List<ExceptionEntity>();
			Console.WriteLine("Going to using bracket");

			using(SqlConnection connection = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ExceptionEntity e = new ExceptionEntity
					{
						ID = Convert.ToInt32(reader["ID"]),
						ExceptionType = reader["ExceptionType"].ToString(),
						ExceptionMessage = reader["ExceptionMessage"].ToString(),
						TimeStamp = Convert.ToDateTime(reader["TimeStamp"])
					};
					output.Add(e);
				}
				connection.Close();
			}
			Console.WriteLine("out");
			return output;
		}
	}
}
