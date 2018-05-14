using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class ThreadPoolTests
    {
        public static void SetThreadPoolTest()
        {
            ThreadPool.SetMaxThreads(4, 4);
        }

        public static void GetThreadPoolTest()
        {
            int worker = 0;
            int io = 0;
            ThreadPool.GetAvailableThreads(out worker, out io);

            Console.WriteLine("Thread pool threads available at startup: ");
            Console.WriteLine("   Worker threads: {0:N0}", worker);
            Console.WriteLine("   Asynchronous I/O threads: {0:N0}", io);
        }

        public static void CreateThreadPoolTest()
        {
           
            ThreadPool.QueueUserWorkItem(Download, "http://www.intel.com");

            for (int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(Download, "http://www.altkom.pl");
                
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

                GetThreadPoolTest();

                Thread.Sleep(TimeSpan.FromSeconds(2));

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");
            }
        }
    }
}
