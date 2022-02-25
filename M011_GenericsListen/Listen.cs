namespace M011_GenericsListen;

public class Listen
{
	public static void Main2(string[] args)
	{
		List<string> staedte = new List<string>(); //Erstellung einer Liste mit generischem Typ
		staedte.Add("Hamburg"); //Elemente hinzufügen
		staedte.Add("Wien");
		staedte.Add("Berlin");
		staedte.Add("Köln");

		Console.WriteLine(staedte[1]); //Element angreifen wie bei einem Array

		Console.WriteLine(staedte.Count); //Count statt Length wie beim Array

		staedte[2] = "Dresden"; //Wie beim Array auf Liste zugreifen mit []

		staedte.Remove("Hamburg"); //Höhere Elemente werden nachgeschoben

		foreach (string s in staedte) //Liste durchgehen
		{
			Console.WriteLine(s);
		}

		staedte.Sort();

		Stack<string> staedteStack = new Stack<string>();
		staedteStack.Push("Berlin");
		staedteStack.Push("Wien");
		staedteStack.Push("Köln");
		staedteStack.Push("Hamburg");

		Console.WriteLine(staedteStack.Peek()); //Hamburg

		Console.WriteLine(staedteStack.Pop()); //Hamburg genommen und entfernt

		Queue<string> staedteQueue = new Queue<string>();
		staedteQueue.Enqueue("Berlin");
		staedteQueue.Enqueue("Wien");
		staedteQueue.Enqueue("Köln");
		staedteQueue.Enqueue("Hamburg");

		Console.WriteLine(staedteQueue.Peek()); //Berlin

		Console.WriteLine(staedteQueue.Dequeue()); //Berlin genommen und entfernt

		Dictionary<string, int> einwohnerzahlen = new Dictionary<string, int>(); //Dictionary: Liste von KeyValuePairs
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);

		if (einwohnerzahlen.ContainsKey("Wien"))
			Console.WriteLine(einwohnerzahlen["Wien"]); //Value holen mit Key

		Console.WriteLine(einwohnerzahlen.ContainsValue(2000000));

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen)
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner");
		}
	}
}
