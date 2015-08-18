using Autofac;
using IocBattle.Benchmark.Models;
using SimpleInjector;

namespace IocBattle.Benchmark.Tests
{
	public class SimpleInjectorContainer : IContainer
	{
	    private Container _container;

		public string Name
		{
			get { return "SimpleInjector"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.GetInstance<T>();
		}

		public void SetupForTransientTest()
		{
            _container = new Container();
			_container.Register<IRepository, Repository>();
            _container.Register<IAuthenticationService, AuthenticationService>();
            _container.Register<UserController>();
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
		}

		public void SetupForSingletonTest()
		{
            _container = new Container();
            _container.Register<IRepository, Repository>(Lifestyle.Singleton);

            _container.Register<IAuthenticationService, AuthenticationService>(Lifestyle.Singleton);
            _container.Register<UserController>(Lifestyle.Singleton);
            _container.Register<IWebService, WebService>(Lifestyle.Singleton);
            _container.Register<IAuthenticator, Authenticator>(Lifestyle.Singleton);
            _container.Register<IStockQuote, StockQuote>(Lifestyle.Singleton);
            _container.Register<IDatabase, Database>(Lifestyle.Singleton);
            _container.Register<IErrorHandler, ErrorHandler>(Lifestyle.Singleton);
            _container.Register<IService1, Service1>(Lifestyle.Singleton);
            _container.Register<IService2, Service2>(Lifestyle.Singleton);
            _container.Register<IService3, Service3>(Lifestyle.Singleton);
            _container.Register<IService4, Service4>(Lifestyle.Singleton);
            _container.Register<ILogger, Logger>(Lifestyle.Singleton);
		}
	}
}