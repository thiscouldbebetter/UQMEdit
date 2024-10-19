namespace UrQuanMastersSaveEditor.Tests.Framework
{
	internal class Logger
	{
		class Severity
		{
			public const string
				Error = "Error",
				Info = "Info";
		}

		public static void Error(string message)
		{
			var colorSaved = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			LogMessageWithSeverity(message, Severity.Error);
			Console.ForegroundColor = colorSaved;
        }

        public static void Info(string message)
        {
            LogMessageWithSeverity(message, Severity.Info);
        }

        public static void LogMessageWithSeverity(string message, string severity)
		{
			var timestamp = DateTime.UtcNow.ToString("o"); // YYYY-MM-DDTHH:mm:SSz
			var messagePrefixed = $"{timestamp}: {severity}: {message}";
			Console.WriteLine(messagePrefixed);
		}
	}
}
