namespace FrameworkTests.Configuration
{
	using FrameworkTests.Utilities.Objects;
	using Microsoft.Extensions.Configuration;
	using System;
	public class TestConfiguration
	{
		public static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local";
		private static IConfigurationRoot Configuration { get; }

		static TestConfiguration()
		{
			Configuration = LoadAppSettings(); 
		}

		public static AppSettings GetAppSettings()
		{
			return Configuration.Get<AppSettings>();
		}

		private static IConfigurationRoot LoadAppSettings()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Env}.json", optional: true)
				.AddEnvironmentVariables();

			return builder.Build();
		}
	}
}