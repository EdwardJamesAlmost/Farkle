using System;
using System.Collections.Generic;
using System.Text;

class Dice
{
    private int faceValue;
    public int FaceValue { get ; set ; }

    //public Dice operator=() { }

    public Dice() {}

    /// <summary>Rolls the dice and returns a dice object
    /// 
    /// </summary>
    /// <returns>Dice</returns>
    public void rollDice()
    {
        Random rnd = new Random();
        FaceValue = rnd.Next(1, 6);
        
        //return aDie;

        // debug rollDice method
        //Console.WriteLine($"roll die  - face: {FaceValue} ");

    } // roll the die and return a dice object

    /// <summary> write the face value of a single die to the console
    /// 
    /// </summary>
    /// <param name="aDie"></param>
    public void displayDieFace()
    {
        //Console.WriteLine($"Die face: {FaceValue}");
    }  // writes the face of a single die to the console

    public override String ToString()
    {
        String faceValue = FaceValue.ToString();
        return faceValue;
    } // override to string method

    

} // end die class

