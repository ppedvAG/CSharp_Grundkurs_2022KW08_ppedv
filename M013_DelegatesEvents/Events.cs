namespace M013_DelegatesEvents
{
	public class Events
	{
		static event EventHandler<EventArgs> Event; //event: delegate Untertyp

		static void Main(string[] args)
		{
			Event += Events_Event; //Kein new zum dranhängen
			Event(null, new EventArgs()); //Generische Eventargs, spezielle z.B.: MouseEventArgs, KeyEventArgs
			Event = Events_Event1; //Zuweisung
			Event(null, new EventArgs());
		}

		private static void Events_Event1(object? sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private static void Events_Event(object? sender, EventArgs e)
		{
			Console.WriteLine("Event wurde aufgerufen");
		}
	}
}
