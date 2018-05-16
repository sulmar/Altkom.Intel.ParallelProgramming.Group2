using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class MyObserver : IObserver<string>
    {
        public void OnCompleted()
        {
            Console.WriteLine("End of transmission");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Exception {error.Message}");
        }

        public void OnNext(string value)
        {
            Console.WriteLine($"Received value: {value}");
        }
    }
}
