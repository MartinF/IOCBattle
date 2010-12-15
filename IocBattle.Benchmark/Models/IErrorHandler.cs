using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IocBattle.Benchmark.Models
{
	public interface IErrorHandler
	{
		ILogger Logger { get; }
	}
}
