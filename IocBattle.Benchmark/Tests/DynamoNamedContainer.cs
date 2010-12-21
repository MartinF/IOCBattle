using Dynamo.IocContainer;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class DynamoNamedContainer : IContainer
	{
		private Container _container;

		public string Name
		{
			get { return "Dynamo Named"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.Resolve<T>("WebService");
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

			container.Register<IWebService>("WebService", c => new WebService(c.Resolve<IAuthenticator>("Authenticator"), c.Resolve<IStockQuote>("StockQuote")));
			container.Register<IAuthenticator>("Authenticator", c => new Authenticator(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler"), c.Resolve<IDatabase>("Database")));
			container.Register<IStockQuote>("StockQuote", c => new StockQuote(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler"), c.Resolve<IDatabase>("Database")));
			container.Register<IDatabase>("Database", c => new Database(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler")));
			container.Register<IErrorHandler>("ErrorHandler", c => new ErrorHandler(c.Resolve<ILogger>("Logger")));

			container.Register<IService1>(c => new Service1(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler")));
			container.Register<IService2>(c => new Service2(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler")));
			container.Register<IService3>(c => new Service3(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler")));
			container.Register<IService4>(c => new Service4(c.Resolve<ILogger>("Logger"), c.Resolve<IErrorHandler>("ErrorHandler")));

			container.Register<ILogger>("Logger", c => new Logger());

			_container.Compile();
			_container.Verify();
		}
	}
}