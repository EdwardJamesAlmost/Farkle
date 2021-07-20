using System;
using System.Collections.Generic;
using System.Timers;

namespace Farkle
{
    class Program
    {
        private int score;
        
        public int Score { get; set; }
        
        static void Main(string[] args)
        {
            String farkle = "FARKLE";
            String diceSelectPrompt = "Select which dice you are going to keep; enter zero to quit >> ";

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"{farkle}    ");
            } // write game header
            
            int maxDice = 6;
            
            List<Dice> diceOnTable = new List<Dice>();
            

            Console.WriteLine("\n - First Player Roll - \n\n");

            for (int i = 0; i < maxDice; i++)
            {
                // a new Dice object must be created fo reach iteration through the loop
                Dice aDie = new Dice(); 

                // first roll
                aDie.rollDice();
                diceOnTable.Add(aDie);
                diceOnTable[i].displayDieFace();

                /**debug first roll

                //Console.WriteLine($"Dice #{i+1}:   {diceOnTable[i].FaceValue}");
                //Console.WriteLine($"another debug method, ith dice face:");
                //Console.WriteLine($"ith dice i = {i} on table: ");
                */
            } // roll the number of dice in play
            
            //Console.WriteLine("\nDice on table:");
            //Console.WriteLine($"table 1: {diceOnTable[0]}");
            
            displayDiceList(ref diceOnTable); // 
            
            int diceChoice = 0;
            List<Dice> keepDice = new List<Dice>();
            Boolean continueStatus = true;
            int n = 0;
            
            do
            {
                Console.Write($"{ diceSelectPrompt}");
                diceChoice = int.Parse(Console.ReadLine());

                Console.WriteLine($"diceChoice: {diceChoice}");

                keepDice.Add(diceOnTable[diceChoice]);

                if (diceChoice <=6 && diceChoice > 0 && keepDice.Count <= 5)
                {
                    Console.WriteLine($"keepDice[{n}]: {keepDice[n]} ");
                    Console.WriteLine($"diceOnTable[{diceChoice}]: {diceOnTable[diceChoice]}");
                    n++;
                    continue;
                }
                else if (diceChoice == 0)
                    continueStatus = false;
            } while (continueStatus == true);

            
            //displayDiceList(keepDice);

            Console.WriteLine("Roll again.");
            
        } // end main method

        /// <summary> A method to display all of the face values of the dice in a list
        /// 
        /// </summary>
        /// <param name="aDiceList"></param>
        public static void displayDiceList(ref List<Dice> aDiceList)
        {
            Console.WriteLine("Run displayDiceList() method");
            int i = 1;
            foreach (Dice aDie in aDiceList)
            {
                Console.WriteLine($"Die {i}: {aDie}");
                i++;
            }

        } // display device list

        //public 



        public static void didYouFarkle(List<Dice> aDiceList)
        {
            //if (aDiceList.Contains()
            {

            }
        }

    } // end Program class

} // end Farkle namespace
