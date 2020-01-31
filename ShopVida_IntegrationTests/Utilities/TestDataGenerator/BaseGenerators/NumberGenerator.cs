namespace ShopVidaTests.Utilities.TestDataGenerator.BaseGenerators
{
	using static Faker.RandomNumber;
	public class NumberGenerator
	{
		public int RandomNumber() => Next();

		public int RandomNumber(int max) => Next(max);

		public int RandomNumber(int min, int max) => Next(min, max);
	}
}