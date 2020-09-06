using System;
using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using NumSharp;

namespace NumSharp.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\haipi\AppData\Local\Temp\mnist.npz";
            var datax = np.Load_Npz<byte[,,]>(file);
            var datay = np.Load_Npz<byte[]>(file);

            if (args?.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string name = $"NumSharp.Benchmark.{args[i]}";
                    var type = Type.GetType(name);
                    BenchmarkRunner.Run(type);
                }
            }
            else
            {
                BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args, ManualConfig.Create(DefaultConfig.Instance).With(ConfigOptions.DisableOptimizationsValidator));
            }

            Console.ReadLine();
        }
    }
}
