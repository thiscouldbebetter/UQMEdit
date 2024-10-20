
namespace UrQuanMastersSaveEditor.Tests.Framework
{
	internal class Assert
	{
		public static void AreByteArraysEqual(byte[] expected, byte[] actual)
		{
			if (expected == null)
			{
				if (actual != null)
				{
					throw new Exception("Expected null, but was not null.");
				}
			}
			else if (actual == null)
			{
				throw new Exception("Expected not null, but was null.");
			}
			else
			{
				int i;
				for (i = 0; i < expected.Length; i++)
				{
					var byteExpected = expected[i];
					var byteActual = actual[i];
					if (byteActual != byteExpected)
					{
						break;
					}
				}

				if (i < expected.Length)
				{
					throw new Exception(
						$"The byte arrays were expected to be equal, but they only matched until byte {i}."
					);
				}
			}
		}

		public static void AreDecimalsEqual(decimal expected, decimal actual)
		{
			var areValuesEqual = (expected == actual);
			if (areValuesEqual == false)
			{
				throw new Exception("Expected '" + expected + "', but was '" + actual + "'.");
			}
		}

		public static void AreIntegersEqual(int expected, int actual)
		{
			var areValuesEqual = (expected == actual);
			if (areValuesEqual == false)
			{
				throw new Exception("Expected '" + expected + "', but was '" + actual + "'.");
			}
		}

		public static void AreStringsEqual(string expected, string actual)
		{
			var areValuesEqual = expected.Equals(actual);
			if (areValuesEqual == false)
			{
				if (expected == null || actual == null)
				{
					throw new Exception("Exactly one of the strings was null.");
                }
				else
				{
					int i;
					for (i = 0; i < expected.Length; i++)
					{
						var charExpected = expected[i];
						var charActual = actual[i];
						if (charActual != charExpected)
						{
							break;
						}
					}

					throw new Exception(
						$"Expected equal, but only matched until character {i}."
					);
				} 
			}
		}

		public static void IsFalse(bool valueToCheck)
		{
			if (valueToCheck != false)
			{
				throw new Exception("Expected false, but was not false.");
			}
		}

		public static void IsNotNull(object valueToCheck)
		{
			if (valueToCheck == null)
			{
				throw new Exception("Expected not null, but was null.");
			}
		}

		public static void IsNull(object valueToCheck)
		{
			if (valueToCheck != null)
			{
				throw new Exception("Expected null, but was not null.");
			}
		}

		public static void IsTrue(bool valueToCheck)
		{
			if (valueToCheck != true)
			{
				throw new Exception("Expected true, but was not true.");
			}
		}
	}
}
