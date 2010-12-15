
namespace IocBattle.Benchmark.Models
{
	public class ErrorHandler : IErrorHandler
	{
		ILogger logger;

		public ErrorHandler(ILogger logger)
		{
			this.logger = logger;
		}

		public ILogger Logger { get { return logger; } }
	}
}
