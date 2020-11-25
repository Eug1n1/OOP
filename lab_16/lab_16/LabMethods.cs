using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace lab_16
{
    public static class LabMethods
    {
        private static readonly CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private static CancellationToken _token = cancelTokenSource.Token;

        private static List<int> list = new List<int>();

        public static void TestLoad()
        {
            var task = Task.Run(SetLoad);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!task.IsCompleted)
            {
                Console.WriteLine("Task1 is running");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed.Seconds;

            Console.WriteLine($"{ts} seconds passed");

            var task2 = Task.Run(SetLoad2);
            stopWatch.Reset();
            stopWatch.Start();
            while (!task2.IsCompleted)
            {
                Console.WriteLine("Task2 is running");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed.Seconds;

            Console.WriteLine($"{ts} seconds passed");
        }

        public static void TestCancellationToken()
        {
            var task = Task.Run(SetLoad2);
            Console.WriteLine("Enter anything");
            Console.ReadKey(true);
            cancelTokenSource.Cancel();
        }

        public static void TestContinuationTask()
        {
            var task1 = new Task<int>(() => Sum(4, 5));
            var task2 = new Task<int>(() => Squaring(task1.GetAwaiter().GetResult()));
            Task task3 = task2.ContinueWith(a => Display(a.Result));

            task1.Start();
            task2.Start();
            task3.Wait();
        }

        public static void TestParallel()
        {
            Parallel.For(0, 10000, ParallelForLoad1);
            List<FileInfo> a =
                new List<FileInfo>(new DirectoryInfo("/home/eug1n1/").GetFiles("", SearchOption.AllDirectories));

            Parallel.ForEach(a, ParallelForEachLoad2);
        }

        public static void TestParallelInvoke()
        {
            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine("я работаю\t как и все здесь");
                        Thread.Sleep(1000);
                    }
                },
                () =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                        Thread.Sleep(3000);
                    }
                },
                () =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }
                });
        }

        public static void TestBlockingCollection()
        {
            using (var shop = new BlockingCollection<int>() {1, 2, 3, 4, 5, 6, 7, 78, 9,})
            {
                var task = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (_token.IsCancellationRequested)
                        {
                            break;
                        }

                        shop.Add(new Random().Next(10));
                        Console.WriteLine("Add");
                        Thread.Sleep(500);
                    }
                });

                var task5 = Task.Run(() =>
                {
                    try
                    {
                        while (true)
                        {
                            if (_token.IsCancellationRequested)
                            {
                                break;
                            }

                            Console.WriteLine("Count: " + shop.Count);
                            Thread.Sleep(500);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("That's All!");
                    }
                });

                var task2 = Task.Run(() =>
                {
                    try
                    {
                        while (true)
                        {
                            if (_token.IsCancellationRequested)
                            {
                                break;
                            }

                            Console.WriteLine("Sell" + shop.Take());
                            Thread.Sleep(500);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("That's All!");
                    }
                });

                var task3 = Task.Run(() =>
                {
                    try
                    {
                        while (true)
                        {
                            if (_token.IsCancellationRequested)
                            {
                                break;
                            }

                            Console.WriteLine(shop.Take());
                            Thread.Sleep(500);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("That's All!");
                    }
                });

                Console.WriteLine("Press any key....");
                Console.ReadKey(true);
                cancelTokenSource.Cancel();

                task.Wait();
                Console.WriteLine("task complete");
            }
        }

        public static void TestAsync()
        {
            FactorialAsync();   // вызов асинхронного метода
 
            Console.WriteLine("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен {n * n}");
        }

        private static void ParallelForEachLoad2(FileInfo i)
        {
            Console.WriteLine(i.Name);
        }

        private static void ParallelForLoad1(int i)
        {
            list.Add(i);
        }

        private static int Squaring(int a)
        {
            return a * a;
        }

        private static int Sum(int a, int b)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return a + b;
        }

        private static void Display(int sum)
        {
            Console.WriteLine($"Num: {sum}");
        }

        private static void SetLoad()
        {
            var e = new Eratosfen(100000);
            e.DoEratosfen();
        }

        private static void SetLoad2()
        {
            for (int i = 0; i < 100; i++)
            {
                if (_token.IsCancellationRequested)
                {
                    Console.WriteLine("Canceled");
                    return;
                }

                Thread.Sleep(100);
            }
        }
        
        private static void Factorial()
        {
            int result = 1;
            for(int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал равен {result}");
        }
        
        private static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); 
            await Task.Run(()=>Factorial());                
            Console.WriteLine("Конец метода FactorialAsync");
        }
    }
}