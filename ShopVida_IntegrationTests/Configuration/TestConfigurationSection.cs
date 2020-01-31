namespace FrameworkTests.Configuration
{
    using System.Configuration;

	public class TestConfigurationSection : ConfigurationSection
	{
		public static readonly TestConfigurationSection SectionDetails = ConfigurationManager.GetSection("testConfiguration") as TestConfigurationSection;

		[ConfigurationProperty("waitTimeout", IsRequired = true, DefaultValue = "30")]
		public int WaitTimeout
		{
			get { return (int)this["waitTimeout"]; }
		}

		[ConfigurationProperty("screenshotDirectory", IsRequired = false)]
		public string ScreenshotDirectory
		{
			get { return (string)this["screenshotDirectory"]; }
		}
    }
}