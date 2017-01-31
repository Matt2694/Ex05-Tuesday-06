using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex05_Tuesday_6
{
    class Program
    {
        private static int _counter = 0;
        private static Object o = _counter;
        static void Main(string[] args)
        {
            Thread myThread1 = new Thread(new ThreadStart(Thread1));
            Thread myThread2 = new Thread(new ThreadStart(Thread2));
            myThread1.Start();
            myThread2.Start();
        }

        static void Thread1()
        {
            while (true)
            {
                Monitor.Enter(o);
                string output = "";
                try
                {
                    _counter = _counter + 60;
                    for (int i = 0; i < 60; i++)
                    {
                        output += "*";
                    }
                }
                finally
                {
                    Console.WriteLine(output + " " + _counter);
                    Monitor.Exit(o);
                    Thread.Sleep(1000);
                }
            }
        }

        static void Thread2()
        {
            while (true)
            {
                Monitor.Enter(o);
                string output = "";
                try
                {
                    _counter = _counter + 60;
                    for (int i = 0; i < 60; i++)
                    {
                        output += "#";
                    }
                }
                finally
                {
                    Console.WriteLine(output + " " + _counter);
                    Monitor.Exit(o);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
