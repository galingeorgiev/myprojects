/*Read in MSDN about the keyword event in C# and
 *how to publish events. Re-implement the above
 *using .NET events and following the best practices.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8.EventsExercise
{
    public delegate void EventHandler();
    public delegate void myDelegate();

    public class Timer
    {
        public static void ShowTime()
        {
            Console.WriteLine("{0:hh:mm:ss}", DateTime.Now);
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    class ShowEvetns
    {
        public static event EventHandler Show;

        static void Main()
        {
            myDelegate del = new myDelegate(Timer.ShowTime);

            Show = new EventHandler(del);

            for (int i = 0; i < 60; i++)
            {
                Show.Invoke();
            }
        }
    }
}
