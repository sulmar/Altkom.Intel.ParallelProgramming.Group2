using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class HotSourceTests
    {
        // Install-Package System.Reactive
        public static void SubjectTest()
        {
            var source = new Subject<string>();
            source.OnNext("Hello");
            source.OnNext("World");

            var observer = new MyObserver("Marcin");

            var sub = source.Subscribe(observer);

            source.OnNext("Hello");

            var observer2 = new MyObserver("Bartek");
            source.Subscribe(observer2);

            source.OnError(new Exception("failure"));

            sub.Dispose();

            source.OnNext("Intel");

            

            source.OnCompleted();

        }
    }
}
