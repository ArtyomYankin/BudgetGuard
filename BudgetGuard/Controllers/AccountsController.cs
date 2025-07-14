using BG.Data.Models;
using BG.Service.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetGuard.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUserAccounts(int userId)
        {
            var accounts = await _accountService.GetAllAccountsForUser(userId);

            if (accounts == null || !accounts.Any())
                return NotFound("No accounts found for this user");

            return Ok(accounts);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccountDto>> CreateAccount([FromBody] AccountCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accountResponse = await _accountService.CreateUserAccount(dto);

            return CreatedAtAction(
                nameof(GetAccount),
                new { id = accountResponse.Id },
                accountResponse
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            var accountResponse = await _accountService.GetUserAccount(id);

            if (accountResponse == null)
                return NotFound();

            return Ok(accountResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccountDto>> UpdateAccount(int id, [FromBody] AccountUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            dto.Id = id;
            //if (id != dto.Id)
            //    return BadRequest("ID in route does not match ID in body");

            var accountResponse = await _accountService.UpdateUserAccount(dto);

            if (accountResponse == null)
                return NotFound();

            return Ok(accountResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var result = await _accountService.DeleteAccount(id);

            if (!result)
                return NotFound();

            return NoContent(); // 204 No Content - стандартный ответ для успешного удаления
        }
    }
}