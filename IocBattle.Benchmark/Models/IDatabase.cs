using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IocBattle.Benchmark.Models
{
	public interface IDatabase
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
	}
}
