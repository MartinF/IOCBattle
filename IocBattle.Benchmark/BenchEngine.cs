using System;
using System.Diagnostics;
using System.Threading;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark
{
	public class BenchEngine 
	{
		private readonly IContainer _container;

		public BenchEngine(IContainer container)
		{
			_container = container;
		}

		public void Start()
		{
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
			// Thread.Sleep(1000);

			RunBenchmark(_container.SetupForSingletonTest, "Singleton");

			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
			// Thread.Sleep(1000);

			RunBenchmark(_container.SetupForTransientTest, "Transient");

			Console.WriteLine("");
		}

		private void RunBenchmark(Action setupAction, string mode)
		{
			var regTimer = new Stopwatch();
			var resolveTimer = new Stopwatch();

			regTimer.Start();
			setupAction();
			regTimer.Stop();

			resolveTimer.Start();

			for (int i = 0; i < 1000000; i++)
			{
				var instance = _container.Resolve<IWebService>();
			}

			resolveTimer.Stop();

			Console.WriteLine("{0}: - {1} - Registartion time: \t{2}ms", _container.Name, mode, regTimer.Elapsed.TotalMilliseconds);
            Console.WriteLine("{0}: - {1} - Component resolve time: \t{2}ms", _container.Name, mode, resolveTimer.Elapsed.TotalMilliseconds);
		}
	}
}