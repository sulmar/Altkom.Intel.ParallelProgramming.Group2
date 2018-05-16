using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class ReactiveTests
    {
        public static void ObserverAndObservableTest()
        {
            var source = new SimpleColdSource();

            var observer1 = new MyObserver();
            var observer2 = new MyObserver();

            using (var subscibtion = source.Subscribe(observer1))
            {

            }

            source.Subscribe(observer2);

                //subscibtion.Dispose();

        }
    }
}
