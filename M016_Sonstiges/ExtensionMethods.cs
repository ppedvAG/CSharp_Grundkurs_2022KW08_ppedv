namespace M016_Sonstiges
{
	public static class ExtensionMethods
	{
		public static int Quersumme(this int x)
		{
			return x.ToString().Select(e => int.Parse(e.ToString())).Sum();
		}
	}
}
