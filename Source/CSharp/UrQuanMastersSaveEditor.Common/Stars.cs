using System.Text;

namespace UrQuanMastersSaveEditor
{
	public class Stars
	{
		public static List<Star> StarsList = new List<Star>(510);
		public static bool HasBeenLoaded = false;

		public static string NearestStar(double x, double y) {
			var num = 2147483647.0;
			var text = "";
			foreach (var star in StarsList)
			{
				var num2 =
					Math.Sqrt((x - star.X) * (x - star.X) + (y - star.Y) * (y - star.Y));
				if (num2 < num)
				{
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
			var list = new List<object>();
			var fileStreamStarsAsTxt =
				// Assembly.GetExecutingAssembly().GetManifestResourceStream("UQMEdit.Resources.stars.txt");
				new FileStream("Resources/stars.txt", FileMode.Open);

			using (var streamReader = new StreamReader(fileStreamStarsAsTxt, Encoding.Default))
			{
				streamReader.ReadLine(); // Ignored?
				var line = streamReader.ReadLine();
				const string tab = "\t";
				var tabAsCharArray = new char[] { '\t' };
				var lineFields = line.Split(tabAsCharArray);

				list.Add(
					string.Concat(
						[
							lineFields[0],
							tab,
							lineFields[1],
							tab,
							lineFields[2],
							tab,
							lineFields[3].PadRight(20),
							tab,
							lineFields[4],
							tab,
							lineFields[5]
						]
					)
				);

				while ((line = streamReader.ReadLine()) != null)
				{
					var colonAsCharArray = new char[] { ':' };
					lineFields = line.Split(tabAsCharArray);
					if
					(
						lineFields.Length >= 6
						&& lineFields[4] != "-"
						&& lineFields[4].Split(colonAsCharArray).Length == 2
					)
					{
						string text2 = string.Concat(
							[
								lineFields[0].PadRight(20),
								tab,
								lineFields[1],
								tab,
								lineFields[2],
								tab,
								lineFields[3].PadRight(20),
								"\t[ ",
								lineFields[4].Split(colonAsCharArray)[0],
								" : ",
								lineFields[4].Split(colonAsCharArray)[1],
								" ]"
							]
						);
						if (spoilers)
						{
							text2 = text2 + "\t" + lineFields[5];
						}
						list.Add(text2);

						if (!Stars.HasBeenLoaded)
						{
							Stars.StarsList.Add(
								new Star(
									double.Parse(
										lineFields[4].Split(colonAsCharArray)[0]
									),
									double.Parse(
										lineFields[4].Split(colonAsCharArray)[1]
									),
									lineFields[1] + " " + lineFields[0]
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
