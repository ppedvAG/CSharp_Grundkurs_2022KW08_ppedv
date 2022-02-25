using System.Collections.Generic;
using System.Linq;

namespace M011_GenericsListen;

public class Linq
{
	public static void Main(string[] args)
	{
		#region Simple Linq
		//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elemente
		//(5, 20): gibt eine Liste mit 5-24 zurück (da Start 5 und insgesamt 20 Elemente)
		List<int> linqTest = Enumerable.Range(1, 20).ToList();

		Random rand = new Random();
		linqTest = linqTest.OrderBy(x => rand.Next()).ToList(); //Liste mischen

		Console.WriteLine(linqTest.Average());
		Console.WriteLine(linqTest.Min());
		Console.WriteLine(linqTest.Max());

		Console.WriteLine(linqTest.Sum());

		Console.WriteLine(linqTest.First()); //Erstes Element der Liste
		Console.WriteLine(linqTest.Last()); //Exception wenn Liste leer

		Console.WriteLine(linqTest.FirstOrDefault()); //Letztes Element der Liste
		Console.WriteLine(linqTest.LastOrDefault()); //null zurück wenn Liste leer

		//List<double> doubleList = linqTest.Cast<double>().ToList(); //Cast -> wandelt alle Elemente in einer Liste zu einem anderen Typen um und macht eine neue Liste

		IEnumerable<int[]> chunk = linqTest.Chunk(5); //Teilt Liste in 5er Teile auf
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
		fahrzeuge.Add(new Fahrzeug(250, "BMW"));
		fahrzeuge.Add(new Fahrzeug(270, "BMW"));
		fahrzeuge.Add(new Fahrzeug(200, "VW"));
		fahrzeuge.Add(new Fahrzeug(180, "Audi"));
		fahrzeuge.Add(new Fahrzeug(250, "VW"));
		fahrzeuge.Add(new Fahrzeug(300, "BMW"));
		fahrzeuge.Add(new Fahrzeug(150, "VW"));
		fahrzeuge.Add(new Fahrzeug(250, "VW"));
		fahrzeuge.Add(new Fahrzeug(210, "Audi"));

		#region BMWs filtern mit Schleife
		List<Fahrzeug> bmwsForEach = new List<Fahrzeug>();
		foreach (Fahrzeug auto in fahrzeuge)
			if (auto.Bezeichnung == "BMW")
				bmwsForEach.Add(auto);
		#endregion

		#region BMWs filtern mit SQL-Schreibweise
		List<Fahrzeug> bmws =  (from auto in fahrzeuge 
								where auto.Bezeichnung == "BMW"
								select auto).ToList(); //Für ToList() keine eigene Funktionalität
		#endregion

		#region BMWs filtern mit Methodenketten
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(auto => auto.Bezeichnung == "BMW").ToList();
		#endregion

		Console.WriteLine(fahrzeuge.Max(auto => auto.MaxGeschwindigkeit)); //Holt die höchste Geschwindigkeit

		//OrderBy sortiert aufsteigend
		Fahrzeug fzg = fahrzeuge.OrderByDescending(auto => auto.MaxGeschwindigkeit).First(); //Sortiere nach Geschwindigkeit und nehme das erste Element
		Console.WriteLine($"Das schnellste Fahrzeug ist ein {fzg.Bezeichnung} und die Höchstgeschwindigkeit ist {fzg.MaxGeschwindigkeit}");
	
		List<string> alleBez = fahrzeuge.Select(auto => auto.Bezeichnung).ToList(); //Holt alle Autobezeichnungen

		List<string> distinct = alleBez.Distinct().ToList(); //Filtert Elemente sodass jedes Element einzigartig ist

		int summeGeschwindigkeit = fahrzeuge.Sum(auto => auto.MaxGeschwindigkeit); //Summiert alle Geschwindigkeit

		int summeVWs = fahrzeuge.Where(auto => auto.Bezeichnung == "VW" && auto.MaxGeschwindigkeit >= 200)
								.Sum(e => e.MaxGeschwindigkeit); //Mehrere Bedingungen mit &&

		bool alleAutosSchnell = fahrzeuge.All(auto => auto.MaxGeschwindigkeit >= 150); //Checkt ob alle Autos mindestens 150 fahren können

		bool einAutoSchnell = fahrzeuge.Any(auto => auto.MaxGeschwindigkeit >= 250); //Checkt ob ein Auto die Bedingung erfüllt

		List<Fahrzeug> pagedFahrzeuge;
		int maxPages = 3;
		for (int i = 0; i < 3; i++) //Paging: Zeige nur eine fixe Anzahl an Elementen
			pagedFahrzeuge = fahrzeuge.Skip(i * maxPages).Take(3).ToList();
		//Skip: überspringt Elemente vom Anfang der Liste
		//Take: Nimmt entsprechend viele Elemente vom Anfang der Liste

		//Dictionary<string, int> maxGeschwindigkeit = fahrzeuge //ToDictionary: Zwei Parameter mit zweimal => und Beistrich getrennt
		//	.ToDictionary(auto => auto.Bezeichnung, auto => auto.MaxGeschwindigkeit);

		string agg = fahrzeuge.Aggregate("", (str, fzg) => //Aggregiert Code auf einen Aggregator (string) (Aggregator = str)
			str + $"Bezeichnung: {fzg.Bezeichnung}, Maximalgeschwindigkeit: {fzg.MaxGeschwindigkeit}\n");
		Console.WriteLine(agg);

		fahrzeuge.Aggregate(0, (sum, fzg) => sum += fzg.MaxGeschwindigkeit); //Maximalgeschwindigkeit addieren (Aggregator = sum)

		//fahrzeuge.Concat -> Verbindet zwei Listen
		var x = fahrzeuge.GroupBy(e => e.Bezeichnung); //Gruppiert alle Fahrzeuge nach der Bezeichnung
		//fahrzeuge.Append() und fahrzeuge.Prepend() fügen Elemente am Anfang/Ende hinzu
	}

	public class Fahrzeug
	{
		public int MaxGeschwindigkeit;

		public string Bezeichnung;

		public Fahrzeug(int v, string b)
		{
			MaxGeschwindigkeit = v;
			Bezeichnung = b;
		}
	}
}
