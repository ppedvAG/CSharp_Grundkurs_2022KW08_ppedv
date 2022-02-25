namespace M009_Polymorphismus
{
	public abstract class Lebewesen //abstrake Klasse = Struktur für erbende Klassen
	{
		public string Name { get; set; }

		public Lebewesen(string name)
		{
			Name = name;
		}

		//Abstrakte Methode hat keinen Körper (Code)
		/// <summary>
		/// PrintStatus soll den Status den Objekts zeigen
		/// </summary>
		public abstract void PrintStatus(); //Unterklassen müssen die Methode implementieren
	}

	/// <summary>
	/// Die Mensch Klasse. Erbt von Lebewesen.
	/// </summary>
	public class Mensch : Lebewesen
	{
		/// <summary>
		/// Gibt das Alter des Menschen in Jahren an
		/// </summary>
		public int AlterInJahren { get; set; }

		/// <summary>
		/// Konstruktor von Mensch
		/// </summary>
		/// <param name="name">Der Name</param>
		/// <param name="alter">Das Alter</param>
		public Mensch(string name, int alter) : base(name)
		{
			AlterInJahren = alter;
		}

		public override void PrintStatus()
		{
			Console.WriteLine($"Mein Name ist {Name} und ich bin {AlterInJahren} alt");
		}
	}

	public class Hund : Lebewesen
	{
		public Hund(string name) : base(name) { }

		public override void PrintStatus()
		{
			Console.WriteLine("Ich bin ein Hund");
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			//new Lebewesen(); //kann nicht erstellt werden weil Abstrakt
			Mensch m = new Mensch("Herbert", 34);
			Hund h = new Hund("Bello");

			List<Lebewesen> lw = new List<Lebewesen>();
			lw.Add(m); //Objekte die von Lebewesen erben können in eine Liste mit Lebewesen eingefügt werden
			lw.Add(h); //Hund erbt auch von Lebewesen

			foreach(Lebewesen l in lw)
			{
				//Hier wird die entsprechende implementierte Methode von dem erbenden Lebewesen (Mensch oder Hund) ausgeführt
				l.PrintStatus();
			}
		}
	}
}