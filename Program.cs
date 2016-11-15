/*
 *
 * App to calculate QB Passer Rating 
 *
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarterbackRating
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goAgain = true;
            do
            {

                // Instantiate new player object
                Player player = new Player();

                // Have user input data
                player.getUserInput();

                // Show data
                Console.Write(player.name + "'s QB Rating is: " + player.getPasserRating() + "\n");

                Console.Write("Would you like to start over? (yes/no): ");
                string answer = Console.ReadLine();
                // If answer is any variant of no, don't restart
                if (answer.ToLower() == "no")
                {
                    goAgain = false;
                }
                Console.Write("\n");
            } while(goAgain);
            
        }
    }
}

