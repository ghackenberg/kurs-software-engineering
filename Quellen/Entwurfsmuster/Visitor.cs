namespace Entwurfsmuster
{
    // Definition der Arten von Elementen, die in der Struktur auftreten können
    public interface Element { /* ... */ }
    public class Gruppe : Element
    {
        public List<Element> Kinder { get;  } = new List<Element>();
    }
    public class Linie : Element { /* ... */ }
    public class Kreis : Element { /* ... */ }

    public interface Besucher
    {
        // Methoden für alle Arten von Elementen, die in der Struktur auftreten können
        void Besuche(Element element);
        void Besuche(Gruppe gruppe);
        void Besuche(Linie linie);
        void Besuche(Kreis kreis);
    }

    public abstract class AbstrakterBesucher : Besucher
    {
        public void Besuche(Element element)
        {
            // Prüfe den konkreten Typ des Elements und rufe die entsprechende Methode auf
            if (element is Gruppe) Besuche((Gruppe)element);
            else if (element is Linie) Besuche((Linie)element);
            else if (element is Kreis) Besuche((Kreis)element);
            else throw new Exception("Element type not supported!");
        }

        public void Besuche(Gruppe gruppe)
        {
            // Wende diesen Besucher auf alle Kinder der aktuellen Gruppe an
            foreach (Element kind in gruppe.Kinder) Besuche(kind);
        }

        public abstract void Besuche(Linie linie);
        public abstract void Besuche(Kreis kreis);
    }
}
