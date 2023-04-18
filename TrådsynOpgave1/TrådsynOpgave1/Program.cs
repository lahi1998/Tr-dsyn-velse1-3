using System;
using System.Threading;

namespace TrådsynOpgave1
{
    class Program
    {
        static int Count;
        static readonly object  Lock = new object();

        static void Main(string[] args)
        {
            bool run = true;
            while (run == true)
            {

                    Thread t1 = new Thread(CountUp);
                t1.Name = "CountUp";
                t1.Priority = ThreadPriority.Normal;
                t1.Start();

                Thread t2 = new Thread(CountDown);
                t2.Name = "CountDown";
                t2.Priority = ThreadPriority.Normal;
                t2.Start();

            }
        }

        public static void CountUp()
        {
            Monitor.Enter(Lock);
            try
            {

                    Count++;
                    Count++;
                    Console.WriteLine(Count);
                    Thread.Sleep(1000);
                
            }
            finally
            {
                Monitor.Exit(Lock);
            }
        }

        public static void CountDown()
        {
            Monitor.Enter(Lock);
            try
            {

                    Count--;
                    Console.WriteLine(Count);
                    Thread.Sleep(1000);
                

            }
            finally
            {
                Monitor.Exit(Lock);
            }
        }
    }
}
