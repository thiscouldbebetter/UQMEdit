
namespace UrQuanMastersSaveEditor.Common
{
	internal class ByteStream : IDisposable
	{
		private long _byteCurrentIndex;
		private byte[] _bytes;

		public ByteStream(byte[] bytes)
		{
			_bytes = bytes;
			_byteCurrentIndex = 0;
		}

		public long Length { get; }

		public byte ReadByte()
		{
			var byteRead = _bytes[_byteCurrentIndex];
			_byteCurrentIndex++;
			return byteRead;
		}

		public void Seek(long offsetToSeekTo)
		{
			_byteCurrentIndex = offsetToSeekTo;
		}

		public void Write(
			byte[] byteBuffer, long offsetWithinBytesToWrite, long lengthToWriteInBytes
		)
		{
			for (var i = 0; i < lengthToWriteInBytes; i++)
			{
				var offset = offsetWithinBytesToWrite + i;
				var byteToWrite = byteBuffer[offset];
				WriteByte(byteToWrite);
			}
		}

		public void WriteByte(byte byteToWrite)
		{
			_bytes[_byteCurrentIndex] = byteToWrite;
			_byteCurrentIndex++;
		}

		// IDisposable.

		public void Dispose()
		{
			// Do nothing.
		}

	}
}
