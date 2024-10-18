using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UrQuanMastersSaveGameEditor.Tests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			new Program().Run();
		}

		public void Run()
		{
			Console.WriteLine("Program begins at " + DateTime.Now.ToString("o") + ".");

			var testSuite = new TestSuite
			(
				"TestSuite",
				new List<TestFixture>()
				{
					new TestFixture
					(
						"Tests",
						new List<Test>()
						{
							new Test("AlwaysFail", () => alwaysFail() )
						}
					)
				}
			);

			testSuite.RunTestFixtures();

			Console.WriteLine("Program ends at " + DateTime.Now.ToString("o") + ".");

			if (Debugger.IsAttached)
			{
				Console.Write("Press the Enter key to quit.");
				Console.ReadLine();
			}
		}

		private void alwaysFail()
		{
			Assert.IsTrue(false);
		}
	}
}
