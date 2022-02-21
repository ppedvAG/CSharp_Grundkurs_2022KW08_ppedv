#region Arrays
int[] zahlen = new int[5]; //Array mit Länge 5 (höchste Stelle ist 4)
zahlen[1] = 5; //Zuweisung des Werts 5 an die Stelle 1
Console.WriteLine(zahlen[0]);

int[] zahlenDirekt = new int[] { 2, 3, 4, 5 }; //Mit Initialwerten

int[] zahlenDirektKurz = new[] { 2, 3, 4, 5 }; //Kurzschreibweise

int[] zahlenDirektNochKuerzer = { 2, 3, 4, 5 }; //Noch kürzer

Console.WriteLine(zahlenDirekt.Length); //Gibt Länge von Array aus

Console.WriteLine(zahlenDirekt.Sum()); //Summiert das Array auf

int[,] zweiDArray = new int[3, 2]; //2D-Array, beliebig viele Dimensionen möglich mit mehr Beistrichen
zweiDArray[1, 1] = 3;
Console.WriteLine(zweiDArray[1, 1]);
/*	Array Darstellung:
 *	| 0, 0 |
 *	| 0, 1 |
 *	| 0, 0 |
 */

Console.WriteLine(zweiDArray.GetLength(1)); //Länge von Dimension (2)

int[,] zweiDInit = { { 1, 1, 1 }, { 3, 6, 10 } }; //Direkt initialisiert

Console.WriteLine(zweiDInit.Rank); //Anzahl Dimensionen
#endregion

#region Bedingungen
int zahl1 = 3;
int zahl2 = 4;
if (zahl1 == zahl2)
{
	Console.WriteLine("Zahl1 gleich Zahl2");
}
else
{
	Console.WriteLine("Zahl1 ungleich Zahl2");
}

Console.WriteLine(zahl1 == zahl2 ? "Zahl1 gleich Zahl2" : (zahl1 < zahl2 ? "Zahl1 kleiner Zahl2" : "Zahl1 größer Zahl2"));
#endregion

LabLoesung.Execute();