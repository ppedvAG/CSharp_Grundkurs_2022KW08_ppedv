namespace M015_Files;

public class Program
{
	static void Main(string[] args)
	{
		//Desktop Folder (C:\Users\User\Desktop)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path Klasse für alle möglichen Pfad Operationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles mit Ordnern
			Directory.CreateDirectory(folderPath);

		#region StreamWriter
		//StreamWriter zum Schreiben von Files
		StreamWriter sw = new StreamWriter(Path.Combine(folderPath, "M015_Testfile"));
		sw.WriteLine("Test"); //Buffer beschreiben
		sw.Flush(); //Stream in File schreiben
		sw.Close(); //Stream schließen
		sw.Dispose(); //Entfernt den Writer

		//Using: schließt Stream automatisch
		//AutoFlush: schreibt nach jedem WriteLine ins File
		//using StreamWriter swUsing = new StreamWriter(Path.Combine(folderPath, "M015_Usingfile.txt")) { AutoFlush = true };
		//swUsing.WriteLine("Test");
		#endregion

		#region StreamReader
		using StreamReader sr = new StreamReader(Path.Combine(folderPath, "M015_Testfile.txt"));
		List<string> lines = new List<string>(); //File Zeile für Zeile einlesen und in Liste schreiben
		string read = sr.ReadLine();
		while (!sr.EndOfStream) //EndOfStream: schaut ob weitere Daten existieren
		{
			lines.Add(read);
			read = sr.ReadLine();
		}

		sr.ReadToEnd(); //Liest das gesamte File ein
		sr.BaseStream.Position = 0;
		List<string> readToEnd = sr.ReadToEnd().Split(Environment.NewLine).ToList(); //Das gleiche wie oben nur einem Aufruf
		#endregion
	}
}