using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class TimeObservableTest
    {

        public static void TimerTest()
        {
            var random = new Random();

            var source = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => random.Next(1, 100));

            var sourceConnectable = source.Publish();

            sourceConnectable.Connect();

            // Timer wysyla jednorazowo
            // var source = Observable.Timer(TimeSpan.FromSeconds(4)).Select(_ => 10);

            var alerts = sourceConnectable.Where(item => item > 70);

            // sourceConnectable.Where(item => item < 10).Subscribe

            var sub = sourceConnectable.Subscribe(item => Console.WriteLine(item));

            alerts.Subscribe(item => Console.WriteLine($"ALERT {item}"));

            //for (double i = 0; i < 100; i++)
            //{
            //    source.OnNext(i);
            //}

            Console.ReadKey();

            
            
        }
    }
}
