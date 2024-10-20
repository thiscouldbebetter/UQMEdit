﻿
namespace UrQuanMastersSaveEditor.Common
{
	class ByteStreamReader : IDisposable
	{
		private ByteStream _fileStream;

		public ByteStreamReader(string fileToReadName)
		{
			_fileStream =
				// new FileStream(fileToReadName, FileMode.Open);
				new ByteStream(File.ReadAllBytes(fileToReadName));
		}

		public byte ReadByteFromOffset(int offsetInBytes)
		{
			return ReadBytesFromOffsetWithLength(offsetInBytes, 1)[0];
		}

		public byte[] ReadBytesFromOffsetWithLength(
			int offsetInBytes, int lengthInBytes
		)
		{
			var bytesRead = new byte[lengthInBytes];
			_fileStream.Seek(offsetInBytes);
			for (var i = 0; i < lengthInBytes; i++)
			{
				bytesRead[i] = _fileStream.ReadByte();
			}
			return bytesRead;
		}

		public int ReadIntegerFromOffsetWithLength(
			int offsetInBytes,
			int lengthInBytes,
			bool convertToUnsigned16BitNotSigned32BitInteger = false
		)
		{
			var bytesRead = ReadBytesFromOffsetWithLength(offsetInBytes, lengthInBytes);
			int query =
				convertToUnsigned16BitNotSigned32BitInteger
				? BitConverter.ToUInt16(bytesRead, 0)
				: BitConverter.ToInt32(bytesRead, 0);
			return query;
		}

		public int ReadIntegerFromOffsetWithLength16BitUnsigned(
			int offsetInBytes, int lengthInBytes
		)
		{
			return ReadIntegerFromOffsetWithLength(
				offsetInBytes, lengthInBytes, convertToUnsigned16BitNotSigned32BitInteger: true
			);
		}

		public int ReadIntegerFromOffset32BitSigned(
			int offsetInBytes
		)
		{
			return ReadIntegerFromOffsetWithLength(
				offsetInBytes, lengthInBytes: 4, convertToUnsigned16BitNotSigned32BitInteger: false
			);
		}

		// IDisposable.

		public void Dispose()
		{
			_fileStream.Dispose();
		}
	}
}
