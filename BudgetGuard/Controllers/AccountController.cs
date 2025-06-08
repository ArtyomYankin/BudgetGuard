using BG.Data.Models;
using BG.Service.Account;
using Microsoft.AspNetCore.Mvc;

namespace BudgetGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService _accountService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserAccounts(int userId)
        {
            var accounts = _accountService.GetAllAccountsForUser(userId);
            return Ok(accounts);
        }
    }
}
