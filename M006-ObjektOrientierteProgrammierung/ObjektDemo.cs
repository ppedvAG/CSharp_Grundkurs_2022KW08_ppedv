namespace M006_ObjektOrientierteProgrammierung
{
	public class ObjektDemo
	{
		public class Raum
		{
			public Fenster fenster; //Fenster Variable

			public static void Main(string[] args)
			{
				Fenster f = new Fenster(100, 100); //Erstelle ein neues Fenster
				//Fenster f2 = new Fenster(); //Nicht möglich weil privater Standardkonstruktor
				Fenster offenesFenster = new Fenster(100, 100, false); //3-Werte Konstruktor
				f.Länge = 100; //weise Länge und Breite zu
				f.Breite = 100;

				Raum r = new Raum(); //Erstelle einen neuen Raum
				r.fenster = f; //weise das Fenster zu
			}
		}
	}

	public class Fenster
	{
		public int Länge { get; set; }

		public int Breite { get; set; }

		public bool IstOffen { get; set; }

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
	}
}
