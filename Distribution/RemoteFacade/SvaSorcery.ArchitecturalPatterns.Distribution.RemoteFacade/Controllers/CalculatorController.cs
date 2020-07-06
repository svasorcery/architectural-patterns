using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorWsdlService;

namespace SvaSorcery.ArchitecturalPatterns.Distribution.RemoteFacade.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorSoapClient _calculatorClient;

        public CalculatorController(CalculatorSoapClient calculatorClient)
        {
            _calculatorClient = calculatorClient;
        }

        public async Task<IActionResult> Add(int a, int b)
            => Ok(await _calculatorClient.AddAsync(a, b));

        public async Task<IActionResult> Subtract(int a, int b)
            => Ok(await _calculatorClient.SubtractAsync(a, b));

        public async Task<IActionResult> Multiply(int a, int b)
            => Ok(await _calculatorClient.MultiplyAsync(a, b));

        public async Task<IActionResult> Divide(int a, int b)
            => Ok(await _calculatorClient.DivideAsync(a, b));
    }
}
