using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Alpha
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Jatek();  
        }
        
        static void Jatek()
        {
            char input;
            string word = Switcheles();
            string blank = MakeBlank(word);
            /*while (true)
            {
                input = Convert.ToChar(Console.ReadLine());
                Guess(input, word, blank);
            }
           */
            Console.WriteLine(word);
            Console.WriteLine(blank);
        }
        static string MakeBlank(string word)
        {
            string output = "";
            for (int i = 0; i < word.Length; i++)
            {
                output = string.Concat(output, "_");
            }
            return output;
        }
        static string Switcheles()
        {
            string szo ="";
            Console.WriteLine("Which topic you would like to chose?\nPress zero to cancel.\n\t1:All\n\t2:Fruits");
            int szam = IntParse();
            bool IfSzam = true;
            do
            {
                if (IfSzam == false) { szam = IntParse(); }
                IfSzam = true;
                switch (szam)
                {
                    case 0: break;
                    case 1: /*Method();*/ IfSzam = true; break;
                    case 2: szo = SzobeolvasasFruits(); IfSzam = true; break;
                    default: Console.WriteLine("Ez nem egy feladatszám"); IfSzam = false; break;
                }

            } while (IfSzam == false);
            return szo;
        }
        static string SzobeolvasasFruits()
        {
            StreamReader sr = new StreamReader("fruits.txt");
            //string beolvasValtozo = "";
            List<string> fruits = new List<string>();
            while (!sr.EndOfStream)
            {
                fruits.Add(sr.ReadLine());
                
            }
            sr.Close();
            return fruits[rnd.Next(0, fruits.Count())];
        }
        

        // string - szo UGYANOLYAN HOSSZU masik string - megoldas underlineokkal.
        //     Ahol jó, ott átrakjuk a szo[i]-t a megoldas[i]-re
        // all.txt nem kell, az all-nál minden txt-t beolvasunk egy listába.
        // difficulties -  Rich kid 18; Casual 14; Veteran 10; Dark Souls 7;
        static Char CharParse()
        {
            bool ifInt;
            Char karakter;
            do
            {
                string switchszam = Console.ReadLine();

                ifInt = Char.TryParse(switchszam, out karakter);
                if (ifInt == false) { Console.WriteLine("Ez nem egy betű"); };

            } while (ifInt == false);
            return karakter;
        }
        static int IntParse()
        {
            bool ifInt;
            int szam1;
            do
            {
                string switchszam = Console.ReadLine();

                ifInt = int.TryParse(switchszam, out szam1);
                if (ifInt == false) { Console.WriteLine("Ez nem egy szám"); };

            } while (ifInt == false);
            return szam1;
        }
    }
}
