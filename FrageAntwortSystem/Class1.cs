using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace FrageAntwortSystem
{
    public class Breitsprecher
    {
        static bool quiz_aktiv = true;
        static int richtige_fragen = 0;
        static string eingabe;
        public Breitsprecher()
        {
            //Dieser Konstruktor bleibt leer
        }
        public void Ausfueren()
        {
            while (quiz_aktiv)
            {
                Start();
            }
        }
        static void Frage_Erstellung() //hier werden die Fragen als Klasser erstellt
        {
            List<string> line = new List<string>();
            StreamReader sr = new StreamReader(@"C:\Projekte\Visual\FrageAntwortSystem\FRAGEN.txt"); // hier wird die Textdokument ausgelesen

            do
            {
                for(int x=0; x<19; x++)
                    line.Add(sr.ReadLine());  // hier werden die gelesene Zeilen auf line überschrieben
            } while(sr.EndOfStream);

            Zufalls_frage();


             void Frage_1()
            {
                var frage_1 = new Fragen();
                frage_1.Thema = line[0];
                frage_1.Frage = line[1];
                frage_1.Antworten.Add(line[2]);
                frage_1.Antworten.Add(line[3]);
                frage_1.Antworten.Add(line[4]);
                frage_1.Antworten.Add(line[5]);
                frage_1.Antworten.Add(line[6]);
                frage_1.Antworten.Add(line[7]);
                frage_1.Richtige_Antwort = line[8];
                frage_1.Ausgabe();
                Console.WriteLine();
                Console.Write("\nAntwort: ");
                eingabe = Console.ReadLine();
                
                while (true)
                {
                    int z;
                    bool isnumber = int.TryParse(eingabe, out z);
                    if (isnumber)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bitte nur die Nummer eingeben");
                        eingabe = Console.ReadLine();
                    }
                }
                int eingabe_1 = Int32.Parse(eingabe);
                if (eingabe_1 == 00007)
                {
                    Console.WriteLine("Die Frage wurde richtig beantwortet.");
                    Console.WriteLine();
                    richtige_fragen = richtige_fragen + 1;
                }
                else
                {
                    Console.WriteLine("Die Frage wurde falsch beantwortet");
                    Console.WriteLine();
                }
            }
            void Frage_2()
            {
                var frage_2 = new Fragen();
                frage_2.Thema = line[9];
                frage_2.Frage = line[10];
                frage_2.Antworten.Add(line[11]);
                frage_2.Antworten.Add(line[12]);
                frage_2.Antworten.Add(line[13]);
                frage_2.Antworten.Add(line[14]);
                frage_2.Antworten.Add(line[15]);
                frage_2.Antworten.Add(line[16]);
                frage_2.Antworten.Add(line[17]);
                frage_2.Richtige_Antwort = line[18];
                frage_2.Ausgabe();
                Console.WriteLine();
                Console.Write("\nAntwort: ");
                eingabe = Console.ReadLine();

                while (true)
                {
                    int z;
                    bool isnumber = int.TryParse(eingabe, out z);
                    if (isnumber)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bitte nur die Nummer eingeben");
                        eingabe = Console.ReadLine();
                    }
                }
                int eingabe_1 = Int32.Parse(eingabe);
                if (eingabe_1 == 00016)
                {
                    Console.WriteLine("Die Frage wurde richtig beantwortet.");
                    Console.WriteLine();
                    richtige_fragen = richtige_fragen + 1;
                }
                else
                {
                    Console.WriteLine("Die Frage wurde falsch beantwortet.");
                    Console.WriteLine();
                }

            }
            Console.WriteLine("Sie haben "+ richtige_fragen +" von 5 Fragen richtig beantwortet.");

            void Zufalls_frage()
            {
                int n = 2; int k = 2;
                int[] zahlen = Enumerable.Range(0, n).ToArray();
                Random r = new Random();
                for (int i = 0; i < k; i++)
                {
                    int index = r.Next(i, n);
                    int tmp = zahlen[index];
                    zahlen[index] = zahlen[i];
                    zahlen[i] = tmp;
                    switch (zahlen[i])
                    {
                        case 0:
                            Frage_1();
                            break;
                        case 1:
                            Frage_2();
                            break;
                    }
                }
            }
        }
        void Start() //hier wird die Methode Frage_Erstellung mit einer Zeitmesseung gestartet
        {
            Stopwatch zeit =new Stopwatch();
            zeit.Start();
            Frage_Erstellung();
            zeit.Stop();
            TimeSpan z = zeit.Elapsed; 
            int tz = Convert.ToInt32(z.TotalSeconds); // wandelt die sekunden in int, um keine Kommastelle zubekommen
            Console.WriteLine("Für den Test benötigten Sie "+ tz + " Sekunden.");
            quiz_aktiv =false;
        }
    }

    public class Fragen  // hier wird eine Klasse "Fragen" definiert, die dann alle Werte zuweist 
    {
        private string thema;
        private string frage;
        private List<string> antworten = new List<string>();
        private string richtige_antwort;

        public void Ausgabe()  //diese Methode gibt die Ausgabe der Frage/Antwort aus
        {
            if (frage.Length > 10)
            {
                string hilfstring = "";
                bool leerzeichen = true;

                for(int i=0; i<frage.Length; i++)
                {
                    hilfstring += frage[i];
                    if(i%10 == 0 && i !=0 || leerzeichen) // soll den Text formatieren aber geht noch nicht
                    {
                        if(frage.ToString() != " ")
                            leerzeichen=false;
                        else
                        {
                            hilfstring += "\r\n";
                            leerzeichen = true;
                        }
                    }
                }
                frage = hilfstring;
            }
            Console.WriteLine(thema);
            Console.WriteLine(frage);
            for(int i=0; i<antworten.Count; i++)
            {
                Console.WriteLine(antworten[i]);
            }
        }
        public string Thema // die Strings sind für die Zuweisung der line's
        {
            get { return thema; }
            set { thema = value; }
        }
        public string Frage
        {
            get { return frage; }
            set { frage = value; }
        }
        public List<string> Antworten
        {
            get { return antworten; }
            set { antworten = value; }
        }
        public string Richtige_Antwort
        {
            get { return richtige_antwort; }
            set { richtige_antwort = value; }
        }
    }
}
