using Autofac;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class AutoFacLambdaContainer : IContainer
	{
		private Autofac.IContainer _container;

		public string Name
		{
			get { return "AutoFac Lambda"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.Resolve<T>();
		}

		public void SetupForTransientTest()
		{
			var builder = new ContainerBuilder();

			builder.Register(c => new Repository()).As<IRepository>();
			builder.Register(c => new AuthenticationService()).As<IAuthenticationService>();
			builder.Register(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>()));

			builder.Register<IWebService>(c => new WebService(c.Resolve<IAuthenticator>(), c.Resolve<IStockQuote>()));
			builder.Register<IAuthenticator>(c => new Authenticator(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>()));
			builder.Register<IStockQuote>(c => new StockQuote(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>()));
			builder.Register<IDatabase>(c => new Database(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			builder.Register<IErrorHandler>(c => new ErrorHandler(c.Resolve<ILogger>()));

			builder.Register(c => new Service1(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService1>();
			builder.Register(c => new Service2(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService2>();
			builder.Register(c => new Service3(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService3>();
			builder.Register(c => new Service4(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService4>();

			builder.Register<ILogger>(c => new Logger());

			//builder.Register(c => new Repository()).As<IRepository>();
			//builder.Register(c => new AuthenticationService()).As<IAuthenticationService>();
			//builder.Register(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>()));

			//builder.Register(c => new WebService(c.Resolve<IAuthenticator>(), c.Resolve<IStockQuote>())).As<IWebService>();
			//builder.Register(c => new Authenticator(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>())).As<IAuthenticator>();
			//builder.Register(c => new StockQuote(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>())).As<IStockQuote>();
			//builder.Register(c => new Database(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IDatabase>();
			//builder.Register(c => new ErrorHandler(c.Resolve<ILogger>())).As<IErrorHandler>();

			//builder.Register(c => new Service1(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService1>();
			//builder.Register(c => new Service2(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService2>();
			//builder.Register(c => new Service3(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService3>();
			//builder.Register(c => new Service4(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService4>();

			//builder.Register(c => new Logger()).As<ILogger>();

			_container = builder.Build();
		}

		public void SetupForSingletonTest()
		{
			var builder = new ContainerBuilder();

			builder.Register(c => new Repository()).As<IRepository>().SingleInstance();
			builder.Register(c => new AuthenticationService()).As<IAuthenticationService>().SingleInstance();
			builder.Register(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>())).SingleInstance();

			builder.Register(c => new WebService(c.Resolve<IAuthenticator>(), c.Resolve<IStockQuote>())).As<IWebService>().SingleInstance();
			builder.Register(c => new Authenticator(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>())).As<IAuthenticator>().SingleInstance();
			builder.Register(c => new StockQuote(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>())).As<IStockQuote>().SingleInstance();
			builder.Register(c => new Database(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IDatabase>().SingleInstance();
			builder.Register(c => new ErrorHandler(c.Resolve<ILogger>())).As<IErrorHandler>().SingleInstance();

			builder.Register(c => new Service1(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService1>().SingleInstance();
			builder.Register(c => new Service2(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService2>().SingleInstance();
			builder.Register(c => new Service3(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService3>().SingleInstance();
			builder.Register(c => new Service4(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>())).As<IService4>().SingleInstance();

			builder.Register(c => new Logger()).SingleInstance().As<ILogger>().SingleInstance();

			_container = builder.Build();
		}
	}
}