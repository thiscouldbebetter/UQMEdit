namespace UQMEdit
{
	partial class Write
	{
		public static void Coordinates() {

			var f = Functions.Instance;

			int snum;

			// UniverseX
			decimal UniverseX = Window.UniverseX.Value * 10;
			var offsets = f.ByteOffsetsPick();
			snum = f.UniverseToLogX(decimal.ToInt32(UniverseX) );
			f.WriteOffset(
				offsets.LogX,
				valueFromControl: snum,
				lengthInBytes: 4,
				valueMax: 159735
			);

			// UniverseY
			decimal UniverseY = Window.UniverseY.Value * 10;
			snum = f.UniverseToLogY(decimal.ToInt32(UniverseY));
			f.WriteOffset(
				offsets.LogY,
				valueFromControl: snum,
				lengthInBytes: 4,
				valueMax: 191990
			);
		}
	}
}