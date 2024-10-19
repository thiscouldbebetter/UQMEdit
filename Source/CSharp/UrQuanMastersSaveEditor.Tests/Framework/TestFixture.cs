
namespace UrQuanMastersSaveEditor.Tests.Framework
{
	internal abstract class TestFixture
	{
		public string Name;
		
		public abstract List<Test> Tests();

		public TestFixture(string name)
		{
			Name = name;
		}

		public void RunTests()
		{
			var tests = Tests();

			Logger.Info($"Test fixture '{Name}', containing {tests.Count} tests, begins.");

			var testsSuccessfulCount = 0;

			foreach (var test in tests)
			{
				var wasTestSuccessful = test.Run();
				if (wasTestSuccessful)
				{
					testsSuccessfulCount++;
				}
			}

			var testsWereAllSuccessful =
				(testsSuccessfulCount == tests.Count);

			if (testsWereAllSuccessful)
			{
				Logger.Info(
					$"Test fixture '{Name}' ends, with all tests successful."
				);
			}
			else
			{
				Logger.Error(
					$"Test fixture '{Name}' ends, with only {testsSuccessfulCount}/{tests.Count} successful."
				);
			}
		}
	}
}
