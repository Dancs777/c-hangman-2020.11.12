using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Alpha
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Jatek(); // somehow i made it not work. YEA
        }
        static void Jatek()
        {
            szobeolvasasLetter();
            char input = 'a';
            string word = Switcheles();
            string blank = MakeBlank(word);
            char[] üres = blank.ToCharArray();
            int nehezseg = Nehezseg();
            int probalkozas = word.Length;
            char underscore = '_';
            bool ifFeluliras;
            Console.WriteLine("Please give me a letter from the English Alphabet");
            do
            {
                bennevan = false;
                ifFeluliras = false;
                input = LetterParse();
                Console.Clear();
                DisplayUsedCharacters(input);
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.ToLower(input) == word[i])
                    {
                        üres[i] = char.ToUpper(input);
                        ifFeluliras = true;
                    }
                    if (underscore != üres[i]&&bennevan == false)
                    {
                        probalkozas--;
                    }
                }
                DisplayCurrent(üres);
                if (bennevan == true) { Console.WriteLine("This character was tried before, therefore yet failed. "); }
                if (probalkozas == 0) { Console.WriteLine($"Congratulations, you have won the game\nYour lives remaining:{nehezseg}"); break; }
                else { probalkozas = word.Length; }
                if (ifFeluliras == false) { nehezseg--; Console.WriteLine($"This is letter is not included in the word.You have {nehezseg} lives remaining\n"); }
                else { Console.WriteLine($"Your character is in the word. You have {nehezseg} lives remaining"); }
                if (nehezseg == 0) { Console.WriteLine($"Sorry, you have lost the game. Your word was {word}"); }
               

            } while (nehezseg > 0);
        }
        /*
         * 
        static bool isNew(char input)
        {
            for (int i = 0; i < alreadyUsedCharacters.Count; i++)
            {
                if (input==alreadyUsedCharacters[i])
                {
                    return false;
                }
            }
            return true;
        }*/
        static void DisplayCurrent(char[] current)
        {
            string display = Convert.ToString(current[0]);
            for (int i = 1; i < current.Length; i++)
            {
                display = String.Concat(display, " ", Convert.ToString(current[i]));
            }
            Console.WriteLine(display);
        }
        static List<char> alreadyUsedCharacters = new List<char>();
        static bool bennevan;
        static void DisplayUsedCharacters(char input)
        {
            Console.Write($"Already used characters:");
            for (int i = 0; i < alreadyUsedCharacters.Count - 1; i++)
            {
                Console.Write($"{alreadyUsedCharacters[i]} ");
                if (alreadyUsedCharacters[i] == input)
                {
                    bennevan = true;
                    alreadyUsedCharacters.Add(input);
                }
            }
            Console.WriteLine();
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
            
            Console.WriteLine("Which difficulty you would like to play at?\n\t1:Rich kid(13 try)\n\t2:Casual(10 try)\n\t3:Veteran(7 try)\n\t4:Dark Souls(4 try)");
            int szam = IntParse();
            int visszaaadSzam = 0;
            bool IfSzam = true;
            do
            {
                if (IfSzam == false) { szam = IntParse(); }
                
                switch (szam)
                {
                    case 0: break;
                    case 1: visszaaadSzam = 13;  IfSzam = true; break;
                    case 2: visszaaadSzam = 10 ; IfSzam = true; break;
                    case 3: visszaaadSzam = 7 ; IfSzam = true; break;
                    case 4: visszaaadSzam = 4 ;  IfSzam = true; break;
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

        //minden guess után a blanket átnézzük hogy van-e benne underscore
        // string - szo UGYANOLYAN HOSSZU masik string - megoldas underlineokkal.
        //     Ahol jó, ott átrakjuk a szo[i]-t a megoldas[i]-re
        // all.txt nem kell, az all-nál minden txt-t beolvasunk egy listába.
        // difficulties -  Rich kid 18; Casual 14; Veteran 10; Dark Souls 7; - turns out those are too much so 13/10/7/4
        
        static Char LetterParse()
        {
            bool ifInt;
            Char karakter;
            bool ifLetter;
            do
            {
                string switchszam = Console.ReadLine();
                ifInt = Char.TryParse(switchszam, out karakter);
                ifLetter = LetterCheck(karakter);
                if (ifInt == false) { Console.WriteLine("This is not a letter"); }
                else if (ifLetter == false) { ifInt = false; Console.WriteLine("This is not a letter"); }
                    
            } while (ifInt==false);
            return char.ToUpper(karakter);
        }
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
                if (ifInt == false) { Console.WriteLine("This is not a number"); };

            } while (ifInt == false);
            return szam1;
        }
    }
}
