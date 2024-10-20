namespace UrQuanMastersSaveEditor.Common
{
	public class CoordinateConverter
	{
		private readonly int _gameStateSaveVersion;

		public CoordinateConverter(int gameStateSaveVersion)
		{
			_gameStateSaveVersion = gameStateSaveVersion;
		}

		private int ChooseBewtweenValuesBasedOnSaveVersion(int valueOld, int valueNew)
		{
			return
				(_gameStateSaveVersion == 0 || _gameStateSaveVersion == 3)
				? valueOld
				: valueNew;
		}

		private int HalveIntegerWithRightShift(int integerToRound)
		{
			return (integerToRound >> 1);
		}

		public decimal LogXToUniverse(int logX)
		{
			var universeUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.UniverseUnitsOld, Constants.UniverseUnits
			);

			var logUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.LogUnitsXOld, Constants.LogUnits
			);

			var workingValue =
				Math.Round(
					(double)logX
					/ (double)logUnits
					* universeUnits
				) / 10;

			var returnValue = (decimal)workingValue;

			return returnValue;
		}

		public decimal LogYToUniverse(int logY)
		{
			var universeUnits =
				Constants.UniverseUnits;
				//ChooseBewtweenValuesBasedOnSaveVersion(Constants.UniverseUnitsOld, Constants.UniverseUnits);

			var logUnits =
				ChooseBewtweenValuesBasedOnSaveVersion(
					Constants.LogUnitsYOld, Constants.LogUnits
				);
			var logUnitsHalved = HalveIntegerWithRightShift(logUnits);

			var workingValue = logY;
			workingValue *= universeUnits;
			workingValue += logUnitsHalved;
			workingValue /= logUnits;
			workingValue = Constants.MaxUniverse - workingValue;
			workingValue /= 10;

			var returnValue = workingValue;

			return returnValue;
		}

		public int UniverseToLogX(decimal universeX)
		{
			var universeUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.UniverseUnitsOld, Constants.UniverseUnits
			);

			var logUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.LogUnitsXOld, Constants.LogUnits
			);

			var workingValue =
				Math.Round((double)universeX * 10 * logUnits / universeUnits);

			var returnValue = (int)workingValue;

			return returnValue;
		}

		public int UniverseToLogY(decimal universeY)
		{
			var universeUnits =
				Constants.UniverseUnits;
				//ChooseBewtweenValuesBasedOnSaveVersion(Constants.UniverseUnitsOld, Constants.UniverseUnits);

			int logUnits =
				ChooseBewtweenValuesBasedOnSaveVersion(
					Constants.LogUnitsYOld, Constants.LogUnits
				);
			var logUnitsHalved = HalveIntegerWithRightShift(logUnits);

			double workingValue = (double)universeY;
			workingValue *= 10;
			workingValue -= Constants.MaxUniverse;
			workingValue *= -1;
			workingValue *= logUnits;
			workingValue -= logUnitsHalved;
			workingValue /= universeUnits;
			var returnValue = (int)Math.Round(workingValue);

			return returnValue;
		}

	}
}