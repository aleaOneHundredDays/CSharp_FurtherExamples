using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadExample
{
    class TestLock_2
    {

        static readonly object _object = new object();
        static int threadCount =0;


        public static void PrintNumbers()
        {
            

            Monitor.Enter(_object);
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(_object);
            }
        }



        static void TestLock()
        {

            lock (_object)
            {
                Thread.Sleep(100);
                Console.WriteLine(Environment.TickCount);
                
            }

        }


        static void Main(string[] args)
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(new ThreadStart(PrintNumbers));
                Threads[i].Name = "Child " + i;
            }
            foreach (Thread t in Threads)
                t.Start();

            Console.ReadLine();


            //for (int i = 0; i < 10; i++)
            //{
            //    threadCount++;
            //    Console.WriteLine(threadCount);
            //    ThreadStart start = new ThreadStart(TestLock);
            //    new Thread(start).Start();
            //}

            Console.ReadLine();
        }
    }
}
