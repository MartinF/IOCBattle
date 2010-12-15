using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class WindsorContainer : IContainer
	{
		private IWindsorContainer _container;

		public string Name
		{
			get { return "Castle Windsor"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _container.Resolve<T>();
		}

		public void SetupForTransientTest()
		{
			Setup(LifestyleType.Transient);
		}

		public void SetupForSingletonTest()
		{
			Setup(LifestyleType.Singleton);
		}

		public void Setup(LifestyleType lifestyle)
		{
			_container = new Castle.Windsor.WindsorContainer();

			_container.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IAuthenticationService>().ImplementedBy<AuthenticationService>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<UserController>().ImplementedBy<UserController>().LifeStyle.Is(lifestyle));

			_container.Register(Component.For<IWebService>().ImplementedBy<WebService>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IAuthenticator>().ImplementedBy<Authenticator>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IStockQuote>().ImplementedBy<StockQuote>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IDatabase>().ImplementedBy<Database>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IErrorHandler>().ImplementedBy<ErrorHandler>().LifeStyle.Is(lifestyle));

			_container.Register(Component.For<IService1>().ImplementedBy<Service1>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IService2>().ImplementedBy<Service2>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IService3>().ImplementedBy<Service3>().LifeStyle.Is(lifestyle));
			_container.Register(Component.For<IService4>().ImplementedBy<Service4>().LifeStyle.Is(lifestyle));

			_container.Register(Component.For<ILogger>().ImplementedBy<Logger>().LifeStyle.Is(lifestyle));
		}
	}
}