using System;
using System.Collections.Generic;

namespace UrQuanMastersSaveGameEditor.Tests
{
	internal class TestFixture
	{
		public string Name;
		public List<Test> Tests;

		public TestFixture(string name, List<Test> tests)
		{
			Name = name;
			Tests = tests;
		}

		public void RunTests()
		{
			Console.WriteLine("Test fixture '" + Name + "' begins at " + DateTime.Now.ToString("o") + ".");

			foreach (var test in Tests)
			{
				test.Run();
			}

			Console.WriteLine("Test fixture '" + Name + "' ends at " + DateTime.Now.ToString("o") + ".");
		}
	}
}
