namespace FrameworkTests.Utilities.Helpers
{
	using System.Collections.Generic;

	public class DictionaryProperties
	{
		public static Dictionary<string, string> Details { get; private set; }

		static DictionaryProperties()
		{
			Details = new Dictionary<string, string>();
		}
	}
}