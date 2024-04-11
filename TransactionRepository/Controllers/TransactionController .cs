using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TransactionRepository.Data;
using TransactionRepository.Interface;
using TransactionRepository.Model;

namespace TransactionRepository.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        
        public TransactionController(ITransactionService transactionService)
        {  
            _transactionService = transactionService;
        }
        
        [HttpPost]
        public IActionResult CreateTransaction([FromBody] TransactionRequestDto request)
        {
            // Processing the transaction
            var response = _transactionService.ProcessTransaction(request);

            if (response.Status == 0)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}




