using System.ComponentModel.Design;
using System.Text.Json;

namespace RandomGames
{
    class Program
    {
        static int teRadenNum;
        static int aantalWorpen;
        static int gegooideOgen;
        static int totaleOgen;
        static int chips = 10;

        static void Main()
        {
            Console.WriteLine("What do you want to play?");
            Console.WriteLine("(A)Guess the number (B)Dobbelen (C)Blackjack (D)Roulette");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a":
                    Console.Clear();
                    RandNum();
                    NummerRader();
                    break;
                case "b":
                    Console.Clear();
                    Dobbelen();
                    break;
                case "c":
                    Console.Clear();
                    BlackJack();
                    break;
                case "d":
                    Console.Clear();
                    Roulette();
                    break;
            }
        }
        static void RandNum()
        {
            Random rnd = new Random();
            teRadenNum = rnd.Next(1, 101);
        }
        static void NummerRader()
        {
            int geradenNum;
            int aantalGokken = 5;
            while (aantalGokken > 0)
            {
                Console.WriteLine("vul het getal in wat jij denkt dat het is tussen de 1 en 100.");
                geradenNum = int.Parse(Console.ReadLine());
                aantalGokken--;
                if (geradenNum == teRadenNum)
                {
                    Console.WriteLine("Gefeliciteerd, je hebt het getal geraden!");
                    Console.ReadKey();
                    Console.Clear();
                    Main();
                }
                else
                {
                    if (geradenNum > teRadenNum)
                    {
                        Console.WriteLine("Het geraden getal is te hoog.");
                        Console.WriteLine("je hebt nog " + aantalGokken + " kansen over.");
                    }
                    else if (geradenNum < teRadenNum)
                    {
                        Console.WriteLine("Het geraden getal is te laag.");
                        Console.WriteLine("je hebt nog " + aantalGokken + " kansen over.");
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
            Main();
        }
        static void Dobbelen()
        {
            Console.WriteLine("hoevaak wil je de dobbelsteen gooien?");
            aantalWorpen = int.Parse(Console.ReadLine());
            for (int i = 0; i < aantalWorpen; i++)
            {
                DobbelSteen();
                totaleOgen += gegooideOgen;
                Console.WriteLine("Totaal aantal ogen: " + totaleOgen);
                Console.ReadKey();
            }
        }
        static void DobbelSteen()
        {
            Random rnd = new Random();
            gegooideOgen = rnd.Next(1, 7);
            Console.WriteLine("je hebt " + gegooideOgen + " gegooid.");
        }
        static void BlackJack()
        {

        }
        static void Roulette()
        {
            Random rnd = new Random();
            int gewonnenGetal;
            int ingezetGetal;
            Console.WriteLine("Waar wil je een chip op inzetten?");
            Console.WriteLine("je kunt inzetten op getallen van 0 tot en met 36 door het getal in te vullen.");
            Console.WriteLine("je kan ook inzetten op andere dingen. Wat wil je?");
            Console.WriteLine("(A)Op een getal inzetten (B)Andere inzetten");
            string choice = Console.ReadLine().ToLower();
            gewonnenGetal = rnd.Next(0, 37);
            switch (choice)
            {
                case "a":
                    Console.WriteLine("op welk getal wil je inzetten?");
                    chips -= 1;
                    ingezetGetal = int.Parse(Console.ReadLine());
                    if (ingezetGetal == gewonnenGetal)
                    {
                        Console.WriteLine("je hebt ingezet op het getal " + ingezetGetal + " en je hebt gewonnen.");
                        chips += 35;
                        Console.WriteLine("je hebt nu " + chips + " chips.");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        Console.WriteLine("je hebt ingezet op het getal " + ingezetGetal + " en bent je inzet kwijtgeraakt.");
                        Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                        Console.WriteLine("je hebt nu " + chips + " chips.");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                    break;
                case "b":
                    Console.WriteLine("Waar zou je op willen inzetten?");
                    Console.WriteLine("(A)Even (B)Oneven (C)Rood (D)Zwart (E)1 t/m 18 (F)19 t/m 36 (G)1st 12 (H)2nd 12 (I)3rd 12 (J)Bovenste rij (K)Middelste rij (L)Onderste rij");
                    string choice2 = Console.ReadLine().ToLower();
                    chips -= 1;
                    switch (choice2)
                    {
                        case "a":
                            Console.WriteLine("je hebt een chip ingezet op even.");
                            if (gewonnenGetal % 2 == 0)
                            {
                                Console.WriteLine("het getal was even je inzet is verdubbeld");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 2;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het getal was oneven je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "b":
                            Console.WriteLine("je hebt een chip ingezet op oneven.");
                            if (gewonnenGetal % 2 != 0)
                            {
                                Console.WriteLine("het getal was even je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het getal was oneven je inzet is verdubbeld");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 2;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "c":
                            Console.WriteLine("je hebt een chip ingezet op rood.");
                            if (gewonnenGetal % 2 == 0)
                            {
                                Console.WriteLine("de kleur was rood je inzet is verdubbeld");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 2;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("de kleur was zwart je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "d":
                            Console.WriteLine("je hebt een chip ingezet op zwart.");
                            if (gewonnenGetal % 2 == 1)
                            {
                                Console.WriteLine("de kleur was zwart je inzet is verdubbeld");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 2;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("de kleur was rood je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "e":
                            Console.WriteLine("je hebt een chip ingezet op 1 t/m 18.");
                            if (gewonnenGetal < 19 && gewonnenGetal > 0)
                            {
                                Console.WriteLine("het winnende getal was tussen de 1 en 18 je inzet is x2.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 2;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het winnende getal was niet tussen de 1 en 18 je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "f":
                            Console.WriteLine("je hebt een chip ingezet op 19 t/m 36.");
                            if (gewonnenGetal < 37 && gewonnenGetal > 18)
                            {
                                Console.WriteLine("het winnende getal was tussen de 19 en 36 je inzet is x2.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 2;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het winnende getal was niet tussen de 19 en 36 je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "g":
                            Console.WriteLine("je hebt een chip ingezet op de eerste 12.");
                            if (gewonnenGetal < 13 && gewonnenGetal > 0)
                            {
                                Console.WriteLine("het winnende getal was in de eerste 12 je inzet is x3.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 3;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het winnende getal was niet in de eerste 12 je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "h":
                            Console.WriteLine("je hebt een chip ingezet op de tweede 12.");
                            if (gewonnenGetal < 25 && gewonnenGetal > 11)
                            {
                                Console.WriteLine("het winnende getal was in de tweede 12 je inzet is x3.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 3;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het winnende getal was niet in de tweede 12 je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "i":
                            Console.WriteLine("je hebt een chip ingezet op de derde 12.");
                            if (gewonnenGetal < 37 && gewonnenGetal > 24)
                            {
                                Console.WriteLine("het winnende getal was in de derde 12 je inzet is x3.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 3;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het winnende getal was niet in de derde 12 je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "j":
                            Console.WriteLine("je hebt een chip ingezet op de bovenste rij.");
                            if (gewonnenGetal % 3 == 0)
                            {
                                Console.WriteLine("het getal was in de bovenste rij je inzet is x3");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 3;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het getal was niet op de bovenste rij je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "k":
                            Console.WriteLine("je hebt een chip ingezet op de midelste rij.");
                            if (gewonnenGetal % 3 == 2)
                            {
                                Console.WriteLine("het getal was in de middelste rij je inzet is x3");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 3;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het getal was niet op de middelste rij je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                        case "l":
                            Console.WriteLine("je hebt een chip ingezet op de onderste rij.");
                            if (gewonnenGetal % 3 == 1)
                            {
                                Console.WriteLine("het getal was in de onderste rij je inzet is x3");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                chips += 3;
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            else
                            {
                                Console.WriteLine("het getal was niet op de onderste rij je bent je inzet kwijt.");
                                Console.WriteLine("het winnende getal was: " + gewonnenGetal);
                                Console.WriteLine("je hebt nu " + chips + " chips.");
                                Console.ReadKey();
                                Console.Clear();
                                Main();
                            }
                            break;
                    }
                    break;
            }
        }
    }
}

