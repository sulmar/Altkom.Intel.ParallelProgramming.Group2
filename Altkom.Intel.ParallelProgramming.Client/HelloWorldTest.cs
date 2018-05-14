using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class HelloWorldTest
    {

        public static void Hello(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sending {message}...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sent. {message}");


        }
    }
}
