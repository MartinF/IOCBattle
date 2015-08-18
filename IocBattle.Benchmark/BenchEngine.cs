using System;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using IocBattle.Benchmark.Models;
using System.Collections.Generic;

namespace IocBattle.Benchmark
{
	public class BenchEngine 
	{
		private readonly IContainer _container;

		public BenchEngine(IContainer container)
		{
			_container = container;
		}

		public List<Result> Start()
		{
			List<Result> results = new List<Result>();

			Result ret = null;
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
			// Thread.Sleep(1000);

			ret = RunBenchmark( _container.SetupForSingletonTest, "Singleton" );

			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
			results.Add( ret );
			// Thread.Sleep(1000);

			ret = RunBenchmark(_container.SetupForTransientTest, "Transient");
			results.Add( ret );

			return results;
		}

		private Result RunBenchmark(Action setupAction, string mode)
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

			return new Result
				{
					Name = _container.Name,
					Mode = mode,
					RegisterTime = regTimer.Elapsed.TotalMilliseconds,
					ResolveTime = resolveTimer.Elapsed.TotalMilliseconds
				};
		}
	}
}