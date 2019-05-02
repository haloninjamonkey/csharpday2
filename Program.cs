using System;
using System.Threading;

namespace dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool running = true;

            while(running) {

                Console.Clear();
                //String of dice provided. 'Ex: 1d6'
                Console.WriteLine("Give me a die: "); 
                string strDice = Console.ReadLine();
    #region Bad Solution
                //values to save integers for rolling
                //int numberOfDice = 0;
                //int sidesOfDice = 0;
                // bool numberSuccess = Int32.TryParse(strDice[0].ToString(), out int numberOfDice);
                //                                                               ^ creates new int numberOfDice
                // bool sidesSuccess = Int32.TryParse(strDice.Substring(2), out sidesOfDice);
                //                                                              ^ sets value of sidesOfDice
    #endregion
                //improved solution with the Split() method
                string[] valuesArray = strDice.ToLower().Split('d');
                bool numberSuccess = Int32.TryParse(valuesArray[0], out int numberOfDice);
                bool sidesSuccess = Int32.TryParse(valuesArray[1], out int sidesOfDice);
                //attempt to convert strings to ints
                //if both succeeded
                
                if (numberSuccess && sidesSuccess)
                {
                    System.Console.WriteLine("rolling...");
                    int total = 0;
                    
                    for(int i = 0; i < numberOfDice; i++) 
                    {
                        int roll = rng.Next(1, sidesOfDice+1);
                        // System.Console.WriteLine(roll);
                        // Thread.Sleep(250);
                        total += roll;
                    }
                    System.Console.WriteLine("Total: " + total);
                } 
                else{
                    System.Console.WriteLine("No dice");
                }
                System.Console.WriteLine("Again? (Y/N)");
                ConsoleKeyInfo choice = Console.ReadKey();
                if(choice.KeyChar == 'n'){
                    running = false;
                }

            }
            Console.Clear();
            System.Console.WriteLine("Goodbye");

        }
    }
}
