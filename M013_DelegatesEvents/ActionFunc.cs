namespace M013_DelegatesEvents
{
	public class ActionFunc
	{
		public static void Main2(string[] args)
		{
			Action<int, int> action = Addiere; //Action mit Parametern (int, int), Addiere Methode drangehängt
			action += Subtrahiere;
			action.Invoke(5, 9); //Aufruf mit Parametern, gibt immer void zurück

			Predicate<int> checkZero = CheckForZero;
			Console.WriteLine(checkZero.Invoke(0)); //Gibt immer bool zurück

			Func<int, int, int> func = Multipliziere; //Dritter Wert ist der return Wert
			func += delegate (int x, int y) { return x * y; }; //Neues Delegate erstellt und drangehängt
			Console.WriteLine(func.Invoke(5, 9)); //Gibt immer den angebenen return Wert zurück

			int doubleInt(int x) => x * 2; //Lokale Methode, Methode in der Methode

			Console.WriteLine(doubleInt(5));

			List<string> staedteListe = new List<string>() { "Berlin", "Wien", "Paris", "Köln" };
			string found = staedteListe.Find //Schreibweise mit Delegate
			(
				delegate (string stadt)
				{
					return stadt.StartsWith("B");
				}
			);

			string foundEasy = staedteListe.Find((stadt) => stadt.StartsWith("B"));
		}

		public static void Addiere(int a, int b)
		{
			Console.WriteLine(a + b);
		}

		public static void Subtrahiere(int a, int b)
		{
			Console.WriteLine(a - b);
		}

		public static bool CheckForZero(int x)
		{
			return x == 0;
		}

		public static int Multipliziere(int a, int b)
		{
			return a * b;
		}
	}
}
