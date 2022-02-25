//namespace M009_Polymorphismus
//{
//	public class Lebewesen
//	{
//		public string Name { get; set; }

//		public Lebewesen(string name)
//		{
//			Name = name;
//		}

//		public virtual void PrintStatus()
//		{
//			Console.WriteLine($"Ich bin ein {GetType().Name} und mein Name ist {Name}");
//		}
//	}

//	public sealed class Mensch : Lebewesen
//	{
//		public int AlterInJahren { get; set; }

//		public Mensch(string name, int alter) : base(name)
//		{
//			AlterInJahren = alter;
//		}

//		//public override void PrintStatus() //überschreibt die obere Methode, Verbindung bleibt bestehen
//		//{
//		//	Console.WriteLine($"Mein Name ist {Name} und ich bin {AlterInJahren} alt");
//		//}

//		public new void PrintStatus() //versteckt die obere Methode, trennt die Verbindung zur Methode darüber
//		{
//			Console.WriteLine($"Mein Name ist {Name} und ich bin {AlterInJahren} alt");
//		}
//	}

//	public class Program
//	{
//		public static void Main(string[] args)
//		{
//			Lebewesen mensch = new Mensch("Herbert", 34);
//			Console.WriteLine(mensch.GetType().Name); //gibt Mensch zurück
//			if (mensch is Lebewesen) //is: Typvergleiche
//			{
//				Console.WriteLine("Mensch ist ein Lebewesen");
//			}

//			if (mensch.GetType() == typeof(Lebewesen)) { } //Alte Schreibweise von der oberen if (mit is)

//			#region PrintStatus Override
//			//Mensch castMensch = new Mensch("Walter", 55);
//			//castMensch.PrintStatus(); //Printet den Status vom Mensch aus

//			//Lebewesen menschAlsLebewesen = castMensch; //castMensch weis weiterhin das sie ein Mensch ist
//			//menschAlsLebewesen.PrintStatus(); //Printet weiterhin den Status vom Mensch aus
//			#endregion

//			#region PrintStatus New
//			Mensch castMensch = new Mensch("Walter", 55);
//			castMensch.PrintStatus(); //Printet den Status vom Mensch aus

//			Lebewesen menschAlsLebewesen = castMensch; //castMensch weis weiterhin das sie ein Mensch ist
//			menschAlsLebewesen.PrintStatus(); //Printet den Status vom Lebewesen aus, da Verbindung getrennt durch new (Zeile 32)
//			#endregion
//		}
//	}
//}