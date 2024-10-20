
namespace UrQuanMastersSaveEditor.Common
{
	class ByteStreamWriter : IDisposable
	{
		private ByteStream _fileStream;
		private byte[] _fileBuffer;

		public ByteStreamWriter(string fileToWriteName)
		{
			_fileStream =
				// new FileStream(fileToWriteName, FileMode.OpenOrCreate);
				new ByteStream(File.ReadAllBytes(fileToWriteName));

			var fileSize = (int)_fileStream.Length;
			_fileBuffer = new byte[fileSize];
		}

		public byte[] BytesAll()
		{
			return _fileStream.ReadBytesAll();
		}

		private byte[] StringToByteArray(string stringToConvert, int maxLength)
		{
			var charArr = stringToConvert.ToCharArray();
			var bytes = new byte[maxLength];
			for (var i = 0; i < maxLength; i++)
			{
				bytes[i] =
					(i < charArr.Length)
					? Convert.ToByte(charArr[i])
					: (byte)0;
			}
			return bytes;
		}

		public void WriteBytesToOffset(
			byte[] bytesToWrite,
			int offsetToWriteToInBytes
		)
		{
			_fileStream.Seek(offsetToWriteToInBytes);
			foreach (var byteToWrite in bytesToWrite)
			{
				_fileStream.WriteByte(byteToWrite);
			}
		}

		private void WriteDecimalToOffsetWithLengthAndMax(
			decimal valueToWrite,
			int offsetToWriteToInBytes,
			int lengthInBytes,
			uint valueMax,
			bool isUnsignedNotSigned = false
		)
		{
			_fileStream.Seek(offsetToWriteToInBytes);
			if (isUnsignedNotSigned)
			{
				var valueToWriteAsUnsignedInt = decimal.ToUInt32(valueToWrite);
				if (valueToWriteAsUnsignedInt >= valueMax)
				{
					valueToWriteAsUnsignedInt = valueMax;
				}
				_fileBuffer = BitConverter.GetBytes(valueToWriteAsUnsignedInt);
			}
			else
			{
				var valueToWriteAsSignedInt = decimal.ToInt32(valueToWrite);
				if (valueToWriteAsSignedInt >= valueMax)
				{
					valueToWriteAsSignedInt = (int)valueMax;
				}
				_fileBuffer = BitConverter.GetBytes(valueToWriteAsSignedInt);
			}
			_fileStream.Write(_fileBuffer, 0, lengthInBytes);
		}

		public void WriteDecimalToOffsetWithLengthAndMaxSigned(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			int lengthInBytes,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMax(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes, valueMax, isUnsignedNotSigned: false
			);
		}

		public void WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxSigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 2, valueMax
			);
		}

		public void WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxSigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 4, valueMax
			);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxUnsigned(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			int lengthInBytes,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMax(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes, valueMax, isUnsignedNotSigned: true
			);
		}

		public void WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxUnsigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 2, valueMax
			);
		}

		public void WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxUnsigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 4, valueMax
			);
		}

		public void WriteStringToOffsetWithLength(
			string stringToWrite, int offset, int lengthInBytes
		)
		{
			_fileStream.Seek(offset);
			_fileBuffer = StringToByteArray(stringToWrite, lengthInBytes);
			_fileStream.Write(_fileBuffer, 0, lengthInBytes);
		}

		public void Dispose()
		{
			_fileStream.Dispose();
		}
	}
}
