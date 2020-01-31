namespace ShopVidaTests.Utilities.Helpers
{
	using System.IO;
	using System.Reflection;

	public class DataFiles
	{
		private static readonly string ApiDataFilesDir = "/Data/API/";

		private static readonly string DataFilesDir = "/Data/";

        public static string ReadJsonApiFile(string fileName)
		{
			return File.ReadAllText(GetApiDataFilePath(fileName));
		}

		public static string ReadJsonDataFile(string fileName)
		{
			return File.ReadAllText(GetDataFilePath(fileName));
		}

		public static string GetApiDataFilePath(string fileName)
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + ApiDataFilesDir + fileName;
		}

		public static string GetDataFilePath(string fileName)
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DataFilesDir + fileName;
		}
	}
}