using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.Serialization.Formatters.Binary;

namespace M015_Files;

public class Program
{
	public static void Main(string[] args)
	{
		//Desktop Folder (C:\Users\User\Desktop)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path Klasse für alle möglichen Pfad Operationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles mit Ordnern
			Directory.CreateDirectory(folderPath);

		#region StreamWriter
		//StreamWriterTest();
		#endregion

		#region StreamReader
		//StreamReaderTest();
		#endregion

		//File.WriteAllText(Path.Combine(folderPath, "M015_Testfile"), "Test"); //File schreiben
		//File.ReadAllLines(Path.Combine(folderPath, "M015_Testfile")); //File lesen

		#region JSON
		string jsonPath = Path.Combine(folderPath, "M015_JSON.txt");
		Fahrzeug f = new Fahrzeug() { Automarke = "BMW", MaxGeschwindigkeit = 300 };

		//JSON schreiben
		File.WriteAllText(jsonPath, JsonConvert.SerializeObject(f));

		//JSON lesen
		Fahrzeug read = JsonConvert.DeserializeObject<Fahrzeug>(File.ReadAllText(jsonPath));
		#endregion

		#region CSV
		//CSV parser
		TextFieldParser csvParser = new TextFieldParser(Path.Combine(folderPath, "Test.csv"));
		csvParser.SetDelimiters(";"); //Delimiter um Felder zu trennen
		List<string[]> lines = new List<string[]>();
		while (!csvParser.EndOfData)
		{
			lines.Add(csvParser.ReadFields()); //Alle Felder lesen
		}

		List<string> column = lines.Select(e => e[1]).ToList(); //Einzelne Spalte nehmen
		#endregion

		#region Binary Serialization
		//Output unleserlich machen
		BinaryFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(Path.Combine(folderPath, "BinaryTest.txt"), FileMode.Create);
		formatter.Serialize(stream, f); //Speichert das Objekt ins File (Binär serialisiert)

		stream.Position = 0;
		Fahrzeug binFahrzeug = formatter.Deserialize(stream) as Fahrzeug; //Fahrzeug wieder einlesen aus File
		#endregion
	}

	public static void StreamWriterTest()
	{
		//Desktop Folder (C:\Users\User\Desktop)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path Klasse für alle möglichen Pfad Operationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles mit Ordnern
			Directory.CreateDirectory(folderPath);

		//StreamWriter zum Schreiben von Files
		StreamWriter sw = new StreamWriter(Path.Combine(folderPath, "M015_Testfile"));
		sw.WriteLine("Test"); //Buffer beschreiben
		sw.Flush(); //Stream in File schreiben
		sw.Close(); //Stream schließen
		sw.Dispose(); //Entfernt den Writer

		//Using: schließt Stream automatisch
		//AutoFlush: schreibt nach jedem WriteLine ins File
		using StreamWriter swUsing = new StreamWriter(Path.Combine(folderPath, "M015_Usingfile.txt")) { AutoFlush = true };
		swUsing.WriteLine("Test");
	}

	public static void StreamReaderTest()
	{
		//Desktop Folder (C:\Users\User\Desktop)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path Klasse für alle möglichen Pfad Operationen
		string folderPath = Path.Combine(desktop, "M015");

		if (!Directory.Exists(folderPath)) //Directory Klasse für alles mit Ordnern
			Directory.CreateDirectory(folderPath);

		string pathToFile = Path.Combine(folderPath, "M015_Testfile.txt");
		if (File.Exists(pathToFile))
		{
			using StreamReader sr = new StreamReader(pathToFile);
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
		}
	}

	[Serializable] //BinaryFormatter: Klasse muss als Serializable gekennzeichnet sein
	public class Fahrzeug
	{
		public string Automarke;

		public int MaxGeschwindigkeit;
	}
}