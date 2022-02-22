#region Schleifen
int a = 0;
int b = 10;
while (a < b) //läuft während die Bedingung true ist
{
	Console.WriteLine("while: " + a);
	if (a == 5)
		break; //break beendet Schleife
	a++;
}

while (true) //Endlosschleife
{
	//Code
}

int c = 0;
int d = 10;
do //läuft während die Bedingung true ist UND mindestens einmal
{
	c++;
	if (c == 5)
		continue; //springt zum Kopf zurück
	Console.WriteLine("do-while: " + c);
}
while (c < d);

for (int i = 0; i < 10; i++) //läuft während die Bedingung true ist und hat eine Laufvariable integriert
{
	Console.WriteLine("for: " + i);
}

for (int i = 0; i < 10; i += 2) //Variable kann um beliebig viel erhöht werden
{
	Console.WriteLine("for + 2: " + i);
}

int maximum = 9;
for (int i = maximum; i >= 0; i--) //Schleife die nach unten zählt
{
	Console.WriteLine("for-Rückwärts: " + i);
}

int[] zahlen = { 4, 9, 2, 5, 1, 7, 0 };
for (int i = 0; i < zahlen.Length; i++) //Array durchgehen und ausgeben
{
	Console.WriteLine(zahlen[i]);
}

foreach (int z in zahlen) //Geht das Array auch durch kann aber nicht daneben greifen (sicherer)
{
	Console.WriteLine(z);
}
#endregion

#region Enums
//string[] wochentage = { "Sonntag", "Montag", "Dienstag", "Mittwoch" }; //unpraktisch

Wochentag wochentag = Wochentag.Dienstag; //Wochentag Variable + Zuweisung
Console.WriteLine(wochentag);

////////////

for (int i = 0; i < 7; i++) //int zu Enum casten
{
	Console.WriteLine((Wochentag) i);
}

////////////

Wochentag intInput = (Wochentag) int.Parse(Console.ReadLine()); //Input casten zu Wochentag
Console.WriteLine(intInput);

Wochentag stringInput = (Wochentag) Enum.Parse(typeof(Wochentag), Console.ReadLine());
Console.WriteLine(stringInput);
#endregion

#region Switch
Wochentag tag = Wochentag.Samstag;

if (tag == Wochentag.Montag) //Negativbeispiel
	Console.WriteLine("Wochenanfang");
else if (tag == Wochentag.Dienstag || tag == Wochentag.Mittwoch || tag == Wochentag.Donnerstag)
	Console.WriteLine("Normaler Wochentag");
else
	Console.WriteLine("Wochenende");

switch (tag) //Vergleichbar mit if-else aber übersichtlicher
{
	case Wochentag.Montag:
		Console.WriteLine("Wochenanfang");
		break;
	case Wochentag.Dienstag:
	case Wochentag.Mittwoch:
	case Wochentag.Donnerstag:
		Console.WriteLine("Normaler Wochentag");
		break;
	case Wochentag.Freitag:
	case Wochentag.Samstag:
	case Wochentag.Sonntag:
		Console.WriteLine("Wochenende");
		break;
	default:
		Console.WriteLine("Etwas ist schiefgelaufen");
		break;
}

switch (tag) //switch mit boolscher Logik
{
	case >= Wochentag.Montag and <= Wochentag.Freitag:
		Console.WriteLine("Wochentag");
		break;
	case Wochentag.Samstag or Wochentag.Sonntag:
		Console.WriteLine("Wochenende");
		break;
}

Wochentag wochentage = Wochentag.Montag | Wochentag.Dienstag | Wochentag.Mittwoch; //0000111
if (wochentage.HasFlag(Wochentag.Montag))
	Console.WriteLine("Montag ist enthalten");

Wochentag[] wochentagArray = { Wochentag.Montag, Wochentag.Dienstag, Wochentag.Mittwoch };
if (wochentagArray.Contains(Wochentag.Montag))
	Console.WriteLine("Montag ist enthalten");
#endregion

Lab.Execute();

[Flags]
enum Wochentag
{
	Montag = 1,
	Dienstag = 2,
	Mittwoch = 4,
	Donnerstag = 8,
	Freitag = 16,
	Samstag = 32,
	Sonntag = 64
}