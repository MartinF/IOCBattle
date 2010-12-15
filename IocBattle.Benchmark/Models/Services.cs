
namespace IocBattle.Benchmark.Models
{
	public interface IService1
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
	}

	public interface IService2
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
	}

	public interface IService3
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
	}

	public interface IService4
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
	}

	public class Service1 : IService1
	{
		ILogger logger;
		IErrorHandler handler;

		public Service1(ILogger logger, IErrorHandler handler)
		{
			this.logger = logger;
			this.handler = handler;
		}

		public ILogger Logger { get { return logger; } }
		public IErrorHandler ErrorHandler { get { return handler; } }
	}

	public class Service2 : IService2
	{
		ILogger logger;
		IErrorHandler handler;

		public Service2(ILogger logger, IErrorHandler handler)
		{
			this.logger = logger;
			this.handler = handler;
		}

		public ILogger Logger { get { return logger; } }
		public IErrorHandler ErrorHandler { get { return handler; } }
	}

	public class Service3 : IService3
	{
		ILogger logger;
		IErrorHandler handler;

		public Service3(ILogger logger, IErrorHandler handler)
		{
			this.logger = logger;
			this.handler = handler;
		}

		public ILogger Logger { get { return logger; } }
		public IErrorHandler ErrorHandler { get { return handler; } }
	}

	public class Service4 : IService4
	{
		ILogger logger;
		IErrorHandler handler;

		public Service4(ILogger logger, IErrorHandler handler)
		{
			this.logger = logger;
			this.handler = handler;
		}

		public ILogger Logger { get { return logger; } }
		public IErrorHandler ErrorHandler { get { return handler; } }
	}
}
