using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Alpha{
    class Program{
        static void Guess(char guess, string word, out string current){
            bool found = false;
            for (int i = 0; i < word.Length; i++){
                if(word[i] == guess){
                    current[i] == guess;
                    found = true;
                }
			}
            if(!found) Console.WriteLine("you fucked up");  //strike function
            Console.WriteLine(word);
            Current(current);
            Console.WriteLine();
        }
        static void Current(string current){
            foreach (char i in current){
                Console.Write($" {i} ");
        	}
        }
        static string MakeBlank(string word){
            string output = "";
            for (int i = 0; i < word.Length; i++)
			{
                output.Concat(output, "_");
			}
        }
        static void Main(string[] args){
            char input;
            string word = "apple";
            string blank = MakeBlank(word);
            while (true){
                input = Convert.ToChar(Console.ReadLine());
                Guess(input, word, out blank);
	        }
            Console.ReadKey();
        }
    }
}

