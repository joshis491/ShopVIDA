namespace ShopVidaTests.Utilities.Helpers
{
	using ShopVidaTests.Utilities.Enums;
	using TechTalk.SpecFlow;

	[Binding]
	public class SharedStorage
	{
		private ScenarioContext scenarioContext;

		public SharedStorage(ScenarioContext scenarioContext)
		{
			this.scenarioContext = scenarioContext;
		}

		public void CleanUp()
		{
			scenarioContext.Clear();
		}

		public T GetSharedInfo<T>(ContextTag key)
		{
			return GetSharedInfo<T>(key.ToString());
		}

		public T GetSharedInfo<T>(string key)
		{
			return scenarioContext.Get<T>(key);
		}

		public void SetSharedInfo(ContextTag key, object obj)
		{
			SetSharedInfo(key.ToString(), obj);
		}

		public void SetSharedInfo(string key, object obj)
		{
			scenarioContext.Add(key, obj);
		}

		public void RemoveSharedInfo(ContextTag key)
		{
			RemoveSharedInfo(key.ToString());
		}

		public void RemoveSharedInfo(string key)
		{
			if (scenarioContext.ContainsKey(key))
			{
				scenarioContext.Remove(key);
			}
		}

		public void ResetSharedInfo(ContextTag key, object obj)
		{
			ResetSharedInfo(key.ToString(), obj);
		}

		public void ResetSharedInfo(string key, object obj)
		{
			RemoveSharedInfo(key);
			SetSharedInfo(key, obj);
		}
	}
}