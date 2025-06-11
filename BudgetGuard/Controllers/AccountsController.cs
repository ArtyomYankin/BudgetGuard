using BG.Data.Models;
using BG.Service.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetGuard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController(IAccountService _accountService) : ControllerBase
    {
        [Authorize]
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserAccounts(int userId)
        {
            var accounts = await _accountService.GetAllAccountsForUser(userId);
            return Ok(accounts);
        }

        [HttpPost("createAccount")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AccountDto>> CreateAccount([FromBody] AccountCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountResponse = await _accountService.CreateUserAccount(dto);

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
