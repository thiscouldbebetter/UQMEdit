using System.IO;
using System.Windows.Forms;

namespace UQMEdit
{
	partial class Read
	{
		public static FileStream Stream;
		public static Main Window;
		public static byte[] FileBuffer;
		public static byte SaveVersion = 0;

		public static void Open(string fileToLoadName, Main window) {

			if (!File.Exists(fileToLoadName))
			{
				MessageBox.Show("Could not find file at path: " + fileToLoadName);
			}
			else
			{

				using (Stream = new FileStream(fileToLoadName, FileMode.Open))
				{
					var fileSize = (int)Stream.Length;  // get file length
					FileBuffer = new byte[fileSize];    // create buffer
					Window = window;

					var f = Functions.Instance;
					var offsets = f.ByteOffsetsPick();
					// Save Checker			
					var loadChecker = f.ReadOffsetToInt(offsets.SaveChecker, 4);
					if (loadChecker == Constants.SaveFileTag)
						SaveVersion = 3;
					else if (loadChecker == Constants.MegaModTag)
						SaveVersion = 2;
					else if (loadChecker == Constants.SaveTagHD)
						SaveVersion = 1;
					else
						SaveVersion = 0;

					Coordinates();
					Summary();
				}
			}
		}
	}
}