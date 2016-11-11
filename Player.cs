using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarterbackRating
{
    class Player
    {
        private string   name;

        private double  passesCompleted,
                        passingAttempts,
                        passingYards,
                        tdPasses,
                        passingInterceptions;
        
        // Constructor
        public Player()
        {
            name = "unknown";
            passesCompleted = 0;
            passingAttempts = 0;
            passingYards = 0;
            tdPasses = 0;
            passingInterceptions = 0;
        }

        // Deconstructor
        ~Player()
        {

        }




        public int getUserInput()
        {
            // Get player name                
            Console.Write("Please enter the player's full name (press enter when finished)\n");
            name = Console.ReadLine();

            // Get passing attempts
            do
            {
                Console.Write("Please enter the number of passing attempts made by " + name + ": \n");
                passingAttempts = double.Parse(Console.ReadLine());
                if (passingAttempts < 1)
                {
                    Console.Write("Passing attempts cannot be less than 1\n");
                }

            } while (passingAttempts < 1); 
            
            
            // Get passes completed
            do
            {
                Console.Write("Please enter the number of passing completions made by " + name + ": \n");
                passesCompleted = double.Parse(Console.ReadLine());

                //Passes completed cannot be more than passing attempts
                if (passesCompleted > passingAttempts || passesCompleted < 0)
                {
                    Console.Write("Invalid number of passing attempts.\n");
                }
            } while (passesCompleted > passingAttempts || passesCompleted < 0 );
            
            // Passing yards
            do
            {
                Console.Write("Please enter " + name + "'s passing yards: \n");
                passingYards = double.Parse(Console.ReadLine());

                // Impossible to have more than 100 yards per passes completed
                if ( (passingYards / passesCompleted) > 100 || passingYards < 0 )
                {
                    Console.Write("Invalid number of passing yards.\n");
                }

            } while ( (passingYards / passesCompleted) > 100 || passingYards < 0);
            
            // Number of touchdown passes
            do
            {
                Console.Write("Please enter " + name + "'s number of touchdown passes: \n");
                tdPasses = double.Parse(Console.ReadLine());

                // Impossible to have more touchdowns than completions
                if (tdPasses > passesCompleted || tdPasses < 0)
                {
                    Console.Write("Invalid number of touchdown passes.");
                }

            } while (tdPasses > passesCompleted || tdPasses < 0);
            

        
            // Number of interceptions
            do
            {
                Console.Write("Please enter " + name + "'s number of interceptions: \n");
                passingInterceptions = double.Parse(Console.ReadLine());
                if (passingInterceptions > (passingAttempts - passesCompleted))
                {
                    Console.Write("Invalid number of interceptions.");
                }
            } while (passingInterceptions > (passingAttempts - passesCompleted));

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
            passerRating = (getWCompPerAttempt() + getWYardsPerAttempt() + getWTDPassesPerAttempt() + getWIntPerAttempt()) / 6 * 100;
            passerRating = Math.Round(passerRating, 1);
            return passerRating;
        }



        
        
        // Setters
        public void setName(string setter)
        {
            name = setter;
        }
        public void setPassesCompleted(double setter)
        {
            passingAttempts = setter;
        }
        public void setPassingAttempts(double setter)
        {
            passesCompleted = setter;
        }
        public void setPassingYards(double setter)
        {
            passingYards = setter;
        }
        public void setTDPasses(double setter)
        {
            tdPasses = setter;
        }
        public void setPassingInterceptions(double setter)
        {
            passingInterceptions = setter;
        }

        //Getters
        public string getName()
        {
            return name;
        }
        public double getPassesCompleted()
        {
            return passesCompleted;
        }
        public double getPassingAttempts()
        {
            return passingAttempts;
        }
        public double getPassingYards()
        {
            return passingYards;
        }
        public double getTDPasses()
        {
            return tdPasses;
        }
        public double getPassingInterceptions()
        {
            return passingInterceptions;
        }

    }
}
