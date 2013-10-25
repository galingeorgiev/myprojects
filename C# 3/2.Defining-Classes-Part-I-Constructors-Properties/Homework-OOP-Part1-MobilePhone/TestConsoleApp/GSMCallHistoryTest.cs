/*Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
*Create an instance of the GSM class.
*Add few calls.
*Display the information about the calls.
*Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
*Remove the longest call from the history and calculate the total price again.
*Finally clear the call history and print it.*/

using System;
using AboutPhone;
using System.Collections.Generic;

namespace TestConsoleApp
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            //Create an instance of the GSM class.
            GSM myGSM = new GSM("Desire", "HTC");
            string dateFormat = "M.d.yyyy";
            string timeFormat = "hh:mm:ss";
            //Add few calls.
            Call testCall1 = new Call(DateTime.Now, DateTime.Now, "0878xxxxxx", 80);
            Call testCall2 = new Call(DateTime.Now, DateTime.Now, "0877xxxxxx", 60);
            Call testCall3 = new Call(DateTime.Now, DateTime.Now, "0876xxxxxx", 40);
            Call testCall4 = new Call(DateTime.Now, DateTime.Now, "0875xxxxxx", 90);
            Call testCall5 = new Call(DateTime.Now, DateTime.Now, "0874xxxxxx", 20);

            myGSM.AddInCallHistory(testCall1);
            myGSM.AddInCallHistory(testCall2);
            myGSM.AddInCallHistory(testCall3);
            myGSM.AddInCallHistory(testCall4);
            myGSM.AddInCallHistory(testCall5);

            //Display the information about the calls.
            List<Call> calls = new List<Call>() { testCall1, testCall2, testCall3, testCall4, testCall5 };
            foreach (var call in calls)
            {
                Console.WriteLine("Call info: date {0:d.M.yyyy} in {1:hh:mm:ss} with number: {2} call duration: {3}s",
                    call.Date, call.Time, call.DialedNumber, call.Duration);
            }

            //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            float callPrice = 0.37f;
            Console.WriteLine("Total price of the calls is: {0:c}",myGSM.CallsTotalPrice(callPrice));

            //Remove the longest call from the history and calculate the total price again.
            int longestCallPosition = 0;
            int bestDuration = 0;
            int index = 0;
            foreach (var call in calls)
            {
                if (call.Duration > bestDuration)
                {
                    longestCallPosition = index;
                    bestDuration = call.Duration;
                }
                index++;
            }

            myGSM.RemoveFromCallHistory(longestCallPosition);
            Console.WriteLine("Total price of the calls after removing longest call is: {0:c}", myGSM.CallsTotalPrice(callPrice));

            //Finally clear the call history and print it.
            myGSM.ClearCallHistory();
            Console.WriteLine("Total price of the calls after clearing calls history is: {0:c}", myGSM.CallsTotalPrice(callPrice));
        }
    }
}
