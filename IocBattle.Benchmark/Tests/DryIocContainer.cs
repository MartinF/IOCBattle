using DryIoc;
using IocBattle.Benchmark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocBattle.Benchmark.Tests
{
	public class DryIocContainer : IContainer
	{
		private Container _container;

		public string Name { get { return "DryIoc"; } }

		public T Resolve<T>() where T : class
		{
			return _container.Resolve<T>();
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
			_container.Register<IRepository, Repository>( Reuse.Singleton );

			_container.Register<IAuthenticationService, AuthenticationService>( Reuse.Singleton );
			_container.Register<UserController>( Reuse.Singleton );
			_container.Register<IWebService, WebService>( Reuse.Singleton );
			_container.Register<IAuthenticator, Authenticator>( Reuse.Singleton );
			_container.Register<IStockQuote, StockQuote>( Reuse.Singleton );
			_container.Register<IDatabase, Database>( Reuse.Singleton );
			_container.Register<IErrorHandler, ErrorHandler>( Reuse.Singleton );
			_container.Register<IService1, Service1>( Reuse.Singleton );
			_container.Register<IService2, Service2>( Reuse.Singleton );
			_container.Register<IService3, Service3>( Reuse.Singleton );
			_container.Register<IService4, Service4>( Reuse.Singleton );
			_container.Register<ILogger, Logger>( Reuse.Singleton );
		}
	}
}
