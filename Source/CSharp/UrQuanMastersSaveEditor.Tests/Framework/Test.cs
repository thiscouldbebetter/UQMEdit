
namespace UrQuanMastersSaveEditor.Tests.Framework
{
	internal class Test
	{
		private string Name;
		private Action _run;

		public Test(string name, Action run)
		{
			Name = name;
			_run = run;
		}

		public bool Run()
		{
			bool wasSuccessful;

			Logger.Info($"Test '{Name}' begins.");

			try
			{
				_run();
				wasSuccessful = true;
				Logger.Info("Test passes.");
			}
			catch (Exception ex)
			{
				wasSuccessful = false;
				Logger.Error("Test fails with exception: " + ex.Message);
			}

			Logger.Info($"Test '{Name}' ends.");

			return wasSuccessful;
		}
	}
}
