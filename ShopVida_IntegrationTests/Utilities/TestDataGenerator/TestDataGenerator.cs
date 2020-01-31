namespace ShopVidaTests.Utilities.TestDataGenerator
{
	using RandomNameGeneratorLibrary;
	using ShopVidaTests.Utilities.TestDataGenerator.BaseGenerators;

	public static class TestDataGenerator
	{
		public static PersonNameGenerator Name => new PersonNameGenerator();

		public static PlaceNameGenerator Place => new PlaceNameGenerator();

		public static string PhoneNumber => Faker.Phone.Number();

		public static NumberGenerator Number => new NumberGenerator();

		public static StringGenerator String => new StringGenerator();
	}
}