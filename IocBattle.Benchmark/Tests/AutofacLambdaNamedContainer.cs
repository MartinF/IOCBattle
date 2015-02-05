using Autofac;
using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
    public class AutoFacLambdaNamedContainer : IocBattle.Benchmark.IContainer
    {
        private Autofac.IContainer _container;

        public string Name
        {
            get { return "AutoFac Lambda Named"; }
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.ResolveNamed<T>("WebService");
        }

        public void SetupForTransientTest()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new Repository()).As<IRepository>();
            builder.Register(c => new AuthenticationService()).As<IAuthenticationService>();
            builder.Register(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>()));

            builder.Register(c => new WebService(c.ResolveNamed<IAuthenticator>("Authenticator"), c.ResolveNamed<IStockQuote>("StockQuote"))).As<IWebService>().Named<IWebService>("WebService");
            builder.Register(c => new Authenticator(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"), c.ResolveNamed<IDatabase>("Database"))).As<IAuthenticator>().Named<IAuthenticator>("Authenticator");
            builder.Register(c => new StockQuote(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"), c.ResolveNamed<IDatabase>("Database"))).As<IStockQuote>().Named<IStockQuote>("StockQuote");
            builder.Register(c => new Database(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IDatabase>().Named<IDatabase>("Database");
            builder.Register(c => new ErrorHandler(c.ResolveNamed<ILogger>("Logger"))).As<IErrorHandler>().Named<IErrorHandler>("ErrorHandler");

            builder.Register(c => new Service1(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService1>();
            builder.Register(c => new Service2(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService2>();
            builder.Register(c => new Service3(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService3>();
            builder.Register(c => new Service4(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService4>();

            builder.Register(c => new Logger()).As<ILogger>().Named<ILogger>("Logger");

            _container = builder.Build();
        }

        public void SetupForSingletonTest()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new Repository()).As<IRepository>().SingleInstance();
            builder.Register(c => new AuthenticationService()).As<IAuthenticationService>().SingleInstance();
            builder.Register(c => new UserController(c.Resolve<IRepository>(), c.Resolve<IAuthenticationService>())).SingleInstance();

            builder.Register(c => new WebService(c.ResolveNamed<IAuthenticator>("Authenticator"), c.ResolveNamed<IStockQuote>("StockQuote"))).As<IWebService>().Named<IWebService>("WebService").SingleInstance();
            builder.Register(c => new Authenticator(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"), c.ResolveNamed<IDatabase>("Database"))).As<IAuthenticator>().Named<IAuthenticator>("Authenticator").SingleInstance();
            builder.Register(c => new StockQuote(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"), c.ResolveNamed<IDatabase>("Database"))).As<IStockQuote>().Named<IStockQuote>("StockQuote").SingleInstance();
            builder.Register(c => new Database(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IDatabase>().Named<IDatabase>("Database").SingleInstance();
            builder.Register(c => new ErrorHandler(c.ResolveNamed<ILogger>("Logger"))).As<IErrorHandler>().Named<IErrorHandler>("ErrorHandler").SingleInstance();

            builder.Register(c => new Service1(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService1>().SingleInstance();
            builder.Register(c => new Service2(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService2>().SingleInstance();
            builder.Register(c => new Service3(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService3>().SingleInstance();
            builder.Register(c => new Service4(c.ResolveNamed<ILogger>("Logger"), c.ResolveNamed<IErrorHandler>("ErrorHandler"))).As<IService4>().SingleInstance();

            builder.Register(c => new Logger()).As<ILogger>().Named<ILogger>("Logger").SingleInstance();

            _container = builder.Build();
        }
    }
}