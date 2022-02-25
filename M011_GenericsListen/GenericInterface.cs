namespace M011_GenericsListen;

public class GenericInterface : IGeneric<string> //Hier kein T sondern expliziter Typ
{
	public void InterfacePrintType(string t) //T wird ersetzt durch oben angegebener Typ
	{
		Console.WriteLine(t);
	}
}

public interface IGeneric<T> //Interface mit generic Type (T)
{
	void InterfacePrintType(T t); //T als Übergabeparameter
}
