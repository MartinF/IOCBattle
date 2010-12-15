
namespace IocBattle.Benchmark
{
	public interface IContainer
	{
		string Name { get; }

		T Resolve<T>() where T : class;
	
		void SetupForTransientTest();
		void SetupForSingletonTest();
	}
}