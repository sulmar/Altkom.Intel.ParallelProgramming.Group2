using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class TaskTests
    {
        public static Task<int> CalculateAsync(string uri)
        {
            return Task.Run(() => Calculate(uri));
        }

        public static void ContinueWithTaskTest()
        {
            //var t1 = Task.Run(() => Calculate("http://www.intel.com"));

            //t1.ContinueWith(bla => Console.WriteLine($"Result: {bla.Result}"));

            CalculateAsync("http://www.intel.com")
                .ContinueWith(t => Task.Run(() => Console.WriteLine($"Result: {t.Result}")));
            
        }



        public static void CreateParameterTaskTest()
        {
            var t1 = Task.Run(() => Calculate("http://www.intel.com"));

            Console.WriteLine($"Result: {t1.Result}");
        }

        public static void CreateMultiTask()
        {
            for (int i = 0; i < 20; i++)
            {
                CreateTask();
            }
        }

        public static void CreateTask()
        {
            Task task = new Task(() => Download("http://www.intel.com"), TaskCreationOptions.LongRunning);
            task.Start();
        }

        public static void CreateFactoryTask()
        {
            Task.Factory.StartNew(() => Download("http://www.intel.com"));
        }

        public static void RunTaskTest()
        {
            var task = Task.Run(() => Download("http://www.intel.com"));
        }


        public static void Download(string uri)
        {
            using (var client = new WebClient())
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {uri}...");

                string content = client.DownloadString(uri);
                
                Thread.Sleep(TimeSpan.FromSeconds(2));

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");
            }
        }

        public static int Calculate(string uri)
        {
            int result = 0;

            using (var client = new WebClient())
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {uri}...");

                string content = client.DownloadString(uri);

                Thread.Sleep(TimeSpan.FromSeconds(2));

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");

                result = content.Length;
            }

            return result;
        }
    }
}
