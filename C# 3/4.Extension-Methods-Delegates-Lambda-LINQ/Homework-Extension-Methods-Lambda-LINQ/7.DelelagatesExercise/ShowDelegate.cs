/*Using delegates write a class Timer that
 *has can execute certain method at each t seconds.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _7.DelelagatesExercise
{
    public delegate void TimerDelegate(int interval);

    public class Timer
    {
        public static void PrintTime(int interval)
        {
            Console.WriteLine("{0:hh:mm:ss}",DateTime.Now);
            Thread.Sleep(interval*1000);
            Console.Clear();
        }
    }

    class ShowDelegate
    {
        static void Main()
        {
            TimerDelegate timerDelegate = new TimerDelegate(Timer.PrintTime);
            
            int i = 0;
            //Start timer for 1 minute
            while (i < 60)
            {
                timerDelegate(1);
                i++;
            }
        }
    }
}
