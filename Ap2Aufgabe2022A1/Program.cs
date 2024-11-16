
using System.Reflection.Metadata;

namespace Ap2Aufgabe2022A1
{
    internal class Program
    {
        // beispieldaten
        public static int[][] verbrauch =
        [ 
            [ 1001, 23, 28, 31, 35, 42, 45, 47, 50, 56, 61, 67, 73, 78 ],
            [ 1002, 25, 29, 33, 37, 42, 46, 49, 53, 58, 62, 66, 72, 78 ],
            [ 5999, 24, 30, 34, 40, 44, 48, 55, 62, 66, 71, 77, 82, 88 ]
        ];

        static void Main(string[] args)
        {
            Console.WriteLine("AP2 Aufgabe 2022 Nr. 1 \n");

            // testaufrufe der statistik methode (nicht teil der aufgabe!)
            int limit = 5;
            Console.WriteLine("Limit: " + limit);
            Console.WriteLine(statistik(verbrauch, limit));

            limit = 4;
            Console.WriteLine("Limit: " + limit);
            Console.WriteLine(statistik(verbrauch, limit));

            Console.WriteLine("\nPress [ENTER] to exit...");
            Console.ReadLine();
        }

        // die eigentliche aufgabe => die methode "statistik" zu schreiben:
        private static Jahresstatistik statistik(int[][] verbrauch, int limit)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int v = 0;
            List<Monatsverbrauch> lst = new List<Monatsverbrauch>();

            for (int i = 0; i < verbrauch.Length; i++)
            {
                for (int j = 2; j <= 13; j++)
                {
                    v = verbrauch[i][j] - verbrauch[i][j -1];
                    if (v < min) 
                        min = v;
                    if (v > max) 
                        max = v;
                    if (v > limit)
                    {
                        lst.Add(new Monatsverbrauch(verbrauch[i][0], j -1, v));
                    }
                }
            }

            return new Jahresstatistik(min, max, lst);
        }
    }

    // die vorgegebenen klassen Jahresstatistik + Monatsverbrauch
    public class Jahresstatistik
    {
        public int minVerbrauch { get; set; }
        public int maxVerbrauch { get; set; }
        public List<Monatsverbrauch> limitVerbraucher { get; set; }

        public Jahresstatistik(int minVerbrauch, int maxVerbrauch, List<Monatsverbrauch> limitVerbraucher)
        {
            this.minVerbrauch = minVerbrauch;
            this.maxVerbrauch = maxVerbrauch;
            this.limitVerbraucher = limitVerbraucher;
        }

        // ToString um ein ergebnis auf der console ausgeben zu können (nicht teil der Aufgabe!)
        public override string ToString()
        {
            string statistik = $"Jahresstatistik \n" +
                $"Minimale Verbrauch:  {minVerbrauch, 4} \n" +
                $"Maximaler Verbrauch: {maxVerbrauch, 4} \n" +
                $"Verbraucher die das vorgegebene Limit überschritten haben: \n";

            foreach (var verbraucher in limitVerbraucher)
            {
                statistik += 
                    $"VerbraucherNr: {verbraucher.VerbraucherNr}   " +
                    $"MonatsNr: {verbraucher.MonatsNr, 2}   " +
                    $"Verbrauch: {verbraucher.Verbrauch, 3} \n";
            }
            
            return statistik;
        }
    }

    public class Monatsverbrauch
    {
        public int VerbraucherNr { get; set; }
        public int MonatsNr { get; set; }
        public int Verbrauch { get; set; }
        
        public Monatsverbrauch(int verbraucherNr, int monatsNr, int verbrauch)
        {
            VerbraucherNr = verbraucherNr;
            MonatsNr = monatsNr;
            Verbrauch = verbrauch;
        }
    }
}
