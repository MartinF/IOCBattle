using IocBattle.Benchmark.Models;
using StructureMap;

// How do i specify that it should use a specific named instance ? 

namespace IocBattle.Benchmark.Tests
{
	public class StructureMapNamedContainerTest : IContainer
	{
		public string Name
		{
			get { return "StructureMap Named"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return ObjectFactory.GetNamedInstance<T>("WebService");
		}

		public void SetupForTransientTest()
		{
			ObjectFactory.Container.Dispose();

			ObjectFactory.Initialize(x =>
											 {
												 x.For<IRepository>().Use<Repository>();
												 x.For<IAuthenticationService>().Use<AuthenticationService>();
												 x.For<UserController>().Use<UserController>();

												 x.For<IWebService>().Use<WebService>().Named("WebService");
												 x.For<IAuthenticator>().Use<Authenticator>().Named("Authenticator");
												 x.For<IStockQuote>().Use<StockQuote>().Named("StockQuote");
												 x.For<IDatabase>().Use<Database>().Named("Database");
												 x.For<IErrorHandler>().Use<ErrorHandler>().Named("ErrorHandler");

												 x.For<IService1>().Use<Service1>();
												 x.For<IService2>().Use<Service2>();
												 x.For<IService3>().Use<Service3>();
												 x.For<IService4>().Use<Service4>();

												 x.For<ILogger>().Use<Logger>().Named("Logger");
											 });
		}

		public void SetupForSingletonTest()
		{
			ObjectFactory.Container.Dispose();

			ObjectFactory.Initialize(x =>
			{
				x.For<IRepository>().Singleton().Use<Repository>();
				x.For<IAuthenticationService>().Singleton().Use<AuthenticationService>();
				x.For<UserController>().Singleton().Use<UserController>();

				x.For<IWebService>().Singleton().Use<WebService>().Named("WebService");
				x.For<IAuthenticator>().Singleton().Use<Authenticator>().Named("Authenticator");
				x.For<IStockQuote>().Singleton().Use<StockQuote>().Named("StockQuote");
				x.For<IDatabase>().Singleton().Use<Database>().Named("Database");
				x.For<IErrorHandler>().Singleton().Use<ErrorHandler>().Named("ErrorHandler");

				x.For<IService1>().Singleton().Use<Service1>();
				x.For<IService2>().Singleton().Use<Service2>();
				x.For<IService3>().Singleton().Use<Service3>();
				x.For<IService4>().Singleton().Use<Service4>();

				x.For<ILogger>().Singleton().Use<Logger>().Named("Logger");
			});
		}
	}
}