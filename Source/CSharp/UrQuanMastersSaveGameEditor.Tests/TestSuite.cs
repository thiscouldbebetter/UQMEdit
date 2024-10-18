using System;
using System.Collections.Generic;

namespace UrQuanMastersSaveGameEditor.Tests
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
			Console.WriteLine("Test suite '" + Name + "' begins at " + DateTime.Now.ToString("o") + ".");
			foreach (var fixture in Fixtures)
			{
				fixture.RunTests();
			}
			Console.WriteLine("Test suite '" + Name + "' ends at " + DateTime.Now.ToString("o") + ".");
		}
	}
}
