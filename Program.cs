using System;
using System.Collections.Generic;
using System.Timers;

namespace Farkle
{
    class Program
    {
        private int score;
        public int Score { get; set; }

        //Timer gfxTimer = new Timer();
        
        
        static void Main(string[] args)
        {
            String farkle = "FARKLE";
            String diceSelectPrompt = "Select which dice you are going to keep; enter r to roll again >> ";

            /////   
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"- {farkle} -   ");
            } // write game header
            Console.WriteLine("\n\n - First Player Roll - \n");
            /////

            List<Dice> diceOnTable = initializeDice();
            List<Dice> keepDice = new List<Dice>();
            bool continueStatus = true;
            bool gameStatus = true;
            
            //int diceChoice = 0;
            //int n = 0;

            do // game loop
            {
                Console.WriteLine(" - Player Turn - ");


                do  // player turn loop
                {
                    Console.WriteLine("\n\n - Player Roll - \n");

                    rollDiceList(ref diceOnTable);
                    displayDiceList(ref diceOnTable);
                    didYouFarkle(ref diceOnTable);

                    String choiceStr;


                    //ClearKeys();

                    /// use unicode character values in the switch?
                    //int choiceInt;
                    int choiceCounter = 0;
                    do
                    {
                        Console.Write($"{diceSelectPrompt}");
                        choiceStr = Console.ReadLine();
                        
                        choiceCounter++;                        

                        switch (choiceStr)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                                keepDice.Add(diceOnTable[int.Parse(choiceStr) - 1]);
                                continue;
                            case "r":
                            case "R":
                                continueStatus = false;
                                break;
                            default:
                                continueStatus = false;
                                break;
                        } // switch on choiceInt and populate the keepDice array
                    } while (continueStatus == true);


                    //Console.WriteLine($"diceChoice: {diceChoice}");
                    //diceOnTable[diceChoice].ToString();

                    Console.WriteLine("Dice kept by player ");
                    displayDiceList(ref keepDice);

                    //Console.WriteLine("Play again? ");
                    String continueChoice = Console.ReadLine();

                    if (continueChoice == "Y" || continueChoice == "y")
                    {
                        continueStatus = true;
                    }
                    else
                        break;

                } while (continueStatus == true);

                Console.WriteLine("Display keep dice ");
                displayDiceList(ref keepDice);

                gameStatus = false;
            } while (gameStatus == true); // game loop

            //Console.WriteLine("Roll Again");

            //rollDiceList(ref keepDice);



            //displayDiceList(ref keepDice);
            //calculateScore(ref keepDice);

            
            Console.WriteLine("END GAME");
        } // end main method

        /// <summary> A method to display all of the face values of the dice in a list
        /// 
        /// </summary>
        /// <param name="aDiceList"></param>
        public static void displayDiceList(ref List<Dice> aDiceList)
        {
            //Console.WriteLine("Run displayDiceList() method");
            int i = 1;
            foreach (Dice aDie in aDiceList)
            {
                Console.WriteLine($"Die {i}: {aDie}");
                i++;
            } // interate through a provided list of Dice objects and display the face value
        } 

        public static List<Dice> rollDiceList(ref List<Dice> someDice)
        {
            //Console.WriteLine("roll dice method");
            List<Dice> rolledDice = new List<Dice>();
            //int i = 0;
            
            foreach (Dice aDie in someDice)
            {
                aDie.rollDice();
                rolledDice.Add(aDie);
            }
            return rolledDice;
        } // rollDiceList

        /// <summary> Populates initial dice list
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Dice> initializeDice()
        {
            Console.WriteLine("Initialize Dice");
            int diceNum = 6;
            List<Dice> gameDice = new List<Dice>();

            for (int i = 0; i < diceNum; i++)
            {
                Dice aDie = new Dice();
                gameDice.Add(aDie);
            }
            
            return gameDice;
        }


        public static void didYouFarkle(ref List<Dice> aDiceList)
        {
            Console.WriteLine("run didYouFarkle");

            List<Dice> checkList = new List<Dice>();


            foreach (Dice aDie in aDiceList)
            {
                if (aDie.FaceValue == 5 || aDie.FaceValue == 1)
                    checkList.Add(aDie);
            }

            if (checkList.Count > 0)
            {
                Console.WriteLine("points on the table");
                calculateScore(ref aDiceList);
            }
            else
                Console.WriteLine("Farkle");

            //Console.WriteLine($"checkList count: {checkList.Count}");
        } // check for farkle

        public static void calculateScore(ref List<Dice> diceOnTable)
        {
            int numDiceRolled = diceOnTable.Count;
            int score = 0;
            //byte gameState = 0b0010_1100;

            //Byte gamebyte = 0b_1100_1001;
            //Console.WriteLine($"calculate score {gamebyte} ");

            foreach (Dice aDie in diceOnTable)
            {
                if (aDie.FaceValue == 5)
                {
                    //Console.WriteLine($"score 50");
                    score += 50;
                } // score 50
                else if (aDie.FaceValue == 1)
                {
                    //Console.WriteLine("score 100");
                    score += 100;
                } // score 100
            }


            switch (numDiceRolled)
            {
                case 1: //can only score 50 or 100
                    
                case 2: //2 dice
                        //*one = 100
                        //* five = 50
                        //* 2 * five = 100
                        //* one & five = 150
                        //* 2 * one = 200
                    
                case 3:
                    //  3 dice
                    //* one = 100
                    //* five = 50
                    //* 2 * five = 100
                    //* one & five = 150
                    //* 2 * one = 200
                    //* three of a kind = Dice value * 100
                case 4:
                    //    4 dice
                    //  * one = 100
                    //  * five = 50
                    //  * 2 * five = 100
                    //  * one & five = 150
                    //  * 2 * one = 200
                    //  * three of a kind = Dice value * 100
                    //* four of a kind = 1000
                case 5:
                    //         *one = 100
                    //  * five = 50
                    //  * 2 * five = 100
                    //  * one & five = 150
                    //  * 2 * one = 200
                    //  * three of a kind = Dice value * 100
                    //* four of a kind = 1000
                    //* five of a kind = 2000
                case 6:
                //          *6 dice
                //  * one = 100
                //  * five = 50
                //  * 2 * five = 100
                //  * one & five = 150
                //  * 2 * one = 200
                //  * three of a kind = Dice value * 100
                //* four of a kind = 1000
                //* five of a kind = 2000
                //* six of a kind = 3000
                // * 1 - 6 straight = 1500
                //   * three pair = 1500
                //   * MM NNNN = 1500
                //   * two triplets = 2500
                default:

                    break;
            } // num dice rolled

            /** Table of scores - ordered by required number of dice
             * 
             * 0b_0000_0001 = 1
             * 0b_0000_0010 = 2
             * 0b_0000_0100 = 3
             * 0b_0000_1000 = 4
             * 0b_0001_0000 = 5
             * 0b_0010_0000 = 6
             * 
             * 0b_0010_0000 => 5 & 5
             * 0b_0001_0001 => 1 & 5
             * 0b_0000_0010 => 1 & 1
             * 
             * 0b_0011_1111 => 1-6 strait
             * 0b_0110_0000 => 3x 6
             * 0b_0011_0000 => 3x 5
             * 0b_0001_1000 => 3x 4
             * 0b_0000_1100 => 3x 3
             * 0b_0000_0110 => 3x 2
             * 0b_0000_0011 => 3x 1
             * 
             */

            Console.WriteLine($"total score: {score}");

        } // Calculate score of list

        public static void ClearKeys()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        } // ClearKeys method code located through research to ensure that characters are read correctly


    } // end Program class

} // end Farkle namespace
