using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class MergeSourceTests
    {
        public static void ConcatTest()
        {
            var tempRoom1 = Observable.Range(1, 5);
            var tempRoom2 = Observable.Range(10, 5);

            var temps = tempRoom1.Concat(tempRoom2);

            temps.Subscribe(temp => Console.WriteLine(temp));
        }

        public static void ConcatIntervalTest()
        {
            var tempRoom1 = Observable.Interval(TimeSpan.FromSeconds(1)).Select(item => 1);
            var tempRoom2 = Observable.Interval(TimeSpan.FromSeconds(1)).Select(item => 10);

            var temps = tempRoom1.Concat(tempRoom2);

            temps.Subscribe(temp => Console.WriteLine(temp));
        }

        public static void MergeTest()
        {
            var tempRoom1 = Observable.Range(1, 5);
            var tempRoom2 = Observable.Range(10, 5);

            var temps = tempRoom1.Merge(tempRoom2);

            temps.Subscribe(temp => Console.WriteLine(temp));
        }

        public static void MergeIntervalTest()
        {
            var tempRoom1 = Observable.Interval(TimeSpan.FromSeconds(1)).Select(item => 1);
            var tempRoom2 = Observable.Interval(TimeSpan.FromSeconds(2)).Select(item => 10);

            var temps = tempRoom1.Merge(tempRoom2);

            // Observable.Merge()

            temps.Subscribe(temp => Console.WriteLine(temp));
        }

    }
}
