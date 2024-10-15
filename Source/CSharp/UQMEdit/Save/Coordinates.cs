namespace UQMEdit
{
	partial class Write
	{
		public static void Coordinates() {
			int snum;

			// UniverseX
			decimal UniverseX = Window.UniverseX.Value * 10;
			snum = Functions.UniverseToLogX(decimal.ToInt32(UniverseX) );
			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.LogX,
					Offsets.MegaModFieldOffsets.LogX
				),
				valueFromControl: snum,
				lengthInBytes: 4,
				valueMax: 159735
			);

			// UniverseY
			decimal UniverseY = Window.UniverseY.Value * 10;
			snum = Functions.UniverseToLogY(decimal.ToInt32(UniverseY));
			Functions.WriteOffset(
				Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.LogY, Offsets.MegaModFieldOffsets.LogY), snum, 4, 191990
			);
		}
	}
}