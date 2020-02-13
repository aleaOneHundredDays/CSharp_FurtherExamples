using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        public static int someValue;

        // Main method 
        //static  void Main(string[] args)
        //{

           
        //    someValue = 1;

        //    // Creating and initializing thread 
        //    Thread thr = new Thread(mythread);
        //    thr.Start();


        //    //Join thread
        //    thr.Join();  // <<<<<<BLOCKS THE CALLING THREAD UNTIL CURRENT THREAD (thr) TERMINATES

        //    // first thread is done, so off you go
        //    Thread thr2 = new Thread(mythread2);
        //    thr2.Start();

        //  //  thr2.Join();

        //    Thread thr3 = new Thread(Thread3);  // <<< RUNS CONCURRENTLY with thr2
        //    thr3.Start();

        //    Console.WriteLine("Main Thread Ends!!");
        //}

        // Static method 
        static void mythread()
        {
            for (int c = 0; c <= 3; c++)
            {
                someValue++;
                Console.WriteLine($"Thread 1 is in Progess!! Iteration:{c} SomeValue: {someValue}");
                Thread.Sleep(100);
                
            }
        
            Console.WriteLine("THREAD 1 ends!!");
        }


        static void mythread2()
        {
            for (int c = 0; c <= 5; c++)
            {
                someValue++;
                Console.WriteLine($"Thread 2 is In Progress, and reached iteration --> {c}!!  SomeValue: {someValue}");
                Thread.Sleep(500);
                
            }
            Console.WriteLine("THREAD 2 ends!!");
        }


        static void Thread3()
        {
            Console.WriteLine("Thread 3 Time!");

            for (int c = 0; c <= 10; c++)
            {
                someValue++;
                Console.WriteLine($"Now Thread3 is In Progress, and reached iteration --> {c}!  SomeValue: {someValue}!");
                Thread.Sleep(1000);
              
            }

            Console.WriteLine("THREAD 3 ends!!");
        }

    }
}
