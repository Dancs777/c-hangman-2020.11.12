using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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
            char input = 'a';
            string word = Switcheles();
            string blank = MakeBlank(word);
            int nehezseg = Nehezseg();
            input = LetterParse();
            /*while (nehezseg>0)
            {
                input = LetterParse();
                for (int i = 0; i < word.Length; i++)
                {
                    if (input == word[i])
                    {

                    }
                    
                }
            }*/

            Console.WriteLine(word);
            Console.WriteLine(blank);
            Console.WriteLine(nehezseg);
            Console.WriteLine(input);
            
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
                    default: Console.WriteLine("This is not a topic number"); IfSzam = false; break;
                }

            } while (IfSzam == false);
            return szo;
        }
        static int Nehezseg()
        {
            
            Console.WriteLine("Which difficulty you would like to play at?\n\t1:Rich kid(18 try)\n\t2:Casual(14 try)\n\t3:Veteran(10 try)\n\t4:Dark Souls(7 try)");
            int szam = IntParse();
            int visszaaadSzam = 0;
            bool IfSzam = true;
            do
            {
                if (IfSzam == false) { szam = IntParse(); }
                
                switch (szam)
                {
                    case 0: break;
                    case 1: visszaaadSzam = 18;  IfSzam = true; break;
                    case 2: visszaaadSzam = 14 ; IfSzam = true; break;
                    case 3: visszaaadSzam = 10 ; IfSzam = true; break;
                    case 4: visszaaadSzam = 7 ;  IfSzam = true; break;
                    default: Console.WriteLine("This is not a difficulty"); IfSzam = false; break;
                }

            } while (IfSzam == false);
            return visszaaadSzam;
        }
        static List<char> letters = new List<char>();
        
        static void szobeolvasasLetter()
        {
            StreamReader sr = new StreamReader("letters.txt");
            while (!sr.EndOfStream)
            {
                letters.Add(char.Parse(sr.ReadLine()));
            }
            sr.Close();
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
        
        /*static Char LetterParse()
        {
            Console.WriteLine("Gimme Letter");
            bool ifInt;
            Char karakter;
            do
            {
                string switchszam = Console.ReadLine();

                ifInt = Char.TryParse(switchszam, out karakter);
                if (ifInt == false || !LetterCheck(karakter)) { Console.WriteLine("This is not a letter"); };
                    
            } while (!LetterCheck(karakter));
            return karakter;
        }*/
        static bool LetterCheck(char karakter)
        {
            karakter = char.ToUpper(karakter);

            for (int i = 0; i < letters.Count; i++)
            {
                if (karakter == letters[i])
                {
                    return true;
                }
            }

            return false;
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
