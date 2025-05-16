namespace Entwurfsmuster
{
    public interface AllgemeineSchnittstelle
    {
        public int Dienst(int a, int b);
    }

    public class AdapterSumme : AllgemeineSchnittstelle
    {
        public int Dienst(int a, int b)
        {
            // Übersetzung der allgemeinen Schnittstelle auf den Addierer
            return new Addierer().Addiere(a, b);
        }
    }

    public class AdapterProdukt : AllgemeineSchnittstelle
    {
        public int Dienst(int a, int b)
        {
            // Übersetzung der allgemeinen Schnittstelle auf den Multiplizierer
            return new Multiplizierer().Multipliziere(a, b);
        }
    }

    public class Addierer
    {
        public int Addiere(int a, int b)
        {
            return a + b;
        }
    }

    public class Multiplizierer
    {
        public int Multipliziere(int a, int b)
        {
            return a * b;
        }
    }
}

