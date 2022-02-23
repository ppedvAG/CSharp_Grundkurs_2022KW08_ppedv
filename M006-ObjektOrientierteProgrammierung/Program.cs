using Audi; //Importiert den Namespace für das ganze File

namespace Fahrzeughandel //Namespaces dienen zur Gruppierung von Klassen
{
	public class Fahrzeuggeschäft
	{
		private Fahrzeug fzg { get; set; } //get; set; -> Neue Schreibweise von Get und Set Methoden
		private Audi.Sportwagen.Sportwagen spw; //Klasse aus einem anderen Namespace
		
		/* Veraltet
		public Fahrzeug GetFahrzeug()
		{
			return fzg;
		}

		public void SetFahrzeug(Fahrzeug fzg)
		{
			this.fzg = fzg; //this greift nach oben
		}
		*/
	}
}

namespace Audi
{
	public class Fahrzeug
	{
		public void Fahre() { }
	}

	namespace Kleinwagen { } //Verschachtelung direkt
}

namespace Audi.Sportwagen //Verschachtelung indirekt (via Namespace darüber)
{
	public class Sportwagen { }
}

namespace Audi.SUV
{
	public class SUV { }
}