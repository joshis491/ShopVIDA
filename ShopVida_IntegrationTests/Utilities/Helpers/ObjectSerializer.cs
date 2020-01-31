namespace ShopVidaTests.Utilities.Helpers
{
	using Newtonsoft.Json;

	public static class ObjectSerializer
	{
		public static string SerializeToJson(this object data)
		{
			return JsonConvert.SerializeObject(data);
		}

		public static T DeserializeToObject<T>(this string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}