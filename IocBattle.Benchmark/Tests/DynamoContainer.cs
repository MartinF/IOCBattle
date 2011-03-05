using Dynamo.Ioc;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class DynamoContainer : IContainer
	{
		private Container _container;

		public string Name
		{
			get { return "Dynamo Manual"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.Resolve<T>();
		}

		public void SetupForTransientTest()
		{
			_container = new Container();
			Setup(_container);
		}

		public void SetupForSingletonTest()
		{
			_container = new Container(Lifetime.Container);
			Setup(_container);
		}

		public void Setup(Container container)
		{
			container.Register<IRepository>(c => new Repository());
			container.Register<IAuthenticationService>(c => new AuthenticationService());
			container.Register<UserController>(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>()));

			container.Register<IWebService>(c => new WebService(c.Resolve<IAuthenticator>(), c.Resolve<IStockQuote>()));
			container.Register<IAuthenticator>(c => new Authenticator(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>()));
			container.Register<IStockQuote>(c => new StockQuote(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>(), c.Resolve<IDatabase>()));
			container.Register<IDatabase>(c => new Database(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			container.Register<IErrorHandler>(c => new ErrorHandler(c.Resolve<ILogger>()));

			container.Register<IService1>(c => new Service1(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			container.Register<IService2>(c => new Service2(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			container.Register<IService3>(c => new Service3(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			container.Register<IService4>(c => new Service4(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));

			container.Register<ILogger>(c => new Logger());

			_container.Compile();
			_container.Verify();
		}
	}
}