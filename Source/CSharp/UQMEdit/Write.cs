using System.IO;

namespace UQMEdit
{
	partial class Write
	{
		public static FileStream Stream;
		public static Main Window;
		public static int Num;
		public static uint uNum;
		public static byte[] FileBuffer;

		public static void Save(string fileToWriteToName, Main window)
		{
			using (Stream = new FileStream(fileToWriteToName, FileMode.OpenOrCreate))
			{
				var fileSize = (int)Stream.Length;  // get file length
				FileBuffer = new byte[fileSize];    // create buffer
				Window = window;

				Summary();
				Coordinates();
			}
		}
	}
}