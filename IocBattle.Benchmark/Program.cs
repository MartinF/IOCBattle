using System;
using System.Linq;
using IocBattle.Benchmark.Tests;
using System.Collections.Generic;

namespace IocBattle.Benchmark
{
	public class Program
	{
		public static int MaxContainerNameLength = 0;

		static void Main( string[] args )
		{
			var containers = new IContainer[]
			                 {
			                 	new NewContainer(),
			                 	new DynamoAutoContainer(),
								/*
								new AutoFacLambdaContainer(),
								new AutoFacContainer(),
								new StructureMapContainer(),
                                new SimpleInjectorContainer(), 
			                 	new UnityContainer(),
								new NinjectContainer(),
								new WindsorContainer(),
								*/
								new DryIocContainer()
			                 };

			MaxContainerNameLength = containers.Max( c => c.Name.Length );

			List<Result> results = new List<Result>();

			foreach ( var container in containers )
			{
				Console.WriteLine( "Testing {0}", container.Name );
				var res = ( new BenchEngine( container ) ).Start();
				_writeTestResult( res );
				results.AddRange( res );
			}

			_writeResults( results );
			
			Console.WriteLine( "Tests complete. [Enter] to terminate." );
			Console.ReadLine();
		}

		private static void _writeTestResult( List<Result> results )
		{
			results.ForEach(
				res =>
				{
					Console.WriteLine( "{0}: - {1} - Registration time:      {2," + ( Program.MaxContainerNameLength - res.Name.Length + 11 ) + ":####0.0000}ms", res.Name, res.Mode, res.RegisterTime );
					Console.WriteLine( "{0}: - {1} - Component resolve time: {2," + ( Program.MaxContainerNameLength - res.Name.Length + 11 ) + ":####0.0000}ms", res.Name, res.Mode, res.ResolveTime );
				}
			);
			Console.WriteLine( "" );
		}
		private static void _writeResults( IList<Result> results )
		{
			Console.WriteLine( "************************************************************************" );

			Console.WriteLine();

			Console.WriteLine( "Singletons" );
			Console.WriteLine( "==============================" );

			Console.WriteLine( "Fastest registrations --------" );
			results
				.Where( r => r.Mode == "Singleton" )
				.OrderBy( r => r.RegisterTime )
				.ToList()
				.ForEach(
					r => Console.WriteLine( "  {0," + ( Program.MaxContainerNameLength + 1 ) + "}: {1,11:##0.0000}ms", r.Name, r.RegisterTime )
				);

			Console.WriteLine();

			Console.WriteLine( "Fastest resolvers ------------" );
			results
				.Where( r => r.Mode == "Singleton" )
				.OrderBy( r => r.ResolveTime )
				.ToList()
				.ForEach(
					r => Console.WriteLine( "  {0," + ( Program.MaxContainerNameLength + 1 ) + "}: {1,11:##0.0000}ms", r.Name, r.ResolveTime )
				);

			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine( "Transients" );
			Console.WriteLine( "==============================" );

			Console.WriteLine( "Fastest registrations --------" );
			results
				.Where( r => r.Mode == "Transient" )
				.OrderBy( r => r.RegisterTime )
				.ToList()
				.ForEach(
					r => Console.WriteLine( "  {0," + ( Program.MaxContainerNameLength + 1 ) + "}: {1,11:##0.0000}ms", r.Name, r.RegisterTime )
				);

			Console.WriteLine();

			Console.WriteLine( "Fastest resolvers ------------" );
			results
				.Where( r => r.Mode == "Transient" )
				.OrderBy( r => r.ResolveTime )
				.ToList()
				.ForEach(
					r => Console.WriteLine( "  {0," + ( Program.MaxContainerNameLength + 1 ) + "}: {1,11:##0.0000}ms", r.Name, r.ResolveTime )
				);

			Console.WriteLine();
			Console.WriteLine();
		}
	}
}