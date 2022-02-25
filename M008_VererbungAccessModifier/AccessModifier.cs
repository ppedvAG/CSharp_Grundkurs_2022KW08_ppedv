namespace M008_VererbungAccessModifier
{
	public class Lebewesen
	{
		public string Name { get; set; }

		protected string Lieblingsnahrung { get; set; } //protected: ähnlich wie private nur auch in Unterklassen sichtbar

		protected private string Wohnort { get; set; } //protected private: nur in Unterklassen im selben Assembly sichtbar

		protected internal string Lieblingfarbe { get; set; } //protected internal: im Assembly und Unterklassen in anderen Assemblies sichtbar

		public Lebewesen(string name)
		{
			Name = name;
		}

		public virtual void PrintStatus()
		{
			Console.WriteLine($"Ich bin ein {GetType().Name} und mein Name ist {Name}");
		}
	}

	public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen
	{
		//Alle Felder werden übernommen

		public int AlterInJahren { get; set; }

		private string PrivateVariable { get; set; } //private nur in der selben Klasse sichtbar

		internal string InternalVariable { get; set; } //internal nur im selben Assembly/Projekt sichtbar

		public Mensch(string name, int alter) : base(name) //base: ruft den überliegenden Konstruktor auf
		{
			AlterInJahren = alter;
		}

		public override sealed void PrintStatus() //überschreibt die Methode darüber (override -> zeigt überschreibbare Methoden an)
		{
			//base.PrintStatus(); //Ruft die Methode von oben auf
			Console.WriteLine($"Mein Name ist {Name} und ich bin {AlterInJahren} alt");
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			Mensch m = new Mensch("Herbert", 34);
			m.PrintStatus();
			//m.PrivateVariable = ""; //Nicht möglich da private
			//m.Lieblingsnahrung = ""; //Nicht möglich da protected
		}
	}
}