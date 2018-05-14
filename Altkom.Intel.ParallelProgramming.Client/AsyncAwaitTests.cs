using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class AsyncAwaitTests
    {
        public static async Task AsyncAwaitTest()
        {
            int result1 = await CalculateAsync("http://www.intel.com");

            int result2 = await CalculateAsync("http://www.altkom.pl");

            int result3 = await HttpClientCalculateAsync("http://www.altkom.pl");

            Console.WriteLine($"Result: {result1 + result2}");
        }

        public static void ContinueWithTest()
        {
            CalculateAsync("http://www.intel.com")
             .ContinueWith(t => Console.WriteLine($"Result: {t.Result}"));
        }

        //public static Task<int> CalculateAsync(string uri)
        //{
        //    return Task.Run(() => Calculate(uri));
        //}


        public static async Task<int> HttpClientCalculateAsync(string uri)
        {
            int result = 0;

            using (var client = new HttpClient())
            {                
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {uri}...");

                var content = await client.GetStringAsync(uri);

                // Thread.Sleep(TimeSpan.FromSeconds(5));

                await Task.Delay(TimeSpan.FromSeconds(3));

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");


                return content.Length;
            }
        }

        public static async Task<int> CalculateAsync(string uri)
        {
            int result = 0;

            using (var client = new WebClient())
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {uri}...");

                string content = await client.DownloadStringTaskAsync(uri);

                Thread.Sleep(TimeSpan.FromSeconds(5));

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");

                result = content.Length;
            }

            return result;
        }

        public static int Calculate(string uri)
        {
            int result = 0;

            using (var client = new WebClient())
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {uri}...");

                string content = client.DownloadString(uri);

                Thread.Sleep(TimeSpan.FromSeconds(5));

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} " +
                    $"downloaded {uri} length: {content.Length}");

                result = content.Length;
            }

            return result;
        }
    }
}
