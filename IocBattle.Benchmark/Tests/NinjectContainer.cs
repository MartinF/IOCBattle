using IocBattle.Benchmark.Models;
using Ninject;
using Ninject.Modules;

namespace IocBattle.Benchmark.Tests
{
	public class NinjectContainer : IContainer
	{
		private IKernel _kernel;

		public string Name
		{
			get { return "Ninject"; }
		}

		public T Resolve<T>()
			where T : class
		{
			return _kernel.Get<T>();
		}

		public void SetupForTransientTest()
		{
			_kernel = new StandardKernel(new TransientModule());
		}

		public void SetupForSingletonTest()
		{
			_kernel = new StandardKernel(new SingletonModule());
		}
	}

	public class TransientModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRepository>().To<Repository>().InTransientScope();
			Bind<IAuthenticationService>().To<AuthenticationService>().InTransientScope();
			Bind<UserController>().ToSelf().InTransientScope();

			Bind<IWebService>().To<WebService>().InTransientScope();
			Bind<IAuthenticator>().To<Authenticator>().InTransientScope();
			Bind<IStockQuote>().To<StockQuote>().InTransientScope();
			Bind<IDatabase>().To<Database>().InTransientScope();
			Bind<IErrorHandler>().To<ErrorHandler>().InTransientScope();

			Bind<IService1>().To<Service1>().InTransientScope();
			Bind<IService2>().To<Service2>().InTransientScope();
			Bind<IService3>().To<Service3>().InTransientScope();
			Bind<IService4>().To<Service4>().InTransientScope();

			Bind<ILogger>().To<Logger>().InTransientScope();
		}
	}

	public class SingletonModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRepository>().To<Repository>().InSingletonScope();
			Bind<IAuthenticationService>().To<AuthenticationService>().InSingletonScope();
			Bind<UserController>().ToSelf().InSingletonScope();

			Bind<IWebService>().To<WebService>().InSingletonScope();
			Bind<IAuthenticator>().To<Authenticator>().InSingletonScope();
			Bind<IStockQuote>().To<StockQuote>().InSingletonScope();
			Bind<IDatabase>().To<Database>().InSingletonScope();
			Bind<IErrorHandler>().To<ErrorHandler>().InSingletonScope();

			Bind<IService1>().To<Service1>().InSingletonScope();
			Bind<IService2>().To<Service2>().InSingletonScope();
			Bind<IService3>().To<Service3>().InSingletonScope();
			Bind<IService4>().To<Service4>().InSingletonScope();

			Bind<ILogger>().To<Logger>().InSingletonScope();
		}
	}
}