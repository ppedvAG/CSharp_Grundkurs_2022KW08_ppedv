using M012_FehlerbehandlungUnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace M012_Tests
{
	[TestClass]
	public class UnitTest1
	{
		Rechner rechner;

		[TestInitialize] //Wird aufgerufen vor JEDEM Test
		public void ErzeugeRechner()
		{
			rechner = new Rechner();
			System.Console.WriteLine("Rechner erzeugt");
		}

		[TestCleanup] //Wird aufgerufen nach JEDEM Test
		public void Cleanup()
		{
			System.Console.WriteLine("Cleanup ausgeführt");
			rechner = null;
		}

		[TestCategory("Erfolg")] //Kategorisieren
		[TestMethod] //Erfolgreiche Methode
		public void TesteAddiere()
		{
			int sum = rechner.Addiere(5, 9);
			Assert.AreEqual(14, sum);
		}

		[TestCategory("Fehler")]
		[TestMethod] //Fehlerhafte Methode
		public void TesteAddiereFehler()
		{
			int sum = rechner.Addiere(5, 9);
			Assert.AreNotEqual(6, sum);
		}
	}
}