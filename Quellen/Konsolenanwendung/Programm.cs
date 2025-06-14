//using Klassenbibliothek;
namespace Konsolenanwendung
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            // Variable mit boolschen Literal
            var a = true;

            // Variable mit numerischen Literal
            var b = 2;

            // Variable mit Zeichenkettenliteral
            var c = "Zeichenkette";

            // Boolsche Rechnung mit Literalen
            var d = true && false;

            // Numerische Rechnung mit Literalen
            var e = 1 + 5 * 7;

            // Geklammerte numerische Rechnung mit Literalen
            var f = (1 + 5) * 7;

            // Boolsche Rechnung mit Variable
            var g = true || d;

            // Numerische Rechnung mit variable
            var h = e - 5 / 3;

            // Geklammerte numerische Rechnung mit Variable
            var i = (e - 5) / 2;

            // Datenbasierte Verzweigung
            switch (b)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            // Berechnungsbasierte Verzweigung
            if (a)
            {

            }
            else if (d)
            {

            }
            else
            {

            }

            // Ausnahsmenbasierte Verzweigung
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {

            }
            finally
            {

            }

            // Schleife mit vorheriger Prüfung der Bedingung
            var j = 0;
            while (j < 10)
            {
                j++;
            }

            // Schleife mit späterer Prüfung der Bedingung
            var k = 0;
            do
            {
                k++;
            }
            while (k < 10);

            // Schleife mit kompakterer Schreibweise
            for (var l = 0; l < 10; l++)
            {

            }

            // Schleife mit Werten
            var m = new int[] { 1, 2, 3 };

            foreach (var n in m)
            {

            }

            // Funktionsaufruf mit Literalen
            Addition(1, 2);

            // Funktionsaufruf mit Operatoren
            Subtraktion(1 + 2, 2);

            // Funktionsaufruf mit Funktionsaufrufen
            Multiplikation(Addition(1, 2), 2);

            // Funktionsaufruf mit Variablen
            var o = Subtraktion(1, 2);

            Division(o, 2);

            // Klasse Kunde instanziieren
            var p = new Klassenbibliothek.Kunde("Max", "Muster", new DateTime(2010, 5, 15));
            var q = new Klassenbibliothek.Kunde("Anna", "Muster", new DateTime(2015, 8, 21));

            // Eigenschaften lesen
            Console.WriteLine($"{p.Vorname} {p.Nachname}");
            Console.WriteLine($"{q.Vorname} {q.Nachname}");

            // Eigenschaften schreiben
            p.Vorname = "Peter";
            q.Vorname = "Julia";

            // Methoden aufrufen
            Console.WriteLine($"{p.Vorname} ist {p.Alter().TotalDays} Tage alt");
            Console.WriteLine($"{q.Vorname} ist {q.Alter().TotalDays} Tage alt");

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);

            Console.WriteLine(g);
            Console.WriteLine(h);
            Console.WriteLine(i);

            ExponentialFunktionIterativ(1, 5);
            ExponentialFunktionRekursiv(1, 5);
        }

        public static double Addition(double a, double b)
        {
            return a + b;
        }

        public static double Subtraktion(double a, double b)
        {
            return Addition(a, -b);
        }

        public static double Multiplikation(double a, double b)
        {
            return a * b;
        }

        public static double Division(double a, double b)
        {
            return Multiplikation(a, 1 / b);
        }

        // Berechnung der Exponentialfunktion mit ITERATIVEM Verfahren
        public static double ExponentialFunktionIterativ(double basis, uint exponent)
        {
            // Initialisierung des Ergebnisses
            var ergebnis = 1d;

            // Durchführung der Exponentialrechnung
            while (exponent > 0)
            {
                // Basis multiplizieren
                ergebnis *= basis;

                // Exponent dekrementieren
                exponent--;
            }

            // Rückgabe des Berechnungsergebnisses
            return ergebnis;
        }

        // Berechnung der Exponentialfunktion mit REKURSIVEM Verfahren
        public static double ExponentialFunktionRekursiv(double basis, uint exponent)
        {
            // Prüfung der Abbruchbedingung für die Rekursion
            if (exponent == 0)
            {
                // Rückgabe des Startwertes der Exponentialfunktion
                return 1d;
            }
            else
            {
                // Rekursiver Aufruf der Funktion mit reduziertem Problem
                var rest = ExponentialFunktionRekursiv(basis, exponent - 1);

                // Durchführung eines einzigen Rechenschritts der Exponentialfunktion
                return rest * basis;
            }
        }
    }
}