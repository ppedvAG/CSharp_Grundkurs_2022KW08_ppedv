namespace M006_ObjektOrientierteProgrammierung
{
	public class Properties
	{
		#region Property Einführung
		//private string hintergrundName; //Im Hintergrund damit andere Entwickler nicht darauf zugreifen können

		//public string Name //Für Entwickler zum zugreifen
		//{
		//	get
		//	{
		//		return hintergrundName;
		//	}

		//	set
		//	{
		//		hintergrundName = value; //value: Der Wert gesetzt wird
		//	}
		//}
		#endregion

		#region Property mit Bedingung
		//private string hintergrundName; //Im Hintergrund damit andere Entwickler nicht darauf zugreifen können

		//public string Name //Für Entwickler zum zugreifen
		//{
		//	get
		//	{
		//		return hintergrundName;
		//	}

		//	set
		//	{
		//		if (value.Length > 1) //Überprüfung bevor der value zugewiesen wird
		//			hintergrundName = value; //value: Der Wert gesetzt wird
		//	}
		//}

		//public void SetName(string userInput) //User setzt Wert -> Wert geht in das Property zur set -> Property gibt den Wert weiter an die private Variable
		//{
		//	Name = userInput;
		//}
		#endregion

		#region Auto-Property Zuweisung
		//public string Name { get; set; } = "Ein Name"; //Auto-Property kann ein Standardwert zugewiesen werden
		#endregion

		#region private Properties und get-only
		private string hintergrundName; //Im Hintergrund damit andere Entwickler nicht darauf zugreifen können

		public string Name //Für Entwickler zum zugreifen
		{
			get
			{
				return hintergrundName; //Nur get Property
			}

			private set
			{
				hintergrundName = value; //Nur in dieser Klasse aufrufbar
			}
		}

		private DateTime geburtdatum;

		public int Alter
		{
			get //Nur zur Berechnung vom Alter (kann nicht gesetzt werden)
			{
				return DateTime.Now.Year - geburtdatum.Year; //Von überall aufrufbar
			}
		}

		private decimal hintergrundGehalt;

		public decimal Gehalt
		{
			private get
			{
				return hintergrundGehalt; //Nur in dieser Klasse aufrufbar
			}

			set
			{
				hintergrundGehalt = value; //Von überall aufrufbar
			}
		}
		#endregion

		//public static void Main(string[] args)
		//{
		//	Properties prop = new Properties(); //new erstellt ein Objekt
		//	prop.Name = "Ein Name";
		//}

		public Properties()
		{

		}
	}
}
