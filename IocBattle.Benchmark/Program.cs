using System;
using IocBattle.Benchmark.Tests;

namespace IocBattle.Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			var containers = new IContainer[]
			                 {
			                 	new NewContainer(),

			                 	new DynamoAutoContainer(),

									new AutoFacLambdaContainer(),
									
									new AutoFacContainer(),

									new StructureMapContainer(),

                                    new SimpleInjectorContainer(), 

			                 	new UnityContainer(),

									new NinjectContainer(),

									new WindsorContainer(),
			                 };

			foreach (var container in containers)
			{
				(new BenchEngine(container)).Start();
			}

			Console.Read();
		}
	}
}