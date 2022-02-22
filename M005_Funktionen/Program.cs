public class Program
{
	static void Main(string[] args)
	{
		string input = "34";
		int parse;
		if (int.TryParse(input, out parse)) { }


		int summeIntAddition = Addiere(5, 7, 5, 2, 9, 3, 5, 8, 1, 39, 29); //Rückgabewert in Variable geschrieben
		double summeAddition = Addiere(5.5, 7); //5.5 erzwingt die double-Methode
		Console.WriteLine(summeAddition);

		PrintString("Ein Text");

		//optionale Parameter
		int sub = Subtrahiere(10, 5, 2);

		//out-Keyword
		int subtraktion;
		int summe = AddiereUndSubtrahiere(10, 5, out subtraktion);
		Console.WriteLine(summe + ", " + subtraktion);
	}

	static int Addiere(int zahl1, int zahl2) //Struktur: Rückgabedatentyp Name (Parameter1, Parameter2, ...)
	{
		return zahl1 + zahl2;
	}

	//int Addiere(int zahlEins, int zahlZwei) { } //-> Nicht möglich

	static double Addiere(double zahl1, double zahl2) //Zwei Methoden mit gleichen Namen aber unterschiedlichen Parameters funktionierten
	{
		return zahl1 + zahl2;
	}

	static int Addiere(params int[] zahlen) //params: Beliebige Anzahl an Parametern
	{
		return zahlen.Sum();
	}

	static int Subtrahiere(int zahl1, int zahl2, int zahl3 = 0, int zahl4 = 0) //optionale Parameter: müssen nach erforderlichen Parametern sein und können beliebig viele sein
	{
		return zahl1 - zahl2 - zahl3 - zahl4;
	}

	static int AddiereUndSubtrahiere(int zahl1, int zahl2, out int subtraktion) //out: gibt zusätzliche Werte zurück, kann mehrere out Parameter haben
	{
		subtraktion = zahl1 - zahl2;
		return zahl1 + zahl2;
	}

	static void PrintString(string str)
	{
		Console.WriteLine(str);
		return; //Springt aus Methode raus
		Console.WriteLine(str);
	}
}