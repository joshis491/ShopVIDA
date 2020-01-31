namespace FrameworkTests.Utilities.Database
{
	using System;
	using TechTalk.SpecFlow;

	public class QueryBuilder
	{
		private readonly ScenarioContext _scenarioContext;

		public QueryBuilder(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		private static string GetQuoteted(string value)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					return null;
				}
				else
				{
					return "'" + value + "'";
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}