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
            var accounts = await _accountService.GetAllAccountsForUser(userId);
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccount([FromBody] AccountCreateDto dto, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountResponse = await _accountService.CreateUserAccount(dto, userId);

            return Ok(accountResponse);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> UpdateAccount([FromBody] AccountDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountResponse = await _accountService.UpdateUserAccount(dto);

            return Ok(accountResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            await _accountService.DeleteAccount(accountId);

            return (Ok("Account deleted successfully."));
        }
    }
}
