using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class ParallelAggregationTest
    {
        public static void CalculateTest()
        {
            double[] sequence = new double[] { 5, 6, 6, 8 };

            var result = Calculate(sequence);

            Console.WriteLine(result);
        }

        public static double Calculate(double[] sequence)
        {
            object lockObject = new object();
            double sum = 0.0d;

            Parallel.ForEach(
              // The values to be aggregated 
              sequence,

              // The local initial partial result
              () => 0.0d,

              // The loop body
              (x, loopState, partialResult) =>
              {
                  return Normalize(x) + partialResult;
              },

              // The final step of each local context            
              (localPartialSum) =>
              {
        // Enforce serial access to single, shared result
        lock (lockObject)
                  {
                      sum += localPartialSum;
                  }
              });
            return sum;
        }

        private static double Normalize(double x)
        {
            return x * x;
        }
    }
}
