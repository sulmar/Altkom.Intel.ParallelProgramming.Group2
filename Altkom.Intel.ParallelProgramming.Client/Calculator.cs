using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    public class Calculator : IDisposable
    {
        private IProgress<int> progress = new Progress<int>(p => Console.Write($"{p} "));


        public Task LongCalculateAsync()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            CancellationToken token = cancellationTokenSource.Token;

            token.Register(() => Console.WriteLine("Canceled Task."));
           
            var t = Task.Run(() => LongCalculate(token));

            // ręczne
            //Console.WriteLine("Press any key to cancel");
            //Console.ReadKey();
            // cancellationTokenSource.Cancel();

            // automatyczne
            // cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(3));

          
            return t;
        }


        public void LongCalculate(CancellationToken token)
        {
            for (int i = 0; i < 100 && !token.IsCancellationRequested; i++)
            {
             

               //  token.ThrowIfCancellationRequested();

                // lub 
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("IsCancellationRequested");                   
                    break;
                }

                //  Console.Write(".");                

                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                progress.Report(i);
            }
        }


        private const string tempfile = "temp.txt";

        public decimal Calculate()
        {
            File.Create(tempfile);

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(15));

            Console.WriteLine("#{Thread.CurrentThread.ManagedThreadId} Calculated.");

            return 100;
        }

        public void Dispose()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Disposed.");

            if (File.Exists(tempfile))
                    File.Delete(tempfile);
            
        }
    }
}
