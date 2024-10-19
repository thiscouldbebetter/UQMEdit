using UrQuanMastersSaveEditor.Common;
using UrQuanMastersSaveEditor.Tests.Framework;

namespace UrQuanMastersSaveEditor.Tests.TestFixtures
{
	internal class TestsAll : TestFixture
	{
		public TestsAll(): base(typeof(TestsAll).Name)
		{
			// todo
		}

		public override List<Test> Tests()
		{
			return new List<Test>()
			{
				new Test(
					"LoadAndSaveGameThenCompareFiles_Initial",
					() => LoadAndSaveGameThenCompareFiles_Initial()
				)
			};
		}

		// Tests.

		private void LoadAndSaveGameThenCompareFiles_Initial()
		{
			const string fileToLoadPath =
				"../../../../../../Samples/Named/01-Start.uqmsave.dat";
			var gameState = GameState.Instance;
			gameState.Open(fileToLoadPath);
			const string fileToSavePath = "LoadedThenSaved.uqmsave.dat";
			gameState.Save(fileToSavePath);

			var fileContentsBeforeAsBytes =
				File.ReadAllBytes(fileToLoadPath);
			var fileContentsAfterAsBytes =
				File.ReadAllBytes(fileToSavePath);

			var fileContentsBeforeAsHexadecimal =
				BitConverter.ToString(fileContentsBeforeAsBytes);
			var fileContentsAfterAsHexadecimal =
				BitConverter.ToString(fileContentsAfterAsBytes);

			Assert.AreStringsEqual(
				fileContentsBeforeAsHexadecimal,
				fileContentsAfterAsHexadecimal
			);
        }

	}
}
