using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class ParallelLinqTests
    {

        public static void SequentialTest()
        {
            var chars = "abcdefgh".Select(c => char.ToUpper(c));

            foreach (var item in chars)
            {
                Console.Write(item);
            }
        }

        public static void ParallelTest2()
        {
            for (int i = 0; i < 20; i++)
            {
                var items = (from item in "abcdefgh".AsParallel()
                             select item);

                foreach (var item in items)
                {
                    Console.Write(item);
                }

                Console.WriteLine("----");
            }

            


        }

        public static void ParallelTest()
        {
            for (int i = 0; i < 20; i++)
            {
                var items = "abcdefgh".AsParallel().WithDegreeOfParallelism(2)
                 // .AsOrdered()
                 .Select(c =>
                    {
                        Console.Write($"#{Thread.CurrentThread.ManagedThreadId} ({c})");
                        return char.ToUpper(c); }
                    )
                 .ToList();

                foreach (var item in items)
                {
                    Console.Write(item);
                }

                Console.WriteLine("---");
            }
            

        }
    }
}
