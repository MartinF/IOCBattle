using Dynamo.IocContainer;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class DynamoTypeofContainer : IContainer
	{
		private Container _container;

		public string Name
		{
			get { return "Dynamo Typeof"; }
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
			_container.Register<IRepository>(c => new Repository());
			_container.Register<IAuthenticationService>(c => new AuthenticationService());
			_container.Register<UserController>(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>()));

			_container.Register<IWebService>(c => new WebService((IAuthenticator)c.Resolve(typeof(IAuthenticator)), (IStockQuote)c.Resolve(typeof(IStockQuote))));
			_container.Register<IAuthenticator>(c => new Authenticator((ILogger)c.Resolve(typeof(ILogger)), (IErrorHandler)c.Resolve(typeof(IErrorHandler)), (IDatabase)c.Resolve(typeof(IDatabase))));
			_container.Register<IStockQuote>(c => new StockQuote((ILogger)c.Resolve(typeof(ILogger)), (IErrorHandler)c.Resolve(typeof(IErrorHandler)), (IDatabase)c.Resolve(typeof(IDatabase))));
			_container.Register<IDatabase>(c => new Database((ILogger)c.Resolve(typeof(ILogger)), (IErrorHandler)c.Resolve(typeof(IErrorHandler))));
			_container.Register<IErrorHandler>(c => new ErrorHandler((ILogger)c.Resolve(typeof(ILogger))));

			_container.Register<IService1>(c => new Service1(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			_container.Register<IService2>(c => new Service2(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			_container.Register<IService3>(c => new Service3(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));
			_container.Register<IService4>(c => new Service4(c.Resolve<ILogger>(), c.Resolve<IErrorHandler>()));

			_container.Register<ILogger>(c => new Logger());

			_container.Compile();
		}
	}
}
