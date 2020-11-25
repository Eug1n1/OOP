using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;

namespace lab_15
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true)
        {
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }

    public static class LabMethods
    {
        private static int complete = 0;

        static Mutex mutexObj = new Mutex();

        public static event Action Complete;


        private static StreamWriter sw;

        public static void GetProcessesInfo()
        {
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine(
                    $"Name: {process.ProcessName}\n\tId: {process.Id}\n\tBasePriority: {process.BasePriority}\n\t" +
                    $"StartTime: {process.StartTime}\n\tTotalProcessorTime: {process.TotalProcessorTime}");
            }
        }

        public static void GetDomainInfo()
        {
            var domain = AppDomain.CurrentDomain;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"BaseDirectory: {domain.BaseDirectory}");

            var asms = domain.GetAssemblies();

            foreach (var a in asms)
            {
                Console.WriteLine($"{a.GetName().Name}");
            }

            Console.ResetColor();
        }

        public static void LoadAssembly()
        {
            LoadAssembly(6);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);
        }

        private static void LoadAssembly(int number)
        {
            var context = new CustomAssemblyLoadContext();

            context.Unloading += Context_Unloading;

            var assemblyPath = "/home/eug1n1/Desktop/MyApp.dll";

            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);

            var type = assembly.GetType("MyApp.Program");

            var greetMethod = type.GetMethod("Factorial");

            var instance = Activator.CreateInstance(type);
            int result = (int) greetMethod.Invoke(instance, new object[] {number});

            Console.WriteLine($"Факториал числа {number} равен {result}");

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);

            context.Unload();
        }

        private static void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("Библиотека MyApp выгружена \n");
        }

        public static void ThreadReset()
        {
            Thread thr = new Thread(Method);
            ManualResetEvent me = new ManualResetEvent(true);

            thr.Start(me);

            Console.ReadKey(true);
            Console.WriteLine("Pause");
            me.Reset();

            Console.ReadKey(true);
            Console.WriteLine("Run");
            me.Set();
        }

        public static void Timer()
        {
            TimerCallback tm = new TimerCallback(TimerFunc);
            Timer timer = new Timer(tm, null, 0, 2000);
 
            Console.ReadKey(true);
        }

        private static void Method(object state)
        {
            ManualResetEvent mre = (ManualResetEvent) state;

            var tr = Thread.CurrentThread;

            Console.WriteLine($"Name: {tr.Name}");
            Console.WriteLine($"\tId: {tr.ManagedThreadId}");
            Console.WriteLine($"\tPriority: {tr.Priority}");
            Console.WriteLine($"\tThreadState: {tr.ThreadState.ToString()}");

            for (int i = 0; i < 20; i++)
            {
                mre.WaitOne();
                Thread.Sleep(500);
                Console.WriteLine("Hi");
            }
        }

        public static void Threads()
        {
            var th1 = new Thread(Thread1);
            var th2 = new Thread(Thread2);
            th2.Priority = ThreadPriority.Highest;
            sw = new StreamWriter("/home/eug1n1/th.txt");

            Complete += () =>
            {
                sw.Dispose();
                Console.WriteLine("Complete!");
            };

            th1.Start();
            th2.Start();
        }

        private static void Thread1()
        {
            lock (sw)
            {
                for (int i = 0; i < 20; i += 2)
                {
                    Thread.Sleep(500);
                    sw.Write(i + "\n");
                    Console.WriteLine(i);
                }

                complete++;
                OnComplete();
            }
        }

        private static void Thread2()
        {
            lock (sw)
            {
                for (int i = 1; i < 20; i += 2)
                {
                    Thread.Sleep(1000);
                    sw.Write(i + "\n");
                    Console.WriteLine(i);
                }

                complete++;
                OnComplete();
            }
        }

        private static void OnComplete()
        {
            if (complete == 2)
            {
                Complete?.Invoke();
            }
        }

        public static void Threads2()
        {
            var th1 = new Thread(Thread11);
            var th2 = new Thread(Thread22);
            sw = new StreamWriter("/home/eug1n1/th.txt");

            Complete += () =>
            {
                sw.Dispose();
                Console.WriteLine("Complete!");
            };

            th1.Start();
            Thread.Sleep(100);
            th2.Start();
        }

        private static void Thread11()
        {
            for (int i = 0; i < 20; i += 2)
            {
                mutexObj.WaitOne();
                sw.Write(i + "\n");
                Console.WriteLine(i);
                mutexObj.ReleaseMutex();
                Thread.Sleep(500);
            }

            complete++;
            OnComplete();
        }

        private static void Thread22()
        {
            for (int i = 1; i < 20; i += 2)
            {
                mutexObj.WaitOne();
                sw.Write(i + "\n");
                Console.WriteLine(i);
                mutexObj.ReleaseMutex();
                Thread.Sleep(500);
            }

            complete++;
            OnComplete();
        }
        
        private static void TimerFunc(object a)
        {
            Console.WriteLine("Hi!");
        }
    }
}