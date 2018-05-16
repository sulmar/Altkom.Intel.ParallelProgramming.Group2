using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class MyObserver : IObserver<string>
    {
        public string Name { get; private set; }

        public MyObserver(string name)
        {
            this.Name = name;
        }

        public void OnCompleted()
        {
            Console.WriteLine($"[{Name}] End of transmission");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"[{Name}] Exception {error.Message}");
        }

        public void OnNext(string value)
        {
            Console.WriteLine($"[{Name}] Received value: {value}");
        }
    }
}
