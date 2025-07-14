using BG.Data.Models;
using BG.Service.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetGuard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionsController(ITransactionsService _transactionsService) : ControllerBase
    {
        [HttpGet("account/{accountId}")]
        [ProducesResponseType(typeof(IEnumerable<TransactionDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByAccountId(int accountId)
        {
            var transactions = await _transactionsService.GetTransactionsByAccountAsync(accountId);
            if (transactions == null || !transactions.Any())
                return NotFound("No transactions found for this account");
            return Ok(transactions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await _transactionsService.AddTransactionAsync(dto);
            return Ok(transaction);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _transactionsService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound();

            return Ok();
        }
    }
}
