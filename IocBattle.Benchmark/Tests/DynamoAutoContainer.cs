using Dynamo.IocContainer;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class DynamoAutoContainer : IContainer
	{
		private Container _container;

		public string Name
		{
			get { return "Dynamo"; }
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
			_container = new Container(defaultLifetime: Lifetime.Container);
			Setup(_container);
		}

		public void Setup(Container container)
		{
			_container.Register<IRepository, Repository>();
			_container.Register<IAuthenticationService, AuthenticationService>();
			_container.Register<UserController, UserController>();

			_container.Register<IWebService, WebService>();
			_container.Register<IAuthenticator, Authenticator>();
			_container.Register<IStockQuote, StockQuote>();
			_container.Register<IDatabase, Database>();
			_container.Register<IErrorHandler, ErrorHandler>();

			_container.Register<IService1, Service1>();
			_container.Register<IService2, Service2>();
			_container.Register<IService3, Service3>();
			_container.Register<IService4, Service4>();

			_container.Register<ILogger, Logger>();

			_container.Optimize();
		}
	}
}
