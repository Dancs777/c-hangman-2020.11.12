using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
    TODO
    - exception handlig for already guessed characters (player cannot enter the same character more than once)
    - word selection from file
    - difficulties
    - stickman figure from file
*/

namespace Hangman_Alpha{
    class Program{
        static string word;
        static char[] current;
        static int lives;
        static List<char> characterCollection = new List<char>();
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
            converted = Char.ToUpper(converted);
            while(!isLegal || !IsInCollection(converted)){
                DisplayCurrent();
                Console.WriteLine("Not a legal character. Please, try again.");
                isLegal = Char.TryParse(Console.ReadLine(), out converted);
                converted = Char.ToUpper(converted);
            }
            return converted;
        }
        static bool IsInCollection(char input){
            int i = 0;
            while(i < characterCollection.Count && characterCollection[i] != input){
                i++;
            }
            if (i < characterCollection.Count) return true;
            return false;
        }
        static void ReadCharacterCollection(){
            StreamReader sr = new StreamReader("English alphabet.txt");
            while (!sr.EndOfStream){
                try{
                    characterCollection.Add(Char.ToUpper(char.Parse(sr.ReadLine())));
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();
        }
        static void Main(string[] args){
            ReadCharacterCollection();
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