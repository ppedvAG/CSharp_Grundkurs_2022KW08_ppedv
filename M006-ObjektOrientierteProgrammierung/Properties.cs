namespace M006_ObjektOrientierteProgrammierung
{
	public class Properties
	{
		#region Property Einführung
		//private string hintergrundName; //Im Hintergrund damit andere Entwickler nicht darauf zugreifen können

		//public string Name //Für Entwickler zum zugreifen
		//{
		//	get => hintergrundName; 
		//	set => hintergrundName = value; //value: Der Wert gesetzt wird
		//}
		#endregion

		private string hintergrundName; //Im Hintergrund damit andere Entwickler nicht darauf zugreifen können

		public string Name //Für Entwickler zum zugreifen
		{
			get => hintergrundName;
			set => hintergrundName = value; //value: Der Wert gesetzt wird
		}

		public void SetName(string userInput) //User setzt Wert -> Wert geht in das Property zur set -> Property gibt den Wert weiter an die private Variable
		{
			Name = userInput;
		}
	}
}
