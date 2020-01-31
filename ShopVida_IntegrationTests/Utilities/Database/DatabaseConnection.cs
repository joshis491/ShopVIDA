namespace FrameworkTests.Utilities.Database
{
	using FrameworkTests.Utilities.Helpers;
	using System;
	using System.Data;
	using System.Data.SqlClient;

	public class DatabaseConnection
	{
		public static void ExecuteQuery(string queryString, string connectionString)
		{
			SqlDataAdapter sqlDataAdapter = null;
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					sqlDataAdapter = new SqlDataAdapter(queryString, sqlConnection);
					sqlDataAdapter.SelectCommand.CommandTimeout = 10000;
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable.Columns.Count; j++)
						{
							if (dataTable.Rows.Count < 2)
							{
								if (!DictionaryProperties.Details.ContainsKey("Database " + dataTable.Columns[j].ColumnName))
								{
									DictionaryProperties.Details.Add("Database " + dataTable.Columns[j].ColumnName, Convert.ToString(dataTable.Rows[i][j]));
								}
								else
								{
									DictionaryProperties.Details["Database " + dataTable.Columns[j].ColumnName] = Convert.ToString(dataTable.Rows[i][j]);
								}
							}
							else
							{
								if (!DictionaryProperties.Details.ContainsKey(i + "_Database " + dataTable.Columns[j].ColumnName))
								{
									DictionaryProperties.Details.Add(i + "_Database " + dataTable.Columns[j].ColumnName, Convert.ToString(dataTable.Rows[i][j]));
								}
								else
								{
									DictionaryProperties.Details[i + "_Database " + dataTable.Columns[j].ColumnName] = Convert.ToString(dataTable.Rows[i][j]);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}