using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class SimpleColdSource : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            observer.OnNext("Hello");
            observer.OnNext("World");
            observer.OnCompleted();

            return new EmptyDisposable();
        }

        private class EmptyDisposable : IDisposable
        {
            // public static EmptyDisposable Instance = new EmptyDisposable();

            public void Dispose()
            {             
            }
        }
    }
}
