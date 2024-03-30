using Microsoft.AspNetCore.Mvc;
using Teste.BackEnd.Domain.Entitys;
using Teste.BackEnd.Domain.Services;

namespace Teste.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : Controller
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost("process")]
        public IActionResult ProcessCredit(Credit credit)
        {
            // Aqui você pode realizar algumas validações adicionais, se necessário
            var result = _creditService.ProcessCredit(credit);
            return Ok(result);
        }
    }
}
