using System.Text;

namespace UQMEdit
{
	partial class Read
	{
		public static void Coordinates()
		{
			var f = Functions.Instance;

			var offsets = f.ByteOffsetsPick();

			// X Coordinates
			decimal LogX = f.LogXToUniverse(
				f.ReadOffsetToInt(
					offsets.LogX,
					lengthInBytes: 4
				)
			);
			Window.UniverseX.Value = LogX / 10;

			// Y Coordinates
			decimal LogY = f.LogYToUniverse(
				f.ReadOffsetToInt(
					offsets.LogY,
					lengthInBytes: 4
				)
			);
			Window.UniverseY.Value = LogY / 10;

			// Status
			var statusAsByte = f.ReadBytesFromOffsetToLength(
				offsets.Status,
				lengthInBytes: 1
			)[0];

			if (statusAsByte < 0 || statusAsByte >= Constants.StatusNames.Length)
			{
				Window.CurrentStatus.SelectedIndex = 9;
			}
			else
			{
				Window.CurrentStatus.SelectedIndex = statusAsByte;
			}

			// Planet Orbit
			if (statusAsByte == 7 || statusAsByte == 8)
			{
				var planet = Encoding.Default.GetString(
					f.ReadBytesFromOffsetToLength(
						offsets.NearestPlanet,
						16
					)
				);
				Window.NearestPlanet.Text = planet;
			}
			else
			{
				Window.NearestPlanet.Text = "Not In Orbit";
			}
		}
	}
}
