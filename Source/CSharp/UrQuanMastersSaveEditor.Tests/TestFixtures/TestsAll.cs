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
			// Copy the sample file to the working directory.
			const string fileToCopyPath =
				"../../../../../../Samples/Named/01-Start.uqmsave.dat";
			const string fileToLoadThenSavePath = "LoadedThenSaved.uqmsave.dat";

			var fileContentsBeforeAsBytes =
				File.ReadAllBytes(fileToCopyPath);

			File.WriteAllBytes(fileToLoadThenSavePath, fileContentsBeforeAsBytes);

			// Load from and then save to that file.

			var gameState = GameState.Instance;
			gameState.Open(fileToLoadThenSavePath);
			gameState.Save(fileToLoadThenSavePath);

			// Compare the resaved file to the original.

			var fileContentsAfterAsBytes =
				File.ReadAllBytes(fileToLoadThenSavePath);

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
