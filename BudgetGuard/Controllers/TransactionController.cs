using BG.Data.Models;
using BG.Service.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace BudgetGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(ITransactionsService _transactionsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetByAccount(int accountId)
        {
            if (accountId <= 0)
                return BadRequest("Account id can't be 0");
            var transaction = _transactionsService.GetTransactionByAccountAsync(accountId);
            if (transaction == null)
                return Ok("There are no transactions on your account");
            return Ok(transaction);
        }
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> CreateTransaction([FromBody] TransactionCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transactionReposnse = await _transactionsService.AddTransactionAsync(dto);

            return Ok(transactionReposnse);
        }
    }
}
