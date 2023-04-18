using System;
using System.Threading;

namespace TrådsynOpgave2_3
{
    class Program
    {
        static int Count;
        static readonly object Lock = new object();

        static void Main(string[] args)
        {
            bool run = true;
            while (run == true)
            {

                Thread t1 = new Thread(Star);
                t1.Name = "*";
                t1.Priority = ThreadPriority.Normal;
                t1.Start();

                Thread t2 = new Thread(Pound);
                t2.Name = "#";
                t2.Priority = ThreadPriority.Normal;
                t2.Start();

            }
        }

        public static void Star()
        {
            Monitor.Enter(Lock);
            try
            {
                Console.WriteLine("************************************************************");
                Thread.Sleep(50);
            }
            finally
            {
                Monitor.Exit(Lock);
            }
        }

        public static void Pound()
        {
            Monitor.Enter(Lock);
            try
            {
                Console.WriteLine("############################################################");
                Thread.Sleep(50);
            }
            finally
            {
                Monitor.Exit(Lock);
            }
        }
    }
}
