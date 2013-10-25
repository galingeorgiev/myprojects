/*Write a class GSMTest to test the GSM class:
Create an array of few instances of the GSM class.
Display the information about the GSMs in the array.
Display the information about the static property IPhone4S.*/

using System;
using AboutPhone;
using System.Collections.Generic;

namespace GSMTest
{
    class GSMTest
    {
        static void Main()
        {
            //Create an array of few instances of the GSM class.
            GSM[] gsmArr = new GSM[] {
                new GSM("Lumia","Nokia"),
                new GSM("Asha","Nokia"),
                new GSM("Galaxy","Samsung"),
                new GSM("One", "HTC"),
                new GSM("Desire","HTC") };

            //Add more info for GSMs
            gsmArr[0].Price = 300;
            gsmArr[1].Owner = "Svetlin Nakov";
            
            //Display the information about the GSMs in the array.
            foreach (var gsm in gsmArr)
            {
                Console.WriteLine(gsm);
            }

            //Display the information about the static property IPhone4S.
            Console.WriteLine(GSM.Iphone4S);
        }
    }
}
