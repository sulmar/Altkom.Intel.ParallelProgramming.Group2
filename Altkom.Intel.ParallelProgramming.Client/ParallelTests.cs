using Altkom.Intel.ParallelProgramming.IServices;
using Altkom.Intel.ParallelProgramming.Models;
using Altkom.Intel.ParallelProgramming.Services.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class ParallelTests
    {
        public static async void SafeForParallelTest()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            IList<string> urls = new List<string>()
            {
                "http://localhost:58686/api/robots",
                "http://localhost:58686/api/robots",
                "http://localhost:58686/api/robots",

            };
            
            Parallel.ForEach(urls,
                () => new WebClient(),
                (url, loopstate, index, client) =>
                {

                    GetRobots(client);

                    return client;
                },
                client => { Console.WriteLine("Finished."); });
                
                
            

            //Parallel.For(0, 1000, 
            //    () => new WebClient(),
            //    (loopstate, index, client) =>
            //    {
            //        GetRobots(client);

            //        return client;
            //    });

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.Elapsed}");

        }

        public static async void UnsafeForParallelTest()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            using (var client = new WebClient())
            {
                Parallel.For(0, 1000, i => GetRobots(client));
            }

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.Elapsed}");

        }

        public static async void WaitTaskTest()
        {
            var t1 = GetRobotsAsync();

            var t2 = GetRobotsAsync();

            var t3 = GetRobotsAsync();

            // IList<Task> tasks = new List<Task> { t1, t2, t3 };

            // blocking UI
            Task.WaitAll(t1, t2, t3);

            // non blocking UI
            await Task.WhenAll(t2, t2, t3);

            // await Task.WhenAll(tasks);

            Console.WriteLine("done.");
        }

        public static async void ForSequentialTest()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                GetRobots();
            }

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.Elapsed}");
            
        }


        //public static async void ForParallelTest()
        //{
        //    Parallel.For
        //}

        private static void GetRobots()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading...");

            using (var client = new WebClient())
            {
                var content = client.DownloadString("http://localhost:58686/api/robots");

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {content.Length} downloaded.");

            }
        }

        private static void GetRobots(WebClient client)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading...");

            var content = client.DownloadString("http://localhost:58686/api/robots");

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {content.Length} downloaded.");
            
        }


        private static async Task GetRobotsAsync()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading...");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58686");

                var response = await client.GetAsync("api/robots");

                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} {content.Length} downloaded.");

                
            }
        }




    }
}
