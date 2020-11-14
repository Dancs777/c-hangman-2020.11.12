using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    TODO
    -lives
    -word selection from file
    -stickman figure from file
*/

namespace Hangman_Alpha{
    class Program{
        static string word;
        static char[] current;
        static void DisplayCurrent(){
            Console.Clear();
            string display = Convert.ToString(current[0]);
            for (int i = 1; i < current.Length; i++){
                display = String.Concat(display, " ", Convert.ToString(current[i]));
            }
            Console.WriteLine($"{display}");
        }
        static bool IsWon(){
            int i = 0;
            while (i < current.Length){
                if (current[i] == '_') break;
                i++;
            }
            if (i < current.Length) return false;
            return true;
        }
        
        static bool Guess(char guess){
            
            bool found = false;
            for(int i = 0; i < word.Length; i++){
                if(word[i] == guess){
                    current[i] = guess;
                    found = true;
                }
            }
            DisplayCurrent();
            if (!found){
                //lives--;
            }
            return IsWon();
        }
        static void Blank(ref char[] blank){
            for (int i = 0; i < word.Length; i++){
                blank[i] = '_';
			}
        }
        static void Main(string[] args){
            word = "apple";
            current = new char[word.Length];
            Blank(ref current);
            char input;
            DisplayCurrent();
            do
            {
                input = Convert.ToChar(Console.ReadLine());
            } while (!Guess(input));
            //Console.WriteLine(word);
            //DisplayCurrent();
            //char[] temp = { 'a', 'b', 'c' };
            //Console.WriteLine(IsWon(current));
            //Console.WriteLine(IsWon(temp));
            Console.ReadKey();
        }
    }
}