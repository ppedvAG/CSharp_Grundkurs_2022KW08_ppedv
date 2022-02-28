namespace M012_FehlerbehandlungUnitTests;

public class Program
{
	static void Main(string[] args)
	{
		#region Exception Basics
		//ExceptionBasics();
		#endregion

		#region Eigene Exception
		try
		{
			int zahl = int.Parse(Console.ReadLine());
			if (zahl == 0)
				throw new TestException("Das ist ex.Message"); //throw: wirft eine Exception
		}
		catch (FormatException ex) //Falsche Eingabe abfangen
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(ex.Message);
		}
		catch (OverflowException ex) //Numerische Eingabe aber zu groß
		{
			Console.WriteLine("Zahl zu groß");
			Console.WriteLine(ex.Message);
		}
		catch (TestException ex) //TestException fangen
		{
			Console.WriteLine("Zahl darf nicht 0 sein");
			Console.WriteLine(ex.Message); //Nachricht im Konstruktor der Exception im throw
		}
		catch (Exception ex) //Alle anderen Fehler
		{
			Console.WriteLine("Allgemeine Exception");
			Console.WriteLine(ex.Message);
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception auftritt
		{
			Console.WriteLine("Finally Block wurde ausgeführt");
		}
		#endregion
	}

	public static void ExceptionBasics()
	{
		try
		{
			string eingabe = Console.ReadLine();
		}
		catch (IOException ex) //Fehlerhafter Input
		{
			Console.WriteLine($"Input Fehlerhaft: {ex.Message}"); //Lesbare Nachricht
		}
		catch (Exception ex) //Zu großer Input
		{
			Console.WriteLine($"Anderer Fehler: {ex.StackTrace}"); //Genau Auftrittspunkt von der Exception
		}
	}
}