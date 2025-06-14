// Implizite Namenraumangabe!
using Namensräume.B;

namespace Namensräume
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Explizite Namensraum-Angabe
            var a = new A.MeineKlasse();

            // Implizite Namensraum-Angabe
            // ... (über using)
            var b = new MeineKlasse();
        }
    }
}
