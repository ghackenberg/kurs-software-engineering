namespace Entwurfsmuster
{
    // Schnittstellendefinition für alle Arten von Knoten in der Knotenstruktur
    public interface Knoten
    {
        public int ZähleKnoten();
    }

    // Implementierung eines Gruppenknoten mit beliebiger Anzahl an Kindknoten
    public class GruppenKnoten : Knoten
    {
        public List<Knoten> Kinder { get; } = new List<Knoten>();

        public int ZähleKnoten()
        {
            int anzahl = 1;
            foreach (Knoten kind in Kinder)
            {
                anzahl += kind.ZähleKnoten();
            }
            return anzahl;
        }
    }

    // Implementierung eines Blattknoten, welcher keine weitern Knoten enthält
    public class BlattKnoten : Knoten
    {
        public int ZähleKnoten()
        {
            return 1;
        }
    }

    // Nutzer einer beliebigen Knotenstruktur
    public class KnotenNutzer
    {
        public void Dienst(Knoten knoten)
        {
            Console.WriteLine(knoten.ZähleKnoten());
        }
    }
}

