namespace M011_GenericsListen;

public class Program
{
	//public static void Main(string[] args)
	//{
	//	PrintType<Program>(); //In den spitzen Klammern einen Typ übergeben
	//	PrintTypeRestricted<Program>();
	//}

	public static void PrintType<T>() //definiert einen generischen Typen der mit spitzen Klammern (< >) übergeben wird
	{
		Console.WriteLine(typeof(T).Name); //typeof: Konvertiert einen Datentyp zu einem Type Objekt
	}

	public static void PrintTypeRestricted<T>() where T : Program //where T : ...: restriktiert den möglichen Übergabewert
	{
		Console.WriteLine(typeof(T).Name);
	}
}