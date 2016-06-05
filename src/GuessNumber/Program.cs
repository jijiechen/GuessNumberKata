using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {


            var game = new Game("1234");

            var result = game.Guess("1234");

            Console.WriteLine(result);


        }
    }
}
