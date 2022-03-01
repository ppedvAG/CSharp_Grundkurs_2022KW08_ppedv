using System.Collections;
using System.Diagnostics;

namespace M016_Sonstiges;

public class Program
{
	static void Main(string[] args)
	{
		#region Operatoren überladen
		Wagon a = new Wagon() { Sitzplaetze = 15 };
		Wagon b = new Wagon() { Sitzplaetze = 20 };
		if (a <= b)
		{
			Console.WriteLine("A hat weniger Sitzplätze als B");
		}

		Zug z1 = new Zug();
		Zug z2 = new Zug();
		Zug newZug = z1 + z2;
		#endregion

		#region Enumerator
		Zug enumerator = new Zug();
		foreach (Wagon w in enumerator)
		{
			//...
		}
		#endregion

		#region Indexer
		Zug indexer = new Zug();
		//indexer.Wagons[...]
		//Wagon w = indexer[2];
		#endregion

		#region Erweiterungsmethoden
		Console.WriteLine(359721.Quersumme());
		#endregion

		#region Stopwatch
		//Perfomancetest
		Stopwatch sw = new Stopwatch();
		sw.Start();
		//Code der zu testen ist
		Count();
		//Ende vom Code
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);

		void Count()
		{
			for (int i = 0; i < 10000; i++)
				Console.WriteLine(i);
		}
		#endregion
	}

	public class Zug : IEnumerable
	{
		private List<Wagon> Wagons { get; set; } = new List<Wagon>();

		public static Zug operator +(Zug a, Zug b)
		{
			Zug newZug = new Zug();
			newZug.Wagons.AddRange(a.Wagons);
			newZug.Wagons.AddRange(b.Wagons);
			return newZug;
		}

		//Objekt muss IEnumerable implementieren
		//Macht Objekt foreach-able
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (Wagon w in Wagons)
				yield return w; //yield gibt den return Wert in den Enumerator hinein
		}

		//Objekt ansprechbar machen mit [index] (wie bei Array/Listen)
		public Wagon this[int index]
		{
			get => Wagons[index];
			set => Wagons[index] = value;
		}
	}

	public class Wagon
	{
		public int Sitzplaetze { get; set; }

		public string Farbe { get; set; }

		//Operator überladen (<= und >=, bei gespiegelten Operatoren müssen beide überladen werden)
		public static bool operator <=(Wagon a, Wagon b) => a.Sitzplaetze <= b.Sitzplaetze;

		public static bool operator >=(Wagon a, Wagon b) => a.Sitzplaetze >= b.Sitzplaetze;
	}
}