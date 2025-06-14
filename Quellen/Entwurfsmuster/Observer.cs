namespace Entwurfsmuster
{
    public interface Beoachter
    {
        void Benachrichtigen();
    }

    public class KonkreterBeobachter : Beoachter
    {
        public void Benachrichtigen()
        {
            // Auf der Konsole eine Nachricht ausgeben, sobald der Gegenstand aktualisiert wurde
            Console.WriteLine("Benachrichtigung erhalten");
        }
    }

    public class Gegenstand
    {
        public List<Beoachter> Beobachter { get; } = new List<Beoachter>();

        public void Aktualisieren()
        {
            // Aktualisierung des Gegenstand durchführen und dann alle Beobachter informieren.
            foreach (Beoachter beoachter in Beobachter)
            {
                beoachter.Benachrichtigen();
            }
        }
    }

    public class ObserverNutzer
    {
        public void Dienst(Gegenstand gegenstand)
        {
            // Dem Gegenstand einen neuen konkreten Beobachter hinzufügen
            gegenstand.Beobachter.Add(new KonkreterBeobachter());
            // Den Gegenstand aktualisieren
            gegenstand.Aktualisieren();
        }
    }
}
