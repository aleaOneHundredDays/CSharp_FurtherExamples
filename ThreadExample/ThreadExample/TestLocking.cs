using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadExample
{
     class TestLocking
    {

        static object someLock = new object();

        //static void Main()
        //{



        //    //Console.WriteLine("Main thread starting");
        //    //Thread secondThread = new Thread(new ThreadStart(ThreadJob));
        //    //secondThread.Start();
        //    //Console.WriteLine("Main thread sleeping");
        //    //Thread.Sleep(500);
        //    //lock (someLock)
        //    //{
        //    //    Console.WriteLine("Main thread acquired lock - pulsing monitor");
        //    //    Monitor.Pulse(someLock);
        //    //    Console.WriteLine("Monitor pulsed; interrupting second thread");
        //    //    secondThread.Interrupt();
        //    //    Thread.Sleep(1000);
        //    //    Console.WriteLine("Main thread still owns lock...");
        //    //}
        //}

        static void ThreadJob()
        {
            Console.WriteLine("Second thread starting");

            lock (someLock)
            {
                Console.WriteLine("Second thread acquired lock - about to wait");
                try
                {
                    Monitor.Wait(someLock);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Second thread caught an exception: {0}", e.Message);
                }
            }
        }
    }
}
