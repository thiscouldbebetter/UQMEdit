namespace UQMEdit
{
	partial class Write
	{
		public static void Coordinates() {

            var f = Functions.Instance;

            int snum;

			// UniverseX
			decimal UniverseX = Window.UniverseX.Value * 10;
			snum = f.UniverseToLogX(decimal.ToInt32(UniverseX) );
			f.WriteOffset(
				f.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.LogX,
					Offsets.MegaModFieldOffsets.LogX
				),
				valueFromControl: snum,
				lengthInBytes: 4,
				valueMax: 159735
			);

			// UniverseY
			decimal UniverseY = Window.UniverseY.Value * 10;
			snum = f.UniverseToLogY(decimal.ToInt32(UniverseY));
			f.WriteOffset(
				f.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.LogY,
					Offsets.MegaModFieldOffsets.LogY
				),
				valueFromControl: snum,
				lengthInBytes: 4,
				valueMax: 191990
			);
		}
	}
}