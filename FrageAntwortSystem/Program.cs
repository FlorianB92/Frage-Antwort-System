﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FrageAntwortSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Programm starten
            Console.WriteLine("FRAGE-ANTWORT-SYSTEM\n********************\n");
            //Aufruf der Methode "Ausführen()" im instanziierten Klasse
            // swnobjekt "breitsprecher" der projektspezifischen Klasse "Breitsprecher"
            Breitsprecher breitsprecher = new Breitsprecher();
            breitsprecher.Ausfueren();
            Console.WriteLine();

            //Programm anhalten
            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }// Main()
    }// Class
}// namespace
