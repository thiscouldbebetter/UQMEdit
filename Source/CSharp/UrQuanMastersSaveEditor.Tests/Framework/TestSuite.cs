
namespace UrQuanMastersSaveEditor.Tests.Framework
{
	internal class TestSuite
	{
		private string Name;
		private List<TestFixture> Fixtures;

		public TestSuite(string name, List<TestFixture> fixtures)
		{
			Name = name;
			Fixtures = fixtures;
		}

		public void RunTestFixtures()
		{
			Logger.Info($"Test suite '{Name}', containing {Fixtures.Count} fixtures, begins.");

			foreach (var fixture in Fixtures)
			{
				fixture.RunTests();
			}

			Logger.Info($"Test suite '{Name}' ends.");
		}
	}
}
