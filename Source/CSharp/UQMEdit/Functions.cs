using System;
using System.IO;

namespace UQMEdit
{
	class Functions
	{
		public static Functions Instance = new Functions();

		public byte[] StringToByteArray(string stringToConvert, int maxLength)
		{
			var charArr = stringToConvert.ToCharArray();
			var bytes = new byte[maxLength];
			for (int i = 0; i < maxLength; i++) {
				if (i < charArr.Length)
					bytes[i] = Convert.ToByte(charArr[i]);
				else
					bytes[i] = 0;
			}
			return bytes;
		}

		public byte[] ReadBytesFromOffsetToLength(int offsetInBytes, int lengthInBytes, bool isReversed = false)
		{
			Read.Stream.Seek(offsetInBytes, !isReversed ? SeekOrigin.Begin : SeekOrigin.End);
			Read.Stream.Read(Read.FileBuffer, 0, lengthInBytes);
			return Read.FileBuffer;
		}

		public int ReadOffsetToInt(
			int offsetInBytes, int lengthInBytes, int bitWidth = 32, bool isReversed = false
		)
		{
			var bytesRead = ReadBytesFromOffsetToLength(offsetInBytes, lengthInBytes, isReversed);
			int query =
				(bitWidth == 16)
				? BitConverter.ToUInt16(bytesRead, 0)
				: BitConverter.ToInt32(bytesRead, 0);
			return query;
		}
		public bool ReadGameStateFromOffset(int offsetInBytes) {
			bool wasReadSuccessful;
			var gameStateAsBytes = ReadBytesFromOffsetToLength(offsetInBytes, 1);
			wasReadSuccessful = (gameStateAsBytes[0] > 0);
			return wasReadSuccessful;
		}

		public void WriteOffset(
			int offsetInBytes,
			decimal valueFromControl,
			int lengthInBytes,
			uint valueMax,
			bool isUnsignedNotSigned = false
		) {
			Write.Stream.Seek(offsetInBytes, SeekOrigin.Begin);
			if (isUnsignedNotSigned) {
				Write.uNum = decimal.ToUInt32(valueFromControl);
				if (Write.uNum >= valueMax) {
					Write.uNum = valueMax;
				}
				Write.FileBuffer = BitConverter.GetBytes(Write.uNum);
			} else {
				Write.Num = decimal.ToInt32(valueFromControl);
				if (Write.Num >= valueMax) {
					Write.Num = (int)valueMax;
				}
				Write.FileBuffer = BitConverter.GetBytes(Write.Num);
			}
			Write.Stream.Write(Write.FileBuffer, 0, lengthInBytes);
		}

		public void WriteOffsetString(int offset, string stringToWrite, int lengthInBytes) {
			Write.Stream.Seek(offset, SeekOrigin.Begin);
			Write.FileBuffer = StringToByteArray(stringToWrite, lengthInBytes);
			Write.Stream.Write(Write.FileBuffer, 0, lengthInBytes);
		}

		public int ByteOffsetsPick(int highDefinitionRemaster, int megaMod, int core = 0) {
			switch (Read.SaveVersion) {
				case 0:
					return (highDefinitionRemaster - 48);
				case 1:
					return highDefinitionRemaster;
				case 2:
					return megaMod;
				case 3:
					return (core > 0 ? core : megaMod);
				default:
					return (highDefinitionRemaster - 48);
			}
		}

		public int HSCoordChecker(int valueOld, int valueNew) {
			if (Read.SaveVersion == 0 || Read.SaveVersion == 3)
				return valueOld;
			else
				return valueNew;
		}

		public int RoundingError(int div) {
			return (div >> 1);
		}

		public int LogXToUniverse(int logX) {
			int UniverseUnits = HSCoordChecker(Constants.UniverseUnitsOld, Constants.UniverseUnits);
			int LogUnits = HSCoordChecker(Constants.LogUnitsXOld, Constants.LogUnits);
			return (logX * UniverseUnits + RoundingError(LogUnits)) / LogUnits;
		}
		public int LogYToUniverse(int logY) {
			int LogUnits = HSCoordChecker(Constants.LogUnitsYOld, Constants.LogUnits);
			return Constants.MaxUniverse - ((logY * Constants.UniverseUnits + RoundingError(LogUnits)) / LogUnits);
		}

		public int UniverseToLogX(int universeX) {
			universeX -= HSCoordChecker(3, 0);
			// todo - Is this right?
			var universeUnits = HSCoordChecker(Constants.UniverseUnitsOld, Constants.UniverseUnits);
			var logUnits = HSCoordChecker(Constants.LogUnitsXOld, Constants.LogUnits);
			return (universeX * Constants.LogUnits + RoundingError(Constants.UniverseUnits)) / Constants.UniverseUnits;
		}
		public int UniverseToLogY(int universeY) {
			int LogUnits = HSCoordChecker(Constants.LogUnitsYOld, Constants.LogUnits);
			return ((Constants.MaxUniverse - universeY) * LogUnits + RoundingError(Constants.UniverseUnits)) / Constants.UniverseUnits;
		}
	}
}