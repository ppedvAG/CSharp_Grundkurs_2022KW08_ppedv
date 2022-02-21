#region Variablen
//Variable: Typ Name;
int zahl; //Variablendefinition
zahl = 5; //Variablenzuweisung
Console.WriteLine(zahl); //cw + Tab + Tab: Console.WriteLine()

int zahlMitZuweisung = 5; //Definition mit Zuweisung
Console.WriteLine(zahlMitZuweisung);

int zahlMalZwei = zahl * 2; //Arithmetik direkt in der Zuweisung
Console.WriteLine(zahlMalZwei);

string stadt = "Berlin";
Console.WriteLine(stadt);

char zeichen = 'A';
Console.WriteLine(zeichen);

double kosten = 48.23d;
Console.WriteLine(kosten);

float kostenFloat = 43.88f;
//0.2 - 0.1 = 0.1000000000000000000004
Console.WriteLine(kostenFloat);

decimal kostenDecimal = 2_835_128_093_205.44m; //Geldwerte: 0.30000000000000000000000000000000000004
Console.WriteLine(kostenDecimal);

string umbruch = "Hallo ich bin \n ein string"; //\n = Zeilenumbruch
Console.WriteLine(umbruch);

string stringKombination = umbruch + "\t" + kostenDecimal; //$"{umbruch}\t{kostenDecimal}"
Console.WriteLine(stringKombination);

string str = "Test";
Console.WriteLine("Platzhalter 0: {0}", str);

string stringInterpolation = $"Ein Code {kosten} {kosten * kostenFloat}"; //$ -> Code im String
Console.WriteLine(stringInterpolation);

string verbatimString = @"C:\Users\Folder\n
	Umbruch"; //@ -> Keine Escapesequenzen
Console.WriteLine(verbatimString);
#endregion

//Console.WriteLine("text"); Strg + K, C: Alle markierten Zeilen auskommentieren
//Console.WriteLine("text"); Strg + K, U: Alle markierten Zeilen einkommentieren
//Console.WriteLine("text");

#region Eingabe
string eingabe = Console.ReadLine(); //Zeileneingabe (Enter um Eingabe zu beenden)
Console.WriteLine(eingabe);

char eingabeReadKey = Console.ReadKey().KeyChar; //Zeicheneingabe (ohne Enter)
Console.WriteLine(eingabeReadKey);

int eingabeZahl = int.Parse(eingabe); //Umwandlung zu einer ganzen Zahl
Console.WriteLine(eingabeZahl * 2);

int convert = Convert.ToInt32(eingabeZahl); //Alte Umwandlung
Console.WriteLine(convert);

double eingabeDouble = double.Parse(eingabe); //Eingabe in Deutschland/Österreich mit ,
Console.WriteLine(eingabeDouble);             //Außerhalb mit .

bool boolParse = bool.Parse(eingabe);
Console.WriteLine(boolParse);
#endregion

#region Typecasting
int implizit = 50; //impliziter Cast: Casten ohne erzwingen von Typ
double implizitDouble = implizit;

double doubleZahl = 50.5; //expliziter Cast: Casten mit erzwingen von Typ da Konversierung nicht erlaubt ohne explizierter Typ (Kommastellen)
int intZahl = (int) doubleZahl;
Console.WriteLine(intZahl);

double zero = 0.0;
double divisionDurchZero = 2 / zero; //Ungenauigkeit sorgt für 2 * 0.0 = 8
Console.WriteLine(divisionDurchZero);
#endregion

#region Mathematik
int zahl1 = 7; //Modulo (%): Gibt den Rest einer Division zurück
int zahl2 = 3;
Console.WriteLine(zahl1 % zahl2);

zahl1++;
zahl1 = zahl1 + zahl2;
zahl1 += zahl2; //Berechnung mit direkter Zuweisung, Ergebnis wird in zahl1 geschrieben
Console.WriteLine(zahl1 + zahl2);

double round = 2.6; //Aufgerundet, 2.5 wird abgerundet
Console.WriteLine(Math.Round(round));

Console.WriteLine(Math.Min(zahl1, zahl2)); //Kleinere Zahl von beiden wird geprinted
Console.WriteLine(Math.Max(zahl1, zahl2)); //Größere Zahl von beiden wird geprinted
#endregion

LabLoesung.Execute();