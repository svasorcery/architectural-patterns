using System.Threading.Tasks;

namespace SvaSorcery.Patterns.Enterprise.Base.ServiceStub
{
    public interface ICalculatorService
    {
        Task<int> AddAsync(int a, int b);
        Task<int> SubtractAsync(int a, int b);
        Task<int> MultiplyAsync(int a, int b);
        Task<int> DivideAsync(int a, int b);
    }
}
