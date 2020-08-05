using System.Threading.Tasks;

namespace SvaSorcery.Patterns.Enterprise.Base.ServiceStub
{
    public class CalculatorServiceStub : ICalculatorService
    {
        public Task<int> AddAsync(int a, int b) => Task.FromResult(a + b);

        public Task<int> SubtractAsync(int a, int b) => Task.FromResult(a - b);

        public Task<int> MultiplyAsync(int a, int b) => Task.FromResult(a * b);

        public Task<int> DivideAsync(int a, int b) => Task.FromResult(a / b);
    }
}
