using Altkom.Intel.ParallelProgramming.Client.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorCpu.Test();

            // WindowTests.WindowTest();

            //   WindowTests.BufferTimeTest();

            // 6WindowTests.Test();

            // FileWatcherTests.Test();

            // MergeSourceTests.MergeIntervalTest();

            // MergeSourceTests.MergeTest();

            // MergeSourceTests.ConcatIntervalTest();

            // MergeSourceTests.ConcatTest();

            // TimeObservableTest.TimerTest();

            // HotSourceTests.SubjectTest();

            // ReactiveTests.ObserverAndObservableTest();

            // ParallelAggregationTest.CalculateTest();

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            // ParallelLinqTests.ParallelTest2();

            //ParallelLinqTests.ParallelTest();

            //ParallelLinqTests.ParallelTest();

            //ParallelLinqTests.SequentialTest();

            // ParallelTests.SafeForParallelTest();

            // ParallelTests.UnsafeForParallelTest();


            // Task.Run(()=>ParallelTests.ForSequentialTest());

            // TaskTests.TaskRunTest();

            // TaskTests.CancelTaskTest();

            //   TaskTests.CancelDownloadAsyncTest();

            //   TaskTests.CancelTaskTest();

            // ThreadTests.UsingTest();



            //Task.Run(()=>AsyncAwaitTests.GetRobotsTest());
            //Task.Run(() => AsyncAwaitTests.GetRobotsTest());
            //Task.Run(() => AsyncAwaitTests.GetRobotsTest());

            // AsyncAwaitTests.AsyncAwaitTest();

            //  Console.WriteLine("next...");

            //TaskTests.ContinueWithTaskTest();
            //TaskTests.ContinueWithTaskTest();
            //TaskTests.ContinueWithTaskTest();

            //TaskTests.CreateParameterTaskTest();

            //TaskTests.CreateParameterTaskTest();

            //TaskTests.CreateParameterTaskTest();

            // TaskTests.CreateMultiTask();

            // TaskTests.CreateTask();


            //ThreadPoolTests.SetThreadPoolTest();

            //ThreadPoolTests.GetThreadPoolTest();

            //ThreadPoolTests.CreateThreadPoolTest();

            // ThreadTests.ThreadWithParametersLambdaTest();

            // ThreadTests.ThreadWithParameterTest();

            //ThreadTests.CreateThread();
            //ThreadTests.CreateThread();
            //ThreadTests.CreateThread();


            //HelloWorldTest.Hello("Hello Intel!");
            //HelloWorldTest.Hello("Hello Altkom!");

            Console.WriteLine("Press key to exit.");

            Console.ReadKey();
        }
    }
}
