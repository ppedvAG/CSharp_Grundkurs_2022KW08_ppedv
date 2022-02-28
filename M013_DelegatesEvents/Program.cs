namespace M013_DelegatesEvents;

public class Program
{
	//Speichert Referenzen zu anderen Methoden, können zur Laufzeit hinzugefügt oder weggenommen werden
	public delegate void Vorstellungen(string name);

	static void Main2(string[] args)
	{
		Vorstellungen vorstellung; //Variablendeklaration
		vorstellung = new Vorstellungen(VorstellungDE); //Erstellung des Delegates
		vorstellung += new Vorstellungen(VorstellungEN);
		vorstellung("Max"); //Aufruf

		foreach (Delegate dg in vorstellung.GetInvocationList()) //Alle Methoden die dranhängen
		{
			Console.WriteLine(dg.Method); //Gibt hier alle Methoden aus
		}

		vorstellung -= VorstellungEN; //Entfernt die entsprechende Methode vom Delegate
		vorstellung("Max");

		vorstellung = null; //Entfernt alle Methoden vom Delegate
	}

	public static void VorstellungDE(string name)
	{
		Console.WriteLine($"Hallo mein Name ist {name}");
	}

	public static void VorstellungEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}
}