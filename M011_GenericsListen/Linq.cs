using static M011_GenericsListen.Linq.Fahrzeug;

namespace M011_GenericsListen;

public class Linq
{
	public static void Main(string[] args)
	{
		#region Einfaches Linq
		//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elemente
		//(5, 20): gibt eine Liste mit 5-24 zurück (da Start 5 und insgesamt 20 Elemente)
		List<int> linqTest = Enumerable.Range(1, 20).ToList();

		Random rand = new Random();
		linqTest = linqTest.OrderBy(x => rand.Next()).ToList(); //Liste mischen

		Console.WriteLine(linqTest.Average());
		Console.WriteLine(linqTest.Min());
		Console.WriteLine(linqTest.Max());

		Console.WriteLine(linqTest.Sum());

		Console.WriteLine(linqTest.First()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(linqTest.FirstOrDefault()); //null zurück wenn Liste leer

		Console.WriteLine(linqTest.Last()); //Letztes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(linqTest.LastOrDefault()); //null zurück wenn Liste leer

		//Cast -> wandelt alle Elemente in einer Liste zu einem anderen Typen um und macht eine neue Liste
		//List<long> doubleList = linqTest.Cast<long>().ToList();

		IEnumerable<int[]> chunk = linqTest.Chunk(5); //Teilt Liste in 5er Teile auf
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(250, FahrzeugMarke.BMW),
			new Fahrzeug(270, FahrzeugMarke.BMW),
			new Fahrzeug(200, FahrzeugMarke.Audi),
			new Fahrzeug(180, FahrzeugMarke.Audi),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(300, FahrzeugMarke.BMW),
			new Fahrzeug(150, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(210, FahrzeugMarke.Audi)
		};

		#region BMWs filtern mit Schleife
		List<Fahrzeug> bmwsForEach = new List<Fahrzeug>();
		foreach (Fahrzeug auto in fahrzeuge)
			if (auto.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(auto);
		#endregion

		#region BMWs filtern mit SQL-Schreibweise
		List<Fahrzeug> bmws =  (from auto in fahrzeuge 
								where auto.Marke == FahrzeugMarke.BMW
								select auto).ToList(); //Für ToList() keine eigene Funktionalität
		#endregion

		#region BMWs filtern mit Methodenketten
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(auto => auto.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Einfache Linq-Statements mit einer Objektliste
		//Holt die höchste Geschwindigkeit (selbiges w.o. mit Min und Average)
		Console.WriteLine(fahrzeuge.Max(auto => auto.MaxGeschwindigkeit));

		//OrderBy sortiert aufsteigend
		//Sortiere nach Geschwindigkeit und nehme das erste Element
		Fahrzeug fzg = fahrzeuge.OrderByDescending(auto => auto.MaxGeschwindigkeit).First();
		Console.WriteLine($"Das schnellste Fahrzeug ist ein {fzg.Marke} und die Höchstgeschwindigkeit ist {fzg.MaxGeschwindigkeit}");

		//Speichert alle vorhandenen Automarken
		List<FahrzeugMarke> alleBez = fahrzeuge.Select(auto => auto.Marke).ToList();

		//Filtert Elemente sodass jedes Element einzigartig ist
		List<FahrzeugMarke> distinct = alleBez.Distinct().ToList();

		//Summiert alle Geschwindigkeiten
		int summeGeschwindigkeiten = fahrzeuge.Sum(auto => auto.MaxGeschwindigkeit);

		int summeVWs = fahrzeuge.Where(auto => auto.Marke == FahrzeugMarke.VW && auto.MaxGeschwindigkeit >= 200)
								.Sum(e => e.MaxGeschwindigkeit); //Mehrere Bedingungen mit &&

		//Checkt ob alle Autos mindestens 150 fahren können
		bool alleAutosSchnell = fahrzeuge.All(auto => auto.MaxGeschwindigkeit >= 150);

		//Checkt ob mindestens ein Fahrzeug in der Liste ist
		bool mindestensEinFahrzeug = fahrzeuge.Any();

		//Checkt ob ein Auto die Bedingung erfüllt
		bool einAutoSchnell = fahrzeuge.Any(auto => auto.MaxGeschwindigkeit >= 250);

		//Voller Typ: IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>>
		//Gruppiert alle Fahrzeuge nach der Bezeichnung
		var groupedFahrzeuge = fahrzeuge.GroupBy(e => e.Marke);

		//fahrzeuge.Concat() -> Verbindet zwei Listen
		//fahrzeuge.Append() und fahrzeuge.Prepend() fügen Elemente am Anfang/Ende hinzu
		#endregion

		#region Erweiterte Linq-Statements mit einer Objektliste
		//Paging: Zeige nur eine fixe Anzahl an Elementen
		List<Fahrzeug> pagedFahrzeuge;
		int maxPages = 3;

		//Skip: überspringt Elemente vom Anfang der Liste
		//Take: Nimmt entsprechend viele Elemente vom Anfang der Liste
		for (int i = 0; i < maxPages; i++)
			pagedFahrzeuge = fahrzeuge.Skip(i * maxPages).Take(3).ToList();

		//ToDictionary: Zwei Parameter mit zweimal => und Beistrich getrennt
		//Gibt die maximale Geschwindigkeit pro Automarke zurück
		Dictionary<FahrzeugMarke, int> maxGeschwindigkeit = fahrzeuge
			.GroupBy(auto => auto.Marke)
			.ToDictionary(auto => auto.Key, auto => auto.Select(e => e.MaxGeschwindigkeit).Max());

		//Aggregiert Code auf einen Aggregator (string) (Aggregator = str)
		//Nützlich um eine Liste schön formatiert auszugeben
		string agg = fahrzeuge.Aggregate("", (str, fzg) =>
			str + $"Bezeichnung: {fzg.Marke}, Maximalgeschwindigkeit: {fzg.MaxGeschwindigkeit}\n");
		Console.WriteLine(agg);

		//Maximalgeschwindigkeit addieren (Aggregator = sum)
		fahrzeuge.Aggregate(0, (sum, fzg) => sum += fzg.MaxGeschwindigkeit);
		#endregion
	}

	public class Fahrzeug
	{
		public int MaxGeschwindigkeit;

		public FahrzeugMarke Marke;

		public Fahrzeug(int v, FahrzeugMarke fm)
		{
			MaxGeschwindigkeit = v;
			Marke = fm;
		}

		public enum FahrzeugMarke
		{
			BMW,
			Audi,
			VW
		}
	}
}
