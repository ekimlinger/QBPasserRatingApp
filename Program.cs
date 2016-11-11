/*
 * 
 *   Notes to self :
 *       - Need to make sure completions/td/int cannot be more than attempts
 *       - Check to make sure that user can enter commas
 *       - NEED MINIMUM OF 1 PASS ATTEMPT
 *       - Reformat output
 *       - Be able to restart within application
 *       - Create flags showing whether or not calculations have been made      
 *       - General moron QA
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
            Player player = new Player();

            // Have user input data
            player.getUserInput();            
            

            // Show data
            // "PLAYER NAME's QB Rating is: RATING" (show with one decimal place)
            Console.Write(player.getName() + "'s QB Rating is: " + player.getPasserRating() + "\n");


            // Ask to repeat process or quit

        }
    }
}

