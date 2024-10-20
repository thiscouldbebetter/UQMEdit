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
					"CoordinatesConvertFromLogToUniverseAndBack_X",
					() => CoordinatesConvertFromLogToUniverseAndBack_X()
				),
				new Test(
					"CoordinatesConvertFromLogToUniverseAndBack_Y",
					() => CoordinatesConvertFromLogToUniverseAndBack_Y()
				),
				new Test(
					"LoadAndSaveGameThenCompareFiles_Initial",
					() => LoadAndSaveGameThenCompareFiles_Initial()
				)
			};
		}

		// Tests.

		private void CoordinatesConvertFromLogToUniverseAndBack_X()
		{
			var coordinateConverter = new CoordinateConverter(0);

			const int logXBefore = 27987;
			var universeX = coordinateConverter.LogXToUniverse(logXBefore);
			const decimal universeXExpected = 175.2M;
			Assert.AreDecimalsEqual(universeXExpected, universeX);
			var logXAfter = coordinateConverter.UniverseToLogX(universeX);
			Assert.AreIntegersEqual(logXBefore, logXAfter);
		}

		private void CoordinatesConvertFromLogToUniverseAndBack_Y()
		{
			var coordinateConverter = new CoordinateConverter(0);

			const int logYBefore = 164141;
			var universeY = coordinateConverter.LogYToUniverse(logYBefore);
			const decimal universeYExpected = 145.0M;
			Assert.AreDecimalsEqual(universeYExpected, universeY);
			var logYAfter = coordinateConverter.UniverseToLogY(universeY);
			Assert.AreIntegersEqual(logYBefore, logYAfter);
		}

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

			Assert.AreByteArraysEqual(
				fileContentsBeforeAsBytes,
				fileContentsAfterAsBytes
			);
		}

	}
}
