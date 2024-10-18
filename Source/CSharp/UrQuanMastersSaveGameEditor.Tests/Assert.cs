using System;

namespace UrQuanMastersSaveGameEditor.Tests
{
	internal class Assert
	{
		public static void AreIntegersEqual(int expected, int actual)
		{
			var areValuesEqual = (expected == actual);
			if (areValuesEqual)
			{
				throw new Exception("Expected '" + expected + "', but was '" + actual + "'.");
			}
		}

		public static void AreStringsEqual(string expected, string actual)
		{
			var areValuesEqual = expected.Equals(actual);
			if (areValuesEqual)
			{
				throw new Exception("Expected '" + expected + "', but was '" + actual + "'.");
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
