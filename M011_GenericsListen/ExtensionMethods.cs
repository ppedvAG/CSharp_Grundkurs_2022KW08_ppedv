namespace M011_GenericsListen
{
	public static class ExtensionMethods
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> e)
		{
			Random rand = new Random();
			return e.OrderBy(x => rand.Next());
		}
	}
}
