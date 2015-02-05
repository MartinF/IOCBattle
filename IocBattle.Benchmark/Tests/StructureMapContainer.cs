using IocBattle.Benchmark.Models;
using StructureMap;

namespace IocBattle.Benchmark.Tests
{
    public class StructureMapContainer : IContainer
    {
        private Container _container;

        public string Name
        {
            get { return "StructureMap"; }
        }

        public T Resolve<T>()
            where T : class
        {
            return _container.GetInstance<T>();
        }

        public void SetupForTransientTest()
        {
            _container = new Container(x =>
            {
                x.For<IRepository>().Use<Repository>();
                x.For<IAuthenticationService>().Use<AuthenticationService>();
                x.For<UserController>().Use<UserController>();

                x.For<IWebService>().Use<WebService>();
                x.For<IAuthenticator>().Use<Authenticator>();
                x.For<IStockQuote>().Use<StockQuote>();
                x.For<IDatabase>().Use<Database>();
                x.For<IErrorHandler>().Use<ErrorHandler>();

                x.For<IService1>().Use<Service1>();
                x.For<IService2>().Use<Service2>();
                x.For<IService3>().Use<Service3>();
                x.For<IService4>().Use<Service4>();

                x.For<ILogger>().Use<Logger>();
            });
        }

        public void SetupForSingletonTest()
        {
            _container = new Container(x =>
            {
                x.For<IRepository>().Singleton().Use<Repository>();
                x.For<IAuthenticationService>().Singleton().Use<AuthenticationService>();
                x.For<UserController>().Singleton().Use<UserController>();

                x.For<IWebService>().Singleton().Use<WebService>();
                x.For<IAuthenticator>().Singleton().Use<Authenticator>();
                x.For<IStockQuote>().Singleton().Use<StockQuote>();
                x.For<IDatabase>().Singleton().Use<Database>();
                x.For<IErrorHandler>().Singleton().Use<ErrorHandler>();

                x.For<IService1>().Singleton().Use<Service1>();
                x.For<IService2>().Singleton().Use<Service2>();
                x.For<IService3>().Singleton().Use<Service3>();
                x.For<IService4>().Singleton().Use<Service4>();

                x.For<ILogger>().Singleton().Use<Logger>();
            });
        }
    }
}