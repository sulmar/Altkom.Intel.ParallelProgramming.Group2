using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class ThreadTests
    {
        public static void UsingTest()
        {          
            Thread thread = new Thread(AbortUsingTest);

            thread.Start();

            Console.WriteLine("Press any key to abort.");

            Console.ReadKey();

            thread.Abort();

        }

        private static void AbortUsingTest()
        {
            using (var calculator = new Calculator())
            {
                calculator.Calculate();

              //  Thread.Sleep(TimeSpan.FromDays(1));
            }
        }

        public static void AbortThreadTest()
        {
            Calculator calculator = new Calculator();

            Thread thread = new Thread(() => calculator.Calculate());

            thread.Start();

            Console.WriteLine("Press any key to abort.");

            Console.ReadKey();

            thread.Abort();

            Console.WriteLine("Press any key to abort.");
            Console.ReadKey();
        }

        public static void CreateThread()
        {
            Thread thread = new Thread(DoWork);
            thread.IsBackground = true;
            thread.Start();

        }

        public static void WaitThread()
        {
            Thread thread = new Thread(DoWork);

            thread.Start();

            // czeka na zakonczenie watku
            thread.Join();

        }


        public static void DoWork()
        {
            Hello("Hello Intel");
        }



        public static void Hello(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sending {message}...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sent. {message}");


        }


        public static void ThreadWithParameterTest()
        {
            Thread t1 = new Thread(Download);
            t1.Start("http://www.intel.com");

            Thread t2 = new Thread(Download);
            t2.Start("http://www.altkom.pl");
        }

        public static void ThreadWithParametersLambdaTest()
        {
            Thread t1 = new Thread(() => Download("http://www.intel.com"));
            Thread t2 = new Thread(() => Download("http://www.altkom.pl"));
            Thread t3 = new Thread(() => Download("http://www.altkom.pl"));
            Thread t4 = new Thread(() => Download("http://www.altkom.pl"));
            Thread t5 = new Thread(() => Download("http://www.altkom.pl"));


            for (int i = 0; i < 20; i++)
            {
                Thread t = new Thread(() => Download("http://www.altkom.pl"));
                t.Start();
            }
            

         
        }

        public static void Download(object uri)
        {
            Download((string)uri);
        }

        public static void Download(string uri)
        {
            using (var client = new WebClient())
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {uri}...");

                string content = client.DownloadString(uri);


                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");
            }
                
        }

        private static void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine(e.Result);
        }
    }
}
