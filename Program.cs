using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Alpha{
    class Program{
        static void DisplayCurrent(char[] current){     //hot stuff
            string display = Convert.ToString(current[0]);
            for (int i = 1; i < current.Length; i++){
                display = String.Concat(display, " ", Convert.ToString(current[i]));
            }
            Console.WriteLine($"\r{display}");
        }
        static bool IsWon(char[] blank){
            int i = 0;
            while (i<blank.Length){
                if (blank[i] == '_') break;
                i++;
            }
            if (i < blank.Length) return false;
            return true;
        }
        
        static void Guess(){

        }
        static void Blank(string word, ref char[] blank){
            for (int i = 0; i < word.Length; i++){
                blank[i] = '_';
			}
        }
        static void Main(string[] args){
            string word = "apple";
            char[] blank = new char[word.Length];
            Blank(word, ref blank);
            char[] temp = { 'a', 'b', 'c' };
            Console.WriteLine(IsWon(blank));
            Console.WriteLine(IsWon(temp));
            Console.ReadKey();
        }
    }
}