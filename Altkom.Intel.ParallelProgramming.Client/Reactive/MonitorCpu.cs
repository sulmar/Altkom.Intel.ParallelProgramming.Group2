using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class MonitorCpu
    {
        public static void Test()
        {
            var cpuMonitor = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(_ => cpuMonitor.NextValue());

            source.Subscribe(cpu => Console.WriteLine($"{cpu} %"));

            source
                .Where(cpu => cpu > 10)
                .Subscribe(cpu => Console.WriteLine($"ALERT {cpu}"));

        }
    }
}
