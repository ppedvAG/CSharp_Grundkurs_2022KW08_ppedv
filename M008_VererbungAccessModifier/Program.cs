//namespace M008_VererbungAccessModifier
//{
//	public class Lebewesen
//	{
//		public string Name { get; set; }

//		public Lebewesen(string name)
//		{
//			Name = name;
//		}
//	}

//	public class Mensch : Lebewesen //Mensch ist ein Lebewesen
//	{
//		//Alle Felder werden übernommen

//		public int AlterInJahren { get; set; }

//		public Mensch(string name, int alter) : base(name) //base: ruft den überliegenden Konstruktor auf
//		{
//			AlterInJahren = alter;
//		}
//	}

//	public class Kind : Mensch
//	{
//		//Alle Felder von Mensch und Lebewesen übernommen

//		public int Groesse { get; set; }

//		public Kind(string name, int alter, int groesse) : base(name, alter)
//		{
//			Groesse = groesse;
//		}
//	}

//	public class Program
//	{
//		public static void Main(string[] args) //sim -> Shortcut für Main Methode
//		{
//			Mensch m = new Mensch("Herbert", 34);
//			m.Name = "Einen Namen"; //Name wird von Lebewesen übernommen
//		}
//	}
//}