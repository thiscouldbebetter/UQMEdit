﻿using System.Text;

namespace UQMEdit
{
	partial class Read
	{
		public static void Coordinates()
		{
			var f = Functions.Instance;

			// X Coordinates
			decimal LogX = f.LogXToUniverse(
				f.ReadOffsetToInt(
					f.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.LogX,
						Offsets.MegaModFieldOffsets.LogX
					),
					lengthInBytes: 4
				)
			);
			Window.UniverseX.Value = LogX / 10;

			// Y Coordinates
			decimal LogY = f.LogYToUniverse(
				f.ReadOffsetToInt(
					f.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.LogY,
						Offsets.MegaModFieldOffsets.LogY
					),
					lengthInBytes: 4
				)
			);
			Window.UniverseY.Value = LogY / 10;

			// Status
			var statusAsByte = f.ReadBytesFromOffsetToLength(
				f.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Status,
					Offsets.MegaModFieldOffsets.Status,
					Offsets.Core.Status
				),
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
						f.ByteOffsetsPick(
							Offsets.HighDefinitionRemaster.NearestPlanet,
							Offsets.MegaModFieldOffsets.NearestPlanet
						),
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
