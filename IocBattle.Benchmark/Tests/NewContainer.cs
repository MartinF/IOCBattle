using IocBattle.Benchmark.Models;

namespace IocBattle.Benchmark.Tests
{
	public class NewContainer : IContainer
	{
		private bool _isInTransientMode;
		private object _webService;

		public string Name
		{
			get { return "new Operator"; }
		}

		public T Resolve<T>()
			where T : class
		{
			if (_isInTransientMode)
				return new WebService(new Authenticator(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger()))),
													  new StockQuote(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger())))) as T;

			if (_webService == null)
				_webService = new WebService(new Authenticator(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger()))),
													  new StockQuote(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger()))));

			return _webService as T;



			// Transient - used for test results - need to comment out code above
			//return new WebService(new Authenticator(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger()))),
			//                    new StockQuote(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger())))) as T;

			// Real singleton - used for test results - need to comment out code above and uncomment code in WebService
			//return WebService.Instance as T;
		}

		public void SetupForTransientTest()
		{
			_isInTransientMode = true;
		}

		public void SetupForSingletonTest()
		{
			_isInTransientMode = false;
		}
	}
}