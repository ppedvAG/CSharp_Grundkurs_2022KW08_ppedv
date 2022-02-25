//namespace M008_VererbungAccessModifier
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

//	public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen
//	{
//		//Alle Felder werden übernommen

//		public int AlterInJahren { get; set; }

//		public Mensch(string name, int alter) : base(name) //base: ruft den überliegenden Konstruktor auf
//		{
//			AlterInJahren = alter;
//		}

//		public override sealed void PrintStatus() //überschreibt die Methode darüber (override -> zeigt überschreibbare Methoden an)
//		{
//			//base.PrintStatus(); //Ruft die Methode von oben auf
//			Console.WriteLine($"Mein Name ist {Name} und ich bin {AlterInJahren} alt");
//		}
//	}

//	public class Kind : Mensch //sealed Klasse kann nicht abgeleitet werden
//	{
//		public Kind(string name, int alter) : base(name, alter) { }

//		public override void PrintStatus() { } //sealed Methode kann nicht überschrieben werden
//	}

//	public class Program
//	{
//		public static void Main(string[] args)
//		{
//			Mensch m = new Mensch("Herbert", 34);
//			m.PrintStatus();
//		}
//	}
//}