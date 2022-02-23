namespace M007_GarbageCollectorStaticWerteReferenzTypen
{
	public class ObjektDemo
	{
		public class Raum
		{
			public Fenster fenster; //Fenster Variable

			public static void Main(string[] args)
			{
				int neueLänge = 150;

				Fenster fenster = new Fenster(100, 100); //Erstelle ein neues Fenster
				fenster.FensterÖffnen(); //Nicht-Statisch: braucht ein Objekt
				Fenster.ErhöheZähler(); //Statisch: braucht kein Objekt, wird über den Klassennamen aufgerufen

				//Fenster f2 = new Fenster(); //Nicht möglich weil privater Standardkonstruktor
				Fenster offenesFenster = new Fenster(100, 100, false); //3-Werte Konstruktor
				fenster.Länge = 100; //weise Länge und Breite zu
				fenster.Breite = 100;

				Raum raum = new Raum(); //Erstelle einen neuen Raum
				raum.fenster = fenster; //weise das Fenster zu
				raum.fenster.Länge = neueLänge;
				neueLänge = 200;
				fenster.Breite = 200;
			}

			~Raum() //Destruktor wird aufgerufen wenn das Objekt vom Garbage Collector eingesammelt wird
			{
				Console.WriteLine("Raum wurde eingesammelt");
			}
		}
	}

	public class Fenster
	{
		public int Länge { get; set; }

		public int Breite { get; set; }

		public bool IstOffen { get; set; }

		public static int SchließenÖffnenZähler { get; set; }

		private Fenster() { } //Kann der leere Konstruktor nicht mehr aufgerufen werden

		public Fenster(int länge, int breite) //Übergabeparameter wie bei Funktionen
		{
			Länge = länge;
			Breite = breite;
		}

		public Fenster(int länge, int breite, bool offen)
		{
			Länge = länge;
			Breite = breite;
			IstOffen = offen;
		}

		public void FensterÖffnen()
		{
			IstOffen = true;
		}

		public static void ErhöheZähler()
		{
			SchließenÖffnenZähler++;
		}
	}
}
