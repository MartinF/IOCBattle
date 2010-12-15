using System;

namespace IocBattle.Benchmark.Models
{
	public class WebService : IWebService
	{
		// Real singleton
		//private static WebService _instance = new WebService(new Authenticator(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger()))),
		//                                   new StockQuote(new Logger(), new ErrorHandler(new Logger()), new Database(new Logger(), new ErrorHandler(new Logger()))));

		//public static WebService Instance { get { return _instance; } }
		//static WebService()
		//{ }

		IAuthenticator authenticator;
		IStockQuote quotes;

		public WebService(IAuthenticator authenticator, IStockQuote quotes)
		{
			this.authenticator = authenticator;
			this.quotes = quotes;
		}

		public IAuthenticator Authenticator { get { return authenticator; } }
		public IStockQuote StockQuote { get { return quotes; } }

		public void Execute()
		{
		}
	}
}