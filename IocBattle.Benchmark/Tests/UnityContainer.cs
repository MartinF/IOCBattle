using System;
using IocBattle.Benchmark.Models;
using Microsoft.Practices.Unity;

namespace IocBattle.Benchmark.Tests
{
	public class UnityContainer : IContainer
	{
		private IUnityContainer _container;

		public string Name
		{
			get { return "Unity"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.Resolve<T>();
		}

		public void SetupForTransientTest()
		{
			Setup(GetTransientLifetime);
		}

		public void SetupForSingletonTest()
		{
			Setup(GetContainerLifetime);
		}

		public LifetimeManager GetContainerLifetime()
		{
			return new ContainerControlledLifetimeManager();
		}

		public LifetimeManager GetTransientLifetime()
		{
			return new TransientLifetimeManager();
		}

		public void Setup(Func<LifetimeManager> lifetime)
		{
			_container = new Microsoft.Practices.Unity.UnityContainer();

			_container.RegisterType<IRepository, Repository>(lifetime());
			_container.RegisterType<IAuthenticationService, AuthenticationService>(lifetime());
			_container.RegisterType<UserController, UserController>(lifetime());

			_container.RegisterType<IWebService, WebService>(lifetime());
			_container.RegisterType<IAuthenticator, Authenticator>(lifetime());
			_container.RegisterType<IStockQuote, StockQuote>(lifetime());
			_container.RegisterType<IDatabase, Database>(lifetime());
			_container.RegisterType<IErrorHandler, ErrorHandler>(lifetime());

			_container.RegisterType<IService1, Service1>(lifetime());
			_container.RegisterType<IService2, Service2>(lifetime());
			_container.RegisterType<IService3, Service3>(lifetime());
			_container.RegisterType<IService4, Service4>(lifetime());

			_container.RegisterType<ILogger, Logger>(lifetime());
		}
	}
}