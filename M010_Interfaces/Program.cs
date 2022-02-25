namespace M010_Interfaces;

interface IArbeit //Interfaces sollten mit I anfangen für Übersichtlichkeit
{
	static string EinString = "Ein String"; //Resource

	int Gehalt { get; set; }

	string Job { get; set; } //Properties die weitergegeben werden

	void Lohnauszahlung(); //Leere Methoden wie bei abstrakten Klassen
}

interface IArbeit2
{
	void Lohnauszahlung();
}

public abstract class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, IArbeit2, ICloneable
{
	public int Gehalt { get; set; } = 2500;

	public string Job { get; set; } = "Softwareentwickler";

	public object Clone()
	{
		Mensch newMensch = (Mensch) MemberwiseClone();
		return newMensch;
	}

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt} für den Job {Job} bekommen.");
	}

	void IArbeit2.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt / 2} für den Job {Job} bekommen.");
	}
}

public class Program
{
	static void Main(string[] args)
	{
		IArbeit arbeit = new Mensch();
		arbeit.Lohnauszahlung(); //Ruft Lohnauszahlung 1 auf

		IArbeit2 arbeit2 = new Mensch();
		arbeit2.Lohnauszahlung(); //Ruft Lohnauszahlung 2 auf

		Mensch beideArbeiten = new Mensch();
		//beideArbeiten.Lohnauszahlung(); //Fehler weil nicht klar ist welches Interface gemeint ist
		((IArbeit) beideArbeiten).Lohnauszahlung(); //Lohnauszahlung 1 mit temporärem Cast
		((IArbeit2) beideArbeiten).Lohnauszahlung(); //Lohnauszahlung 2 mit temporärem Cast
		(beideArbeiten as IArbeit2).Lohnauszahlung(); //as-cast: Funktioniert nur bei Objekten die null sein können

		Mensch m = new Mensch
		{
			Gehalt = 2000,
			Job = "Ein Job"
		};

		Mensch neuerMensch;
		if (m is ICloneable)
			neuerMensch = (Mensch) m.Clone();
	}
}