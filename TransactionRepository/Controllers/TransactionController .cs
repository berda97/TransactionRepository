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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHashService _hashService;
        
        public TransactionController(ITransactionService transactionService, IHttpContextAccessor httpContextAccessor, IHashService hashService)
        {
            _transactionService = transactionService;
            _httpContextAccessor = httpContextAccessor;
            _hashService = hashService;
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequestDto request)
        {

            string receivedHash = _httpContextAccessor.HttpContext.Request.Headers["hash"];
            string secretKey = "your_secret_key"; //TODO configuration
            string requestData = $"{request.ExternalTransactionId}{request.UserId}{request.Amount}{request.Currency}";

            if (!_hashService.IsValidHash(receivedHash, requestData, secretKey))
            {
                return BadRequest(new TransactionResponseDto { Message = "Invalid hash", Status = 1 });
            }

            var response = await _transactionService.ProcessTransactionAsync(request);

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




