using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarterbackRating
{
    class Player
    {
        public string name;

        private double  passesCompleted,      
                        passingAttempts,      
                        passingYards,
                        tdPasses,
                        passingInterceptions;

        
        // Constructor
        public Player()
        {
            name = "";
            passesCompleted = -1;
            passingAttempts = -1;
            passingYards = -1;
            tdPasses = -1;
            passingInterceptions = -1;
        }


        public int getUserInput()
        {
            bool err;
            // Get player name                
            Console.Write("Player Name: ");
            name = Console.ReadLine();

            // Get passing attempts
            do
            {
                err = false;
                Console.Write("Pass Attempts: ");
                // Get string from user and attempt to parse, and store error if failed
                if (double.TryParse(Console.ReadLine(), out passingAttempts) == false)
                {
                    err = true;
                }
                // Passing attempts cannot be less than 1
                if (passingAttempts < 1 || err)
                {
                    err = true;
                    Console.Write("Invalid number of passing attempts\n");
                }

            } while (err); 
            
            
            // Get passes completed
            do
            {
                err = false;
                Console.Write("Pass Completions: ");
                // Get string from user and attempt to parse, and store error if failed
                if (double.TryParse(Console.ReadLine(), out passesCompleted) == false)
                {
                    err = true;
                }
                //Passes completed cannot be more than passing attempts
                if (passesCompleted > passingAttempts || passesCompleted < 0 || err)
                {
                    err = true;
                    Console.Write("Invalid number of pass completions.\n");
                }
            } while (err);
            
            // Passing yards
            do
            {
                err = false;
                Console.Write("Passing Yards: ");
                // Get string from user and attempt to parse , and store error if failed
                if (double.TryParse(Console.ReadLine(), out passingYards) == false)
                {
                    err = true;
                }
                // Impossible to have more than +/-99 yards per passes completed
                if (    (passingYards / passesCompleted) >= 100 || 
                        (passingYards / passesCompleted) <= -100 || err)
                {
                    err = true;
                    Console.Write("Invalid number of passing yards.\n");
                }

            } while (err);
            
            // Number of touchdown passes
            do
            {
                err = false;
                Console.Write("Passing Touchdowns: ");

                // Get string from user and attempt to parse, and store error if failed
                if (double.TryParse(Console.ReadLine(), out tdPasses) == false)
                {
                    err = true;
                } 
                
                // Impossible to have more touchdowns than completions, or negative amount
                if (tdPasses > passesCompleted || tdPasses < 0 || err)
                {
                    err = true;
                    Console.Write("Invalid number of touchdown passes.\n");
                }

            } while (err);
            

        
            // Number of interceptions
            do
            {
                err = false;
                Console.Write("Interceptions: ");
                
                // Get string from user and attempt to parse, and store error if failed
                if (double.TryParse(Console.ReadLine(), out passingInterceptions) == false)
                {
                    err = true;
                }
                
                // Interceptions and completions cannot be more than attempts, or negative amount
                if (passingAttempts < ( passesCompleted + passingInterceptions) || passingInterceptions < 0 || err)
                {
                    err = true;
                    Console.Write("Invalid number of interceptions.\n");
                }

            } while (err);

            return 0;
            
        }
        
            


        // 1. Weighted value of percentage of completions per attempt    
        private double getWCompPerAttempt()
        {
            double compPerAttempt;
            compPerAttempt = (passesCompleted / passingAttempts) * 100;
            compPerAttempt = (compPerAttempt - 30) * 0.05;
            if (compPerAttempt < 0)
            {
                compPerAttempt = 0;
            }
            else if (compPerAttempt > 2.375)
            {
                compPerAttempt = 2.375;
            }
            return compPerAttempt;
        }

        // 2. Weighted value of average yards gained per attempt
        private double getWYardsPerAttempt()
        {
            double yardsPerAttempt;
            
            yardsPerAttempt = (passingYards / passingAttempts);
            yardsPerAttempt = (yardsPerAttempt - 3) * 0.25;
            if (yardsPerAttempt < 0)
            {
                yardsPerAttempt = 0;
            }
            else if (yardsPerAttempt > 2.375)
            {
                yardsPerAttempt = 2.375;
            }
            return yardsPerAttempt;
        }

        // 3. Weighted value of percentage of touchdown passes per attempt
        private double getWTDPassesPerAttempt()
        {
            double tdPassesPerAttempt;
            tdPassesPerAttempt = (tdPasses / passingAttempts);
            tdPassesPerAttempt = (tdPassesPerAttempt * 100) * 0.2;
            if (tdPassesPerAttempt > 2.375)
            {
                tdPassesPerAttempt = 2.375;
            }
            return tdPassesPerAttempt;
        }

        // 4. Weighted value of percentage of interceptions per attempt
        private double getWIntPerAttempt()
        {
            double intPerAttempt;
            intPerAttempt = (passingInterceptions / passingAttempts) * 100;
            intPerAttempt = 2.375 - (intPerAttempt * 0.25);
            if (intPerAttempt < 0)
            {
                intPerAttempt = 0;
            }
            
            return intPerAttempt;
        }




        // Final calculation
        public double getPasserRating()
        {
            double passerRating;
            passerRating = (  getWCompPerAttempt() 
                            + getWYardsPerAttempt() 
                            + getWTDPassesPerAttempt() 
                            + getWIntPerAttempt() ) 
                            / 6 * 100;
            
            passerRating = Math.Round(passerRating, 1);
            return passerRating;
        }




    }
}
