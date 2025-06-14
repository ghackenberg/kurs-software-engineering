namespace Entwurfsmuster
{
    public class Singleton
    {
        // Kann nicht von Außen aufgerufen werden
        private Singleton()
        {
            // Initialisierung
        }

        // Einer der öffentlichen Dienste des Singleton
        public void Dienst()
        {
            // Implementierung
        }

        // Erstellung einer einzigen öffentlichen Instanz
        public static Singleton Instanz = new Singleton();
    }

    public class Nutzer
    {
        public void Methode()
        {
            Singleton.Instanz.Dienst();
        }
    }
}
