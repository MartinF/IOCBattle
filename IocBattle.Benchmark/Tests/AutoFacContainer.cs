using Autofac;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class AutoFacContainer : IContainer
	{
		private Autofac.IContainer _container;

		public string Name
		{
			get { return "AutoFac"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.Resolve<T>();
		}

		public void SetupForTransientTest()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<Repository>().As<IRepository>();
			builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
			builder.RegisterType<UserController>().As<UserController>();

			builder.RegisterType<WebService>().As<IWebService>();
			builder.RegisterType<Authenticator>().As<IAuthenticator>();
			builder.RegisterType<StockQuote>().As<IStockQuote>();
			builder.RegisterType<Database>().As<IDatabase>();
			builder.RegisterType<ErrorHandler>().As<IErrorHandler>();

			builder.RegisterType<Service1>().As<IService1>();
			builder.RegisterType<Service2>().As<IService2>();
			builder.RegisterType<Service3>().As<IService3>();
			builder.RegisterType<Service4>().As<IService4>();

			builder.RegisterType<Logger>().As<ILogger>();

			_container = builder.Build();
		}

		public void SetupForSingletonTest()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<Repository>().As<IRepository>().SingleInstance();
			builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
			builder.RegisterType<UserController>().As<UserController>().SingleInstance();

			builder.RegisterType<WebService>().As<IWebService>().SingleInstance();
			builder.RegisterType<Authenticator>().As<IAuthenticator>().SingleInstance();
			builder.RegisterType<StockQuote>().As<IStockQuote>().SingleInstance();
			builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
			builder.RegisterType<ErrorHandler>().As<IErrorHandler>().SingleInstance();

			builder.RegisterType<Service1>().As<IService1>().SingleInstance();
			builder.RegisterType<Service2>().As<IService2>().SingleInstance();
			builder.RegisterType<Service3>().As<IService3>().SingleInstance();
			builder.RegisterType<Service4>().As<IService4>().SingleInstance();

			builder.RegisterType<Logger>().As<ILogger>().SingleInstance();

			_container = builder.Build();
		}
	}
}