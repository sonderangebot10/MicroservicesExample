using MicroservicesExample.Controllers.json;
using MicroservicesExample.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroservicesExample.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountService;

        public AccountController(ILogger<AccountController> logger, AccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        [Route("getAccount")]
        public async Task<double> Get()
        {
            _logger.LogInformation("Get balance command called");
            var result = await _accountService.GetBalanceAsync();
            return result;
        }

        [HttpPost]
        [Route("setAccount")]
        public async Task<bool> Set(Balance balance)
        {
            _logger.LogInformation("Set balance command called");
            var result = await _accountService.SetBalanceAsync(balance.amount);
            return result;
        }
    }
}
