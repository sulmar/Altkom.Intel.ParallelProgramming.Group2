using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client.Reactive
{
    class WindowTests
    {
        public static void WindowTest()
        {
            var random = new Random();

            var source = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => random.Next(1, 10))
                .Publish();


            var sourceConnectable = source.Connect();

            // var buffered = source.Buffer(3);

            var buffered = source.Window(3);

            source.Subscribe(item => Console.WriteLine(item));

            buffered.Subscribe(items =>
            {
                items.Subscribe(item =>
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(item);
                    Console.ResetColor();
                }
                );

                
            });
        }

        public static void BufferTimeTest()
        {
            var random = new Random();

            var source = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => random.Next(1, 10))
                .Publish();


            var sourceConnectable = source.Connect();

            var buffered = source.Buffer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));

            source.Subscribe(item => Console.WriteLine(item));

            buffered.Subscribe(items =>
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Join("-", items));
                Console.ResetColor();
            });
        }

        public static void Test()
        {
            var random = new Random();

            var source = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => random.Next(1, 10))
                .Publish();


            var sourceConnectable = source.Connect();

            // var buffered = source.Buffer(3);

            var buffered = source.Buffer(3, 3);

            source.Subscribe(item => Console.WriteLine(item));

            buffered.Subscribe(items =>
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Join("-", items));
                Console.ResetColor();
            });
        }
    }
}
