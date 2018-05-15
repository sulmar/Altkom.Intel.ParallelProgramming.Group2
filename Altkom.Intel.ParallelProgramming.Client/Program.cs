﻿using System;
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
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            TaskTests.TaskRunTest();

            // TaskTests.CancelTaskTest();

            //   TaskTests.CancelDownloadAsyncTest();

            //   TaskTests.CancelTaskTest();

            // ThreadTests.UsingTest();



            //Task.Run(()=>AsyncAwaitTests.GetRobotsTest());
            //Task.Run(() => AsyncAwaitTests.GetRobotsTest());
            //Task.Run(() => AsyncAwaitTests.GetRobotsTest());

            // AsyncAwaitTests.AsyncAwaitTest();

            Console.WriteLine("next...");

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
