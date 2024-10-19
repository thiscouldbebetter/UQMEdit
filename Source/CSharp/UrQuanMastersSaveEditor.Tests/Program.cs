using System.Diagnostics;
using UrQuanMastersSaveEditor.Tests.Framework;
using UrQuanMastersSaveEditor.Tests.TestFixtures;

namespace UrQuanMastersSaveEditor.Tests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			new Program().Run();
		}

		public void Run()
		{
			Console.WriteLine("Ur-Quan Masters Save Editor Test Program");
            Console.WriteLine("========================================");

            Logger.Info("Program begins.");

			var testSuite = new TestSuite
			(
				"TestSuite",
				new List<TestFixture>()
				{
					new TestsAll()
				}
			);

			testSuite.RunTestFixtures();

			Logger.Info("Program ends.");

			if (Debugger.IsAttached)
			{
				Console.Write("Press the Enter key to quit.");
				Console.ReadLine();
			}
		}
	}
}
