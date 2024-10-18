using System;

namespace UrQuanMastersSaveGameEditor.Tests
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

			Console.WriteLine("Test '" + Name + "' begins at " + DateTime.Now.ToString("o") + ".");

			try
			{
				_run();
				wasSuccessful = true;
				Console.WriteLine("Test passed.");
			}
			catch (Exception ex)
			{
				wasSuccessful = false;
				Console.WriteLine("Test failed with exception: " + ex.Message);
			}

			Console.WriteLine("Test '" + Name + "' ends at " + DateTime.Now.ToString("o") + ".");

			return wasSuccessful;
		}
	}
}
