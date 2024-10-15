using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace UQMEdit
{
	public class Stars
	{
		public static List<Star> StarList = new List<Star>(510);
		public static bool HasBeenLoaded = false;

		public static string NearestStar(double x, double y) {
			double num = 2147483647.0;
			string text = "";
			foreach (var star in StarList) {
				var num2 =
					Math.Sqrt((x - star.X) * (x - star.X) + (y - star.Y) * (y - star.Y));
				if (num2 < num) {
					num = num2;
					text = star.Name;
				}
			}
			if (text.IndexOf('-') != -1) {
				text = text.Replace("-", "").Substring(1);
			}
			return text;
		}
	}

	public struct Star
	{
		public double X;
		public double Y;
		public string Name;
		public Star(double x, double y, string name) {
			X = x;
			Y = y;
			Name = name;
		}
	}

	public static class ParseStars
	{
		public static object[] LoadStars(bool spoilers) {
			List<object> list = new List<object>();
			var fileStreamStarsAsTxt =
				// Assembly.GetExecutingAssembly().GetManifestResourceStream("UQMEdit.Resources.stars.txt");
				new FileStream("Resources/stars.txt", FileMode.Open);

			using (var streamReader = new StreamReader(fileStreamStarsAsTxt, Encoding.Default))
			{
				streamReader.ReadLine(); // Ignored?
				var text = streamReader.ReadLine();
				var array = text.Split(
					new char[] { '\t' }
				);

				list.Add(
					string.Concat(
						new string[]
						{
							array[0],
							"\t",
							array[1],
							"\t",
							array[2],
							"\t",
							array[3].PadRight(20),
							"\t",
							array[4],
							"\t",
							array[5]
						}
					)
				);

				while ((text = streamReader.ReadLine()) != null)
				{
					array = text.Split(new char[]
					{
						'\t'
					});
					if (array.Length >= 6 && array[4] != "-" && array[4].Split(new char[]
					{
						':'
					}).Length == 2)
					{
						string text2 = string.Concat(new string[]
						{
							array[0].PadRight(20),
							"\t",
							array[1],
							"\t",
							array[2],
							"\t",
							array[3].PadRight(20),
							"\t[ ",
							array[4].Split(new char[]
							{
								':'
							})[0],
							" : ",
							array[4].Split(new char[]
							{
								':'
							})[1],
							" ]"
						});
						if (spoilers)
						{
							text2 = text2 + "\t" + array[5];
						}
						list.Add(text2);

						if (!Stars.HasBeenLoaded)
						{
							Stars.StarList.Add(
								new Star(
									double.Parse(
										array[4].Split(
											new char[] { ':' }
										)[0]
									),
									double.Parse(
										array[4].Split(
											new char[] { ':' }
										)[1]
									),
									array[1] + " " + array[0]
								)
							);
						}
					}
				}

				Stars.HasBeenLoaded = true;
			}
			return list.ToArray();
		}
	}
}
