using static System.Net.Mime.MediaTypeNames;

namespace PAD_I_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe1();
            //Aufgabe2();
            //Aufgabe3();
            //Aufgabe4();
            //Aufgabe5();
            //Aufgabe6();
            //Aufgabe7();
            //Aufgabe8();
            Aufgabe9();
        }


        static void Aufgabe1()
        {
            int anzahlTeilnehmende = 18;
            double temperatur = 22.4;
            bool findetUnterrichtStatt = false;

            Console.WriteLine("Anzahl Teilnehmende: " + anzahlTeilnehmende);
            Console.WriteLine("Aktuelle Temperatur: " + temperatur);

            if (findetUnterrichtStatt)
            {
                Console.WriteLine("Heute findet Unterricht statt");
            }
            else
            {
                Console.WriteLine("Heute findet kein Unterricht statt");
            }
        }

        static void Aufgabe2()
        {
            Console.WriteLine("Bitte geben Sie eine Zahl ein: ");
            string eingabe = Console.ReadLine();

            //a % b bedeutet: Rest der Division a / b
            // Beispiel:
            // 8/2=4 Rest 0 -> 8%2 == 0 -> gerade
            // 9/2=4 Rest 1 -> 9%2 == 1 -> ungerade

            if (int.TryParse(eingabe, out int zahl)) // Eine Option um string zu einem int umzuwandeln andere Möglichkeit siehe Aufgabe 3
            {
                if (zahl % 2 == 0)
                {
                    Console.WriteLine("Die Zahl ist gerade");
                }
                else {
                Console.WriteLine("Die Zahl ist ungerade");
                }
            }
            else
            {
                Console.WriteLine("Du schlingel hast keine Zahl eingegeben");
            }
        }

        static void Aufgabe3()
        {
            Console.WriteLine("Bitte geben Sie Ihre erste Zahl ein: ");
            int.TryParse(Console.ReadLine(), out int zahl1);
            Console.WriteLine("Bitte geben Sie Ihre zweite Zahl ein: ");
            int.TryParse(Console.ReadLine(), out int zahl2);



                // Summe:
                Console.WriteLine($"Die Summe von {zahl1} und {zahl2} lautet: {zahl1 + zahl2}");

                // grösseren Wert Option A:
                Console.WriteLine($"Die grössere Zahl von {zahl1} und {zahl2} lautet: {Math.Max(zahl1, zahl2)}");

                // grösseren Wert Option B:
                int groessereZahl1 = Math.Max( zahl1, zahl2 );
                Console.WriteLine($"Die grössere Zahl von {zahl1} und {zahl2} lautet: {groessereZahl1}");

                //Differenz der beiden Werte Option A:
                Console.WriteLine($"Die Differenz von {zahl1} und {zahl2} lautet: {zahl1 - zahl2}");

                //Differenz der beiden Werte Option B (Lutscher):
                int groessereZahl2 = Math.Max(zahl1, zahl2);
                int kleinereZahl = Math.Min(zahl1, zahl2);

                Console.WriteLine($"Die Differenz von {zahl1} und {zahl2} lautet: {kleinereZahl}");
        }


        static void Aufgabe4()
        {
            Console.WriteLine("Bitte geben Sie ein Wort ein: ");
            string eingabe = Console.ReadLine();

            // Länge der Zeichenkette
            Console.WriteLine($"Ihr Wort beinhaltet {eingabe.Length} Buchstaben ");

            //Erstes und letztes Zeichen
            Console.WriteLine($"Der erste Buchstabe Ihres Wortes lautet: {eingabe[0]}. Der letzte Buchstabe Ihres Wortes lautet: {eingabe[eingabe.Length-1]}");

            // Prüfen ob Wort mit Grossbuchstaben beginnt
            if (char.IsUpper(eingabe[0]))
            {
                Console.WriteLine($"Der erste Buchstabe Ihres Wortes ist ein Grossbuchstabe {eingabe[0]}");
            }
            else {
                Console.WriteLine($"Der erste Buchstabe Ihres Wortes ist ein Kleinbuchstabe {eingabe[0]}");

            }

            // Prüfen ob das Wort mit 'a' beginnt
            if (eingabe[0] == 'a')
            {
                Console.WriteLine($"Ihr Wort beginnt mit einem a");
            }

            // Prüfen ob das Wort ein 'a' enthält
            if (eingabe.Contains('a'))
            {
                Console.WriteLine("Ihr Wort enthält ein a");
            }
        }

        static void Aufgabe5()
        {
            int totalBetrag = LeseGanzZahl("Bitte geben Sie den Total Betrag ein");
            int bezahlterBetrag = LeseGanzZahl("Bitte geben Sie den bezahlten Betrag ein");

            PruefeBezahlung(totalBetrag, bezahlterBetrag);

        }

        private static void PruefeBezahlung(int totalBetrag, int bezahlterBetrag)
        {
            if (bezahlterBetrag > totalBetrag)
            {
                GebenGrueneAusgabe($"Rückgeld: {bezahlterBetrag - totalBetrag} Fr.");
            }
            else if (bezahlterBetrag < totalBetrag)
            {
                GebenRoteAusgabe($"Differenz: {totalBetrag - bezahlterBetrag} Fr.");
                BearbeiteNachzahlung(totalBetrag, bezahlterBetrag);
            }
            else if (bezahlterBetrag == totalBetrag)
            {
                GebenGrueneAusgabe("Vielen Dank für Ihren Einkauf.");
            }
        }

        private static void BearbeiteNachzahlung(int totalBetrag, int bezahlterBetrag)
        {
            while (bezahlterBetrag < totalBetrag) {
            int nachzahlung = LeseGanzZahl($"Bitte zahlen Sie den fehlenden Betrag ein (es fehlen{totalBetrag-bezahlterBetrag}): ");
                bezahlterBetrag += nachzahlung;

                if (bezahlterBetrag == totalBetrag)
                {
                    GebenGrueneAusgabe("Vielen Dank für Ihren Einkauf.");
                }
                else if (bezahlterBetrag > totalBetrag)
                {
                    GebenGrueneAusgabe($"Rückgeld: {bezahlterBetrag - totalBetrag} Fr.");
                }
            }
        }

        private static void GebenRoteAusgabe(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void GebenGrueneAusgabe(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static int LeseGanzZahl(string aufforderung)
        {
            while (true)
            {
                Console.WriteLine(aufforderung);
                int.TryParse(Console.ReadLine(), out int eingabe);
                if (eingabe > 0)
                {
                    return eingabe;
                }
                else
                {
                    GebenRoteAusgabe("Du schlingel hast keine gültige Zahl eingegeben");
                }

            }

            
        }


        static void Aufgabe6()
        {
            int anzahlBaukloetze = LeseGanzZahl("Wie viele Bauklötze hast du? ");
            int seitenlaenge = BerechneMaximaleSeitenlaenge(anzahlBaukloetze);

            int benoetigteBaukloetze = seitenlaenge * seitenlaenge;

            Console.WriteLine($"Maximale Seitenlänge: {seitenlaenge}");
            Console.WriteLine($"Benötigte Bauklötze: {benoetigteBaukloetze}");
            Console.WriteLine($"Übrige Bauklötze: {anzahlBaukloetze - benoetigteBaukloetze}");
        }

        static int BerechneMaximaleSeitenlaenge(int anzahlBaukloetze)
        {
            int seitenlaenge = 1;

            while (seitenlaenge * seitenlaenge <= anzahlBaukloetze)
            {
                seitenlaenge++;
            }

            return seitenlaenge - 1;
        }
        
        static void Aufgabe7()
        {
            Boolean wantNote = true; 
            List<float> noten = new List<float>();
            int wiederholung = 0;
            
            while (wantNote) {
                wiederholung++;
                Console.WriteLine($"Bitte geben Sie die {wiederholung}. Note ein: ");
                float note = float.Parse(Console.ReadLine());
                noten.Add(note);
                
                Console.WriteLine($"Das ergibt einen Notendurchschnitt von:  {noten.Sum() /noten.Count}");

                
                Console.WriteLine("Weitere Note eingeben? (j/n): ");
                wantNote = Console.ReadLine() == "j";
            }
            
            Console.WriteLine("Vielen Dank!");
        }
        
        static void Aufgabe8()
        {
            Console.Write("Bitte Startbuchstabe eingeben: ");
            char start = Console.ReadLine()[0];
    
            Console.Write("Bitte Endbuchstabe eingeben: ");
            char end = Console.ReadLine()[0];
    
            for (char c = start; c <= end; c++)
            {
                Console.Write(c);
            }
        }
        
        
        static void Aufgabe9()
        {
            Console.Write("Bitte Anzahl Klötze eingeben: ");
            int kloetze = int.Parse(Console.ReadLine());
            int pyramideZeile = 1;
            int pyramideZeileGroesse = 1;
            int rest = kloetze;

            while (rest >= pyramideZeileGroesse)
            {
                Console.WriteLine($"Zeile Nr. {pyramideZeile}");
                pyramideZeile++;
                rest = rest-pyramideZeileGroesse;
                pyramideZeileGroesse = pyramideZeileGroesse + 2;
                
                Console.WriteLine($"Es bleiben {rest} von {kloetze} übrig.");
            }
            
        }
    }
    
    
    
}
