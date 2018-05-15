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

        public static void TaskRunTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} UI");

        //    DoWorkAsync();

            DoWorkAsync2();

        }

        public static Task<decimal> DoWorkAsync()
        {
            return Task.Run(() => DoWork());
        }

        public static Task<decimal> DoWorkAsync2()
        {
            return Task.FromResult(DoWork());
        }


        public static async Task ComplexDoWorkAsync()
        {
            var result1 = await DoWorkAsync().ConfigureAwait(false);

            var result2 = await DoWorkAsync();

            Console.WriteLine(result1);
        }


        public static decimal DoWork()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} working...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} finished.");

            return 100;
        }


        public static async Task CancelTaskTest()
        { 
            Calculator calculator = new Calculator();

            await calculator.LongCalculateAsync();
        }



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



        public static async Task CancelDownloadAsyncTest()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(100);

            var content = await DownloadAsync("http://www.microsoft.com", cancellationTokenSource.Token);

            Console.WriteLine(content);

        }


        public static async Task<string> DownloadAsync(string uri, CancellationToken token)
        {
            string content;

            using (var client = new WebClient())
            using (var registration = token.Register(() => client.CancelAsync()))
            {
                content = await client.DownloadStringTaskAsync(uri);
            }

            return content;
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
