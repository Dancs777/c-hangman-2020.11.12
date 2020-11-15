using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
    TODO
    - handling both lower- and uppercase letters DONE
    - lives  DONE
    - exception handling for the guess
    - word selection from file
    - stickman figure from file
*/

namespace Hangman_Alpha{
    class Program{
        static string word;
        static char[] current;
        static int lives;
        static void DisplayCurrent(){
            Console.Clear();
            string display = Convert.ToString(current[0]);
            for (int i = 1; i < current.Length; i++){
                display = String.Concat(display, " ", Convert.ToString(current[i]));
            }
            Console.WriteLine($"{display}");
            Console.WriteLine($"Lives remaining: {lives}");
        }
        static bool IsWon(){
            int i = 0;
            while (i < current.Length){
                if (current[i] == '_') break;
                i++;
            }
            if (i < current.Length) return false;
            Console.WriteLine("Congrats");
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
            if (!found){
                lives--;
                if(lives <= 0){
                    Console.WriteLine("Game lost");
                    return true;
                }
            }
            DisplayCurrent();
            return IsWon();
        }
        static void Blank(ref char[] blank){
            for (int i = 0; i < word.Length; i++){
                blank[i] = '_';
			}
        }
        static char ReadGuess(){
            

            char converted;
            bool isLegal = Char.TryParse(Console.ReadLine(), out converted);
            while(!isLegal){
                DisplayCurrent();
                Console.WriteLine("Not a legal character. Please, try again.");
                isLegal = Char.TryParse(Console.ReadLine(), out converted);
            }
            return Char.ToUpper(converted);
        }
        static void Main(string[] args){
            StreamReader characters = new StreamReader("English aplhabet");
            word = "apple".ToUpper();
            current = new char[word.Length];
            Blank(ref current);
            lives = 10;
            char input;
            DisplayCurrent();
            do{
                input = ReadGuess();
            } while (!Guess(input));
            Console.ReadKey();
        }
    }
}