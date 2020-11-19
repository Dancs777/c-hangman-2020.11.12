using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Hangman_Alpha{
    class Program{
        static string word;
        static char[] current;
        static int lives;
        static List<char> alreadyGuessed;
        static List<char> characterCollection = new List<char>();
        static List<string> words = new List<string>();
        static Random rnd = new Random();
        static void Main(string[] args){
            ReadCharacterCollection();
            ReadWords();
            Play();
        }
        static void Play(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            word = words[rnd.Next(0, words.Count)];
            current = new char[word.Length];
            Blank(ref current);
            alreadyGuessed = new List<char>();
            Console.WriteLine("Choose a difficulty.\n\n1: \"Kíméletes megoldás\" mode\n2:  Privileg exec mode\n3:  Badass mode\n4:  Sicko mode\n\n");
            while (!Difficulty(ref lives)){
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine("That is not a difficulty");
            }
            DisplayCurrent();
            //do{
            //    isOver = Guess(ReadGuess());
            //}while(!isOver);
            while (!Guess(ReadGuess())) { }
            Console.WriteLine("\nDo you want to play again?\n\nYes: Y\nNo: [Enter]");
            if (Console.ReadLine().ToUpper() == "Y") Play();
        }
        static bool Guess(char guess){
            bool found = false;
            for (int i = 0; i < word.Length; i++){
                if (word[i] == guess){
                    current[i] = guess;
                    found = true;
                }
            }
            
            if (!found){
                lives--;
                if (lives <= 0){
                    DisplayCurrent();
                    Console.WriteLine($"Game lost\nThe solution was: {word}");
                    return true;
                }
            }
            DisplayCurrent();
            return IsWon();
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
        static void DisplayCurrent(){
            Console.Clear();
            string display = Convert.ToString(current[0]);
            for (int i = 1; i < current.Length; i++){
                display = String.Concat(display, " ", Convert.ToString(current[i]));
            }
            Console.WriteLine($"{display}");
            Gibbet();
            Console.Write("Already guessed:");
            for (int i = 0; i < alreadyGuessed.Count; i++){
                Console.Write($" {alreadyGuessed[i]} ");
            }
            Console.WriteLine($"\nLives remaining: {lives}\n\n");
        }
        static void Gibbet(){
            Console.WriteLine();
            string filename = lives + "lives.txt";
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream){
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine();
        }
        static char ReadGuess(){
            char converted;
            bool isLegal = Char.TryParse(Console.ReadLine(), out converted);
            converted = Char.ToUpper(converted);
            while(!isLegal || !IsInCollection(converted) || !isNewGuess(converted)){
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine("Not a legal character. Please, try again.");
                isLegal = Char.TryParse(Console.ReadLine(), out converted);
                converted = Char.ToUpper(converted);
            }
            alreadyGuessed.Add(converted);
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
        static bool isNewGuess(char input){
            for (int i = 0; i < alreadyGuessed.Count; i++){
                if (input == alreadyGuessed[i]) return false;
            }
            return true;
        }
        static bool Difficulty(ref int lives){
            switch (Console.ReadLine()){
                case "1":
                    lives = 11;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    lives = 9;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    lives = 6;
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Red;
                    lives = 4;
                    break;
                default:
                    return false;
            }
            return true;
        }
        static void Blank(ref char[] blank){
            for (int i = 0; i < word.Length; i++){
                blank[i] = '_';
            }
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
        static void ReadWords(){
            StreamReader sr = new StreamReader("words.txt");
            while (!sr.EndOfStream){
                words.Add(sr.ReadLine().ToUpper());
            }
            sr.Close();
        }
    }
}